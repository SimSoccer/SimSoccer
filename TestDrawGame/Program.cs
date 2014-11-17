using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawGame
{
    class Program
    {
        static void Main(string[] args)
        {
           
            //Dictionary<string, Team> ligue2 = new Dictionary<string, Team>();

            LeagueTeam ligue1 = new LeagueTeam();

            Team psg = ligue1.CreateTeam("psg");
            Team om = ligue1.CreateTeam("om");
            Team lyon = ligue1.CreateTeam("o");

            lyon.Opposent(om);
            lyon.Opposent(psg);

            foreach (Team o in lyon.Name)
            {
                Console.WriteLine("Les opposants sont : " + o.NameTeam);
            }

            foreach(KeyValuePair<string,Team> e in ligue1.Name)
            {
                Console.WriteLine(e);
            }
            Console.Read();
        }
    }
}