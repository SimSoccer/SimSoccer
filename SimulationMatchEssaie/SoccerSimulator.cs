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
        float x;
        float y;

        public SoccerSimulator()
        {
            InitializeComponent();

            player = Image.FromFile( @".\..\..\..\images\PlayerOne.png" );
            field = Image.FromFile( @".\..\..\..\images\nefield.png" );
            XDocument doc = XDocument.Load( @".\..\..\..\testPlayer.xml" );
            theone = new Player(doc, player);

            //230 à remettre ensuite à 280.
            rball = new Rectangle( 485, 230, 17, 17 );
            theball = new Points( ( float )rball.X, ( float )rball.Y );
            Point rectPoint = new Point(0,0);
            System.Drawing.Size fieldSize = new System.Drawing.Size(1000,600);
            fRec = new Rectangle( rectPoint, fieldSize );
            _playerPoints = new Point( 400, 230 );
            _ballPoints = new Point( 485, 230 );
            trajectoir = new List<Points>();
            listBox1.Items.Add( theone.Name);
        }

        private void CreateTrajectoirPoints()
        {
             
        }

        private void SoccerSimulator_Load( object sender, EventArgs e )
        {

            t.Interval = 100;
            t.Tick += t_Tick;
            t.Start();
            this.DoubleBuffered = true;
        }

        private void SoccerSimulator_Paint( object sender, PaintEventArgs e )
        {
            if( i == 0 )
                player = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\PlayerOne.png" );
            else if( i == 1 )
                player = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\PlayerMoveRight1.png" );
            else if( i == 2 )
                player = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\PlayerMoveRight2.png" );
            else if( i == 3 )
                player = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\p1Shoot.png" );
            else if( i == 4 )
                player = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\p5shoot.png" );
            else if( i == 5 )
                player = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\p1Stand.png" );
            else throw new InvalidOperationException( "Le nombre a été dépassé : " + i );

            ballon = iBall + 1;
            ball = Image.FromFile(@"C:\Users\Guenole\Desktop\SimSoccer2\images\ball"+ballon+".png");

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
            //_game.Graphic.DrawImage( field, fRec );
            //_game.Graphic.DrawImage( theone.Image, rPlayer );
            theone.DrawPlayer( _game, player, _playerPoints, _ballPoints, i, count );
            _game.Graphic.DrawImage( ball, rball );

            Points vector = theone.PlayerPosition.Vector( theball );
            Points vectorLess = theone.PlayerPosition.Difference( theball );
            float xNormalized = theone.PlayerPosition.NormalisationX( theball );
            float yNormalized = theone.PlayerPosition.NormalisationY( theball );
            listBox1.Items.Add( "Vector :" + vector.X + ", " + vector.Y );
            listBox1.Items.Add( "VectorLess :" + vectorLess.X + ", " + vectorLess.Y );
            double vectorLenght = theone.PlayerPosition.Lenght( theball );
            listBox1.Items.Add( "Vector Lenght :" + vectorLenght );
            listBox1.Items.Add( "The Ball Points : " + theball.X + ", " + theball.Y );
            listBox1.Items.Add( "The Player Points : " + theone.PlayerPosition.X + ", " + theone.PlayerPosition.Y );
            listBox1.Items.Add( "X normalized is equal to : " + xNormalized );
            Graphics g = e.Graphics;
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
            
            Invalidate();
             */
            #endregion
            //listBox1.Items.Add( "Vector : " + theone.PlayerPosition.Vector( theball ).X + ", " + theone.PlayerPosition.Vector( theball ).Y);
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
