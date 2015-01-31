using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sims.SimSoccerModel
{
    public class Match
    {
        Team _home;
        Team _outside;
        DateTime _hour;
        readonly Game _game;
        MatchResult _result;

        public Game Game
        {
            get { return _game; }
        }

        public Team Home
        {
            get { return _home; }
            set { _home = value; }
        }

        public Team Outside
        {
            get { return _outside; }
            set { _outside = value; }
        }

        public DateTime Hour
        {
            get { return _hour; }
            set { _hour = value; }
        }

        public Match(Team dom, Team ext)
        {
            _game = dom.Game;
            if (_game != ext.Game) throw new ArgumentException("Teams must be in the same Game");
            _home = dom;
            _outside = ext;
            _home.Opponent.Add(_outside);
            _outside.Opponent.Add(_home);
        }

        public Match( Team dom, Team ext, XElement e )
        {
            _game = dom.Game;
            if( _game != ext.Game ) throw new ArgumentException( "Teams must be in the same Game" );
            _home = dom;
            _outside = ext;
            _home.Opponent.Add( _outside );
            _outside.Opponent.Add( _home );
        }

        public override string ToString()
        {
            return _home.TeamTag.ToString() + " - " + _outside.TeamTag.ToString() + " le " + _hour.ToString();
        }

        /// <summary>
        /// Gets the result. Null if <see cref="PlayMatch"/> has not been called yet.
        /// </summary>
        public MatchResult Result
        {
            get { return _result; }
        }



        /// <summary>
        /// Plays the match. Must be called only once.
        /// </summary>
        /// <returns></returns>
        //public MatchResult PlayMatch()

        public void PlayMatch(bool detail)
        {
            if (_result != null) throw new InvalidOperationException("PlayMatch must be called only once!");
            _result = new MatchResult(_home, _outside);


            int tmp = _home.Level + _outside.Level;
            int winRateH = (_home.Level * 100) / tmp;
            _result.ScoreH = 0;
            _result.ScoreO = 0;

            int nbGoal = _game.RndGauss(-1, 2);

            for (int i = 0; i < nbGoal; i++)
            {
                int draw = _game.Rnd.Next(0, 100);

                if (draw < winRateH)
                {
                    if (detail == true)
                    {
                        bool isFound = false;

                        do
                        {
                            int G = _game.Rnd.Next(0, _home.TeamType.Count);
                            if( _home.TeamType[G].Poste == "BU" || _home.TeamType[G].Poste == "ATG" || _home.TeamType[G].Poste == "ATD" || _home.TeamType[G].Poste == "AG" || _home.TeamType[G].Poste == "AD" || _home.TeamType[G].Poste == "MOG" || _home.TeamType[G].Poste == "MOD" || _home.TeamType[G].Poste == "MO" || _home.TeamType[G].Poste == "MOC" )
                            {
                                _result.ScorerH.Add(_home.TeamType[G]);
                                isFound = true;

                            }
                        } while (isFound == false);
                    }

                    _result.ScoreH++;

                }
                else if (draw > winRateH)
                {
                    if (detail == true)
                    {
                        bool isFound = false;
                        do
                        {
                            int G = _game.Rnd.Next(0, _outside.TeamType.Count);
                            if( _outside.TeamType[G].Poste == "BU" || _outside.TeamType[G].Poste == "ATG" || _outside.TeamType[G].Poste == "ATD" || _outside.TeamType[G].Poste == "AG" || _outside.TeamType[G].Poste == "AD" || _outside.TeamType[G].Poste == "MOD" || _outside.TeamType[G].Poste == "MOG" || _outside.TeamType[G].Poste == "MO" || _outside.TeamType[G].Poste == "MOC" )
                            {
                                _result.ScorerO.Add( _outside.TeamType[G] );
                                isFound = true;
                            }
                            else
                                isFound = false;
                        } while (isFound == false);
                    }

                    _result.ScoreO++;
                }
            }

            _result.Result();

            if( _game.Journey == 37 )
            {
                foreach( Team t in _game.TeamList.Teams )
                {
                    if( t.Name == _game.ChoosenTeam )
                    {
                        if( t.Objectif == 1 && t.LeagueRanking > 1 )
                        {
                            _game.GameOver = true;
                            _game.Reached = false;
                        }
                        else if( t.Objectif == 1 && t.LeagueRanking == 1 )
                        {
                            _game.GameOver = true;
                            _game.Reached = true;
                        }
                        else if( t.Objectif == 2 && t.LeagueRanking <= 3 )
                        {
                            _game.GameOver = true;
                            _game.Reached = true;
                        }
                        else if( t.Objectif == 2 && t.LeagueRanking > 3 )
                        {
                            _game.GameOver = true;
                            _game.Reached = false;
                        }
                        else if( t.Objectif == 3 && t.LeagueRanking <= 5 )
                        {
                            _game.GameOver = true;
                            _game.Reached = true;
                        }
                        else if( t.Objectif == 3 && t.LeagueRanking > 5 )
                        {
                            _game.GameOver = true;
                            _game.Reached = false;
                        }
                        else if( t.Objectif == 4 && t.LeagueRanking <= 10 )
                        {
                            _game.GameOver = true;
                            _game.Reached = true;
                        }
                        else if( t.Objectif == 4 && t.LeagueRanking > 10 )
                        {
                            _game.GameOver = true;
                            _game.Reached = false;
                        }
                        else if( t.Objectif == 5 && t.LeagueRanking <= 15 )
                        {
                            _game.GameOver = true;
                            _game.Reached = true;
                        }
                        else if( t.Objectif == 5 && t.LeagueRanking > 15 )
                        {
                            _game.GameOver = true;
                            _game.Reached = false;
                        }
                        else if( t.Objectif == 6 && t.LeagueRanking <= 17 )
                        {
                            _game.GameOver = true;
                            _game.Reached = true;
                        }
                        else if( t.Objectif == 6 && t.LeagueRanking > 17 )
                        {
                            _game.GameOver = true;
                            _game.Reached = false;
                        }

                    }
                }
            }
        }
    }
}