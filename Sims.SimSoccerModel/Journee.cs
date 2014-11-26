using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims.SimSoccerModel
{
    public class Journee
    {
        int numero_;
        List<Match> matchs_;

        public Journee( int numero )
        {
            numero_ = numero;
        }

        public List<Match> Matchs
        {
            get { return matchs_; }
            set { matchs_ = value; }
        }

        public override string ToString()
        {
            return "journee " + numero_.ToString();
        }
    }
}
