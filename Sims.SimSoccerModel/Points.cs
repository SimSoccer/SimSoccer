using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims.SimSoccerModel
{
    /// <summary>
    /// Coordinates are in meters
    /// </summary>
    public struct Points
    {
        float _x;
        float _y;

        public Points( float x, float y )
        {
            _x = x;
            _y = y;
        }

        public Points Move( float deltaX, float deltaY )
        {
            return new Points(_x + deltaX, _y + deltaY);
        }

        public Points PointToObjectif( Points objectif)
        {

            Points vector = new Points( ( objectif.X - this.X ), ( objectif.Y - this.Y - 50 ) );
            Points myNewPoint = new Points();

            if( vector.Y == 0 && vector.X < 0 )
            {
                myNewPoint.X = this.X -= 5;
                myNewPoint.Y = this.Y;
            }
            else if( vector.X > 0 && vector.Y == 0)
            {
                myNewPoint.Y = this.Y;
                myNewPoint.X = this.X += 5;
            }
            else if( vector.X < 0 && vector.Y == 0 )
            {
                myNewPoint.Y = this.Y;
                myNewPoint.X = this.X -= 5;
            }
            else if( vector.Y == 0 && vector.X > 0 )
            {
                myNewPoint.Y = this.Y += 5;
                myNewPoint.X = this.X;
            }
            else if( vector.X == 0 && vector.Y < 0 )
            {
                myNewPoint.Y = this.Y -= 5;
                myNewPoint.X = this.X;
            }
            else if( vector.X == 0 && vector.Y > 0 )
            {
                myNewPoint.Y = this.Y += 5;
                myNewPoint.X = this.X;
            }
            else if( vector.X == this.X && vector.Y < 0 )
            {
                myNewPoint.X = this.X += 0;
                myNewPoint.Y = this.Y -= 5;
            }
            else if( vector.Y < 0 && vector.X < 0 )
            {
                myNewPoint.X = this.X -= 5;
                myNewPoint.Y = this.Y -= 5;
            }
            else if( vector.Y < 0 && vector.X !=0 )
            {
                myNewPoint.Y = this.Y -= 5;
                myNewPoint.X = this.X += 5;
            }
            else if( vector.X < 0 && vector.Y != 0 )
            {
                myNewPoint.Y = this.Y += 5;
                myNewPoint.X = this.X -= 5;
            }
            else if( vector.X != 0 && vector.Y != 0 )
            {
                myNewPoint.X = this.X += 5;
                myNewPoint.Y = this.Y += 5;
            }
            return myNewPoint;
        }

        public double Distance( Points other )
        {
            return Math.Sqrt( Math.Pow( _x - other._x, 2 ) + Math.Pow( _y - other._y, 2 ) );
        }

        public Points Vector( Points other )
        {
            Points vector = new Points();
            vector.X = this.X + other.X;
            vector.Y = this.Y + other.Y;
            return vector;
        }

        public Points Difference( Points other )
        {
            Points vector = new Points();
            vector.X = other.X - this.X;
            vector.Y = other.Y - this.Y;
            return vector;
        }

        public double Lenght( Points other )
        {
            Points vector = this.Vector( other );
            return Math.Sqrt( Math.Pow( vector.X, 2)  + Math.Pow( vector.Y, 2) );
        }

        public float NormalisationX( Points other )
        {
            Points vector = this.Vector( other );
            double lenght = vector.Lenght( other );
            float normalizedX = vector.X / ( float )lenght;
            return normalizedX;
        }

        public float NormalisationY( Points other )
        {
            Points vector = this.Vector( other );
            double lenght = vector.Lenght( other );
            float normalizedY = vector.Y / ( float )lenght;
            return normalizedY;
        }

        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }
    }
}
