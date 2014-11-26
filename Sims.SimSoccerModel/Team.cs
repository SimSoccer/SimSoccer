using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sims.SimSoccerModel
{
    public class Team
    {
        readonly string _name;
        readonly TeamList _owner;
        List<Player> _players;
        readonly Game _game;
        string _teamTag;
        string _town;
        string _stadium;
        string _logo;
        string _manager;
        int _leagueRanking;
        int _level;
        string _playerName;
        
        internal Team( TeamList owner, string name )
        {
            _owner = owner;
            _name = name;
            _players = new List<Player>();
        }

        public TeamList TeamList
        {
            get { return _owner; }
        }

        public Game Game
        {
            get { return _owner.Game; }
        }

        public List<Player> TeamPlayers
        {
            get { return _players; }
            set { _players = value; }
        }

        public Team( TeamList owner, XElement e )
        {
            int i;
            int j;
            _players = new List<Player>();

            string tt = e.Element( "TeamTag" ).Value;
            _owner = owner;
            for( i = 0; i < _owner.Game.PlayerList.Players.Count; i++ )
            {
                if( _owner.Game.PlayerList.Players[i].ActualTeamTag == tt )
                {
                    _players.Add( _owner.Game.PlayerList.Players[i] );
                    for( j = 0; j < _players.Count; j++ )
                    {
                            _playerName = _players[j].Name;
                    }
                }
            }

            _owner = owner;
            _name = e.Attribute( "Name" ).Value;
            TeamTag = e.Element( "TeamTag" ).Value;
            Town = e.Element( "Town" ).Value;
            Stadium = e.Element( "Stadium" ).Value;
            Logo = e.Element( "Logo" ).Value;
            Manager = e.Element( "Manager" ).Value;
            LeagueRanking = int.Parse( e.Element( "LeagueRanking" ).Value );
            Level = int.Parse( e.Element( "Level" ).Value );
            TeamPlayers = _players;
        }

        public XElement ToXml( int id )
        {

            return new XElement( "Team",
                        new XAttribute( "Id", id ),
                        new XAttribute( "Name", Name ),
                        new XElement( "TeamTag", TeamTag ),
                        new XElement( "Town", Town ),
                        new XElement( "Stadium", Stadium ),
                        new XElement( "Logo", Logo ),
                        new XElement( "Manager", Manager ),
                        new XElement( "LeagueRanking", LeagueRanking ),
                        new XElement( "Level", Level ),
                        new XElement( "Players",
                            new XElement( "Player",
                                new XAttribute( "Name", PlayerName ) ) ) );
        }

        public string Name
        {
            get { return _name; }
        }

        public string TeamTag
        {
            get { return _teamTag; }
            set { _teamTag = value; }
        }

        public string Town
        {
            get { return _town; }
            set { _town = value; }
        }

        public string Stadium
        {
            get { return _stadium; }
            set { _stadium = value; }
        }

        public string Logo
        {
            get { return _logo; }
            set { _logo = value; }
        }

        public string Manager
        {
            get { return _manager; }
            set { _manager = value; }
        }

        public int LeagueRanking
        {
            get { return _leagueRanking; }
            set { _leagueRanking = value; }
        }

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public string PlayerName
        {
            get { return _playerName; }
            set { _playerName = value; }
        }

        
    }
}
