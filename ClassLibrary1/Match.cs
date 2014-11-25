using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawGame
{
    class Match
    {
        Team _domicile;
        Team _exterieur;

        public Team Domicile
        {
            get { return _domicile; }
        }

        public Team Exterieur
        {
            get { return _exterieur; }
        }

        public Match(Team domicile, Team exterieur)
        {
            _domicile = domicile;
            _exterieur = exterieur;
        }

        public override string ToString()
        {
            return _domicile.ToString() + " - " + _exterieur.ToString();
        }
    }
}
