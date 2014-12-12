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
        float _ad;
        float _mo;
        float _dcd;
        float _dcg;
        float _dld;
        float _dlg;
        float _gb;
        float _ag;
        float _at;
        float _mdf;
        float _mc;
        float _mlg;
        float _mld;

        public Formation(XElement e)
        {
            _ad = float.Parse(e.Attribute("AD").Value);
            _mo = float.Parse(e.Attribute("MO").Value);
            _dcd = float.Parse(e.Attribute("DCD").Value);
            _dcg = float.Parse(e.Attribute("DCG").Value);
            _dlg = float.Parse(e.Attribute("DLG").Value);
            _dld = float.Parse(e.Attribute("DLD").Value);
            _gb = float.Parse(e.Attribute("GB").Value);
            _at = float.Parse(e.Attribute("AT").Value);
            _mdf = float.Parse(e.Attribute("MDF").Value);
            _mc = float.Parse(e.Attribute("MC").Value);
            _ag = float.Parse(e.Attribute("AG").Value);
            _mld = float.Parse(e.Attribute("MLD").Value);
            _mlg = float.Parse(e.Attribute("MLG").Value);
        }

    }
}