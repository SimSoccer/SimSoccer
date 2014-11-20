using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawGame
{
    public class LeagueTeam
    {
        /// <summary>
        /// fields
        /// </summary>
        List<Team> _teamLeague;
        Random r = new Random();
        int tirageFirstTeam;
        List<Match> matchs = new List<Match>();

        public LeagueTeam()
        {
            _teamLeague = new List<Team>();
        }

        public List<Team> NameLeague
        {
            get { return _teamLeague; }
        }

        public int TotalLeague
        {
            get { return _teamLeague.Count(); }
        }
        public List<Match> ListMatch
        {
            get { return matchs; }
        }
        public int TotalMatch
        {
            get { return matchs.Count(); }
        }

        public Team CreateTeam(string team, int scoreTeam, string stade)
        {
            Team t = new Team(team, scoreTeam, stade);
            _teamLeague.Add(t);
            return t;
        }

        /// <summary>
        /// Function witch return a list of matchs and who put the matchs in the journey
        /// </summary>
        /// <returns>List of matchs</returns>
        public List<Match> CreateDayAller()
        {
            while (TotalMatch <= TotalLeague / 2)
            {
                tirageFirstTeam = r.Next(0, TotalLeague);
                int tirageSecondTeam = r.Next(0, TotalLeague);
                if (!_teamLeague[tirageFirstTeam].Oponent.Contains(_teamLeague[tirageSecondTeam]) && tirageFirstTeam != tirageSecondTeam)
                {
                    Match m = new Match(_teamLeague[tirageFirstTeam], _teamLeague[tirageSecondTeam]);
                    matchs.Add(m);
                }
                else
                {
                    tirageSecondTeam = r.Next(0, TotalLeague);
                    Match m = new Match(_teamLeague[tirageFirstTeam], _teamLeague[tirageSecondTeam]);
                    matchs.Add(m);
                }
            }
            return matchs;
        }
    }
}