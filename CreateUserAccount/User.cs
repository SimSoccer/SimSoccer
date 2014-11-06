using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateUserAccount
{
     public class User
    {
         string _userName;
         string _userPassword;

         public string UserName
         {
             get { return _userName; }
             set { _userName = value; }
         }
         public void SetPassword( string password )
         {
             _userPassword = password;
         }
         public bool UsernameMatch( string candidate1 )
         {
             return _userName == candidate1;
         }
         public bool PasswordMatch( string candidate2 )
         {
             return _userPassword == candidate2;
         }
         
    }
}
