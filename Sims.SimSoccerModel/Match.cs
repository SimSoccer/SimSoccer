using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims.SimSoccerModel
{
    public class Match
    {
        Team _domicile;
        Team _exterieur;
        DateTime _horaire;

        public Team Domicile
        {
            get { return _domicile; }
            set { _domicile = value; }
        }

        public Team Exterieur
        {
            get { return _exterieur; }
            set { _exterieur = value; }
        }

        public DateTime Horaire
        {
            get { return _horaire; }
            set { _horaire = value; }
        }

        public Match(Team dom, Team ext)
        {
            _domicile = dom;
            _exterieur = ext;
            _domicile.Opponent.Add(_exterieur);
            _exterieur.Opponent.Add(_domicile);
        }

        public override string ToString()
        {
            return _domicile.TeamTag.ToString() + " - " + _exterieur.TeamTag.ToString() + " le " + _horaire.ToString();
        }
    }
}
