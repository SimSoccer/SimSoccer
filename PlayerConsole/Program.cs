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

            l.CreateListPlayers();

            foreach( KeyValuePair<string, Player> kvp in l.Name)
            {
                Console.WriteLine( kvp );
            }

            Console.WriteLine( l );

            Console.Read();
        }
    }
}
