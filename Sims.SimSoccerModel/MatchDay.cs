using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sims.SimSoccerModel
{
    public class MatchDay
    {
        int _number;
        DateTime _dayOfWeekEnd;
        List<Match> _matchs;
        List<Match> _matchsList;
        List<Match> day;
        
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

        public MatchDay( Calendar owner )
        {
            _owner = owner;
            _matchs = new List<Match>();
            List<Team> homeTeams = new List<Team>();
            List<Team> awayTeams = new List<Team>();
            List<int> numbers = new List<int>();
            Team team = new Team( _owner.Game.TeamList, "toto" );
            DateTime today = DateTime.Now;

            XDocument doc = XDocument.Load( @".\..\..\..\user_" + _owner.Game.UserName + "_save_" + today.Year + today.Month + today.Day + ".xml" );
            var home = doc.Element( "Game" ).Element( "Profil" ).Element( "Calendar" ).Element( "Days" )
                .Elements( "Day" ).Elements( "Meeting" ).Elements( "HomeTeam" )
                .Select( hT => new Team( _owner.Game.TeamList, hT, 1 ) );

            var away = doc.Element( "Game" ).Element( "Profil" ).Element( "Calendar" ).Element( "Days" )
                .Elements( "Day" ).Elements( "Meeting" ).Elements( "AwayTeam" )
                .Select( hT => new Team( _owner.Game.TeamList, hT, 1 ) );

            foreach( Team t in home )
            {
                foreach( Team tea in owner.Game.TeamList.Teams )
                {
                    if( tea.Name == t.Name )
                        team = tea;
                }
                homeTeams.Add( team );
            }

            foreach( Team t in away )
            {
                foreach( Team tea in owner.Game.TeamList.Teams )
                {
                    if( tea.Name == t.Name )
                        team = tea;
                }
                awayTeams.Add( team );
            }

            var matchDay = doc.Element( "Game" ).Element( "Profil" ).Element( "Calendar" ).Element( "Days" )
               .Elements( "Day" ).Attributes( "Number" );

            foreach( String s in matchDay )
            {
                //if( !numbers.Contains( int.Parse( s ) ) )
                    numbers.Add( int.Parse( s ) );
            }

            for( int i = 0; i <= 9; i++ )
            {
                _matchs.Add( new Match( homeTeams[i], awayTeams[i] ) );
            }
        }

        public MatchDay( Calendar owner, int numero, List<DateTime> dates )
        {
            _owner = owner;
            _matchsList = new List<Match>();
            _matchs = new List<Match>();
            List<Team> homeTeams = new List<Team>();
            List<Team> awayTeams = new List<Team>();
            List<int> numbers = new List<int>();
            Team team = new Team( _owner.Game.TeamList, "toto" );
            DateTime today = DateTime.Now;
            _number = numero;

            XDocument doc = XDocument.Load( @".\..\..\..\user_" + _owner.Game.UserName + "_save_" + today.Year + today.Month + today.Day + ".xml" );
            var home = doc.Element( "Game" ).Element( "Profil" ).Element( "Calendar" ).Element( "Days" )
                .Elements( "Day" ).Elements( "Meeting" ).Elements( "HomeTeam" )
                .Select( hT => new Team( _owner.Game.TeamList, hT, 1 ) );

            var away = doc.Element( "Game" ).Element( "Profil" ).Element( "Calendar" ).Element( "Days" )
                .Elements( "Day" ).Elements( "Meeting" ).Elements( "AwayTeam" )
                .Select( hT => new Team( _owner.Game.TeamList, hT, 1 ) );

            foreach( Team t in home )
            {
                foreach( Team tea in owner.Game.TeamList.Teams )
                {
                    if( tea.Name == t.Name )
                        team = tea;
                }
                homeTeams.Add( team );
            }

            foreach( Team t in away )
            {
                foreach( Team tea in owner.Game.TeamList.Teams )
                {
                    if( tea.Name == t.Name )
                        team = tea;
                }
                awayTeams.Add( team );
            }

            var matchDay = doc.Element( "Game" ).Element( "Profil" ).Element( "Calendar" ).Element( "Days" )
               .Elements( "Day" ).Attributes( "Number" );

            foreach( String s in matchDay )
            {
                //if( !numbers.Contains( int.Parse( s ) ) )
                numbers.Add( int.Parse( s ) );
            }


            day = new List<Match>();

            
            if( homeTeams.Count >= 10 && awayTeams.Count >= 10)
            {
                if( numero - 1 > 0 )
                {
                    int num = (numero - 1 ) * 10 ;
                    for( int j = 0; j < num; j++ )
                    {
                        homeTeams.Remove( homeTeams[0] );
                        awayTeams.Remove( awayTeams[0] );
                    }
                }
                for( int i = 0; i <= 9; i++ )
                {
                    _matchs.Add( new Match( homeTeams[0], awayTeams[0] ) );
                    homeTeams.Remove( homeTeams[0] );
                    awayTeams.Remove( awayTeams[0] );
                    _matchs[i].Hour = dates[0];
                    dates.Remove( dates[0] );
                }
            }
            else
            {
                for( int i = 0; i <= awayTeams.Count; i++ )
                {
                    _matchs.Add( new Match( homeTeams[numero - 1], awayTeams[numero - 1] ) );
                    _matchs[i].Hour = dates[0];
                    dates.Remove( dates[0] );
                }
            }
            
            AddToMatchList();
        }

        public void AddToMatchList()
        {
            foreach( Match m in day )
                _matchsList.Add( m );
        }

        public IReadOnlyList<Match> MatchList
        {
            get { return _matchsList; }
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

        public void playJourney()
        {
            for( int i = 0; i < this.Matchs.Count; i++ )
            {
                if( this.Matchs[i].Home.Name == _owner.Game.ChoosenTeam || this.Matchs[i].Outside.Name == _owner.Game.ChoosenTeam )
                {
                    this.Matchs[i].PlayMatch(true);
                    Console.WriteLine( this.Matchs[i].Result.TextSummary );
                
                } else {
                    this.Matchs[i].PlayMatch(false);
                    Console.WriteLine( this.Matchs[i].Result.TextSummary );
                }            
            }

            
        }

    }
}
