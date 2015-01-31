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
        List<Player> _scorerH;
        List<Player> _scorerO;

        public string TextSummary
        {
            get { return _textSummary; }
        }
        public List<Player> ScorerO
        {
            set { _scorerO = value; }
            get { return _scorerO; }
        }
        public List<Player> ScorerH
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
            ScorerH = new List<Player>();
            ScorerO = new List<Player>();
        }

        public void Result()
        {

            if (_scoreH == _scoreO)
            {
                _winner = _dom.Name;
                _looser = _winner;
                _textSummary = "C'est un match nul entre " + _dom.TeamTag + " et " + _ext.TeamTag + "\r\n Score: " + ScoreH + " - " + ScoreO;

                _dom.LeaguePoint++;
                _ext.LeaguePoint++;

            }
            else if (_scoreH > _scoreO)
            {
                _winner = _dom.Name;
                _looser = _ext.Name;

                if(_winner == _game.UserTeam.Name && _dom.Name == _game.UserTeam.Name)
                    _textSummary = "Vous avez gagné contre " + _ext.TeamTag + "\r\n Score: " + ScoreH + " - " + ScoreO;
                else if(_looser == _game.UserTeam.Name && _dom.Name == _game.UserTeam.Name)
                    _textSummary = "Vous avez perdu contre " + _ext.TeamTag + "\r\n Score: " + ScoreH + " - " + ScoreO;
                else if( _winner == _game.UserTeam.Name && _ext.Name == _game.UserTeam.Name )
                    _textSummary = "Vous avez gagné contre " + _dom.TeamTag + "\r\n Score: " + ScoreH + " - " + ScoreO;
                else if( _looser == _game.UserTeam.Name && _ext.Name == _game.UserTeam.Name )
                    _textSummary = "Vous avez perdu contre " + _dom.TeamTag + "\r\n Score: " + ScoreH + " - " + ScoreO;
                else
                    _textSummary = _dom.TeamTag + " a gagné contre " + _ext.TeamTag + "\r\n Score: " + ScoreH + " - " + ScoreO;

                _dom.LeaguePoint += 3;
            }
            else if (_scoreH < _scoreO)
            {
                _winner = _ext.Name;
                _looser = _dom.Name;

                if( _winner == _game.UserTeam.Name && _dom.Name == _game.UserTeam.Name)
                    _textSummary = "Vous avez gagné contre " + _ext.TeamTag + "\r\n Score: " + ScoreH + " - " + ScoreO;
                else if( _looser == _game.UserTeam.Name && _dom.Name == _game.UserTeam.Name)
                    _textSummary = "Vous avez perdu contre " + _ext.TeamTag + "\r\n Score: " + ScoreH + " - " + ScoreO;
                else if( _looser == _game.UserTeam.Name && _ext.Name == _game.UserTeam.Name )
                    _textSummary = "Vous avez perdu contre " + _dom.TeamTag + "\r\n Score: " + ScoreH + " - " + ScoreO;
                else if( _winner == _game.UserTeam.Name && _ext.Name == _game.UserTeam.Name )
                    _textSummary = "Vous avez gagné contre " + _dom.TeamTag + "\r\n Score: " + ScoreH + " - " + ScoreO;
                else
                    _textSummary = _dom.TeamTag + " a perdu contre " + _ext.TeamTag + "\r\n Score: " + ScoreH + " - " + ScoreO;

                _ext.LeaguePoint += 3;

            }

        }
    }
}