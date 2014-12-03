using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Sims.SimSoccerModel;

namespace SIMS.SimSoccer.Tests
{
    [TestFixture]
    public class PlayMatch
    {
        [Test]
        public void result_match()
        {
        Game g = new Game();
        Team T1 = g.TeamList.CreateTeam("Test1");
        Team T2 = g.TeamList.CreateTeam("Test2");
        T2.Level = 1;
        T1.Level = 99;
        Match M = new Match(T1, T2, g);
        Assert.That(M.PlayMatch( T1, T2 ), Is.EqualTo("the winner is"+ T1.Name));
        //( g.TeamList.Teams[0], g.TeamList.Teams[1] );
            
        }
    }
}
