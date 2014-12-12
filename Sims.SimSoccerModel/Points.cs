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
        //public readonly 
            float _x;
        //public readonly 
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

        public double Distance( Points other )
        {
            return Math.Sqrt( Math.Pow( _x - other._x, 2 ) + Math.Pow( _y - other._y, 2 ) );
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
