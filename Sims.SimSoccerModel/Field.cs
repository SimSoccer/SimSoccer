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
        Size _goalKeeperField;


        public Field()
        {
            _size = new Size( 70, 110 );
            _middleField = new Point( 35, 55 );
        }

        public Point MiddleField
        {
            get { return _middleField; }
        }

    }
}