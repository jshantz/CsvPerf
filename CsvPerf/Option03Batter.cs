using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvPerf
{
    public class Option03Batter
    {
        private Lazy<string> _playerId;
        public string PlayerId
        {
            get
            {
                return _playerId.Value;
            }
        }

        private Lazy<string> _yearId;
        public string YearId
        {
            get
            {
                return _yearId.Value;
            }
        }

        private Lazy<string> _stint;
        public string Stint
        {
            get
            {
                return _stint.Value;
            }
        }

        private Lazy<string> _teamId;
        public string TeamId
        {
            get
            {
                return _teamId.Value;
            }
        }

        private Lazy<string> _leagueId;
        public string LeagueId
        {
            get
            {
                return _leagueId.Value;
            }
        }

        private Lazy<string> _games;
        public string Games
        {
            get
            {
                return _games.Value;
            }
        }

        private Lazy<string> _atBats;
        public string AtBats
        {
            get
            {
                return _atBats.Value;
            }
        }

        private Lazy<string> _runs;
        public string Runs
        {
            get
            {
                return _runs.Value;
            }
        }

        private Lazy<string> _hits;
        public string Hits
        {
            get
            {
                return _hits.Value;
            }
        }

        private Lazy<string> _doubles;
        public string Doubles
        {
            get
            {
                return _doubles.Value;
            }
        }

        private Lazy<string> _triples;
        public string Triples
        {
            get
            {
                return _triples.Value;
            }
        }

        private Lazy<string> _homeRuns;
        public string HomeRuns
        {
            get
            {
                return _homeRuns.Value;
            }
        }

        private Lazy<string> _runsBattedIn;
        public string RunsBattedIn
        {
            get
            {
                return _runsBattedIn.Value;
            }
        }

        private Lazy<string> _stolenBases;
        public string StolenBases
        {
            get
            {
                return _stolenBases.Value;
            }
        }

        private Lazy<string> _caughtStealing;
        public string CaughtStealing
        {
            get
            {
                return _caughtStealing.Value;
            }
        }

        private Lazy<string> _walks;
        public string Walks
        {
            get
            {
                return _walks.Value;
            }
        }

        private Lazy<string> _strikeouts;
        public string Strikeouts
        {
            get
            {
                return _strikeouts.Value;
            }
        }

        private Lazy<string> _intentionalWalks;
        public string IntentionalWalks
        {
            get
            {
                return _intentionalWalks.Value;
            }
        }

        private Lazy<string> _hitByPitch;
        public string HitByPitch
        {
            get
            {
                return _hitByPitch.Value;
            }
        }

        private Lazy<string> _sacrificeHits;
        public string SacrificeHits
        {
            get
            {
                return _sacrificeHits.Value;
            }
        }

        private Lazy<string> _sacrificeFlies;
        public string SacrificeFlies
        {
            get
            {
                return _sacrificeFlies.Value;
            }
        }

        private Lazy<string> _groundedIntoDoublePlays;
        public string GroundedIntoDoublePlays
        {
            get
            {
                return _groundedIntoDoublePlays.Value;
            }
        }

        private readonly string _statLine;
        private readonly StatIndices[] _statIndices = new StatIndices[22];

        public Option03Batter(string statLine)
        {
            _statLine = statLine;

            var startNdx = 0;
            var currNdx = 0;
            var statIndex = 0;
            while (currNdx < statLine.Length)
            {
                if (statLine[currNdx] != ',')
                {
                    currNdx++;
                }
                else
                {
                    _statIndices[statIndex].startNdx = startNdx;
                    _statIndices[statIndex].endNdx = currNdx;
                    startNdx = ++currNdx;
                    statIndex++;
                }
            }

            _statIndices[21].startNdx = startNdx;
            _statIndices[21].endNdx = currNdx;

            _playerId = new Lazy<string>(() => ReadStat(0));
            _yearId = new Lazy<string>(() => ReadStat(1));
            _stint = new Lazy<string>(() => ReadStat(2));
            _teamId = new Lazy<string>(() => ReadStat(3));
            _leagueId = new Lazy<string>(() => ReadStat(4));
            _games = new Lazy<string>(() => ReadStat(5));
            _atBats = new Lazy<string>(() => ReadStat(6));
            _runs = new Lazy<string>(() => ReadStat(7));
            _hits = new Lazy<string>(() => ReadStat(8));
            _doubles = new Lazy<string>(() => ReadStat(9));
            _triples = new Lazy<string>(() => ReadStat(10));
            _homeRuns = new Lazy<string>(() => ReadStat(11));
            _runsBattedIn = new Lazy<string>(() => ReadStat(12));
            _stolenBases = new Lazy<string>(() => ReadStat(13));
            _caughtStealing = new Lazy<string>(() => ReadStat(14));
            _walks = new Lazy<string>(() => ReadStat(15));
            _strikeouts = new Lazy<string>(() => ReadStat(16));
            _intentionalWalks = new Lazy<string>(() => ReadStat(17));
            _hitByPitch = new Lazy<string>(() => ReadStat(18));
            _sacrificeHits = new Lazy<string>(() => ReadStat(19));
            _sacrificeFlies = new Lazy<string>(() => ReadStat(20));
            _groundedIntoDoublePlays = new Lazy<string>(() => ReadStat(21));
        }

        private string ReadStat(int statNdx)
        {
            return _statLine.Substring(_statIndices[statNdx].startNdx, _statIndices[statNdx].endNdx - _statIndices[statNdx].startNdx);
        }

        private struct StatIndices
        {
            public int startNdx;
            public int endNdx;
        }
    }
}
