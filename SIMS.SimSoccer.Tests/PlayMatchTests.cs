using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sims.SimSoccerModel;

namespace SIMS.SimSoccer.Tests
{
    [TestFixture]
    public class PlayMatchTests
    {
        [Test]
        public void result_match_where_the_winner_is_supposed_to_be_the_host()
        {
            Game g = new Game("test", "1234");
            Team t1 = g.TeamList.CreateTeam("Team1");
            t1.Level = 99;
            Team t2 = g.TeamList.CreateTeam("Team2");
            t2.Level = 1;
            Match m = new Match(t1, t2);
            m.PlayMatch();

            Assert.That(m.Result.Winner, Is.EqualTo(t1.Name));
        }

        [Test]
        public void result_match_with_teams_that_not_in_the_same_game()
        {
            Game g = new Game("test", "1234");
            Team t1 = g.TeamList.CreateTeam("Team1");
            t1.Level = 99;
            Game g2 = new Game("test2", "1234");
            Team t2 = g2.TeamList.CreateTeam("Team2");
            t2.Level = 1;

            Assert.Throws<ArgumentException>(() => new Match(t1, t2));
        }

        [Test]
        public void result_matchs_for_a_journey()
        {
            Game g = new Game("test", "12345");
            g.Ligue.fillCalendar();

            for (int i = 0; i < g.Ligue.Calendar.MatchDay.Count; i++)
            {
                Console.WriteLine("Journée " + i + "\n");
                g.Ligue.Calendar.MatchDay[i].playJourney();
            }
        }
    }
}