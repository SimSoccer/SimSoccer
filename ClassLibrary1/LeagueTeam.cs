using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawGame
{
    public class LeagueTeam
    {
        List<Team> _teamLeague;

        public LeagueTeam()
        {
            _teamLeague = new List<Team>();
        }

        public List<Team> NameLeague
        {
            get { return _teamLeague; }
        }

        public Team CreateTeam(string team, int scoreTeam, string stade)
        {
            Team t = new Team(team, scoreTeam, stade);
            _teamLeague.Add(t);
            return t;
        }

        public void CreateDay()
        {
            foreach (Team t in _teamLeague)
            {
                if (!t.Opossent.Contains(t))
                {
                    t.AddOpposent(_teamLeague);
                    t.Remove(t);
                }
            }
        }
    }
}