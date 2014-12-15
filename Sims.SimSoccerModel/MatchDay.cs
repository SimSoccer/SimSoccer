using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims.SimSoccerModel
{
    public class MatchDay
    {
        int _number;
        DateTime _dayOfWeekEnd;
        List<Match> _matchs;
        Calendar _owner;

        public int Numero
        {
            get { return _number; }
        }
        public Game game
        {
            get { return _owner.Ligue.Game; }
        }

        public List<Match> Matchs
        {
            get { return _matchs; }
            set { _matchs = value; }
        }

        public MatchDay(int numero, DateTime dayOfWeekEnd, Calendar owner)
        {
            _owner = owner;
            _number = numero;
            _dayOfWeekEnd = dayOfWeekEnd.AddDays(7 * (_number - 1));
        }

        public void initHoraires()
        {
            for (int i = 0; i < _matchs.Count - 3; i += 3)
                _matchs[i].Hour = _dayOfWeekEnd.AddHours(14);

            for (int i = 1; i < _matchs.Count - 3; i += 3)
                _matchs[i].Hour = _dayOfWeekEnd.AddHours(18);

            for (int i = 2; i < _matchs.Count - 3; i += 3)
                _matchs[i].Hour = _dayOfWeekEnd.AddHours(20);

            _matchs[_matchs.Count - 3].Hour = _dayOfWeekEnd.AddDays(1).AddHours(14);
            _matchs[_matchs.Count - 2].Hour = _dayOfWeekEnd.AddDays(1).AddHours(18);
            _matchs[_matchs.Count - 1].Hour = _dayOfWeekEnd.AddDays(1).AddHours(21);
        }

        public override String ToString()
        {
            return "Journee " + _number;
        }
    }
}
