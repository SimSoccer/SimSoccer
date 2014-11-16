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
            l.CreatePlayersList();
            Console.WriteLine( l.Name );
            Console.ReadLine();
        }
    }
}
