using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sims.SimSoccerModel
{
    public class Injury
    {
        string _duration;
        string _name;

        public Injury(string name, string duration)
        {
            _name = name;
            _duration = duration;
        }
        public string Duration { get; }
    }
}
