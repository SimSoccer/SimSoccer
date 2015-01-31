using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sims.SimSoccerModel
{
    public class TeamList
    {
        readonly Game _game;
        readonly List<Team> _teams;

        public TeamList(Game game)
        {
            _game = game;
            _teams = new List<Team>();
        }

        public Game Game
        {
            get { return _game; }
        }

        public TeamList(Game game, XElement e)
        {
            _game = game;
            _teams = e.Elements("Team")
                .OrderBy(eT => int.Parse(eT.Attribute("Id").Value))
                .Select(eT => new Team(this, eT))
                .ToList();
        }

        public TeamList( Game game, XElement e, string s )
        {
            _game = game;
            _teams = e.Elements( "Team" )
                .OrderBy( eT => int.Parse( eT.Attribute( "Id" ).Value ) )
                .Select( eT => new Team( this, eT ) )
                .ToList();
        }

        public XElement ToXml()
        {
            return new XElement("Teams", _teams.Select((t, idx) => t.ToXml(idx)));
        }

        public IReadOnlyList<Team> Teams
        {
            get { return _teams; }
        }
        public void RemoveTeam(Team t)
        {
            int idx = _teams.IndexOf(t);
            if (idx < 0) throw new ArgumentException();
            _teams.RemoveAt(idx);
        }

        public Team CreateTeam(string uniqueName)
        {
            if (_teams.Any(t => t.Name == uniqueName)) throw new InvalidOperationException("Name must be unique!");
            var team = new Team(this, uniqueName);
            _teams.Add(team);
            return team;
        }
        public void AddTeamToList( Team t )
        {
            _teams.Add( t );
        }
    }
}