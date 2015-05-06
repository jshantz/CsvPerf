using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvPerf
{
    public class Option09Batter
    {
        private string _playerId;
        public string PlayerId
        {
            get
            {
                if (_playerId == null)
                {
                    ReadAllStats();
                }

                return _playerId;
            }
        }

        private string _yearId;
        public string YearId
        {
            get
            {
                if (_yearId == null)
                {
                    ReadAllStats();
                }

                return _yearId;
            }
        }

        private string _stint;
        public string Stint
        {
            get
            {
                if (_stint == null)
                {
                    ReadAllStats();
                }

                return _stint;
            }
        }

        private string _teamId;
        public string TeamId
        {
            get
            {
                if (_teamId == null)
                {
                    ReadAllStats();
                }

                return _teamId;
            }
        }

        private string _leagueId;
        public string LeagueId
        {
            get
            {
                if (_leagueId == null)
                {
                    ReadAllStats();
                }

                return _leagueId;
            }
        }

        private string _games;
        public string Games
        {
            get
            {
                if (_games == null)
                {
                    ReadAllStats();
                }

                return _games;
            }
        }

        private string _atBats;
        public string AtBats
        {
            get
            {
                if (_atBats == null)
                {
                    ReadAllStats();
                }

                return _atBats;
            }
        }

        private string _runs;
        public string Runs
        {
            get
            {
                if (_runs == null)
                {
                    ReadAllStats();
                }

                return _runs;
            }
        }

        private string _hits;
        public string Hits
        {
            get
            {
                if (_hits == null)
                {
                    ReadAllStats();
                }

                return _hits;
            }
        }

        private string _doubles;
        public string Doubles
        {
            get
            {
                if (_doubles == null)
                {
                    ReadAllStats();
                }

                return _doubles;
            }
        }

        private string _triples;
        public string Triples
        {
            get
            {
                if (_triples == null)
                {
                    ReadAllStats();
                }

                return _triples;
            }
        }

        private string _homeRuns;
        public string HomeRuns
        {
            get
            {
                if (_homeRuns == null)
                {
                    ReadAllStats();
                }

                return _homeRuns;
            }
        }

        private string _runsBattedIn;
        public string RunsBattedIn
        {
            get
            {
                if (_runsBattedIn == null)
                {
                    ReadAllStats();
                }

                return _runsBattedIn;
            }
        }

        private string _stolenBases;
        public string StolenBases
        {
            get
            {
                if (_stolenBases == null)
                {
                    ReadAllStats();
                }

                return _stolenBases;
            }
        }

        private string _caughtStealing;
        public string CaughtStealing
        {
            get
            {
                if (_caughtStealing == null)
                {
                    ReadAllStats();
                }

                return _caughtStealing;
            }
        }

        private string _walks;
        public string Walks
        {
            get
            {
                if (_walks == null)
                {
                    ReadAllStats();
                }

                return _walks;
            }
        }

        private string _strikeouts;
        public string Strikeouts
        {
            get
            {
                if (_strikeouts == null)
                {
                    ReadAllStats();
                }

                return _strikeouts;
            }
        }

        private string _intentionalWalks;
        public string IntentionalWalks
        {
            get
            {
                if (_intentionalWalks == null)
                {
                    ReadAllStats();
                }

                return _intentionalWalks;
            }
        }

        private string _hitByPitch;
        public string HitByPitch
        {
            get
            {
                if (_hitByPitch == null)
                {
                    ReadAllStats();
                }

                return _hitByPitch;
            }
        }

        private string _sacrificeHits;
        public string SacrificeHits
        {
            get
            {
                if (_sacrificeHits == null)
                {
                    ReadAllStats();
                }

                return _sacrificeHits;
            }
        }

        private string _sacrificeFlies;
        public string SacrificeFlies
        {
            get
            {
                if (_sacrificeFlies == null)
                {
                    ReadAllStats();
                }

                return _sacrificeFlies;
            }
        }

        private string _groundedIntoDoublePlays;
        public string GroundedIntoDoublePlays
        {
            get
            {
                if (_groundedIntoDoublePlays == null)
                {
                    ReadAllStats();
                }

                return _groundedIntoDoublePlays;
            }
        }

        private readonly string _statLine;
        private readonly StatIndices[] _statIndices = new StatIndices[22];

        public Option09Batter(string statLine)
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
        }

        private void ReadAllStats()
        {
            _playerId = ReadStat(0);
            _yearId = ReadStat(1);
            _stint = ReadStat(2);
            _teamId = ReadStat(3);
            _leagueId = ReadStat(4);
            _games = ReadStat(5);
            _atBats = ReadStat(6);
            _runs = ReadStat(7);
            _hits = ReadStat(8);
            _doubles = ReadStat(9);
            _triples = ReadStat(10);
            _homeRuns = ReadStat(11);
            _runsBattedIn = ReadStat(12);
            _stolenBases = ReadStat(13);
            _caughtStealing = ReadStat(14);
            _walks = ReadStat(15);
            _strikeouts = ReadStat(16);
            _intentionalWalks = ReadStat(17);
            _hitByPitch = ReadStat(18);
            _sacrificeHits = ReadStat(19);
            _sacrificeFlies = ReadStat(20);
            _groundedIntoDoublePlays = ReadStat(21);
        }

        private string ReadStat(int statNdx)
        {
            return _statLine.Substring(_statIndices[statNdx].startNdx, _statIndices[statNdx].endNdx - _statIndices[statNdx].startNdx);
        }

        public override string ToString()
        {
            return String.Concat(PlayerId, YearId, Stint, TeamId, LeagueId, Games, AtBats, Runs, Hits, Doubles, Triples, HomeRuns, RunsBattedIn, StolenBases, CaughtStealing, Walks, Strikeouts, IntentionalWalks, HitByPitch, SacrificeHits, SacrificeFlies, GroundedIntoDoublePlays);
        }

        private struct StatIndices
        {
            public int startNdx;
            public int endNdx;
        }
    }
}
