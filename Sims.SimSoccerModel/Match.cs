﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims.SimSoccerModel
{
    public class Match
    {
        Team _dom;
        Team _ext;
        DateTime horaire_;
        readonly Game _game;      
        MatchResult _result;
        
       
        public Game Game
        {
            get { return _game; }
        }
        
        public Team Domicile
        {
            get { return _dom; }
            set { _dom = value; }
        }

        public Team Exterieur
        {
            get { return _ext; }
            set { _ext = value; }
        }

        public DateTime Horaire
        {
            get { return horaire_; }
            set { horaire_ = value; }
        }

        public Match(Team dom, Team ext)
        {
            _game = dom.Game;
            if( _game != ext.Game ) throw new ArgumentException("Teams must be in the same Game");
            _dom = dom; 
            _ext = ext;
            _dom.Opponent.Add(_ext);
            _ext.Opponent.Add(_dom);
        }

        public override string ToString()
        {
            return _dom.TeamTag.ToString() + " - " + _ext.TeamTag.ToString() + " le " + horaire_.ToString();
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
        public void PlayMatch()
        {
            if( _result != null ) throw new InvalidOperationException( "PlayMatch must be called only once!" );
            _result = new MatchResult( _dom, _ext );
            

            int tmp = _dom.Level + _ext.Level;
            int winRateH = (_dom.Level*100)/tmp;
            _result.ScoreD = 0;
            _result.ScoreE = 0;

            int nbGoal = _game.Rnd.Next( 0, 8 );


            for( int i = 0; i < nbGoal; i++ )
            {            
                int draw = _game.Rnd.Next(0, 100);
                if(draw < winRateH)
                {
                    _result.ScoreD++;
                } 
                else if(draw > winRateH)
                {
                    _result.ScoreE++;   
                }            
            }
           
            _result.Result();
            


        }
    }
}
