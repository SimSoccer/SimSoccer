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

            var players = doc.Descendants( "Player" ).Select( player => new Player
            {
                Id = int.Parse( player.Element( "Id" ).Value ),
                ShirtNumber = int.Parse( player.Element( "ShirtNumber" ).Value ),
                Name = player.Element( "Name" ).Value,
                Nationality = player.Element( "Nationality" ).Value,
                Poste = player.Element( "Poste" ).Value,
                Height = float.Parse( player.Element( "Height" ).Value, System.Globalization.NumberStyles.AllowDecimalPoint ),
                Weight = float.Parse( player.Element( "Weight" ).Value, System.Globalization.NumberStyles.AllowDecimalPoint ),
                BirthDate = player.Element( "BirthDate" ).Value,
                BirthPlace = player.Element( "BirthPlace" ).Value,
                PreviousClub = player.Element( "PreviousClub" ).Value,
                ActualClub = player.Element( "ActualClub" ).Value,
                Stats = int.Parse( player.Element( "Stats" ).Value ),
                FormState = int.Parse( player.Element( "FormState" ).Value ),
                Injury = bool.Parse( player.Element( "Injury" ).Value ),
                Mental = int.Parse( player.Element( "Mental" ).Value ),
                FinancialValue = int.Parse( player.Element( "FinancialValue" ).Value )
            } ).ToDictionary( student => student.Id );
            return ;
        }

        public Dictionary<string,Player> Name
        {
            get { return _players; }
        }
    }
}
