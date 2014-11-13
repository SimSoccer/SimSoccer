using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawGame
{
    public class Calendar
    {
        string _competition;
        string _place;
        Team[] oppenent;
        Team[] _teamPlayer;
        DateTime _date;
        DateTime _hour;

        public Calendar(Team teamPlayer)
        {
            _teamPlayer[0] = teamPlayer;
        }
        public void SeeCalendar()
        {
            /// program in progress...
        }
        public void OrganizeGame()
        {
            /// program in progress...
        }

        public string Competetion
        {
            get { return _competition; }
            set { _competition = value; }
        }

        public string Place
        {
            get { return _place; }
        }
        public DateTime Hour
        {
            get { return _hour; }
        }

        public DateTime Date
        {
            get { return _date; }
        }
    }
}