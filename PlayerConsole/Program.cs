using SoccerSimulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerConsole
{
    class Program
    {
        static void Main( string[] args )
        {

            Player test = new Player();

            Console.WriteLine( test.FinancialValue );

            Console.ReadLine();
        }
    }
}
