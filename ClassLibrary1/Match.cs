using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawGame
{
     public class Match
    {
        Team _team1;
        Team _team2;

        public Match (Team team1, Team team2)
        {
            _team1 = team1;
            _team2 = team2;
        }
    }
}