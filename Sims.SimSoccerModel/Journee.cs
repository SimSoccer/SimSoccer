﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims.SimSoccerModel
{
    public class Journee
    {
        int _numero;
        DateTime dayOfWeekEnd_;
        List<Match> _matchs;
        Game _game;
        Calendar _owner;

        public int Numero
        {
            get { return _numero; }
        }
        public Game game
        {
            get { return _game; }
        }

        public List<Match> Matchs
        {
            get { return _matchs; }
            set { _matchs = value; }
        }

        public Journee(int numero, DateTime dayOfWeekEnd, Calendar owner)
        {
            _game = owner.Game;
            _owner = owner;
            _numero = numero;
            dayOfWeekEnd_ = dayOfWeekEnd.AddDays(7 * (_numero - 1));
        }

        public void initHoraires()
        {
            for (int i = 0; i < _matchs.Count - 3; i += 3)
                _matchs[i].Horaire = dayOfWeekEnd_.AddHours(14);

            for (int i = 1; i < _matchs.Count - 3; i += 3)
                _matchs[i].Horaire = dayOfWeekEnd_.AddHours(18);

            for (int i = 2; i < _matchs.Count - 3; i += 3)
                _matchs[i].Horaire = dayOfWeekEnd_.AddHours(20);

            _matchs[_matchs.Count - 3].Horaire = dayOfWeekEnd_.AddDays(1).AddHours(14);
            _matchs[_matchs.Count - 2].Horaire = dayOfWeekEnd_.AddDays(1).AddHours(18);
            _matchs[_matchs.Count - 1].Horaire = dayOfWeekEnd_.AddDays(1).AddHours(21);
        }

        public override String ToString()
        {
            return "Journee " + _numero;
        }
    }
}
