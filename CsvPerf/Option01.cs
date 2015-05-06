using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvPerf
{
    public static class Option01
    {
        public static void Execute(byte[] bytes)
        {
            var batters = new List<SimpleBatter>();
            using (var byteStream = new MemoryStream(bytes))
            {
                using (var reader = new StreamReader(byteStream))
                {
                    while (!reader.EndOfStream)
                    {
                        var stats = reader.ReadLine().Split(',');
                        var batter = new SimpleBatter
                        {
                            PlayerId = stats[0],
                            YearId = stats[1],
                            Stint = stats[2],
                            TeamId = stats[3],
                            LeagueId = stats[4],
                            Games = stats[5],
                            AtBats = stats[6],
                            Runs = stats[7],
                            Hits = stats[8],
                            Doubles = stats[9],
                            Triples = stats[10],
                            HomeRuns = stats[11],
                            RunsBattedIn = stats[12],
                            StolenBases = stats[13],
                            CaughtStealing = stats[14],
                            Walks = stats[15],
                            Strikeouts = stats[16],
                            IntentionalWalks = stats[17],
                            HitByPitch = stats[18],
                            SacrificeHits = stats[19],
                            SacrificeFlies = stats[20],
                            GroundedIntoDoublePlays = stats[21]
                        };
                        batters.Add(batter);
                    }
                }
            }

            Console.WriteLine(batters.Count + " batters created.");
        }
    }
}
