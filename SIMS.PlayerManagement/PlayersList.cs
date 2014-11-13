using SoccerSimulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SIMS.PlayerManagement
{
    public class PlayersList
    {
        Dictionary<string, Player> _players;

        public PlayersList()
        {
            _players = new Dictionary<string, Player>();
        }

        public Player CreateListPlayers()
        {
            var doc = XDocument.Load( @"C:\Users\Guenole\Documents\GitHub\RealSimSoccer\SimSoccer\Ligue1Players.xml" );
            var rootNodes = doc.Root.DescendantNodes().OfType<XElement>().DescendantNodes().OfType<XAttribute>();
            var keyValuePairs = from n in rootNodes
                                select new
                                {
                                    TagName = n.Name,
                                    TagValue = n.Value
                                };

            Player p = new Player();

            Dictionary<string, Player> allItems = new Dictionary<string, Player>();
            foreach( var token in keyValuePairs )
                allItems.Add( token.TagName.ToString(), p );
            return p;
        }

        public Dictionary<string,Player> Name
        {
            get { return _players; }
        }
    }
}
