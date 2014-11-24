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
            XDocument doc2 = XDocument.Load( @"C:\Users\Guenole\Documents\GitHub\RealSimSoccer\SimSoccer\Ligue1Teams.xml" );

            PlayerList pl = new PlayerList( g, doc.Root.Element( "Players" ) );
            TeamList tl = new TeamList( g, doc2.Root.Element( "Teams" ) );

            Console.WriteLine( "La taille de " + pl.Players[0].Name + " est de : " + pl.Players[0].Height );
            Console.WriteLine( "Id des joueurs du " + tl.Teams[15].Name + " sont : " + tl.Teams[15].PlayerID );

            Console.Read();
        }
    }
}
