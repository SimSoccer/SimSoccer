using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims.SimSoccerModel
{
     public class Calendar
    {
            int nbEquipes_;
            List<Journee> journees_;

            public List<Journee> Journees
            {
                get { return journees_; }
            }

            public Calendar( int nbEquipes )
            {
                nbEquipes_ = nbEquipes;
                journees_ = new List<Journee>();

                for( int i = 1; i <= ( nbEquipes_ - 1 ) * 2; i++ )
                    journees_.Add( new Journee( i ) );
            }
    }
}
