using SIMS.PlayersManagement;
using SIMS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace PlayerConsole
{
    class Program
    {
        static void Main( string[] args )
        {
            PlayersList test = new PlayersList();
            
            test.CreatePlayersList();
            var r = test.Players
                       .Where( a => a.ActualClubTag.Contains( "OL" ) )
                       .Select( a => a.Name );

            foreach (var d in r)
            {
                Console.WriteLine( d.ToString() );
            }
            /*foreach( KeyValuePair<int, Player> pair in test.Name )
            {
                Console.WriteLine( pair.Value.Name );
            }*/

            /*foreach (var d in test.Name)
            {
                Console.WriteLine( "{0} , {1}", d.Key, d.Value.Name );
            }*/
            Console.Read();
        }
    }
}
