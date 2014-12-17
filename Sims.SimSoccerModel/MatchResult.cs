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
        int _scoreH;
        int _scoreO;
        string _winner;
        string _looser;
        string _textSummary;
        List<string> _scorerH;
        List<string> _scorerO;

        public string TextSummary
        {
            get { return _textSummary; }
        }
        public List<string> ScorerO
        {
            set { _scorerO = value; }
            get { return _scorerO; }
        }
        public List<string> ScorerH
        {
            set { _scorerH = value; }
            get { return _scorerH; }
        }
        public int ScoreH
        {
            set { _scoreH = value; }
            get { return _scoreH; }
        }

        public int ScoreO
        {
            set { _scoreO = value; }
            get { return _scoreO; }
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
            if (_game != ext.Game) throw new ArgumentException();
            _dom = dom;
            _ext = ext;
            ScorerH = new List<string>();
            ScorerO = new List<string>();

        }

        public void Result()
        {

            if (_scoreH == _scoreO)
            {
                _textSummary = "it's a tie betwen " + _dom.Name + " and " + _ext.Name + "\nScore: " + ScoreH + " - " + ScoreO;

            }
            else if (_scoreH > _scoreO)
            {
                _winner = _dom.Name;
                _looser = _ext.Name;
                _textSummary = _dom.Name + " won against " + _ext.Name + "\nScore: " + ScoreH + " - " + ScoreO;

            }
            else if (_scoreH < _scoreO)
            {
                _winner = _ext.Name;
                _looser = _dom.Name;
                _textSummary = _dom.Name + " loose against " + _ext.Name + "\nScore: " + ScoreH + " - " + ScoreO;

            }

        }
    }
}