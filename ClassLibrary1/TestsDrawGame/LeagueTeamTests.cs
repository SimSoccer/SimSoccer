using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawGame
{
    [TestFixture]
    public class LeagueTeamTests
    {
        [Test]

        public void Create_a_new_team()
        {
             Team psg = new Team("Psg");

            Assert.That(psg.Name, Is.EqualTo("Psg"));
        }
    }
}
