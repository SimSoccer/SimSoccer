using NUnit.Framework;
using SoccerSimulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.PlayerManagement
{
    [TestFixture]
    class PlayerManagementTests
    {
        [Test]
        public void check_it_there_is_players_in_list()
        {
            // Arrange
            PlayersList test = new PlayersList();
            string container = "";

            // Act
            test.CreatePlayersList();

            if( test.Name.ContainsKey( "50" ) )
            {
                // This is in the Dictionary.
                Console.WriteLine( "The Key" );
                container = "true";
            }

            // Assert
            Assert.That( container == "true" );
        }
    }
}
