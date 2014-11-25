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
           // Console.WriteLine( g.PlayerList.Players[1].Name );
           // Console.WriteLine( "1 : " + g.TeamList.Teams[15].TeamPlayers );
            TeamList tl = g.TeamList;
           // Console.WriteLine( "2 : " + tl.Teams[15].TeamPlayers );
            PlayerList pl = g.PlayerList;



            string ttt = g.TeamList.Teams[15].TeamTag;
            /*int i;

           
           for( i = 0; i <  g.PlayerList.Players.Count; i++ )
            {
                if( g.PlayerList.Players[i].ActualTeamTag == ttt )
                {
                    Console.WriteLine( g.PlayerList.Players[i].Name );
                }
            }*/
            List<string> t = g.PlayerList.Players.Where( p => p.ActualTeamTag == ttt ).Select( p => p.Name ).ToList();

            Console.WriteLine( g.TeamList.Teams[15].TeamPlayers );
           /*foreach( string s in g.PlayerList.Players.Where( p => p.ActualTeamTag == ttt ).Select( p => p.Name ) )
           {
               Console.WriteLine( s );
               t = s;
           }*/

            //Console.WriteLine( pl.Players[1].Name );

            /*
            Console.WriteLine( "La taille de " + pl.Players[0].Name + " est de : " + pl.Players[0].Height );

            int i;
            string tt = tl.Teams[15].TeamTag;
            List<string> teamPlayers = new List<string>();
            for( i = 0; i < pl.Players.Count; i++ )
            {
                if( pl.Players[i].ActualTeamTag == tt )
                {
                    Console.WriteLine( pl.Players[i].Name );
                    teamPlayers.Add( pl.Players[i].Name );
                }
            }

            /*Console.WriteLine( " Joueurs de : " + tt );
            int t;
            for( t = 0; t < teamPlayers.Count; t++ )
            {
                Console.WriteLine( teamPlayers[t] );
            }*/

            /*int t;
            for( t = 0; t < tl.Teams.Count; t++ )
            {
                Console.WriteLine( "______________________" + Environment.NewLine + tl.Teams[t].Name );
                foreach( string s in tl.Teams[t].TeamPlayers )
                {
                    Console.WriteLine( s );
                }
                Console.WriteLine( "______________________" + Environment.NewLine );
            }

            DateTime today = DateTime.Now;

            Console.WriteLine( "Date d'aujoud'hui : " + today.Day );
            //Console.WriteLine( tl.Teams[15].TeamPlayers );*/

            Console.Read();
        }
    }
}
