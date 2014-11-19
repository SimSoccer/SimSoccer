using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.TeamsManagement
{
    [TestFixture]
    class TeamsManagementTests
    {
        [Test]
        public void check_if_there_is_teams_in_teamslist()
        {
            // Arrange
            TeamsList test = new TeamsList();
            bool container = false;

            // Act
            test.CreateTeamsList();
            if( test.Name.ContainsKey( 5 ) )
            {
                // This is in the Dictionary.
                container = true;
            }

            // Assert
            Assert.That( container == true );
        }
    }
}