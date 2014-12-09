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
        public float _xField;
        public float _yField;
        public float _x;
        public float _y;
        public Size _size;

        public Field Field
        {
            get { return _field; }
        }

        public Box( Field field, float xField, float yField, float x, float y )
        {
            _field = field;
            _yField = yField;
            _xField = xField;
            _x = x;
            _y = y;
            _size = new Size( 100, 100 );
        }

        public float Area
        {
            get { return this._size.Heigth * this._size.Width; }
        }
    }
}
