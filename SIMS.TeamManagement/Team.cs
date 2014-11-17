using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SIMS.PlayerManagement
{
    class TeamsList
    {
        Dictionary<string, Team> _teams;
        Team t;
        public TeamsList()
        {
            _teams = new Dictionary<string, Team>();
        }

        public Team CreatePlayerList()
        {

            var doc = XDocument.Load( @"C:\Users\famille\Documents\GitHub\SimSoccer\Ligue1Teams.xml" );

            var players = doc.Descendants( "Team" ).Select( t1 => new Team
            {
                Id = int.Parse(team.Element("Id").Value),
            } ).ToDictionary< teams => team.Id);

            return t;
        }

        public Dictionary<string, Teams> Name
        {
            get { return _teams; }
        }
    }
}
