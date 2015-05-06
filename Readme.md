# Introduction

Batting data courtesy http://seanlahman.com/baseball-archive/statistics/.

A bunch of alternatives for coverting CSV to objects for further use. Objectives:

* Performance analysis, particularly allocations and overall processing time. An opportunity to explore perf recommendations and tools, especially w.r.t. string processing.
* Pipeline patterns using blocking collections.

# Alternative Designs

1. Read line -> String.Split() on comma -> Create new batter instance using split results -> Add instance to list.
2. Read line -> Create new batter instance -> Pull substrings out of line one at a time using String.Substring() and assign to batter properties -> Add instance to list.
3. Read line -> Create new batter instance using line and Lazy wrappers for each property to defer extraction of substrings until needed. -> Add instance to list.
4. Read line -> Create new batter instance -> Pull substrings out of line one at a time by copying to static buffer and creating new String instance, then assign to batter properties -> Add instance to list.
5. Read line -> Create new batter instance using line; batter instance caches start and end points of each property in line but does not extract until needed. -> Add instance to list.
6. Read line -> Create new batter instance using line; batter instance locates property in line when needed and extracts, start and end points are not cached. -> Add instance to list.
7. Option #5, followed by a ToString() call to extract all properties from the line. Each property is extracted when needed.
8. Option #6, followed by a ToString() call to extract all properties from the line. Each property is extracted when needed.
9. Option #5, followed by a ToString() call to extract all properties from the line. All properties are extracted the first time any is accessed.
10. Option #6, followed by a ToString() call to extract all properties from the line. All properties are extracted the first time any is accessed.

# Findings

I ran 100 iterations of each option and captured data using PerfView for analysis.

## CPU

* Option 4 was about 10% faster than options 1 and 2, which were about equal. Eliminating String.Split() (the difference between 1 and 2) didn't help much with CPU but switching from String.Substring() to a String.CopyTo()/new String(char []) pair did.
* Options 5 and 6 were the fastest, as you'd expect, given that they don't actually parse the line until needed. Of the two, option 6 was the fastest as it did not spend time caching the start and end indices of each field in the line.
* Option 3 was the slowest, by far. Generating lambdas on this scale is hella slow.
* Options 7 through 10 were all slower than 1, 2 and 4. Option 10 was the best but was still ~30% slower than option 4.
 
## Allocations

* Option 1 peak working set was 128 MB, option 2 was 192 MB and option 4 was 125 MB. The difference in the case of option 2 was a greatly increased number of strings allocated via the use of String.Substring().
* Between options 5 and 6, option 6 peaked at 60 MB vs. 110 MB. Given this and the CPU results, it doesn't seem to make sense to cache anything in advance of parsing.
* Option 3 was a pig, as you'd expect. Process working set peaked at 464 MB.
* Options 7 and 9 were around 190 MB, 8 and 10 around 150 MB. It makes sense that there'd be a price to pay for deferred parsing.

## Conclusions

* Internet wisdom claims String.Split() is expensive. It is though not as bad as the next item on the list. It's still good to be rid of it if you are doing something simple like CSV parsing.
* String.Substring() is quite costly in terms of CPU and allocations. Options 2 and 4 are similar except for the elimination of substring calls. Option 4 is 10% faster and requires 30% less memory.
* Getting fancy and using lambdas, Lazy, etc. is not worth it when there are large numbers of instances. I'm sure it continues to be worth considering when initializing small quantities of expensive things.
* Deferring parsing only makes sense if you expect to use the minority of the fields in the input. No deferred parsing option compared favorably to the most efficient immediate parsing option, option 4, once the entire input was parsed. 