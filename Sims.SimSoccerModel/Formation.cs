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
        Points _ad;
        Points _mo;
        Points _dcd;
        Points _dcg;
        Points _dld;
        Points _dlg;
        Points _gb;
        Points _ag;
        Points _at;
        Points _mdf;
        Points _mc;
        Points _mlg;
        Points _mld;
        string _name;

        public Formation(FormationList fl, XElement e)
        {
            _name = e.Attribute("Formation").Value;
            _at = new Points (float.Parse(e.Element("ATX").Value), float.Parse(e.Element("ATY").Value));
            _ad = new Points(float.Parse(e.Element("ADX").Value), float.Parse(e.Element("ADY").Value));
            _ag = new Points(float.Parse(e.Element("AGX").Value), float.Parse(e.Element("AGY").Value));
            _mc = new Points(float.Parse(e.Element("MCX").Value), float.Parse(e.Element("MCY").Value));
            _mdf = new Points(float.Parse(e.Element("MDFX").Value), float.Parse(e.Element("MDFY").Value));
            _gb = new Points(float.Parse(e.Element("GBX").Value), float.Parse(e.Element("GBY").Value));
            _dlg = new Points(float.Parse(e.Element("LGX").Value), float.Parse(e.Element("LGY").Value));
            _dld = new Points(float.Parse(e.Element("LDX").Value), float.Parse(e.Element("LDY").Value));
            _mo = new Points(float.Parse(e.Element("MOX").Value), float.Parse(e.Element("MOY").Value));
            _mlg = new Points(float.Parse(e.Element("MLGX").Value), float.Parse(e.Element("MLGY").Value));
            _mld = new Points(float.Parse(e.Element("MLDX").Value), float.Parse(e.Element("MLDY").Value));
        }

        public Points AT
        {
            get { return _at; }
            set { _at = value; }
        }

        public Points AD
        {
            get { return _ad; }
            set { _ad = value; }
        }

        public Points AG
        {
            get { return _ag; }
            set { _ag = value; }
        }
        public Points MC
        {
            get { return _mc; }
            set { _mc = value; }
        }
        public Points MDF
        {
            get { return _mdf; }
            set { _mdf = value; }
        }
        public Points GB
        {
            get { return _gb; }
            set { _gb = value; }
        }
        public Points MLG
        {
            get { return _mlg; }
            set { _mlg = value; }
        }
        public Points MLD
        {
            get { return _mld; }
            set { _mld = value; }
        }

        public Points DG
        {
            get { return _dlg; }
            set { _dlg = value; }
        }
        public Points DD
        {
            get { return _dld; }
            set { _dld = value; }
        }

        public Points DCG
        {
            get { return _dcg; }
            set { _dcg = value; }
        }

        public Points DCD
        {
            get { return _dcd; }
            set { _dcd = value; }
        }

        public Points MO
        {
            get { return _mo; }
            set { _mo = value; }
        }

        public string Name
        {
            get { return _name; }
        }
    }
}