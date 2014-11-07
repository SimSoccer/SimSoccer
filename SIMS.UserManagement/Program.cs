using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateUserAccount
{
    class Program
    {
        static void Main( string[] args )
        {
            User Manager1 = new User();
            Manager1.UserName = "Florian";
            Manager1.SetPassword( "123456" );
            bool success = TryConnection(Manager1);

            if( success )
            {

            }
            Console.ReadLine();
            
        }

            private static bool TryConnection(User u)
           {
            bool success;
            do
            {
                Console.Write("Please enter your username :");
                string myUsername = Console.ReadLine();
                if(myUsername == "")
                {
                    success = false;
                    break;
                }
                if(u.UsernameMatch(myUsername))
                {
                    success = true;
                    break;
                }

                Console.Write("Please enter your password :");
                string myPassword = Console.ReadLine();
                if (myPassword == "")
                {
                    success = false;
                    break;
                }
                if (u.PasswordMatch(myPassword))
                {
                    success = true;
                    break;
                }

            } while (true);
            return success;
            }
    }
}

       



