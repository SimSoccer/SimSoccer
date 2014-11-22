using Sims.SimSoccerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatePlayerListConsole
{
    class Program
    {
        static void Main( string[] args )
        {
            Game g = new Game();
            PlayerList pl = new PlayerList( g );
            pl.CreatePlayerList();

            var r = pl.Players
                .Where( a => a.ActualClub.Contains( "Sporting Club de Bastia" ) )
                .Select( a => a.Name );

            Console.WriteLine( r );
            Console.Read();
        }
    }
}
