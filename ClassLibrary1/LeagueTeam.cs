using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawGame
{
     public class LeagueTeam
    {
        readonly Dictionary<string, Team> _team;
         public LeagueTeam()
         {
              _team = new Dictionary<string, Team>();
         }

         public Team this [string nameTeam]
         {
             get
             {
                 if (string.IsNullOrWhiteSpace(nameTeam)) throw new ArgumentException("The name of team cannot be null.");
                 Team team;
                 _team.TryGetValue(nameTeam, out team);
                 return team;
             }
         }
        
    }
}