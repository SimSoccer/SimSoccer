using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims.SimSoccerModel
{
    class Match
    {
        Team domicile_;
        Team exterieur_;

        public Team Domicile
        {
            get { return domicile_; }
        }

        public Team Exterieur
        {
            get { return exterieur_; }
        }

        public Match( Team domicile, Team exterieur )
        {
            domicile_ = domicile;
            exterieur_ = exterieur;
        }

        public override string ToString()
        {
            return domicile_.ToString() + " - " + exterieur_.ToString();
        }
    }
}
