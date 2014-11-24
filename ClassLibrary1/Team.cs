using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawGame
{
    class Team
    {
        String nom_;

        public String Nom
        {
            get { return nom_; }
        }

        public Team(String nom)
        {
            nom_ = nom;
        }

        public override string ToString()
        {
            return nom_;
        }
    }
}
