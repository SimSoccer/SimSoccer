using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawGame
{
    class Team
    {
        String _nom;

        public String Nom
        {
            get { return _nom; }
        }

        public Team(String nom)
        {
            _nom = nom;
        }

        public override string ToString()
        {
            return _nom;
        }
    }
}
