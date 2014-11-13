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

        public void Opposent( string teamPlayer)
        {
            Team team;
            _leagueTeam.TryGetValue(teamPlayer, out team);
            _leagueTeam.Remove(teamPlayer);
        }

        public Team this[string nameTeam]
        {
            get
            {
                if (string.IsNullOrWhiteSpace(nameTeam)) throw new ArgumentException("The name of team cannot be null.");
                Team team;
                _leagueTeam.TryGetValue(nameTeam, out team);
                return team;
            }
        }

        public Team CreateTeam(string nameTeam)
        {
            if (string.IsNullOrWhiteSpace(nameTeam)) throw new ArgumentException("The name of team cannot be null");
            if (Exist(nameTeam)) throw new ArgumentException("The team already exist");

            Team t = new Team(nameTeam);
            _leagueTeam.Add(nameTeam, t);
            return t;
        }

        /// <summary>
        /// Search in the dictionary if the team already exist
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Exist(string name)
        {
            return _leagueTeam.ContainsKey(name);
        }

        public int NbSeasonMatch
        {
           get {return _nbSeasonMatch;}
        }
    }
}