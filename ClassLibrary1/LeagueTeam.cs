using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawGame
{
    class Ligue
    {
        Calendrier _calendrier;
        List<Team> _equipes;

        public Calendrier Calendar
        {
            get { return _calendrier; }
        }

        public Ligue()
        {
            _equipes = new List<Team>();
        }

        public void fillCalendar()
        {
            Random r = new Random();
            _calendrier = new Calendrier(_equipes.Count);
            List<int> indicesEquipes = Enumerable.Range(0, 20).OrderBy(x => r.Next()).ToList();

            for (int i = 0; i < (_equipes.Count - 1) * 2; i++)
            {
                if (i < _equipes.Count - 1)
                {
                    _calendrier.Journees[i].Matchs = JourneeAller((i % 2 == 0), indicesEquipes);
                    indicesEquipes = permutations(indicesEquipes);
                }
                else
                    _calendrier.Journees[i].Matchs = JourneeRetour(i);
            }
        }

        public void CreateTeam(string nom)
        {
            Team equipe = new Team(nom);
            _equipes.Add(equipe);
        }

        public List<Match> JourneeAller(bool FirstDom, List<int> indicesEquipes)
        {
            List<Match> matchs = new List<Match>();

            if (FirstDom)
                matchs.Add(new Match(_equipes[indicesEquipes[0]], _equipes[indicesEquipes[_equipes.Count / 2]]));
            else
                matchs.Add(new Match(_equipes[indicesEquipes[_equipes.Count / 2]], _equipes[indicesEquipes[0]]));

            for (int i = 1; i < _equipes.Count / 2; i++)
                if (i % 2 != 0)
                    matchs.Add(new Match(_equipes[indicesEquipes[i + _equipes.Count / 2]], _equipes[indicesEquipes[i]]));
                else
                    matchs.Add(new Match(_equipes[indicesEquipes[i]], _equipes[indicesEquipes[i + _equipes.Count / 2]]));
            return matchs;
        }

        public List<int> permutations(List<int> indicesEquipes)
        {
            List<int> newIndices = new List<int>(_equipes.Count);

            for (int i = 0; i < indicesEquipes.Count; i++)
            {
                if (i == 0) newIndices.Add(indicesEquipes[i]);
                if (i == 1) newIndices.Add(indicesEquipes[_equipes.Count / 2]);
                if ((i > 1) && (i < (_equipes.Count / 2))) newIndices.Add(indicesEquipes[i - 1]);
                if ((i >= (_equipes.Count / 2)) && (i < (_equipes.Count - 1))) newIndices.Add(indicesEquipes[i + 1]);
                if (i == (_equipes.Count - 1)) newIndices.Add(indicesEquipes[i - (_equipes.Count / 2)]);
            }

            return newIndices;
        }

        public List<Match> JourneeRetour(int numJournee)
        {
            List<Match> matchs = new List<Match>();

            Journee journee = _calendrier.Journees[numJournee - (_equipes.Count - 1)];

            foreach (Match m in journee.Matchs)
                matchs.Add(new Match(m.Exterieur, m.Domicile));

            return matchs;
        }
    }
}
