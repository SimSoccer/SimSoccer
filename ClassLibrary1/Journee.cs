using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawGame
{
    class Journee
    {
        int _numero;
        List<Match> _matchs;

        public Journee(int numero)
        {
            _numero = numero;
        }

        public List<Match> Matchs
        {
            get { return _matchs; }
            set { _matchs = value; }
        }

        public override string ToString()
        {
            return "journee " + _numero.ToString();
        }
    }
}
