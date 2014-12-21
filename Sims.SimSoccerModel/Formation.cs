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
        Game _game;
       
        Dictionary<XName, Points> positionPlayers;

        public Formation(FormationList fl, XElement f)
        {

            positionPlayers = new Dictionary<XName, Points>();
            f.Elements("Tactics").Elements("Tactic")
                                .Where(eT => eT.Attribute("Formation").Value == _game.TeamList.Teams[2].Formation)
                                .Elements()
                                .Select(eT => new { n = eT.Name, Pos = eT.Value.Split(',') })
                                .Select(eT => new { N = eT.n, P = new Points(float.Parse(eT.Pos[0]), float.Parse(eT.Pos[1])) })
                                .ToDictionary(eT => eT.N, eT => eT.P);


            
                /*foreach (Player p in _game.TeamList.Teams[2].TeamType)
                {
                    p.Position = positionPlayers[p.Poste];
                }*/

        }
    }
}