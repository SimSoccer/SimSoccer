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
        List<Box> _boxes;
        List<Point> _points;
        int _x;
        int _y;

        public Field()
        {
            _size = new Size( 1200, 800 );
            _middleField = new Point( 600, 400 );
            _boxes = new List<Box>();
            _points = new List<Point>();

            /*for( int i = 0; i < 96; i++ )
            {
                Box box = new Box( this, 100, 100 );
                _boxes.Add( box );
            }*/

            int resultX;
            int resultY;
            _x = 0;
            _y = 0;

            Point point = new Point( _x, _y );
            for( _x = 0; _x < 12; _x++ )
            {
                point.X = _x * 100;
                for( _y = 0; _y < 8; _y++ )
                {
                    point.Y = _y * 100;
                    Box box = new Box( this, X, Y, point.X, point.Y );
                    _points.Add( point );
                    _boxes.Add( box );
                }
            }
        }

        public Point MiddleField
        {
            get { return _middleField; }
        }

        public List<Box> Boxes
        {
            get { return _boxes; }
        }

        public List<Point> Points
        {
            get { return _points; }
        }

        public float X
        {
            get { return this.FieldSize.Width; }
        }

        public float Y
        {
            get { return this.FieldSize.Heigth; }
        }

        public Size FieldSize
        {
            get { return _size; }
        }
    }
}