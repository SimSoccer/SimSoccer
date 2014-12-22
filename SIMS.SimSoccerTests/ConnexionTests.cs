using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Sims.SimSoccerModel;

namespace SIMS.SimSoccerTests
{
    [TestFixture]
    class ConnexionTests
    {
        [Test]
        public void wrong_password()
        {
            Game g1 = new Game( "test", "1234", "blabla", "lala" );
        
            string _password = "abcd";
            
            Assert.That( g1.UserPassword != _password);
        }
        [Test]
        public void wrong_userName()
        {
            Game g1 = new Game( "test", "1234", "blabla", "lala" );

            string _userName = "test2";

            Assert.That( g1.UserName != _userName );
        }
        [Test]
        public void password_must_contains_6_caracters_or_more()
        {
            Game g1 = new Game( "test", "1234", "blabla", "lala" );

           

            Assert.That(g1.UserPassword.Length < 6 );
        }
    }

}
