using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims.SimSoccerModel
{
    public class Game
    {
        readonly TeamList _teamList;
        readonly PlayerList _playerList;
        string _userName;
        string _userPassword;
        string _choosenTeam;

        public string UserName
        {
            get { return _userName; }
        }
        public string UserPassword
        {
            get { return _userPassword; }
        }
        public string ChoosenTeam
        {
            get { return _choosenTeam; }
            set { _choosenTeam = value; }
        }
        public Game()
        {
            _teamList = new TeamList( this );
            _playerList = new PlayerList( this );
        }
        public Game( string userName, string userPassword )
        {
            _userName = userName;
            _userPassword = userPassword;
        }
    }
}
