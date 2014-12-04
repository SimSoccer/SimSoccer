using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sims.SimSoccerModel
{
    public class Formation
    {
        List<Player> _players;
        Tactic _owner;

        public List<Player> Player
        {
            get { return _players; }
        }

        public Tactic Owner
        {
            get { return _owner; }
        }

        public Formation(Tactic t, XElement e)
        {
            _owner = t;
            float.Parse(e.Attribute("AD").Value);
        }
    }
}