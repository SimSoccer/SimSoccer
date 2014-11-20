using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawGame
{
    public class Journee
    {
        List<Journee> day;

        public Journee()
        {
            day = new List<Journee>();
        }

        public List<Journee> DayContent
        {
            get { return day; }
        }

        public int DayCount
        {
            get { return day.Count(); }
        }
    }
}
