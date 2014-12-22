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
    public class CalendarTests
    {
        [Test]
        public void create_matchDay()
        {
            Game g = new Game("test", "1234", "blabla", "lala");
            g.Ligue.fillCalendar();

            Assert.That(g.Ligue.Calendar.MatchDay.Count, Is.Not.Null);
        }

        [Test]
        public void list_of_match_is_not_empty()
        {
            Game g = new Game("test", "1234", "blabla", "lala");
            g.Ligue.fillCalendar();
            int i = 0;

            Assert.That(g.Ligue.Calendar.MatchDay[i].Matchs, Is.Not.Null);
        }

        [Test]
        public void Create_a_team_correctly()
        {
            Game g = new Game("test", "1234", "blabla", "lala");
            Team to =  g.TeamList.CreateTeam("Psg");

            Assert.That(g.TeamList.Teams.Contains(to));
        }

        [Test]
        public void My_dictionnary_is_not_empty()
        {
            Game g = new Game("toto", "zozo", "yooooooo", "aaaaaaaaaaa");
            
        }
    }
} 
