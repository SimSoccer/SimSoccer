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

        List<Team> opponent = new List<Team>();

        public Team(string team, int scoreTeam, string stade)
        {
            _team = team;
            _scoreTeam = scoreTeam;
            _stade = stade;
        }

        public string NameTeam
        {
            get { return _team; }
            set { _team = value; }
        }

        public void Remove(Team team)
        {
            opponent.Remove(team);
        }

        public List<Team> Oponent
        {
            get { return opponent; }
        }

        public int TotalOponent
        {
            get { return opponent.Count(); }
        }
    }
}