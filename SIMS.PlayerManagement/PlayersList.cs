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
        Player p;
        public PlayersList()
        {
            _players = new Dictionary<string, Player>();
            
        }


        public Player CreatePlayersList()
        {
            var doc = XDocument.Load( @"C:\Users\Guenole\Documents\GitHub\RealSimSoccer\SimSoccer\Ligue1Players2.xml" );

            _players = doc.Descendants( "Player" ).Select( player => new Player
            {
                Id = player.Element( "Id" ).Value,
                ShirtNumber = player.Element( "ShirtNumber" ).Value,
                Name = player.Element( "Name" ).Value,
                Nationality = player.Element( "Nationality" ).Value,
                Poste = player.Element( "Poste" ).Value,
                Height = player.Element( "Height" ).Value,
                Weight = player.Element( "Weight" ).Value,
                BirthDate = player.Element( "BirthDate" ).Value,
                BirthPlace = player.Element( "BirthPlace" ).Value,
                PreviousClub = player.Element( "PreviousClub" ).Value,
                ActualClub = player.Element( "ActualClub" ).Value,
                Stats = player.Element( "Stats" ).Value,
                FormState = player.Element( "FormState" ).Value,
                Injury = player.Element( "Injury" ).Value,
                Mental = player.Element( "Mental" ).Value,
                FinancialValue = player.Element( "FinancialValue" ).Value
            } ).ToDictionary( player => player.Id, player => player );

            return p;
        }

        public Dictionary<string,Player> Name
        {
            get { return _players; }
        }
    }
}
