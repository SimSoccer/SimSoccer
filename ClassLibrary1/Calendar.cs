using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawGame
{
    class Calendrier
    {
        int _nbEquipes;
        List<Journee> _journees;

        public List<Journee> Journees
        {
            get { return _journees; }
        }

        public Calendrier(int nbEquipes)
        {
            _nbEquipes = nbEquipes;
            _journees = new List<Journee>();

            for (int i = 1; i <= (_nbEquipes - 1) * 2; i++)
                _journees.Add(new Journee(i));
        }
    }
}