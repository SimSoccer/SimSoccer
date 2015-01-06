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


        public Ball( Points point, Image ballImage )
        {
            _ballPosition = point;
            _ballImage = ballImage;
        }

        /// <summary>
        /// Draw the ball in the field
        /// </summary>
        /// <param name="game"></param>
        /// <param name="ballImage"></param>
        /// <param name="countBall"></param>
        /// <param name="ballPosition"></param>
        public void DrawTheBall( Game game, Image ballImage, int countBall, Point ballPosition )
        {
            _game = game;
            System.Drawing.Size ballSize = new System.Drawing.Size( 17, 17 );
            _ballRectangle = new Rectangle( ballPosition, ballSize );
            _ballCount = countBall + 1;
            ballImage = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\ball" + _ballCount + ".png" );
            _ballImage = ballImage;
            _ballPosition = new Points((float)ballPosition.X, (float)ballPosition.Y);
            _game.Graphic.DrawImage( _ballImage, _ballRectangle );
        }

        public Points NextPoint( Player playerOwner )
        {
            float x = this.BallPosition.X;
            float y = this.BallPosition.Y;
            float playerX = playerOwner.NextPosition.X;
            float playerY = playerOwner.NextPosition.Y;
            Points nextPoint = new Points();
            Points vector = new Points( ( playerOwner.FinalObjectif.X - x ), ( playerOwner.FinalObjectif.Y - y + 50 ) );
            
            if( playerOwner.PlayerPosition.X == this._ballPosition.X && playerOwner.PlayerPosition.Y == this.BallPosition.Y - 50 )
            {
                if(vector.X > 0 && vector.Y > 0) 
                {
                    nextPoint.X += x + 25;
                    nextPoint.Y += y;
                }
            }
            else if( playerOwner.PlayerPosition.X == this._ballPosition.X - 20 && playerOwner.PlayerPosition.Y == this.BallPosition.Y - 50 )
            {

            }

            #region Movement Management
            /*
            if( vector.Y == 0 && vector.X < 0 )
            {
                nextPoint.X = playerX -= 25;
                nextPoint.Y = y;
            }
            else if( vector.X > 0 && vector.Y == 0 )
            {
                nextPoint.Y = y;
                nextPoint.X = playerX += 25;
            }
            else if( vector.X < 0 && vector.Y == 0 )
            {
                nextPoint.Y = y;
                nextPoint.X = playerX -= 25;
            }
            else if( vector.Y == 0 && vector.X > 0 )
            {
                nextPoint.Y = playerY += 50;
                nextPoint.X = x;
            }
            else if( vector.X == 0 && vector.Y < 0 )
            {
                nextPoint.Y = playerY -= 50;
                nextPoint.X = x;
            }
            else if( vector.X == 0 && vector.Y > 0 )
            {
                nextPoint.Y = playerY += 50;
                nextPoint.X = x;
            }
            else if( vector.X == x && vector.Y < 0 )
            {
                nextPoint.X = playerX += 0;
                nextPoint.Y = playerY -= 50;
            }
            else if( vector.Y < 0 && vector.X < 0 )
            {
                nextPoint.X = playerX -= 25;
                nextPoint.Y = playerY -= 50;
            }
            else if( vector.Y < 0 && vector.X != 0 )
            {
                nextPoint.Y = playerY -= 50;
                nextPoint.X = playerX += 25;
            }
            else if( vector.X < 0 && vector.Y != 0 )
            {
                nextPoint.Y = playerY += 50;
                nextPoint.X = playerX -= 25;
            }
            else if( vector.X != 0 && vector.Y != 0 )
            {
                nextPoint.X = playerX += 25;
                nextPoint.Y = playerY += 50;
            }
            */
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