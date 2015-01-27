using NUnit.Framework;
using Sims.SimSoccerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.SimSoccerTests
{
     public class TacticTests
    {
         [Test]

         public void team_list_titulaire_is_equal_to_11()
         {
             Game g = new Game("test", "1234", "blabla", "lala");
             int i = 0;
             Assert.That(g.TeamList.Teams[i].TeamType.Count == 11);
         }

         [Test]
         public void team_list_remplacent_is_equal_to_7()
         {
             Game g = new Game("test", "1234", "blabla", "lala");
             int i = 0;
             Assert.That(g.TeamList.Teams[i].Remplacent.Count == 7);
         }
    }
}
