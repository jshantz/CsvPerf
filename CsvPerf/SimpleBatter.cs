using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvPerf
{
    public class SimpleBatter
    {
        public string PlayerId { get; set; }
        public string YearId { get; set; }
        public string Stint { get; set; }
        public string TeamId { get; set; }
        public string LeagueId { get; set; }
        public string Games { get; set; }
        public string AtBats { get; set; }
        public string Runs { get; set; }
        public string Hits { get; set; }
        public string Doubles { get; set; }
        public string Triples { get; set; }
        public string HomeRuns { get; set; }
        public string RunsBattedIn { get; set; }
        public string StolenBases { get; set; }
        public string CaughtStealing { get; set; }
        public string Walks { get; set; }
        public string Strikeouts { get; set; }
        public string IntentionalWalks { get; set; }
        public string HitByPitch { get; set; }
        public string SacrificeHits { get; set; }
        public string SacrificeFlies { get; set; }
        public string GroundedIntoDoublePlays { get; set; }

        public override string ToString()
        {
            return String.Concat(PlayerId, YearId, Stint, TeamId, LeagueId, Games, AtBats, Runs, Hits, Doubles, Triples, HomeRuns, RunsBattedIn, StolenBases, CaughtStealing, Walks, Strikeouts, IntentionalWalks, HitByPitch, SacrificeHits, SacrificeFlies, GroundedIntoDoublePlays);
        }
    }
}
