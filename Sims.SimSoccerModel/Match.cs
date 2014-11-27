using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims.SimSoccerModel
{
    public class Match
    {
        Team domicile_;
        Team exterieur_;
        DateTime horaire_;

        public Team Domicile
        {
            get { return domicile_; }
            set { domicile_ = value; }
        }

        public Team Exterieur
        {
            get { return exterieur_; }
            set { exterieur_ = value; }
        }

        public DateTime Horaire
        {
            get { return horaire_; }
            set { horaire_ = value; }
        }

        public Match(Team dom, Team ext)
        {
            domicile_ = dom;
            exterieur_ = ext;
            domicile_.Opponent.Add(exterieur_);
            exterieur_.Opponent.Add(domicile_);
        }

        public override string ToString()
        {
            return domicile_.TeamTag.ToString() + " - " + exterieur_.TeamTag.ToString() + " le " + horaire_.ToString();
        }
    }
}
