using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims.SimSoccerModel
{
    public class Match
    {
        Team _home;
        Team _outside;
        DateTime _hour;

        public Team Home
        {
            get { return _home; }
            set { _home = value; }
        }

        public Team Outside
        {
            get { return _outside; }
            set { _outside = value; }
        }

        public DateTime Hour
        {
            get { return _hour; }
            set { _hour = value; }
        }

        public Match(Team dom, Team ext)
        {
            _home = dom;
            _outside = ext;
            _home.Opponent.Add(_outside);
            _outside.Opponent.Add(_home);
        }

        public override string ToString()
        {
            return _home.TeamTag.ToString() + " - " + _outside.TeamTag.ToString() + " le " + _hour.ToString();
        }
    }
}
