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
        positionPlayer _at;
        positionPlayer _ad;
        positionPlayer _ag;
        positionPlayer _mo;
        positionPlayer _mdf;
        positionPlayer _gb;
        positionPlayer _dcg;
        positionPlayer _dcd;
        positionPlayer _dlg;
        positionPlayer _dld;
        positionPlayer _mc;
        positionPlayer _mlg;
        positionPlayer _mld;


        public List<Player> Players
        {
            get { return _players; }
        }

        public Formation(Tactic t, XElement e)
        {
            _owner = t;
            _ad = (float)e.Attribute("AD").Value;
        }
    }
}
