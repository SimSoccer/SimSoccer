using Sims.SimSoccerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CreatePlayerListConsole
{
    class Program
    {
        static void Main( string[] args )
        {
            Game g = new Game();
            XDocument doc = XDocument.Load( @"C:\Users\Guenole\Documents\GitHub\RealSimSoccer\SimSoccer\Ligue1Players2.xml" );

            PlayerList pl = new PlayerList( g, doc.Root.Element( "Players" ) );

            Console.WriteLine( pl.Players[0].Id );
            Console.Read();
        }
    }
}
