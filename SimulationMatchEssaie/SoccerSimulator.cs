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
        Rectangle rball;
        Timer t = new Timer();
        int i = 0;
        int ballon;
        int count = 0;
        int iBall = 0;
        Image player;
        Image ball;
        Points theball;
        Player theone;
        Image field;
        Point _playerPoints;
        Point _ballPoints;
        Points intermediatePoint;
        Points postePosition;
        Points secondObjectif;
        Points intermediatePoint2;
        Points nextBallPoint;
        #endregion

        public SoccerSimulator()
        {
            InitializeComponent();

            player = Image.FromFile( @".\..\..\..\images\PlayerOne.png" );
            field = Image.FromFile( @".\..\..\..\images\nefield.png" );
            XDocument doc = XDocument.Load( @".\..\..\..\testPlayer.xml" );
            theone = _game.TeamList.Teams[8].TeamPlayers[8];

            //Position milieu de terrain pour le ballon visuellement.
            rball = new Rectangle( 485, 280, 17, 17 );
            theball = new Points( ( float )rball.X, ( float )rball.Y );

            System.Drawing.Size fieldSize = new System.Drawing.Size(1000,600);
            _playerPoints = new Point( 650, 300 );
            _ballPoints = new Point( 485, 280 );
            secondObjectif = new Points( 855, 250 );
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

            count = 1;

            intermediatePoint = theone.PlayerPosition.PointToObjectif( theball );
            nextBallPoint = theone.PlayerPosition.PointToObjectif( secondObjectif );

            listBox1.Items.Add( "NextBall Point : " + nextBallPoint.X + "; " + nextBallPoint.Y );
            listBox1.Items.Add( "Player : " + _playerPoints.X + "; " + _playerPoints.Y );
            listBox1.Items.Add( "Ballon : " + theball.X + "; " + theball.Y );
            listBox1.Items.Add( "Point intermediare : " + intermediatePoint.X + "; " + intermediatePoint.Y );
            listBox1.Items.Add( "Second Objectif : " + secondObjectif.X + "; " + secondObjectif.Y );

            if( _playerPoints.X == theball.X - 20 && _playerPoints.Y == theball.Y - 50 && rball.X != secondObjectif.X && rball.Y != secondObjectif.Y - 50 )
            {
                rball.X = ( int )nextBallPoint.X + 25;
                rball.Y = ( int )nextBallPoint.Y + 50;
                theball.X = ( float )rball.X;
                theball.Y = ( float )rball.Y;
            }
            else if( _playerPoints.X == theball.X && _playerPoints.Y == theball.Y - 50 && rball.X != secondObjectif.X && rball.Y != secondObjectif.Y - 50 )
            {
                rball.X = ( int )nextBallPoint.X + 25;
                rball.Y = ( int )nextBallPoint.Y + 50;
                theball.X = ( float )rball.X;
                theball.Y = ( float )rball.Y;
            }
            else if( _playerPoints.X != theball.X || _playerPoints.Y != theball.Y - 50 && _playerPoints.X != secondObjectif.X && _playerPoints.Y != secondObjectif.Y && theball.X != secondObjectif.X && theball.Y != secondObjectif.Y - 50 )
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

            #endregion

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
            Graphics g = e.Graphics;
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
