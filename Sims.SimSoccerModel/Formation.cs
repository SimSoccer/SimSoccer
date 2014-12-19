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
        #region Poste
        Points _ad;
        Points _bu;
        Points _mo;
        Points _mog;
        Points _mod;
        Points _mdfg;
        Points _mdfd;
        Points _atg;
        Points _atd;
        Points _dcd;
        Points _dcg;
        Points _dc;
        Points _dld;
        Points _dlg;
        Points _gb;
        Points _ag;
        Points _at;
        Points _mdf;
        Points _mc;
        Points _mcg;
        Points _mcd;
        Points _mlg;
        Points _mld;
        #endregion
        string _name;

        public string Name
        {
            get { return _name; }
        }

        public Points Bu
        {
            get { return _bu; }
        }
        public Points GB
        {
            get { return _gb; }
        }

        public Points DC
        {
            get { return _dc; }
        }

        public Points DCG
        {
            get { return _dcg; }
        }

        public Points DCD
        {
            get { return _dcd; }
        }

        public Points MO
        {
            get { return _mo; }
        }

        public Points MOD
        {
            get { return _mod; }
        }

        public Points MOG
        {
            get { return _mog; }
        }

        public Points DLD
        {
            get { return _dld; }
        }
        public Points DLG
        {
            get { return _dlg; }
        }
        public Points MC
        {
            get { return _mc; }
        }
        public Points MCG
        {
            get { return _mcg; }
        }
        public Points MCD
        {
            get { return _mcd; }
        }
        public Points MDF
        {
            get { return _mdf; }
        }
        public Points MDFG
        {
            get { return _mdfg; }
        }
        public Points MDFD
        {
            get { return _mdfd; }
        }
        public Points AG
        {
            get { return _ag; ; }
        }
        public Points AD
        {
            get { return _ad; }
        }
        public Points ATG
        {
            get { return _atg; }
        }
        public Points ATD
        {
            get { return _atd; }
        }
        public Points MLG
        {
            get { return _mlg; }
        }
        public Points MLD
        {
            get { return _mld; }
        }


        public Formation(FormationList fl, XElement e)
        {
            _name = e.Attribute("Formation").Value;

            e.Elements("Tactics").Elements("Tactic")
                                .Where(eT => eT.Attribute("Formation").Value == _name)
                                .Elements()
                                .Select(eT => new { n = eT.Name, Pos = eT.Value.Split(',') })
                                .Select(eT => new { N = eT.n, P = new Points(float.Parse(eT.Pos[0]), float.Parse(eT.Pos[1])) })
                                .ToDictionary(eT => eT.N, eT => eT.P);
        }
    }
}