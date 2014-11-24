using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims.SimSoccerModel
{
    class Ligue
    {
        Calendar calendrier_;
        List<Team> equipes_;

        public Calendar Calendar
        {
            get { return calendrier_; }
        }

        public Ligue()
        {
            equipes_ = new List<Team>();
        }

        public void fillCalendar()
        {
            Random r = new Random();
            calendrier_ = new Calendar( equipes_.Count );
            List<int> indicesEquipes = Enumerable.Range( 0, 20 ).OrderBy( x => r.Next() ).ToList();

            for( int i = 0; i < ( equipes_.Count - 1 ) * 2; i++ )
            {
                if( i < equipes_.Count - 1 )
                {
                    calendrier_.Journees[i].Matchs = JourneeAller( ( i % 2 == 0 ), indicesEquipes );
                    indicesEquipes = permutations( indicesEquipes );
                }
                else
                    calendrier_.Journees[i].Matchs = JourneeRetour( i );
            }
        }

        public void CreateTeam( string nom )
        {
            Team equipe = new Team( nom );
            equipes_.Add( equipe );
        }

        public List<Match> JourneeAller( bool FirstDom, List<int> indicesEquipes )
        {
            List<Match> matchs = new List<Match>();

            if( FirstDom )
                matchs.Add( new Match( equipes_[indicesEquipes[0]], equipes_[indicesEquipes[equipes_.Count / 2]] ) );
            else
                matchs.Add( new Match( equipes_[indicesEquipes[equipes_.Count / 2]], equipes_[indicesEquipes[0]] ) );

            for( int i = 1; i < equipes_.Count / 2; i++ )
                if( i % 2 != 0 )
                    matchs.Add( new Match( equipes_[indicesEquipes[i + equipes_.Count / 2]], equipes_[indicesEquipes[i]] ) );
                else
                    matchs.Add( new Match( equipes_[indicesEquipes[i]], equipes_[indicesEquipes[i + equipes_.Count / 2]] ) );
            return matchs;
        }

        public List<int> permutations( List<int> indicesEquipes )
        {
            List<int> newIndices = new List<int>( equipes_.Count );

            for( int i = 0; i < indicesEquipes.Count; i++ )
            {
                if( i == 0 ) newIndices.Add( indicesEquipes[i] );
                if( i == 1 ) newIndices.Add( indicesEquipes[equipes_.Count / 2] );
                if( ( i > 1 ) && ( i < ( equipes_.Count / 2 ) ) ) newIndices.Add( indicesEquipes[i - 1] );
                if( ( i >= ( equipes_.Count / 2 ) ) && ( i < ( equipes_.Count - 1 ) ) ) newIndices.Add( indicesEquipes[i + 1] );
                if( i == ( equipes_.Count - 1 ) ) newIndices.Add( indicesEquipes[i - ( equipes_.Count / 2 )] );
            }

            return newIndices;
        }

        public List<Match> JourneeRetour( int numJournee )
        {
            List<Match> matchs = new List<Match>();

            Journee journee = calendrier_.Journees[numJournee - ( equipes_.Count - 1 )];

            foreach( Match m in journee.Matchs )
                matchs.Add( new Match( m.Exterieur, m.Domicile ) );

            return matchs;
        }
    }
}
