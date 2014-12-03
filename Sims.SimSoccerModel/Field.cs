using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims.SimSoccerModel
{
    class Field
    {
        Size _size;
        Point _middleField;

        public Field()
        {
            _size = new Size( 68, 105 );
            _middleField = new Point( 34, 52 );
        }

        public Point MiddleField
        {
            get { return _middleField; }
        }

    }
}