using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sims.SimSoccerModel
{
    public class Calendar
    {
        int _nbTeams;
        List<MatchDay> _matchDay;
        readonly Game _game;
        Ligue _owner;

        public List<MatchDay> MatchDay
        {
            get { return _matchDay; }
        }


        public Calendar(int nbEquipes, int year, Ligue owner)
        {
            _game = owner.Game;
            _owner = owner;
            _nbTeams = nbEquipes;
            _matchDay = new List<MatchDay>();
            DateTime dt = new DateTime(year, 8, 7);
            DateTime Saturday = dt;

            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Saturday: Saturday = dt;
                    break;
                case DayOfWeek.Sunday: Saturday = dt.AddDays(-1);
                    break;
                case DayOfWeek.Friday: Saturday = dt.AddDays(1);
                    break;
                case DayOfWeek.Tuesday: Saturday = dt.AddDays(4);
                    break;
                case DayOfWeek.Wednesday: Saturday = dt.AddDays(3);
                    break;
                case DayOfWeek.Thursday: Saturday = dt.AddDays(2);
                    break;
                case DayOfWeek.Monday: Saturday = dt.AddDays(5);
                    break;
            }

            for (int i = 1; i <= (_nbTeams - 1) * 2; i++)
                _matchDay.Add(new MatchDay(i, Saturday, this));

        }

        public Calendar( int nbEquipes, Ligue owner, XElement e, int year )
        {
            _game = owner.Game;
            _owner = owner;
            _nbTeams = nbEquipes;
            _matchDay = new List<MatchDay>();
            List<DateTime> dates = new List<DateTime>();

            var datesString = e.Element( "Days" ).Elements( "Day" ).Attributes( "Date" ).ToList();
            foreach( String s in datesString )
            {
                dates.Add( DateTime.Parse( s ) );
            }

            DateTime dt = new DateTime( year, 8, 7 );

            for( int i = 1; i <= ( _nbTeams - 1 ) * 2; i++ )
                _matchDay.Add( new MatchDay( this, i, dates ) );
        }

        public void CheckCalendar()
        {
            _matchDay.Add( new MatchDay( this ) );
        }

        public Game Game
        {
            get { return _owner.Game; }
        }

        public Ligue Ligue
        {
            get { return _owner; }
        }
    }
}
