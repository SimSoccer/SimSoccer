using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims.SimSoccerModel
{
    public class Tactic
    {
        List<Formation> _formation;

        public Tactic()
        {
            _formation = new List<Formation>();
        }

        public List<Formation> Formation { get; }
    }
}