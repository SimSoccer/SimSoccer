using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims.SimSoccerModel
{
    public class Field
    {
        Size _size;
        Point _middleField;
        Size _goalKeeperField;


        public Field()
        {
            _size = new Size( 700, 1100 );
            _middleField = new Point( 350, 550 );
        }

        public Point MiddleField
        {
            get { return _middleField; }
        }

    }
}