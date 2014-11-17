using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawGame
{
    public class LeagueTeam
    {
        int _nbSeasonMatch = 38;

        readonly Dictionary<string, Team> _leagueTeam;
        public LeagueTeam()
        {
            _leagueTeam = new Dictionary<string, Team>();
        }

        public Team this[string nameTeam]
        {
            get
            {
                Team team;
                _leagueTeam.TryGetValue(nameTeam, out team);
                return team;
            }
        }

        public Team CreateTeam(string team)
        {
            if (Exist(team)) throw new ArgumentException("The team already exist");

            Team t = new Team(team);
            _leagueTeam.Add(team, t);
            return t;
        }

        /// <summary>
        /// Search in the dictionary if the team already exist
        /// </summary>
        /// <param name="Team"></param>
        /// <returns></returns>
        public bool Exist(string Team)
        {
            return _leagueTeam.ContainsKey(Team);
        }

        public int NbSeasonMatch
        {
           get {return _nbSeasonMatch;}
        }

        public Dictionary<string,Team> Name
        {
            get { return _leagueTeam; }
        }

    }
}