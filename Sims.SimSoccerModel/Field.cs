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
        Points _middleField;
        List<Box> _boxes;
        List<Points> _boxPoints;
        List<Points> _allPoints;
        float _x;
        float _y;
        float _allX;
        float _allY;

        public Field()
        {
            _size = new Size( 1000, 600 );
            _middleField = new Points( 500, 300 );
            _boxes = new List<Box>();
            _boxPoints = new List<Points>();
            _allPoints = new List<Points>();


            
            for( _allX = 0; _allX < 1000; _allX++ )
            {
                for( _allY = 0; _allY < 600; _allY++ )
                {
                    Points allPoints = new Points( _allX, _allY );
                    _allPoints.Add( allPoints );
                }
            }

            _x = 0;
            _y = 0;

            Points boxPoints = new Points( _x, _y );
            for( _x = 0; _x < 10; _x++ )
            {
                boxPoints.X = _x * 100;
                for( _y = 0; _y < 6; _y++ )
                {
                    boxPoints.Y = _y * 100;
                    Box box = new Box( this, X, Y, boxPoints.X, boxPoints.Y );
                    _boxPoints.Add( boxPoints );
                    _boxes.Add( box );
                }
            }


        }

        public Points MiddleField
        {
            get { return _middleField; }
        }

        public List<Box> Boxes
        {
            get { return _boxes; }
        }

        public List<Points> BoxPoints
        {
            get { return _boxPoints; }
        }

        public List<Points> AllPoints
        {
            get { return _allPoints; }
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