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

        public Game()
        {
            _teamList = new TeamList( this );
            _playerList = new PlayerList( this );
        }

        public IEnumerable<Player> Players
        {
            get { return _playerList.Players; }
        }
    }
}
