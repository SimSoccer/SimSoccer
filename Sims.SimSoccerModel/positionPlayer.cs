using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims.SimSoccerModel
{
    public class positionPlayer
    {
        Points _position;
        public positionPlayer(Points p)
        {
            _position = p;
        }
        public Points Position { get; set; }
    }
}