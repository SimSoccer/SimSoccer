using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims.SimSoccerModel
{
    public class positionPlayer
    {
        Point _position;
        public positionPlayer(Point p)
        {
            _position = p;
        }
        public Point Position { get; set; }
    }
}