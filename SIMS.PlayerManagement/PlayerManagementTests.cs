using NUnit.Framework;
using SIMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.PlayersManagement
{
    [TestFixture]
    class PlayerManagementTests
    {
        [Test]
        public void check_if_there_is_players_in_list()
        {
            // Arrange
            PlayersList test = new PlayersList();
            bool container = false;
            string num = "";

            // Act
            test.CreatePlayersList();
            if( test.Name.ContainsKey( 517 ) )
            {
                // This is in the Dictionary.
                Console.WriteLine( "The Key" );
                container = true;
                num = Convert.ToString( test.Name.Keys );

            }

            // Assert
            Assert.That( container == true );
            //Assert.That( num == "517" );
        }
    }
}
