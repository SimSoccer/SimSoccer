using SIMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SIMS.PlayersManagement
{
    public class PlayersList
    {
        internal Dictionary<int, Player> _players;
        Player p;
        public PlayersList()
        {
            _players = new Dictionary<int, Player>();
            
        }

        /// <summary>
        /// Will create Players objects and dictionaries which will contain dictionaries with these Players
        /// </summary>
        /// <returns></returns>
        public Player CreatePlayersList()
        {
            var doc = XDocument.Load( @"C:\Users\Guenole\Documents\GitHub\RealSimSoccer\SimSoccer\Ligue1Players2.xml" );

            _players = doc.Descendants( "Player" ).Select( player => new Player
            {
                Id = int.Parse( player.Element( "Id" ).Value),
                ShirtNumber = int.Parse(player.Element( "ShirtNumber" ).Value),
                Name = player.Element( "Name" ).Value,
                Nationality = player.Element( "Nationality" ).Value,
                FieldPosition = player.Element( "Poste" ).Value,
                Height = float.Parse(player.Element( "Height" ).Value),
                Weight = int.Parse( player.Element( "Weight" ).Value ),
                BirthDate = player.Element( "BirthDate" ).Value,
                BirthPlace = player.Element( "BirthPlace" ).Value,
                PreviousClub = player.Element( "PreviousClub" ).Value,
                ActualClub = player.Element( "ActualClub" ).Value,
                Stats = int.Parse(player.Element( "Stats" ).Value),
                FormState = int.Parse(player.Element( "FormState" ).Value),
                Injury = bool.Parse(player.Element( "Injury" ).Value),
                Mental = int.Parse(player.Element( "Mental" ).Value),
                FinancialValue = int.Parse(player.Element( "FinancialValue" ).Value),
                ActualClubTag = player.Element("ActualClubTag").Value
            } ).ToDictionary( player => player.Id, player => player );
            
            return p;
        }

        public Dictionary<int,Player> Name
        {
            get { return _players; }
        }
    }
}