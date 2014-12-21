using Sims.SimSoccerModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SimulationMatchEssaie
{
    public partial class SoccerSimulator : Form
    {

        #region Attributes
        Game _game = new Game( "Toto", "Tata" );
        Rectangle rPlayer;
        Rectangle rball;
        Timer t = new Timer();
        int i = 0;
        int ballon;
        int count = 0;
        int countBall = 0;
        int iBall = 0;
        Image player;
        Image ball;
        Point initialPlayerPoint;
        Points theball;
        double distance;
        Player theone;
        Image field;
        Rectangle fRec;
        #endregion
        Point _playerPoints;
        Point _ballPoints;
        List<Points> trajectoir;
        float a;
        float b;
        Points difference;
        Points nextPoint;
        Points intermediatePoint;

        public SoccerSimulator()
        {
            InitializeComponent();

            player = Image.FromFile( @".\..\..\..\images\PlayerOne.png" );
            field = Image.FromFile( @".\..\..\..\images\nefield.png" );
            XDocument doc = XDocument.Load( @".\..\..\..\testPlayer.xml" );
            theone = new Player(doc, player);

            //230 à remettre ensuite à 280.
            rball = new Rectangle( 485, 280, 17, 17 );
            theball = new Points( ( float )rball.X, ( float )rball.Y );
            Point rectPoint = new Point(0,0);
            System.Drawing.Size fieldSize = new System.Drawing.Size(1000,600);
            fRec = new Rectangle( rectPoint, fieldSize );
            _playerPoints = new Point( 550, 250 );
            _ballPoints = new Point( 485, 280 );
            trajectoir = new List<Points>();
            listBox1.Items.Add( theone.Name);
        }
        
        private void SoccerSimulator_Load( object sender, EventArgs e )
        {

            t.Interval = 100;
            t.Tick += t_Tick;
            t.Start();
            this.DoubleBuffered = true;
        }

        void t_Tick( object sender, EventArgs e )
        {
            #region Manage Player With And Without The Ball
            /*
            if( count == 0 )
            {
                _playerPoints.X += 0;
                count = 1;
            }
            else if( _playerPoints.X <= 770 && rball.X == ( _playerPoints.X + 20 ) )
            {
                if( count == 1 && i == 0 )
                    i++;

                i++;
                iBall++;
                if( i == 3 && count == 1 )
                    i = 1;
                if( iBall == 7 )
                    iBall = 0;
                rball.X += 25;
                theball.X = ( float )rball.X;

                count = 1;
            }
            else if( _playerPoints.X <= 770 && rball.X != ( _playerPoints.X + 20 ) )
            {
                if( count == 1 && i == 0 )
                    i++;

                i++;
                iBall++;
                if( i == 3 && count == 1 )
                    i = 1;
                if( iBall == 7 )
                    iBall = 0;
                _playerPoints.X += 5;
                rball.X += 0;
                theball.X = ( float )rball.X;
                count = 1;
                listBox1.Items.Add( theone.PlayerPosition.Distance( theball ) );
            }
            else
            {
                i = 2;
                i = 3;
                i++;
                if( rball.X < 950 )
                {
                    _playerPoints.X += 0;
                    rball.X += 5;
                }
            }
             */

            #endregion
            count = 1;

            intermediatePoint = theone.PlayerPosition.PointToObjectif( theball );
            listBox1.Items.Add( "Player : " + _playerPoints.X + "; " + _playerPoints.Y );
            listBox1.Items.Add( "Ballon : " + theball.X + "; " + theball.Y );
            listBox1.Items.Add( "Point intermediare : " + intermediatePoint.X + "; " + intermediatePoint.Y );

            if( _playerPoints.X == theball.X - 20 && _playerPoints.Y == theball.Y - 50 )
            {
                rball.X += 25;
                theball.X = ( float )rball.X;
                theball.Y = ( float )rball.Y;
            }
            else if( _playerPoints.X == theball.X && _playerPoints.Y == theball.Y - 50 )
            {
                rball.X += 25;
                theball.X = ( float )rball.X;
                theball.Y = ( float )rball.Y;
            } 
            else if( _playerPoints.X != theball.X || _playerPoints.Y != theball.Y - 50 )
            {
                i++;
                iBall++;
                if( i == 3 && count == 1 )
                    i = 1;
                if( iBall == 7 )
                    iBall = 0;
                _playerPoints.X = ( int )intermediatePoint.X;
                _playerPoints.Y = ( int )intermediatePoint.Y;
            }

            /*
            if( _playerPoints.X == theball.X - 20 && _playerPoints.Y == theball.Y - 50 )
            {
                rball.X += 25;
                theball.X = ( float )rball.X;
                theball.Y = ( float )rball.Y;
            }
            else if( _playerPoints.X != theball.X || _playerPoints.Y != theball.Y )
            {
                i++;
                iBall++;
                if( i == 3 && count == 1 )
                    i = 1;
                if( iBall == 7 )
                    iBall = 0;
                _playerPoints.X = ( int )nextPoint.X;
                _playerPoints.Y = ( int )nextPoint.Y;

                nextPoint.X = ( float )_playerPoints.X;
                nextPoint.Y = ( float )_playerPoints.Y;
            }

            listBox1.Items.Add( "Actual Player Position : " + theone.PlayerPosition.X + ", " + theone.PlayerPosition.Y );
            listBox1.Items.Add( "Actual Player Position2 : " + _playerPoints.X + ", " + _playerPoints.Y );*/
            Invalidate();
        }

        private void SoccerSimulator_Paint( object sender, PaintEventArgs e )
        {
            ballon = iBall + 1;
            ball = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\ball" + ballon + ".png" );

            _game.Graphic = e.Graphics;

            #region Manage Drawn Field
            //Brushes the whole field in Green
            //Field f = new Field();
            _game.Graphic.FillRectangle( Brushes.DarkGreen, 0, 0, _game.Field.FieldSize.Width, _game.Field.FieldSize.Heigth );

            // Show the field's boxes.
            foreach( Box p in _game.Field.Boxes )
            {
                _game.Graphic.DrawRectangle( Pens.WhiteSmoke, p._x, p._y, p._size.Width, p._size.Heigth );
            }

            /*
            foreach( Points c in _game.Field.BoxCenterPoint )
            {
                _game.Graphic.DrawRectangle( Pens.WhiteSmoke, c.X, c.Y, 1, 1 );
            }*/
            // Draw the throw in lines and the behind goal lines.
            _game.Graphic.DrawLine( Pens.Red, _game.Field.Zones.ThrowIn1[0].X, _game.Field.Zones.ThrowIn1[0].Y, _game.Field.Zones.ThrowIn1[10].X, _game.Field.Zones.ThrowIn1[10].Y );
            _game.Graphic.DrawLine( Pens.Red, _game.Field.Zones.ThrowIn2[0].X, _game.Field.Zones.ThrowIn2[0].Y, _game.Field.Zones.ThrowIn2[10].X, _game.Field.Zones.ThrowIn2[10].Y );
            _game.Graphic.DrawLine( Pens.Red, _game.Field.Zones.BehingGoalLine1[0].X, _game.Field.Zones.BehingGoalLine1[0].Y, _game.Field.Zones.BehingGoalLine1[6].X, _game.Field.Zones.BehingGoalLine1[6].Y );
            _game.Graphic.DrawLine( Pens.Red, _game.Field.Zones.BehingGoalLine2[0].X, _game.Field.Zones.BehingGoalLine2[0].Y, _game.Field.Zones.BehingGoalLine2[6].X, _game.Field.Zones.BehingGoalLine2[6].Y );
            #endregion

            theone.Image = player;
            Points nextPoint = theone.PlayerPosition.PointToObjectif( theball );
            listBox1.Items.Add( "Next Point : " + nextPoint.X + "; " + nextPoint.Y );
            theone.DrawPlayer( _game, player, _playerPoints, theone.PlayerPosition, _ballPoints, nextPoint, i, count );
            _game.Graphic.DrawImage( ball, rball );
            //listBox1.Items.Add( "The Ball Points : " + theball.X + ", " + theball.Y );
            //listBox1.Items.Add( "The Player Points : " + theone.PlayerPosition.X + ", " + theone.PlayerPosition.Y );
            Graphics g = e.Graphics;
            /*
            nextPoint = CreateTrajectoirPoints();
            listBox1.Items.Add( "NextPoint : " + nextPoint.X + ", " + nextPoint.Y );
            difference = theone.PlayerPosition.Difference( nextPoint );
            listBox1.Items.Add( "Difference : " + difference.X + ", " + difference.Y );
             */
        }

        private void SoccerSimulator_MouseClick( object sender, MouseEventArgs e )
        {
        }

        private void SoccerSimulator_Click( object sender, EventArgs e )
        {
            t.Stop();
        }

        

    }
}
