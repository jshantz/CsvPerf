using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvPerf
{
    public static class Option09
    {
        public static void Execute(byte[] bytes)
        {
            var batters = new List<Option09Batter>();
            using (var byteStream = new MemoryStream(bytes))
            {
                using (var reader = new StreamReader(byteStream))
                {
                    while (!reader.EndOfStream)
                    {
                        var batter = new Option09Batter(reader.ReadLine());
                        batter.ToString();
                        batters.Add(batter);
                    }
                }
            }

            Console.WriteLine(batters.Count + " batters created.");
        }
    }
}
