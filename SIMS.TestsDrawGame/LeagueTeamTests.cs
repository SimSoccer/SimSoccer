using DrawGame;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.TestsDrawGame
{
    [TestFixture]
    public class LeagueTeamTests
    {
        [Test]
        public void create_a_team_correctly()
        {
            ///Arrange
            LeagueTeam sut = new LeagueTeam();

            ///Act
            Team paris = sut.CreateTeam("psg");

            ///Assert
            Assert.That(paris.NameTeam, Is.EqualTo(1));
        }

        [Test]
        public void Createteam_with_existing_team_throws_ArgumentException()
        {
            LeagueTeam sut = CreateTestTeam();

            Assert.Throws<ArgumentException>(() => sut.CreateTeam("psg"));
        }

        private LeagueTeam CreateTestTeam()
        {
            ///Arrange
            LeagueTeam leagueTeam = new LeagueTeam();
            ///Act
            Team psg = leagueTeam.CreateTeam("psg");
            return leagueTeam;
        }
    }
}