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
            Team paris = sut.CreateTeam("Psg");

            ///Assert
            Assert.That(paris.Name, Is.EqualTo("Psg"));
        }

        [Test]
        public void create_a_team_with_null_or_whitespace()
        {
            Assert.Throws<ArgumentException>(() => new Team(null));
            Assert.Throws<ArgumentException>(() => new Team(" "));
            Assert.Throws<ArgumentException>(() => new Team(string.Empty));
        }

        [Test]
        public void Createteam_with_existing_team_throws_ArgumentException()
        {
            LeagueTeam sut = CreateTestTeam();

            Assert.Throws<ArgumentException>(() => sut.CreateTeam("Psg"));
        }

        private LeagueTeam CreateTestTeam()
        {
            ///Arrange
            LeagueTeam leagueTeam = new LeagueTeam();
            ///Act
            Team psg = leagueTeam.CreateTeam("Psg");
            return leagueTeam;
        }
    }
}