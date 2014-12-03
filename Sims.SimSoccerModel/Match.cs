using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims.SimSoccerModel
{
    public class Match
    {
        Team domicile_;
        Team exterieur_;
        DateTime horaire_;
        readonly Game _game;

        public Game Game
        {
            get { return _game; }
        }
        
        public Team Domicile
        {
            get { return domicile_; }
            set { domicile_ = value; }
        }

        public Team Exterieur
        {
            get { return exterieur_; }
            set { exterieur_ = value; }
        }

        public DateTime Horaire
        {
            get { return horaire_; }
            set { horaire_ = value; }
        }

        public Match(Team dom, Team ext, Game game)
        {
            _game = game;
            domicile_ = dom;
            exterieur_ = ext;
            domicile_.Opponent.Add(exterieur_);
            exterieur_.Opponent.Add(domicile_);
        }

        public override string ToString()
        {
            return domicile_.TeamTag.ToString() + " - " + exterieur_.TeamTag.ToString() + " le " + horaire_.ToString();
        }

        public string PlayMatch(Team Home, Team Ext)
        {
            Random rnd = new Random();

            int tmp = Home.Level + Ext.Level;
            int winRateH = (Home.Level / tmp) * 100;
            int winRateE = 100 - winRateH;

            int draw = rnd.Next(0, 100);
            if(draw < winRateH)
            {
                Console.WriteLine("the winner is"+ Home.Name);
                return Home.Name;

            } 
            else if(draw > winRateH)
            {
                Console.WriteLine("The winne is"+ Ext.Name);
                return Ext.Name;
            
            }else {
                Console.WriteLine("It's a Tie");
                return "it's a Tie";
            }          
        }
    }
}
