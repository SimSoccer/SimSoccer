﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sims.SimSoccerModel
{
    public class Ligue
    {
        Calendar calendrier_;
        TeamList _tl;
        Game _game = new Game();

        public Calendar Calendar
        {
            get { return calendrier_; }
        }

        public Ligue()
        {
            _tl = new TeamList(_game);
        }

        public void fillCalendar()
        {
            Random r = new Random();
            calendrier_ = new Calendar(_tl.Teams.Count);
            List<int> indicesEquipes = Enumerable.Range(0, 20).OrderBy(x => r.Next()).ToList();

            for (int i = 0; i < (_tl.Teams.Count - 1) * 2; i++)
            {
                if (i < _tl.Teams.Count - 1)
                {
                    calendrier_.Journees[i].Matchs = JourneeAller((i % 2 == 0), indicesEquipes);
                    indicesEquipes = permutations(indicesEquipes);
                }
                else
                    calendrier_.Journees[i].Matchs = JourneeRetour(i);
            }
        }

        public void CreateTeam()
        {
            XDocument doc = XDocument.Load(@".\..\..\..\Ligue1Teams.xml");
            _tl = new TeamList(_game, doc.Root.Element("Teams"));
        }

        public List<Match> JourneeAller(bool FirstDom, List<int> indicesEquipes)
        {
            List<Match> matchs = new List<Match>();

            if (FirstDom)
                matchs.Add(new Match(_tl.Teams[indicesEquipes[0]], _tl.Teams[indicesEquipes[_tl.Teams.Count / 2]]));
            else
                matchs.Add(new Match(_tl.Teams[indicesEquipes[_tl.Teams.Count / 2]], _tl.Teams[indicesEquipes[0]]));

            for (int i = 1; i < _tl.Teams.Count / 2; i++)
                if (i % 2 != 0)
                    matchs.Add(new Match(_tl.Teams[indicesEquipes[i + _tl.Teams.Count / 2]], _tl.Teams[indicesEquipes[i]]));
                else
                    matchs.Add(new Match(_tl.Teams[indicesEquipes[i]], _tl.Teams[indicesEquipes[i + _tl.Teams.Count / 2]]));
            return matchs;
        }

        public List<int> permutations(List<int> indicesEquipes)
        {
            List<int> newIndices = new List<int>(_tl.Teams.Count);

            for (int i = 0; i < indicesEquipes.Count; i++)
            {
                if (i == 0) newIndices.Add(indicesEquipes[i]);
                if (i == 1) newIndices.Add(indicesEquipes[_tl.Teams.Count / 2]);
                if ((i > 1) && (i < (_tl.Teams.Count / 2))) newIndices.Add(indicesEquipes[i - 1]);
                if ((i >= (_tl.Teams.Count / 2)) && (i < (_tl.Teams.Count - 1))) newIndices.Add(indicesEquipes[i + 1]);
                if (i == (_tl.Teams.Count - 1)) newIndices.Add(indicesEquipes[i - (_tl.Teams.Count / 2)]);
            }

            return newIndices;
        }

        public List<Match> JourneeRetour(int numJournee)
        {
            List<Match> matchs = new List<Match>();

            Journee journee = calendrier_.Journees[numJournee - (_tl.Teams.Count - 1)];

            foreach (Match m in journee.Matchs)
                matchs.Add(new Match(m.Exterieur, m.Domicile));

            return matchs;
        }
    }
}
