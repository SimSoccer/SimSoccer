 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if( _game != ext.Game ) throw new ArgumentException("Teams must be in the same Game");
            _home = dom; 
            _outside = ext;
            _home.Opponent.Add(_outside);
            _outside.Opponent.Add(_home);

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
            if( _result != null ) throw new InvalidOperationException( "PlayMatch must be called only once!" );
            _result = new MatchResult( _home, _outside );


            int tmp = _home.Level + _outside.Level;
            int winRateH = (_home.Level * 100) / tmp;
            _result.ScoreH = 0;
            _result.ScoreO = 0;

            int nbGoal = _game.RndGauss(-1, 2);
           
            for( int i = 0; i < nbGoal; i++ )
            {
                int draw = _game.Rnd.Next( 0, 100 );

                if( draw < winRateH )
                {
                    if( detail == true )
                    {
                        bool isFound = false;

                        do
                        {

                            int G = _game.Rnd.Next( 0, _home.TeamPlayers.Count );
                            if( _home.TeamPlayers[G].Poste == "BU" || _home.TeamPlayers[G].Poste == "ATG" || _home.TeamPlayers[G].Poste == "ATD" )
                            {
                             //   Console.WriteLine( _home.TeamPlayers[G].Name + " Scored for " + _home.TeamTag );
                                _result.ScorerH.Add( _home.TeamPlayers[G] );
                                isFound = true;

                            }
                        } while( isFound == false );
                    }

                    _result.ScoreH++;
                
                }
                else if( draw > winRateH )
                {
                    if( detail == true )
                    {

                        bool isFound = false;

                        do
                        {

                            int G = _game.Rnd.Next( 0, _outside.TeamPlayers.Count );
                            if( _outside.TeamPlayers[G].Poste == "BU" || _outside.TeamPlayers[G].Poste == "ATG" || _outside.TeamPlayers[G].Poste == "ATD" )
                            {
                                //Console.WriteLine( _outside.TeamPlayers[G].Name + " Scored for " + _outside.TeamTag );
                                _result.ScorerO.Add( _outside.TeamPlayers[G]);
                                isFound = true;

                            }
                        } while( isFound == false );
                    }

                    _result.ScoreO++;
                }
            }

            _result.Result();
        }
    }
}