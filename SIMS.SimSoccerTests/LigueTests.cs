using NUnit.Framework;
using Sims.SimSoccerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.SimSoccerTests
{
    public class LigueTests
    {
        [Test]

        public void a_calendar_have_38_dayMatch()
        {
            Game g = new Game("test", "1234", "blabla", "lala");
            int _year = 2014;
            Ligue _ligue1 = new Ligue(g, _year);
            Calendar _calendar = new Calendar(g.TeamList.Teams.Count, _year, _ligue1);

            Assert.That(_calendar.MatchDay.Count == 38);
        }

        [Test]
        public void ligue_contains_20_teams()
        {
            Game g = new Game("test", "1234", "blabla", "lala");
            Assert.That(g.TeamList.Teams.Count == 20);
        }
    }
}