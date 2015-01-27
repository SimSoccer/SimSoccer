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
        int _ballon;
        int count = 0;
        int _iBall = 0;
        Image _player;
        Image _ball;
        Points _theBall;
        Player _theOne;
        Image _field;
        Point _playerPoints;
        Point _ballPoints;
        Points _intermediatePoint;
        Points _secondObjectif;
        Points _nextBallPoint;
        List<Player> MyPlayers;
        Team _myTeam;
        Ball _gameBall;
        Player _playerGotTheBall;
        Random rndX = new Random();
        Random rndY = new Random();
        #endregion

        public SoccerSimulator()
        {
            InitializeComponent();

            docX = XDocument.Load( @".\..\..\..\user_guegue_save_2015127.xml" );
            _game = new Game(docX.Element("Game"), 1);

            _player = Image.FromFile(@".\..\..\..\images\PlayerOne.png");
            _field = Image.FromFile(@".\..\..\..\images\nefield.png");
            XDocument doc = XDocument.Load(@".\..\..\..\testPlayer.xml");
            MyPlayers = new List<Player>();
            int pl;

            for (pl = 0; pl < _game.TeamList.Teams.Count; pl++)
            {
                if (_game.TeamList.Teams[pl].Name == _game.ChoosenTeam)
                {
                    _myTeam = _game.TeamList.Teams[pl];
                    for (int j = 0; j < _myTeam.TeamType.Count; j++)
                    {
                        Player newPlayer = _myTeam.TeamType[j];
                        MyPlayers.Add(newPlayer);
                    }
                }
            }

            /// The player is on the field
            _theOne = _game.TeamList.Teams[8].TeamPlayers[8];

            ///Position milieu de terrain pour le ballon visuellement.
            _playerPoints = new Point( 480, 400 );
            _ballPoints = new Point( 480, 350 );
            _theBall = new Points((float)_ballPoints.X, (float)_ballPoints.Y);
            _secondObjectif = new Points( 385, 450 );
            _theOne.FinalObjectif = _secondObjectif;
        }

        private void SoccerSimulator_Load(object sender, EventArgs e)
        {
            t.Interval = 10;
            t.Tick += t_Tick;
            t.Start();
            this.DoubleBuffered = true;
        }

        void t_Tick(object sender, EventArgs e)
        {
            #region Manage Player With And Without The Ball
            count = 1;

           
                if( _theOne.GotTheBall == true )
                {
                    _playerGotTheBall = _theOne;
                    _gameBall.IsOwned = true;
                    _gameBall.PlayerOwner = _theOne;
                    Points _nextGameBallPosition = _gameBall.NextPoint(_gameBall.PlayerOwner);
                    _nextBallPoint = _nextGameBallPosition;
                    listBox1.Items.Add("Game Ball Next Point = " + _nextGameBallPosition.X + ";" + _nextGameBallPosition.Y);
                    _ballPoints.X = (int)_nextGameBallPosition.X;
                    _ballPoints.Y = (int)_nextGameBallPosition.Y;
                    _theBall.X = (float)_ballPoints.X;
                    _theBall.Y = (float)_ballPoints.Y;
                    listBox1.Items.Add("Diff X : " + _gameBall._diffX);
                    listBox1.Items.Add( "Diff Y : " + _gameBall._diffY );
                }
            

            _intermediatePoint = _theOne.PointToObjectif(_gameBall.BallPosition, _secondObjectif);

            listBox1.Items.Add("Player : " + _playerPoints.X + "; " + _playerPoints.Y);
            listBox1.Items.Add("Ballon : " + _theBall.X + "; " + _theBall.Y);
            listBox1.Items.Add("Point intermediare : " + _intermediatePoint.X + "; " + _intermediatePoint.Y);
            listBox1.Items.Add("Second Objectif : " + _secondObjectif.X + "; " + _secondObjectif.Y);

            if( _intermediatePoint.X != 0 && _intermediatePoint.Y != 0 )
            {
                i++;
                _iBall++;
                if( i == 2 && count == 1 )
                    i = 0;
                if( _iBall == 7 )
                    _iBall = 0;
                _playerPoints.X = (int)_intermediatePoint.X;
                _playerPoints.Y = (int)_intermediatePoint.Y;

            }

            _secondObjectif = new Points( rndX.Next( 0, 1000 ), rndY.Next( 0, 200 ) );            
            #endregion

            Invalidate();
        }

        private void SoccerSimulator_Paint(object sender, PaintEventArgs e)
        {
            _game.Graphic = e.Graphics;

            _ballon = _iBall + 1;
            _ball = Image.FromFile(@".\..\..\..\images\ball" + _ballon + ".png");
            _gameBall = new Ball(_theBall, _ball);

            #region Manage Drawn Field
            //Brushes the whole field in Green
            //Field f = new Field();
            _game.Graphic.FillRectangle(Brushes.DarkGreen, 0, 0, _game.Field.FieldSize.Width, _game.Field.FieldSize.Heigth);

            // Show the field's boxes.
            foreach (Box p in _game.Field.Boxes)
            {
                _game.Graphic.DrawRectangle(Pens.WhiteSmoke, p._x, p._y, p._size.Width, p._size.Heigth);
            }

            /*
            foreach( Points c in _game.Field.BoxCenterPoint )
            {
                _game.Graphic.DrawRectangle( Pens.WhiteSmoke, c.X, c.Y, 1, 1 );
            }*/

            // Draw the throw in lines and the behind goal lines.
            _game.Graphic.DrawLine(Pens.Red, _game.Field.Zones.ThrowIn1[0].X, _game.Field.Zones.ThrowIn1[0].Y, _game.Field.Zones.ThrowIn1[10].X, _game.Field.Zones.ThrowIn1[10].Y);
            _game.Graphic.DrawLine(Pens.Red, _game.Field.Zones.ThrowIn2[0].X, _game.Field.Zones.ThrowIn2[0].Y, _game.Field.Zones.ThrowIn2[10].X, _game.Field.Zones.ThrowIn2[10].Y);
            _game.Graphic.DrawLine(Pens.Red, _game.Field.Zones.BehingGoalLine1[0].X, _game.Field.Zones.BehingGoalLine1[0].Y, _game.Field.Zones.BehingGoalLine1[6].X, _game.Field.Zones.BehingGoalLine1[6].Y);
            _game.Graphic.DrawLine(Pens.Red, _game.Field.Zones.BehingGoalLine2[0].X, _game.Field.Zones.BehingGoalLine2[0].Y, _game.Field.Zones.BehingGoalLine2[6].X, _game.Field.Zones.BehingGoalLine2[6].Y);
            #endregion

            _theOne.Image = _player;
            listBox1.Items.Add("Player Got the ball = " + _theOne.GotTheBall);
            _theOne.DrawPlayer(_game, _player, _playerPoints, _theOne.PlayerPosition, _ballPoints, _intermediatePoint, i, count);
            _gameBall.DrawTheBall(_game, _ball, _iBall, _ballPoints);
        }
        private void SoccerSimulator_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void SoccerSimulator_Click(object sender, EventArgs e)
        {
            t.Stop();
        }
    }
}