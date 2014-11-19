using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawGame
{
    class Program
    {
        static void Main(string[] args)
        {
            LeagueTeam ligue1 = new LeagueTeam();

            Team psg = ligue1.CreateTeam("Psg", 89, "Parc des princes");
            Team om = ligue1.CreateTeam("om",78,"Vélodrome");
            Team lyon = ligue1.CreateTeam("lyon",76,"Gerland");
            Team lorient = ligue1.CreateTeam("Lorient", 70, "Le moustoir");
            Team bordeaux = ligue1.CreateTeam("Bordeaux", 76, "Delmas");

            ligue1.DrawTeamLeague();
            ligue1.CreateDay();

            foreach (Team e in ligue1.NameLeague)
            {
                Console.WriteLine("Les equipes dans la ligue sont : " + e.NameTeam);
            }

            foreach (Team o in psg.Opossent)
            {
                Console.WriteLine("Les opposants de " + om.NameTeam + " sont : " + o.NameTeam);
            }          
            Console.Read();
        }
    }
}