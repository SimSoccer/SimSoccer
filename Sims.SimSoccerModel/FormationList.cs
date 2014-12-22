using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sims.SimSoccerModel
{
    public class FormationList
    {
        readonly List<Formation> _formations;
        readonly Game _game;

        public FormationList(Game game)
        {
            _game = game;
            _formations = new List<Formation>();
        }

        public Game Game
        {
            get { return _game; }
        }
        public FormationList(Game game, XElement f)
        {
            _game = game;
            _formations = f.Elements("Tactic")
                .Select(eT => new Formation(game, this, eT))
                .ToList();
        }

        public IReadOnlyList<Formation> Formation
        {
            get { return _formations; }
        }

        public void RemoveFormation(Formation p)
        {
            int idx = _formations.IndexOf(p);
            if (idx < 0) throw new ArgumentException();
            _formations.RemoveAt(idx);
        }
    }
}