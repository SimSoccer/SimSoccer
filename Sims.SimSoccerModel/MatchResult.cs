using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims.SimSoccerModel
{
    public class MatchResult
    {

        Team _dom;
        Team _ext;
        readonly Game _game;
        int _scoreD;
        int _scoreE;
        string _winner;
        string _looser;
        string _textSummary;

        public string TextSummary
        {
            get { return _textSummary; }
        }
        public int ScoreD
        {
            set { _scoreD = value; }
            get { return _scoreD; }
        }

        public int ScoreE
        {
            set { _scoreE = value; }
            get { return _scoreE; }
        }

        public string Winner
        {
            set { _winner = value; }
            get { return _winner; }
        }

        public string Looser
        {
            set { _looser = value; }
            get { return _looser; }
        }

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

        public MatchResult(Team dom, Team ext)
        {
            _game = dom.Game;
            if( _game != ext.Game ) throw new ArgumentException();
            _dom = dom; 
            _ext = ext;
       
        }

        public void Result()
        {
            
            if( _scoreD == _scoreE )
            {
               _textSummary =  "it's a tie betwen " + _dom.Name + " and " + _ext.Name + "\nScore: " + ScoreD + " - " + ScoreE;

            }
             else if( _scoreD > _scoreE )
            {
                _winner = _dom.Name;
                _looser = _ext.Name;
                _textSummary = _dom.Name + " won against " + _ext.Name + "\nScore: " + ScoreD + " - " + ScoreE;
                
            }
            else if( _scoreD < _scoreE )
            {
                _winner = _ext.Name;
                _looser = _dom.Name;
                _textSummary = _dom.Name + " loose against " + _ext.Name + "\nScore: " + ScoreD + " - " + ScoreE;
                
            }
           
        }

    }
}
