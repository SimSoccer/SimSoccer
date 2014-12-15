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
        FormationList _formations;
        Game _game;

        public FormationList Formation
        {
            get { return _formations; }
        }

        public Tactic()
        {
            _formations = _game.FormationList;
        }

        public void MovePlayer(Player p, List<Player> currentlyList, List<Player> listWanted)
        {
            if (!currentlyList.Contains(p) || listWanted.Contains(p)) throw new InvalidOperationException();
            else
            {
                currentlyList.Remove(p);
                listWanted.Add(p);
            }
        }
    }
}