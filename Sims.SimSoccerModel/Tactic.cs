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
        List<Formation> _formation;
        Game _game;

        public Tactic(Game game, XElement e)
        {
            _formation = new List<Formation>();
            _formation = e.Elements("Tactic")
                .Select(eT => new Formation(this, eT))
                .ToList();
        }

        public Tactic(Game game)
        {
            _game = game;
            _formation = new List<Formation>();
        }

        public List<Formation> Formation { get; set; }
    }
}