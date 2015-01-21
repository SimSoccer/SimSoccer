using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sims.SimSoccerModel
{
    public class Ball
    {
        Points _ballPosition;
        Field _fieldOwner;
        Rectangle _ballRectangle;
        Image _ballImage;
        int _ballCount;
        Game _game;
        bool _isOwned;
        Player _playerOwner;
        public float _diffX;
        public float _diffY;


        public Ball( Points point, Image ballImage )
        {
            _ballPosition = point;
            _ballImage = ballImage;
        }

        /// <summary>
        /// Draw the ball in the field
        /// </summary>
        /// <param name="game">The game to refer on</param>
        /// <param name="ballImage">Image file</param>
        /// <param name="countBall"></param>
        /// <param name="ballPosition">Actual ball Point</param>
        public void DrawTheBall( Game game, Image ballImage, int countBall, Point ballPosition )
        {
            _game = game;
            System.Drawing.Size ballSize = new System.Drawing.Size( 17, 17 );
            _ballRectangle = new Rectangle( ballPosition, ballSize );
            _ballCount = countBall + 1;
            ballImage = Image.FromFile( @".\..\..\..\images\ball" + _ballCount + ".png" );
            _ballImage = ballImage;
            _ballPosition = new Points((float)ballPosition.X, (float)ballPosition.Y);
            _game.Graphic.DrawImage( _ballImage, _ballRectangle );
        }

        /// <summary>
        /// Determinates next ball point.
        /// </summary>
        /// <param name="playerOwner">Player which have the ball</param>
        /// <returns>The new ball point.</returns>
        public Points NextPoint( Player playerOwner )
        {
            float ballX = this.BallPosition.X;
            float ballY = this.BallPosition.Y;

            float playerX = playerOwner.NextPosition.X;
            float playerY = playerOwner.NextPosition.Y;

            Points nextPoint = new Points();
            Points vector = new Points( ( playerOwner.FinalObjectif.X - ballX ), ( playerOwner.FinalObjectif.Y - ballY + 50) );

            if( playerOwner.FinalObjectif.X < ballX )
                _diffX = ballX - playerOwner.FinalObjectif.X;
            else if( playerOwner.FinalObjectif.X > ballX )
                _diffX = playerOwner.FinalObjectif.X - ballX;

            if( playerOwner.FinalObjectif.Y < ballY - 50 )
                _diffY = ( ballY - 50 ) - playerOwner.FinalObjectif.Y;
            else if( playerOwner.FinalObjectif.Y > ballY - 50 )
                _diffY = playerOwner.FinalObjectif.Y - ( ballY - 50 );

            #region Movement Management
            if(playerOwner.PlayerPosition.X == this.BallPosition.X - 10 && playerOwner.PlayerPosition.Y == this.BallPosition.Y - 50
                || playerOwner.PlayerPosition.X == this.BallPosition.X &&  this.BallPosition.Y == playerOwner.PlayerPosition.Y + 45
                || playerOwner.PlayerPosition.X == this.BallPosition.X && playerOwner.PlayerPosition.Y == this.BallPosition.Y - 50
                || playerOwner.PlayerPosition.X == this.BallPosition.X && playerOwner.PlayerPosition.Y == this.BallPosition.Y - 55)
            {
                if( vector.X > 0 && vector.Y > 0 && _diffY > 15 && _diffX > 25 )
                {
                    nextPoint.X = ballX += 25;
                    nextPoint.Y = ballY += 15;
                }
                else if( vector.X > 0 && vector.Y > 0 && _diffY <= 15 && _diffX > 25 )
                {
                    nextPoint.X = ballX += 25;
                    nextPoint.Y = ballY += _diffY;
                }
                else if( vector.X > 0 && vector.Y > 0 && _diffX <= 25 && _diffY > 15 )
                {
                    nextPoint.X = ballX += _diffX;
                    nextPoint.Y = ballY += 15;
                }
                else if( vector.X > 0 && vector.Y < 0 && _diffY > 15 && _diffX > 25 )
                {
                    nextPoint.X = ballX += 25;
                    nextPoint.Y = ballY -= 15;
                }
                else if( vector.X > 0 && vector.Y < 0 && _diffY <= 15 && _diffX > 25 )
                {
                    nextPoint.X = ballX += 25;
                    nextPoint.Y = ballY -= _diffY;
                }
                else if( vector.X > 0 && vector.Y < 0 && _diffX <= 25 && _diffY > 15 )
                {
                    nextPoint.X = ballX += _diffX;
                    nextPoint.Y = ballY -= 15;
                }
                else if( vector.X < 0 && vector.Y < 0 && _diffY > 15 && _diffX > 25 )
                {
                    nextPoint.X = ballX -= 25;
                    nextPoint.Y = ballY -= 15;
                }
                else if( vector.X < 0 && vector.Y < 0 && _diffX <= 25 && _diffY > 15 )
                {
                    nextPoint.X = ballX -= _diffX;
                    nextPoint.Y = ballY -= 15;
                }
                else if( vector.X < 0 && vector.Y < 0 && _diffY <= 15 && _diffX > 25 )
                {
                    nextPoint.X = ballX -= 25;
                    nextPoint.Y = ballY -= _diffY;
                }
                else if( vector.X < 0 && vector.Y > 0 && _diffY > 15 && _diffX > 25 )
                {
                    nextPoint.X = ballX -= 25;
                    nextPoint.Y = ballY += 15;
                }
                else if( vector.X < 0 && vector.Y > 0 && _diffX <= 25 && _diffY > 15 )
                {
                    nextPoint.X = ballX -= _diffX;
                    nextPoint.Y = ballY += 15;
                }
                else if( vector.X < 0 && vector.Y > 0 && _diffY <= 15 && _diffX > 25 )
                {
                    nextPoint.X = ballX -= 25;
                    nextPoint.Y = ballY += _diffY;
                }
                else if( vector.X == 0 && vector.Y < 0 && _diffY > 15 )
                {
                    nextPoint.X = ballX;
                    nextPoint.Y = ballY -= 15;
                }
                else if( vector.X == 0 && vector.Y < 0 && _diffY <= 15 )
                {
                    nextPoint.X = ballX;
                    nextPoint.Y = ballY -= _diffY;
                }
                else if( vector.X == 0 && vector.Y > 0 && _diffY > 15 )
                {
                    nextPoint.X = ballX;
                    nextPoint.Y = ballY += 15;
                }
                else if( vector.X == 0 && vector.Y > 0 && _diffY <= 15 )
                {
                    nextPoint.X = ballX;
                    nextPoint.Y = ballY += _diffY;
                }
                else if( vector.X > 0 && vector.Y == 0 && _diffX > 25 )
                {
                    nextPoint.X = ballX += 25;
                    nextPoint.Y = ballY;
                }
                else if( vector.X > 0 && vector.Y == 0 && _diffX <= 25 )
                {
                    nextPoint.X = ballX += _diffX;
                    nextPoint.Y = ballY;
                }
                else if( vector.X < 0 && vector.Y == 0 && _diffX > 25 )
                {
                    nextPoint.X = ballX -= 25;
                    nextPoint.Y = ballY;
                }
                else if( vector.X < 0 && vector.Y == 0 && _diffX <= 25 )
                {
                    nextPoint.X = ballX -= _diffX;
                    nextPoint.Y = ballY;
                }
                else
                    nextPoint = this.BallPosition;
            }/*
            else if( playerOwner.PlayerPosition.X == this._ballPosition.X && playerOwner.PlayerPosition.Y == this.BallPosition.Y - 50 )
            {
                if( vector.X > 0 && vector.Y > 0 && _diffY > 15 && _diffX > 25 )
                {
                    nextPoint.X = ballX += 25;
                    nextPoint.Y = ballY += 15;
                }
                else if( vector.X > 0 && vector.Y > 0 && _diffY <= 15 && _diffX > 25 )
                {
                    nextPoint.X = ballX += 25;
                    nextPoint.Y = ballY += _diffY;
                }
                else if( vector.X > 0 && vector.Y > 0 && _diffX <= 25 && _diffY > 15 )
                {
                    nextPoint.X = ballX += _diffX;
                    nextPoint.Y = ballY += 15;
                }
                else if( vector.X > 0 && vector.Y < 0 && _diffY > 15 && _diffX > 25 )
                {
                    nextPoint.X = ballX += 25;
                    nextPoint.Y = ballY -= 15;
                }
                else if( vector.X > 0 && vector.Y < 0 && _diffY <= 15 && _diffX > 25 )
                {
                    nextPoint.X = ballX += 25;
                    nextPoint.Y = ballY -= _diffY;
                }
                else if( vector.X > 0 && vector.Y < 0 && _diffX <= 25 && _diffY > 15 )
                {
                    nextPoint.X = ballX += _diffX;
                    nextPoint.Y = ballY -= 15;
                }
                else if( vector.X < 0 && vector.Y < 0 && _diffY > 15 && _diffX > 25 )
                {
                    nextPoint.X = ballX -= 25;
                    nextPoint.Y = ballY -= 15;
                }
                else if( vector.X < 0 && vector.Y < 0 && _diffX <= 25 && _diffY > 15 )
                {
                    nextPoint.X = ballX -= _diffX;
                    nextPoint.Y = ballY -= 15;
                }
                else if( vector.X < 0 && vector.Y < 0 && _diffY <= 15 && _diffX > 25 )
                {
                    nextPoint.X = ballX -= 25;
                    nextPoint.Y = ballY -= _diffY;
                }
                else if( vector.X < 0 && vector.Y > 0 && _diffY > 15 && _diffX > 25 )
                {
                    nextPoint.X = ballX -= 25;
                    nextPoint.Y = ballY += 15;
                }
                else if( vector.X < 0 && vector.Y > 0 && _diffX <= 25 && _diffY > 15 )
                {
                    nextPoint.X = ballX -= _diffX;
                    nextPoint.Y = ballY += 15;
                }
                else if( vector.X < 0 && vector.Y > 0 && _diffY <= 15 && _diffX > 25 )
                {
                    nextPoint.X = ballX -= 25;
                    nextPoint.Y = ballY += _diffY;
                }
                else if( vector.X == 0 && vector.Y < 0 && _diffY > 15 )
                {
                    nextPoint.X = ballX;
                    nextPoint.Y = ballY -= 15;
                }
                else if( vector.X == 0 && vector.Y < 0 && _diffY <= 15)
                {
                    nextPoint.X = ballX;
                    nextPoint.Y = ballY -= _diffY;
                }
                else if( vector.X == 0 && vector.Y > 0 && _diffY > 15 )
                {
                    nextPoint.X = ballX;
                    nextPoint.Y = ballY += 15;
                }
                else if( vector.X == 0 && vector.Y > 0 && _diffY <= 15 )
                {
                    nextPoint.X = ballX;
                    nextPoint.Y = ballY += _diffY;
                }
                else if( vector.X > 0 && vector.Y == 0 && _diffX > 25)
                {
                    nextPoint.X = ballX += 25;
                    nextPoint.Y = ballY;
                }
                else if( vector.X > 0 && vector.Y == 0 && _diffX <= 25)
                {
                    nextPoint.X = ballX += _diffX;
                    nextPoint.Y = ballY;
                }
                else if( vector.X < 0 && vector.Y == 0 && _diffX > 25 )
                {
                    nextPoint.X = ballX -= 25;
                    nextPoint.Y = ballY;
                }
                else if( vector.X < 0 && vector.Y == 0 && _diffX <= 25 )
                {
                    nextPoint.X = ballX -= _diffX;
                    nextPoint.Y = ballY;
                }
                else
                    nextPoint = this.BallPosition;
            }*/
            else
                nextPoint = this.BallPosition;

            #endregion

            return nextPoint;
        }

        public Image BallImage
        {
            get { return _ballImage; }
            set { _ballImage = value; }
        }

        public Points BallPosition
        {
            get { return _ballPosition; }
            set { _ballPosition = value; }
        }

        public bool IsOwned
        {
            get { return _isOwned; }
            set { _isOwned = value; }
        }

        public Player PlayerOwner
        {
            get { return _playerOwner; }
            set { _playerOwner = value; }
        }
    }
}