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
         public void team_list_titulaire_is_null_throws_index_out_of_range_exception()
         {
             /*Game g = new Game("test", "1234", "blabla", "lala");
             int i = 0;
             g.TeamList.Teams[i].TeamType.Clear();
             Assert.Throws<IndexOutOfRangeException>(() => g.TeamList.Teams[i].TeamType.Count());*/
         }

         [Test]
         public void team_list_remplacent_is_equal_to_7()
         {
             Game g = new Game("test", "1234", "blabla", "lala");
             int i = 0;
             Assert.That(g.TeamList.Teams[i].Remplacent.Count == 7);
         }
         [Test]
         public void team_list_reservist_is_not_null()
         {
             Game g = new Game("test", "1234", "blabla", "lala");
             int i = 0;
             Assert.That(g.TeamList.Teams[i].Reserve.Count != 0);
         }
    }
}
