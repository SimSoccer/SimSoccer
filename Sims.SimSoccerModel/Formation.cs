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
        Point _ad;
        Point _mo;
        Point _dcd;
        Point _dcg;
        Point _dld;
        Point _dlg;
        Point _gb;
        Point _ag;
        Point _at;
        Point _mdf;
        Point _mc;
        Point _mlg;
        Point _mld;

        public Formation(XElement e)
        {
            _ad = Point.Parse(e.Attribute("AD").Value);
            _mo = Point.Parse(e.Attribute("MO").Value);
            _dcd = Point.Parse(e.Attribute("DCD").Value);
            _dcg = Point.Parse(e.Attribute("DCG").Value);
            _dlg = Point.Parse(e.Attribute("DLG").Value);
            _dld = Point.Parse(e.Attribute("DLD").Value);
            _gb = Point.Parse(e.Attribute("GB").Value);
            _at = Point.Parse(e.Attribute("AT").Value);
            _mdf = Point.Parse(e.Attribute("MDF").Value);
            _mc = Point.Parse(e.Attribute("MC").Value);
            _ag = Point.Parse(e.Attribute("AG").Value);
            _mld = Point.Parse(e.Attribute("MLD").Value);
            _mlg = Point.Parse(e.Attribute("MLG").Value);
        }

    }
}