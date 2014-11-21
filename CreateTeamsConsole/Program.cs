using SIMS.TeamsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateTeamsConsole
{
    class Program
    {
        static void Main( string[] args )
        {
            TeamsList test = new TeamsList();

            test.CreateTeamsList();
            foreach( KeyValuePair<int, Team> pair in test.Name )
            {
                Console.WriteLine( pair.Value );
            }

            /*foreach( var d in test.Name )
            {
                Console.WriteLine( "{0} , {1}", d.Key, d.Value.Name );
            }*/
            Console.Read();
        }
    }
}
