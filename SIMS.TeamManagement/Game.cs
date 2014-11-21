using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.TeamsManagement
{
    public class Game
    {
        readonly TeamList _teamList;

        public Game()
        {
            _teamList = new TeamList( this );
        }
    }
}
