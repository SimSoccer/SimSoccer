﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims.SimSoccerModel
{
    public class Calendar
    {
        int _nbTeams;
        List<MatchDay> _matchDay;
        Ligue _owner;

        public List<MatchDay> MatchDay
        {
            get { return _matchDay; }
        }


        public Calendar(int nbEquipes, int year, Ligue owner)
        {
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
