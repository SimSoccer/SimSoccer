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
    public struct Point
    {
        public readonly float _x;
        public readonly float _y;

        public Point( float x, float y )
        {
            _x = x;
            _y = y;
        }

        public Point Move( float deltaX, float deltaY )
        {
            return new Point(_x + deltaX, _y + deltaY);
        }

        public double Distance( Point other )
        {
            return Math.Sqrt( Math.Pow( _x - other._x, 2 ) + Math.Pow( _y - other._y, 2 ) );
        }
    }
}
