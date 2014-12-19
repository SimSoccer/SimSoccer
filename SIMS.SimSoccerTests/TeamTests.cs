using NUnit.Framework;
using Sims.SimSoccerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.SimSoccerTests
{
    [TestFixture]
    public class TeamTests
    {
        [Test]

        public void Create_a_team_correctly()
        {
            Game g = new Game( "test", "1234", "blabla", "lala" );
        }
    }
}