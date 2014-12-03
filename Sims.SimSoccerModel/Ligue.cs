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
            List<int> indicesEquipes = Enumerable.Range(0, 20).OrderBy(x => r.Next()).ToList();

            for (int i = 0; i < (_game.TeamList.Teams.Count - 1) * 2; i++)
            {
                if (i < _game.TeamList.Teams.Count - 1)
                {
                    _calendar.Journees[i].Matchs = JourneeAller(r, (i % 2 == 0), indicesEquipes);
                    _calendar.Journees[i].initHoraires();
                    indicesEquipes = permutations(indicesEquipes);
                }
                else
                    _calendar.Journees[i].Matchs = JourneeRetour(i);
                _calendar.Journees[i].initHoraires();
            }
        }

        public List<Match> JourneeAller(Random r, bool FirstDom, List<int> indicesEquipes)
        {
            List<Match> matchs = new List<Match>();

            for (int i = 1; i < _game.TeamList.Teams.Count / 2; i++)
                if (i % 2 != 0)
                    matchs.Add(new Match(_game.TeamList.Teams[indicesEquipes[i + _game.TeamList.Teams.Count / 2]], _game.TeamList.Teams[indicesEquipes[i]]));
                else
                    matchs.Add(new Match(_game.TeamList.Teams[indicesEquipes[i]], _game.TeamList.Teams[indicesEquipes[i + _game.TeamList.Teams.Count / 2]]));

            if (FirstDom)
                matchs.Insert(r.Next(0, _game.TeamList.Teams.Count / 2), new Match(_game.TeamList.Teams[indicesEquipes[0]], _game.TeamList.Teams[indicesEquipes[_game.TeamList.Teams.Count / 2]]));
            else
                matchs.Insert(r.Next(0, _game.TeamList.Teams.Count / 2), new Match(_game.TeamList.Teams[indicesEquipes[_game.TeamList.Teams.Count / 2]], _game.TeamList.Teams[indicesEquipes[0]]));

            return matchs;
        }

        public List<int> permutations(List<int> indicesEquipes)
        {
            List<int> newIndices = new List<int>(_game.TeamList.Teams.Count);

            for (int i = 0; i < indicesEquipes.Count; i++)
            {
                if (i == 0) newIndices.Add(indicesEquipes[i]);
                if (i == 1) newIndices.Add(indicesEquipes[_game.TeamList.Teams.Count / 2]);
                if ((i > 1) && (i < (_game.TeamList.Teams.Count / 2))) newIndices.Add(indicesEquipes[i - 1]);
                if ((i >= (_game.TeamList.Teams.Count / 2)) && (i < (_game.TeamList.Teams.Count - 1))) newIndices.Add(indicesEquipes[i + 1]);
                if (i == (_game.TeamList.Teams.Count - 1)) newIndices.Add(indicesEquipes[i - (_game.TeamList.Teams.Count / 2)]);
            }

            return newIndices;
        }

        public List<Match> JourneeRetour(int numJournee)
        {
            List<Match> matchs = new List<Match>();

            Journee journee = _calendar.Journees[numJournee - (_game.TeamList.Teams.Count - 1)];

            foreach (Match m in journee.Matchs)
                matchs.Add(new Match(m.Exterieur, m.Domicile));

            return matchs;
        }
    }
}
