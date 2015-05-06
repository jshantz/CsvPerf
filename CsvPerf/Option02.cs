using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvPerf
{
    public static class Option02
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
                        var stats = reader.ReadLine();

                        var startNdx = 0;
                        var batter = new SimpleBatter();

                        batter.PlayerId = ReadNext(stats, startNdx, out startNdx);
                        batter.YearId = ReadNext(stats, startNdx, out startNdx);
                        batter.Stint = ReadNext(stats, startNdx, out startNdx);
                        batter.TeamId = ReadNext(stats, startNdx, out startNdx);
                        batter.LeagueId = ReadNext(stats, startNdx, out startNdx);
                        batter.Games = ReadNext(stats, startNdx, out startNdx);
                        batter.AtBats = ReadNext(stats, startNdx, out startNdx);
                        batter.Runs = ReadNext(stats, startNdx, out startNdx);
                        batter.Hits = ReadNext(stats, startNdx, out startNdx);
                        batter.Doubles = ReadNext(stats, startNdx, out startNdx);
                        batter.Triples = ReadNext(stats, startNdx, out startNdx);
                        batter.HomeRuns = ReadNext(stats, startNdx, out startNdx);
                        batter.RunsBattedIn = ReadNext(stats, startNdx, out startNdx);
                        batter.StolenBases = ReadNext(stats, startNdx, out startNdx);
                        batter.CaughtStealing = ReadNext(stats, startNdx, out startNdx);
                        batter.Walks = ReadNext(stats, startNdx, out startNdx);
                        batter.Strikeouts = ReadNext(stats, startNdx, out startNdx);
                        batter.IntentionalWalks = ReadNext(stats, startNdx, out startNdx);
                        batter.HitByPitch = ReadNext(stats, startNdx, out startNdx);
                        batter.SacrificeHits = ReadNext(stats, startNdx, out startNdx);
                        batter.SacrificeFlies = ReadNext(stats, startNdx, out startNdx);
                        batter.GroundedIntoDoublePlays = ReadNext(stats, startNdx, out startNdx);

                        batters.Add(batter);
                    }
                }
            }

            Console.WriteLine(batters.Count + " batters created.");
        }

        private static string ReadNext(string stats, int startNdx, out int endNdx)
        {
            var currNdx = startNdx;
            while (currNdx < stats.Length && stats[currNdx] != ',')
            {
                currNdx++;
            }

            endNdx = currNdx;
            return stats.Substring(startNdx, currNdx);
        }
    }
}
