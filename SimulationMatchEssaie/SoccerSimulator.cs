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
        XDocument docX;
        Game _game;
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
        Points secondObjectif;
        Points nextBallPoint;
        List<Player> MyPlayers;
        Team myTeam;
        Ball _gameBall;
        Player _playerGotTheBall;
        #endregion

        public SoccerSimulator()
        {
            InitializeComponent();

            docX = XDocument.Load( @".\..\..\..\user_guegue_save_20141222.xml" );
            _game = new Game( docX.Root.Element( "Profil" ) );

            player = Image.FromFile( @".\..\..\..\images\PlayerOne.png" );
            field = Image.FromFile( @".\..\..\..\images\nefield.png" );
            XDocument doc = XDocument.Load( @".\..\..\..\testPlayer.xml" );
            MyPlayers = new List<Player>();
            int pl;

            for(pl = 0; pl < _game.TeamList.Teams.Count; pl++) 
            {
                if( _game.TeamList.Teams[pl].Name == _game.ChoosenTeam )
                {
                    myTeam = _game.TeamList.Teams[pl];
                    for(int j = 0; j < myTeam.TeamType.Count; j++)
                    {
                        Player newPlayer = myTeam.TeamType[j];
                        MyPlayers.Add( newPlayer );
                    }
                }
            }

            theone = _game.TeamList.Teams[8].TeamPlayers[8];

            //Position milieu de terrain pour le ballon visuellement.
            _playerPoints = new Point( 480, 400 );
            _ballPoints = new Point( 480, 350 );
            theball = new Points( ( float )_ballPoints.X, ( float )_ballPoints.Y );
            secondObjectif = new Points( 385, 450 );
            theone.FinalObjectif = secondObjectif;
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

                foreach( Player p in MyPlayers )
                {
                    if( p.GotTheBall == true )
                    {
                        _playerGotTheBall = p;
                        _gameBall.IsOwned = true;
                        _gameBall.PlayerOwner = p;
                        Points _nextGameBallPosition = _gameBall.NextPoint( _gameBall.PlayerOwner );
                        nextBallPoint = _nextGameBallPosition;
                        listBox1.Items.Add( "Game Ball Next Point = " + _nextGameBallPosition.X + ";" + _nextGameBallPosition.Y );
                        _ballPoints.X = ( int )_nextGameBallPosition.X;
                        _ballPoints.Y = ( int )_nextGameBallPosition.Y;
                        theball.X = ( float )_ballPoints.X;
                        theball.Y = ( float )_ballPoints.Y;
                        listBox1.Items.Add( "Diff X : " + _gameBall._diffX );
                        listBox1.Items.Add( "Diff Y : " + _gameBall._diffY );
                    }
                }

            intermediatePoint = theone.PointToObjectif( _gameBall.BallPosition, secondObjectif );

            listBox1.Items.Add( "Player : " + _playerPoints.X + "; " + _playerPoints.Y );
            listBox1.Items.Add( "Ballon : " + theball.X + "; " + theball.Y );
            listBox1.Items.Add( "Point intermediare : " + intermediatePoint.X + "; " + intermediatePoint.Y );
            listBox1.Items.Add( "Second Objectif : " + secondObjectif.X + "; " + secondObjectif.Y );

            if( intermediatePoint.X != 0 && intermediatePoint.Y != 0 )
            {
                i++;
                iBall++;
                if( i == 2 && count == 1 )
                    i = 0;
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
            _game.Graphic = e.Graphics;

            ballon = iBall + 1;
            ball = Image.FromFile( @".\..\..\..\images\ball" + ballon + ".png" );
            _gameBall = new Ball( theball, ball );

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
            listBox1.Items.Add( "Player Got the ball = " + theone.GotTheBall );
            theone.DrawPlayer( _game, player, _playerPoints, theone.PlayerPosition, _ballPoints, intermediatePoint, i, count );
            _gameBall.DrawTheBall( _game, ball, iBall, _ballPoints );
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
