using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sims.SimSoccerModel
{
    public class Tactic
    {
        List<Formation> _formations;

        public List<Formation> Formation
        {
            get { return _formations; }
        }

        public Tactic()
        {
            _formations = new List<Formation>();
        }
    }
}