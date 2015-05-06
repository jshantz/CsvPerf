using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvPerf
{
    public class Option10Batter
    {
        private static char[] _buffer = new char[16];
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

        public Option10Batter(string statLine)
        {
            _statLine = statLine;
        }

        private void ReadAllStats()
        {
            var startNdx = 0;
            var batter = new SimpleBatter();

            _playerId = ReadNext(_statLine, startNdx, out startNdx);
            _yearId = ReadNext(_statLine, startNdx, out startNdx);
            _stint = ReadNext(_statLine, startNdx, out startNdx);
            _teamId = ReadNext(_statLine, startNdx, out startNdx);
            _leagueId = ReadNext(_statLine, startNdx, out startNdx);
            _games = ReadNext(_statLine, startNdx, out startNdx);
            _atBats = ReadNext(_statLine, startNdx, out startNdx);
            _runs = ReadNext(_statLine, startNdx, out startNdx);
            _hits = ReadNext(_statLine, startNdx, out startNdx);
            _doubles = ReadNext(_statLine, startNdx, out startNdx);
            _triples = ReadNext(_statLine, startNdx, out startNdx);
            _homeRuns = ReadNext(_statLine, startNdx, out startNdx);
            _runsBattedIn = ReadNext(_statLine, startNdx, out startNdx);
            _stolenBases = ReadNext(_statLine, startNdx, out startNdx);
            _caughtStealing = ReadNext(_statLine, startNdx, out startNdx);
            _walks = ReadNext(_statLine, startNdx, out startNdx);
            _strikeouts = ReadNext(_statLine, startNdx, out startNdx);
            _intentionalWalks = ReadNext(_statLine, startNdx, out startNdx);
            _hitByPitch = ReadNext(_statLine, startNdx, out startNdx);
            _sacrificeHits = ReadNext(_statLine, startNdx, out startNdx);
            _sacrificeFlies = ReadNext(_statLine, startNdx, out startNdx);
            _groundedIntoDoublePlays = ReadNext(_statLine, startNdx, out startNdx);
        }

        private string ReadNext(string stats, int startNdx, out int endNdx)
        {
            var currNdx = startNdx;
            while (currNdx < stats.Length && stats[currNdx] != ',')
            {
                currNdx++;
            }

            endNdx = currNdx + 1;
            stats.CopyTo(startNdx, _buffer, 0, currNdx - startNdx);
            return new String(_buffer, 0, currNdx - startNdx);
        }

        public override string ToString()
        {
            return String.Concat(PlayerId, YearId, Stint, TeamId, LeagueId, Games, AtBats, Runs, Hits, Doubles, Triples, HomeRuns, RunsBattedIn, StolenBases, CaughtStealing, Walks, Strikeouts, IntentionalWalks, HitByPitch, SacrificeHits, SacrificeFlies, GroundedIntoDoublePlays);
        }
    }
}
