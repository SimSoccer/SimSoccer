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

        public TeamList CreateTeam() 
        {
            var t = 0;
            TeamList tl = new TeamList(this);
            return tl;
        }
    }
}
