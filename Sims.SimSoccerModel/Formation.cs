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
        
        public Formation(FormationList fl, XElement e)
        {
           /* _name = e.Attribute("Formation").Value;

            e.Elements("Tactics").Elements("Tactic")
                                .Where(eT => eT.Attribute("Formation").Value == _name)
                                .Elements()
                                .Select(eT => new { n = eT.Name, Pos = eT.Value.Split(',') })
                                .Select(eT => new { N = eT.n, P = new Points(float.Parse(eT.Pos[0]), float.Parse(eT.Pos[1])) })
                                .ToDictionary(eT => eT.N, eT => eT.P);*/
        }
    }
}