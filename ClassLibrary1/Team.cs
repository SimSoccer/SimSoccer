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
        string _stade;
        int _scoreTeam;

        List<Team> opposent = new List<Team>();
              
        public Team( string team, int scoreTeam,string stade )
        {
            _team = team;
            _scoreTeam = scoreTeam;
            _stade = stade;
        }

        public string NameTeam
        {
            get { return _team; }
        }
        public void AddOpposent(List<Team> opponent)
        {
            opposent.AddRange(opponent);
        }

        public void Remove(Team opponent)
        {
            opposent.Remove(opponent);
        }

        public List<Team> Opossent
        {
            get { return opposent; }
        }
    }
}