using Sims.SimSoccerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCheck
{
    public class Consolec
    {
        static void Main(string[] args)
        {
            Game g = new Game("Toto","Tata");
            int i;

            for (i = 0; i < g.TeamList.Teams[0].TeamPlayers.Count; i++ )
            {
                Console.WriteLine("Les noms des titulaires sont : " + g.TeamList.Teams[15].TeamType[0].Name);
            }
            Console.ReadLine();
        }
    }
}