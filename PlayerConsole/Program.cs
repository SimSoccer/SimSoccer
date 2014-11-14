using SIMS.PlayerManagement;
using SoccerSimulator;
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
            PlayersList l = new PlayersList();

            Console.WriteLine( l.Name );
            l.CreatePlayersList();
            Console.WriteLine("Count : " + l.Name.Count );

            /*l.CreateListPlayers();
            */
            foreach( KeyValuePair<string, Player> kvp in l.Name)
            {
                Console.WriteLine( "Key : " + kvp.Key + " Value : " + kvp.Value );
            }
            Console.Read();
        }
    }
}
