using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims.SimSoccerModel
{
    public class Box
    {
        Field _field;
        int _x;
        int _y;
        Point _location;

        public Field Field
        {
            get { return _field; }
        }

        public Box( Field field, int x, int y )
        {
            _field = field;
            _x = x;
            _y = y;
        }

        public Point Location
        {
            get { return _location; }
        }
    }
}
