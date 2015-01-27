using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sims.SimSoccerModel
{
    public class Ligue
    {
        Calendar _calendar;
        Game _game;
        int _year;

        public Calendar Calendar
        {
            get { return _calendar; }
        }

        public Ligue(Game game,int year)
        {
            _game = game;
            _year = year;
        }

        public Game Game
        {
            get { return _game; }
        }

        public void fillCalendar()
        {
            Random r = new Random();
            _calendar = new Calendar(_game.TeamList.Teams.Count, _year, this);
            List<int> indexTeams = Enumerable.Range(0, 20).OrderBy(x => r.Next()).ToList();

            for (int i = 0; i < (_game.TeamList.Teams.Count - 1) * 2; i++)
            {
                if (i < _game.TeamList.Teams.Count - 1)
                {
                    _calendar.MatchDay[i].Matchs = MatchDayGo(r, (i % 2 == 0), indexTeams);
                    _calendar.MatchDay[i].initHoraires();
                    foreach( Match m in _calendar.MatchDay[i].Matchs )
                    {
                        DateTime today = DateTime.Now;
                        XDocument doc = XDocument.Load( @".\..\..\..\user_" + _game.UserName + "_save_" + today.Year + today.Month + today.Day + ".xml" );
                        doc.Root.Element( "Profil" ).Element( "Calendar" ).Element( "Days" ).Add( new XElement( "Day" + _calendar.MatchDay[i].Numero, m.Home.TeamTag + " - " + m.Outside.TeamTag + " le " + m.Hour ) );
                        doc.Save( @".\..\..\..\user_" + _game.UserName + "_save_" + today.Year + today.Month + today.Day + ".xml" );
                    }
                    indexTeams = permutations(indexTeams);
                }
                else
                    _calendar.MatchDay[i].Matchs = MatchDayBack(i);
                _calendar.MatchDay[i].initHoraires();
                foreach( Match m in _calendar.MatchDay[i].Matchs )
                {
                    DateTime today = DateTime.Now;
                    XDocument doc = XDocument.Load( @".\..\..\..\user_" + _game.UserName + "_save_" + today.Year + today.Month + today.Day + ".xml" );
                    doc.Root.Element( "Profil" ).Element( "Calendar" ).Element( "Days" ).Add( new XElement( "Day" + _calendar.MatchDay[i].Numero, m.Home.TeamTag + " - " + m.Outside.TeamTag + " le " + m.Hour ) );
                    doc.Save( @".\..\..\..\user_" + _game.UserName + "_save_" + today.Year + today.Month + today.Day + ".xml" );
                }
            }
        }

        public List<Match> MatchDayGo(Random r, bool FirstHome, List<int> indexTeams)
        {
            List<Match> matchs = new List<Match>();

            for (int i = 1; i < _game.TeamList.Teams.Count / 2; i++)
                if (i % 2 != 0)
                    matchs.Add(new Match(_game.TeamList.Teams[indexTeams[i + _game.TeamList.Teams.Count / 2]], _game.TeamList.Teams[indexTeams[i]]));
                else
                    matchs.Add(new Match(_game.TeamList.Teams[indexTeams[i]], _game.TeamList.Teams[indexTeams[i + _game.TeamList.Teams.Count / 2]]));

            if (FirstHome)
                matchs.Insert(r.Next(0, _game.TeamList.Teams.Count / 2), new Match(_game.TeamList.Teams[indexTeams[0]], _game.TeamList.Teams[indexTeams[_game.TeamList.Teams.Count / 2]]));
            else
                matchs.Insert(r.Next(0, _game.TeamList.Teams.Count / 2), new Match(_game.TeamList.Teams[indexTeams[_game.TeamList.Teams.Count / 2]], _game.TeamList.Teams[indexTeams[0]]));

            return matchs;
        }

        public List<int> permutations(List<int> indexTeams)
        {
            List<int> newIndex = new List<int>(_game.TeamList.Teams.Count);

            for (int i = 0; i < indexTeams.Count; i++)
            {
                if (i == 0) newIndex.Add(indexTeams[i]);
                if (i == 1) newIndex.Add(indexTeams[_game.TeamList.Teams.Count / 2]);
                if ((i > 1) && (i < (_game.TeamList.Teams.Count / 2))) newIndex.Add(indexTeams[i - 1]);
                if ((i >= (_game.TeamList.Teams.Count / 2)) && (i < (_game.TeamList.Teams.Count - 1))) newIndex.Add(indexTeams[i + 1]);
                if (i == (_game.TeamList.Teams.Count - 1)) newIndex.Add(indexTeams[i - (_game.TeamList.Teams.Count / 2)]);
            }

            return newIndex;
        }

        public List<Match> MatchDayBack(int numMatchDay)
        {
            List<Match> matchs = new List<Match>();

            MatchDay matchDay = _calendar.MatchDay[numMatchDay - (_game.TeamList.Teams.Count - 1)];

            foreach (Match m in matchDay.Matchs)
                matchs.Add(new Match(m.Outside, m.Home));

            return matchs;
        }
    }
}