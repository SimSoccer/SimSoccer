using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims.SimSoccerModel
{
    public class Journee
    {
        int numero_;
        DateTime dayOfWeekEnd_;
        List<Match> matchs_;
        Calendar _owner;

        public int Numero
        {
            get { return numero_; }
        }
        public Game game
        {
            get { return _owner.Ligue.Game; }
        }

        public List<Match> Matchs
        {
            get { return matchs_; }
            set { matchs_ = value; }
        }

        public Journee(int numero, DateTime dayOfWeekEnd, Calendar owner)
        {
            _owner = owner;
            numero_ = numero;
            dayOfWeekEnd_ = dayOfWeekEnd.AddDays(7 * (numero_ - 1));
        }

        public void initHoraires()
        {
            for (int i = 0; i < matchs_.Count - 3; i += 3)
                matchs_[i].Horaire = dayOfWeekEnd_.AddHours(14);

            for (int i = 1; i < matchs_.Count - 3; i += 3)
                matchs_[i].Horaire = dayOfWeekEnd_.AddHours(18);

            for (int i = 2; i < matchs_.Count - 3; i += 3)
                matchs_[i].Horaire = dayOfWeekEnd_.AddHours(20);

            matchs_[matchs_.Count - 3].Horaire = dayOfWeekEnd_.AddDays(1).AddHours(14);
            matchs_[matchs_.Count - 2].Horaire = dayOfWeekEnd_.AddDays(1).AddHours(18);
            matchs_[matchs_.Count - 1].Horaire = dayOfWeekEnd_.AddDays(1).AddHours(21);
        }

        public override String ToString()
        {
            return "Journee " + numero_;
        }
    }
}
