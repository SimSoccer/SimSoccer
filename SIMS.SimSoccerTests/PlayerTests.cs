using NUnit.Framework;
using Sims.SimSoccerModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SIMS.SimSoccerTests
{
    [TestFixture]
    class PlayerTests
    {
        [Test]
        public void check_if_difference_method_works()
        {
            Image player = Image.FromFile( @".\..\..\..\images\PlayerOne.png" );
            XDocument doc = XDocument.Load( @".\..\..\..\testPlayer.xml" );
            Player theone = new Player(doc, player);
            Rectangle rball = new Rectangle( 485, 280, 17, 17 );
            Point _player = new Point( 400, 230 );
            Point _ball = new Point( 485, 280 );
            Points ball = new Points((float)_ball.X, (float)_ball.Y);
        }
    }
}
