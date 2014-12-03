using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims.SimSoccerModel
{
    public struct Size
    {
        public readonly float Width;
        public readonly float Heigth;

        public Size( float w, float h )
        {
            if( w < 0 && h < 0 ) throw new InvalidOperationException( "" );
            Width = w;
            Heigth = h;
        }
    }
}
