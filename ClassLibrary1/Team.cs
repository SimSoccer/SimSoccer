using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawGame
{
    public class Team
    {

        string _team;
        List<Team> opposent = new List<Team>();
              
        public Team(string team)
        {
            _team = team;
        }

        public string TeamPlayer(string TeamChoice)
        {
            return _team = TeamChoice;
        }
        public string NameTeam
        {
            get { return _team; }
        }
        public void Opposent(Team opponent)
        {
            opposent.Add(opponent);
        }

        public List<Team> Name
        {
            get { return opposent; }
        }
    }
}