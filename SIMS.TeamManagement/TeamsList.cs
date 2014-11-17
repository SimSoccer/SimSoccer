using SIMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SIMS.TeamsManagement
{
    public class TeamsList
    {
        internal Dictionary<int, Team> _teams;
        Team p;
        public TeamsList()
        {
            _teams = new Dictionary<int, Team>();
            
        }


        public Team CreateTeamsList()
        {
            var doc = XDocument.Load( @"C:\Users\Guenole\Documents\GitHub\RealSimSoccer\SimSoccer\Ligue1Teams.xml" );

            _teams = doc.Descendants( "Team" ).Select( team => new Team
            {
                Id = int.Parse( team.Element( "Id" ).Value),
                Name = team.Element( "Name" ).Value,
                TeamTag = team.Element( "TeamTag" ).Value,
                Town = team.Element( "Town" ).Value,
                Stadium = team.Element( "Stadium" ).Value,
                Logo = team.Element( "Logo" ).Value,
                Manager = team.Element( "Manager" ).Value,
                LeagueRanking = int.Parse( team.Element( "LeagueRanking" ).Value )
            } ).ToDictionary( team => team.Id, team => team );
            
            return p;
        }

        public Dictionary<int,Team> Name
        {
            get { return _teams; }
        }
    }
}