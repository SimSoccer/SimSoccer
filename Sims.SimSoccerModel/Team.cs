using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sims.SimSoccerModel
{
    public class Team
    {
        #region attribute
        readonly string _name;
        readonly TeamList _owner;
        List<Player> _players;
        string _teamTag;
        string _town;
        string _stadium;
        string _logo;
        string _manager;
        int _leagueRanking;
        int _level;
        string _playerName;
        string _formation;
        int _leaguePoints;
        List<Team> _opponent;
        List<Player> _teamType;
        List<Player> _remplacents;
        List<Player> _reservist;
        readonly Game _game;
        int _id;
        int _budget;
        #endregion

        #region contructor
        internal Team(TeamList owner, string name)
        {
            _game = owner.Game;
            _owner = owner;
            _name = name;
            _players = new List<Player>();
            _opponent = new List<Team>();
            _teamType = new List<Player>();
            _remplacents = new List<Player>();
            _reservist = new List<Player>();

        }
        #endregion

        public List<Team> Opponent
        {
            get { return _opponent; }
        }

        public List<Player> TeamType
        {
            get { return _teamType; }
            set { _teamType = value; }
        }

        public String Formation
        {
            get { return _formation; }
            set { _formation = value; }
        }
        public List<Player> Remplacent
        {
            get { return _remplacents; }
            set { _remplacents = value; }
        }
        public Game Game
        {
            get { return _game; }
        }
        public List<Player> Reserve
        {
            get { return _reservist; }
            set { _reservist = value; }
        }

        public TeamList TeamList
        {
            get { return _owner; }
        }

        public List<Player> TeamPlayers
        {
            get { return _players; }
            set { _players = value; }
        }

             public Team(TeamList owner, XElement e)
        {
            _game = owner.Game;
            int i;
            int j;
            _players = new List<Player>();
            _opponent = new List<Team>();
            _teamType = new List<Player>();
            _remplacents = new List<Player>();
            _reservist = new List<Player>();
            _owner = owner;
            _leaguePoints = int.Parse(e.Element("Points").Value);
            string tt = e.Element("TeamTag").Value;
            _formation = e.Element("Formation").Value;


            /// Incumbant the players holder in a team and in its global player list
            for (i = 0; i < _game.PlayerList.Players.Count; i++)
            {
                if (_game.PlayerList.Players[i].ActualTeamTag == tt && _game.PlayerList.Players[i].Status == "Titulaire")
                {
                    if (_teamType.Count < 0 || _teamType.Count > 11) throw new IndexOutOfRangeException();
                    if (_players.Count < 0) throw new IndexOutOfRangeException();

                    _players.Add(_owner.Game.PlayerList.Players[i]);
                    _teamType.Add(_owner.Game.PlayerList.Players[i]);

                    for (j = 0; j < _players.Count; j++)
                    {
                        _playerName = _players[j].Name;
                    }
                }

                /// Incumbant the players remplacents in a team and in its global player list
                if (_owner.Game.PlayerList.Players[i].ActualTeamTag == tt && _owner.Game.PlayerList.Players[i].Status == "Remplacent")
                {
                    if (_remplacents.Count < 0 || _remplacents.Count > 7) throw new IndexOutOfRangeException();
                    if (_players.Count < 0) throw new IndexOutOfRangeException();

                    _players.Add(_owner.Game.PlayerList.Players[i]);
                    _remplacents.Add(_owner.Game.PlayerList.Players[i]);

                    for (j = 0; j < _players.Count; j++)
                    {
                        _playerName = _players[j].Name;
                    }
                }

                /// Incumbant the players reservist in a team and in its global player list
                if (_owner.Game.PlayerList.Players[i].ActualTeamTag == tt && _owner.Game.PlayerList.Players[i].Status == "Reserviste")
                {
                    if (_players.Count < 0) throw new IndexOutOfRangeException();
                    _players.Add(_owner.Game.PlayerList.Players[i]);
                    _reservist.Add(_owner.Game.PlayerList.Players[i]);
                    for (j = 0; j < _players.Count; j++)
                    {
                        _playerName = _players[j].Name;
                    }
                }
            }

            _id = int.Parse(e.Attribute( "Id" ).Value);
            _name = e.Attribute("Name").Value;
            TeamTag = e.Element("TeamTag").Value;
            Town = e.Element("Town").Value;
            Stadium = e.Element("Stadium").Value;
            Logo = e.Element("Logo").Value;
            Manager = e.Element("Manager").Value;
            LeagueRanking = int.Parse(e.Element("LeagueRanking").Value);
            Level = int.Parse(e.Element("Level").Value);
            _budget = int.Parse( e.Element( "Budget" ).Value );

            XElement xml = new XElement("Players",
                from p in _players
                select new XElement("Player",
                    new XAttribute("Id", p.Id),
                    new XAttribute("Name", p.Name),
                    new XElement("ShirtNumber", p.ShirtNumber),
                    new XElement("Nationality", p.Nationality),
                    new XElement("Post", p.Poste),
                    new XElement("Height", p.Height),
                    new XElement("BirthDate", p.BirthDate),
                    new XElement("BirthPlace", p.BirthPlace),
                    new XElement("PreviousClub", p.PreviousClub),
                    new XElement("ActualClub", p.ActualClub),
                    new XElement("Stats", p.Stats),
                    new XElement("FormState", p.FormState),
                    new XElement("Injury", p.Injury),
                    new XElement("Mental", p.Mental),
                    new XElement("FinancialValue", p.FinancialValue),
                    new XElement("ActualTeamTag", p.ActualTeamTag),
                    new XElement("Status", p.Status)));
        }

             public Team( TeamList owner, XElement e, int i )
             {
                 _owner = owner;
                 _name = e.Value;
             }
        public XElement ToXml(int id)
        {
            return new XElement("Team",
                        new XAttribute("Id", id),
                        new XElement( "Points", LeaguePoint),
                        new XAttribute( "Name", Name ),
                        new XElement("TeamTag", TeamTag),
                        new XElement("Town", Town),
                        new XElement("Stadium", Stadium),
                        new XElement("Logo", Logo),
                        new XElement("Manager", Manager),
                        new XElement("LeagueRanking", LeagueRanking),
                        new XElement( "Level", Level ),
                        new XElement( "Budget", Budget ),
                        new XElement("Formation", Formation),
                        new XElement("Players",
                            new XElement("Titulaire",
                            from p in TeamType
                            select new XElement("Player",
                                new XAttribute("Id", p.Id),
                                new XAttribute("Name", p.Name),
                                new XElement("ShirtNumber", p.ShirtNumber),
                                new XElement("Nationality", p.Nationality),
                                new XElement("Post", p.Poste),
                                new XElement("Height", p.Height),
                                new XElement("BirthDate", p.BirthDate),
                                new XElement("BirthPlace", p.BirthPlace),
                                new XElement("PreviousClub", p.PreviousClub),
                                new XElement("ActualClub", p.ActualClub),
                                new XElement("Stats", p.Stats),
                                new XElement("FormState", p.FormState),
                                new XElement("Injury", p.Injury),
                                new XElement("Mental", p.Mental),
                                new XElement("FinancialValue", p.FinancialValue),
                                new XElement("ActualTeamTag", p.ActualTeamTag),
                                new XElement("Status", p.Status))),
                                new XElement("Remplacants",
                                from r in Remplacent
                                select new XElement("Player",
                            new XAttribute("Id", r.Id),
                            new XAttribute("Name", r.Name),
                            new XElement("ShirtNumber", r.ShirtNumber),
                            new XElement("Nationality", r.Nationality),
                            new XElement("Post", r.Poste),
                            new XElement("Height", r.Height),
                            new XElement("BirthDate", r.BirthDate),
                            new XElement("BirthPlace", r.BirthPlace),
                            new XElement("PreviousClub", r.PreviousClub),
                            new XElement("ActualClub", r.ActualClub),
                            new XElement("Stats", r.Stats),
                            new XElement("FormState", r.FormState),
                            new XElement("Injury", r.Injury),
                            new XElement("Mental", r.Mental),
                            new XElement("FinancialValue", r.FinancialValue),
                            new XElement("ActualTeamTag", r.ActualTeamTag),
                            new XElement("Status", r.Status))),
                                new XElement("Reservistes",
                                from res in Reserve
                                select new XElement("Player",
                            new XAttribute("Id", res.Id),
                            new XAttribute("Name", res.Name),
                            new XElement("ShirtNumber", res.ShirtNumber),
                            new XElement("Nationality", res.Nationality),
                            new XElement("Post", res.Poste),
                            new XElement("Height", res.Height),
                            new XElement("BirthDate", res.BirthDate),
                            new XElement("BirthPlace", res.BirthPlace),
                            new XElement("PreviousClub", res.PreviousClub),
                            new XElement("ActualClub", res.ActualClub),
                            new XElement("Stats", res.Stats),
                            new XElement("FormState", res.FormState),
                            new XElement("Injury", res.Injury),
                            new XElement("Mental", res.Mental),
                            new XElement("FinancialValue", res.FinancialValue),
                            new XElement("ActualTeamTag", res.ActualTeamTag),
                            new XElement("Status", res.Status)))));
        }

        /// <summary>
        /// Feature to move player from this team to another team
        /// </summary>
        /// <param name="playerName">Chosen player</param>
        /// <param name="teamName"></param>
        public void TransferPlayer(string playerName, string teamName)
        {
            Player newPlayer = new Player(_game.PlayerList, "toto");
            Player previousPlayer = new Player( _game.PlayerList, "tata" );
            Team previousPlayerTeam = new Team(_owner, "tonton");
            Team newPlayerTeam = new Team( _owner, "titi" );
            int otherPlayerBudget = 0;

            foreach( Team t in _game.TeamList.Teams )
            {
                if( t.Name == teamName )
                {
                    foreach( Player p in t.TeamPlayers )
                    {
                        if( playerName == p.Name )
                        {
                            DateTime today = DateTime.Now;
                            string userDoc = @".\..\..\..\user_" + _game.UserName + "_save_" + today.Year + today.Month + today.Day + ".xml";
                            if( File.Exists( userDoc ) )
                            {
                                XDocument doc = XDocument.Load( userDoc );
                                var target = doc.Element( "Game" ).Element( "Teams" ).Elements( "Team" )
                                                .Where( tP => tP.Attribute( "Name" ).Value == teamName )
                                                .Select( tP => tP.Element( "Players" ) )
                                                .Elements()
                                                .Elements( "Player" )
                                                .Where( tP => tP.Attribute( "Name" ).Value == playerName );

                                var target2 = doc.Element( "Game" ).Element( "Teams" ).Elements( "Team" )
                                    .Where( sT => sT.Attribute( "Name" ).Value == _game.ChoosenTeam )
                                    .Select( sT => sT.Element( "Players" ) )
                                    .Select( sT => sT.Element( "Reservistes" ) )
                                    .Single();

                                var managerName = doc.Element( "Game" ).Element( "Teams" ).Elements( "Team" )
                                    .Where( sT => sT.Attribute( "Name" ).Value == _game.ChoosenTeam )
                                    .Select( sT => sT.Element( "Manager" ) )
                                    .Single();

                                var target3 = doc.Element( "Game" ).Element( "Players" ).Elements( "Player" )
                                                .Where( tP => tP.Attribute( "Name" ).Value == playerName );

                                var target4 = doc.Element( "Game" ).Element( "Teams" ).Elements( "Team" )
                                    .Where( cT => cT.Attribute( "Name" ).Value == _game.ChoosenTeam )
                                    .Single();
                                newPlayerTeam = new Team( _owner, target4 );

                                var target5 = doc.Element( "Game" ).Element( "Teams" ).Elements( "Team" )
                                   .Where( cT => cT.Attribute( "Name" ).Value == teamName )
                                   .Single();
                                previousPlayerTeam = new Team( _owner, target5 );

                                var target6 = doc.Element( "Game" ).Element( "Teams" ).Elements("Team")
                                    .Where(cT => cT.Attribute("Name").Value == _game.ChoosenTeam)
                                    .Select(cT => cT.Element("Budget"))
                                    .Single();

                                var target7 = doc.Element( "Game" ).Element( "Teams" ).Elements( "Team" )
                                    .Where( cT => cT.Attribute( "Name" ).Value == teamName )
                                    .Select( cT => cT.Element( "Budget" ) )
                                    .Single();

                                foreach( Team playerTeam in _game.TeamList.Teams )
                                {
                                    if( playerTeam.Name == _game.ChoosenTeam )
                                    {
                                        var teamTag = target.Select( tS => tS.Element( "ActualTeamTag" ) ).Single();
                                        teamTag.Value = playerTeam.TeamTag;
                                        var actualClub = target.Select( aC => aC.Element( "ActualClub" ) ).Single();
                                        actualClub.Value = playerTeam.Name;
                                        var previousClub = target.Select( pC => pC.Element( "PreviousClub" ) ).Single();
                                        previousClub.Value = t.Name;
                                        var status = target.Select( tS => tS.Element( "Status" ) ).Single();
                                        status.Value = "Reserviste";

                                        var manager = managerName.Value;

                                        var teamTag2 = target3.Select( tS => tS.Element( "ActualTeamTag" ) ).Single();
                                        teamTag2.Value = playerTeam.TeamTag;
                                        var actualClub2 = target3.Select( aC => aC.Element( "ActualClub" ) ).Single();
                                        actualClub2.Value = playerTeam.Name;
                                        var previousClub2 = target3.Select( pC => pC.Element( "PreviousClub" ) ).Single();
                                        previousClub.Value = t.Name;
                                        var status2 = target3.Select( tS => tS.Element( "Status" ) ).Single();
                                        status2.Value = "Reserviste";

                                        newPlayerTeam = playerTeam;
                                    }
                                }

                                target2.Add( target );
                                target.Remove();
                                previousPlayer = p;

                                XElement tt = target3.Single();
                                Image i = Image.FromFile( @".\..\..\..\images\PlayerOne.png" );
                                newPlayer = new Player( _game.PlayerList, tt, i );
                                otherPlayerBudget = int.Parse(target6.Value) - newPlayer.FinancialValue;
                                target6.Value = otherPlayerBudget.ToString();
                                target7.Value = ( _budget + newPlayer.FinancialValue ).ToString();
                                _budget = _budget + newPlayer.FinancialValue;
                                doc.Save( @".\..\..\..\user_" + _game.UserName + "_save_" + today.Year + today.Month + today.Day + ".xml" );
                                
                                doc = XDocument.Load( @".\..\..\..\user_" + _game.UserName + "_save_" + today.Year + today.Month + today.Day + ".xml" );
                            }
                        }
                    }
                }
            }
            _game.PlayerList.AddPlayerToList( newPlayer );
            _game.PlayerList.RemovePlayer( previousPlayer );
            _game.TeamList.Teams[newPlayerTeam.Id].TeamPlayers.Add( newPlayer );
            _game.TeamList.Teams[newPlayerTeam.Id].Budget = otherPlayerBudget;

            this.TeamPlayers.Remove( previousPlayer );
            _game.TeamList.Teams.OrderBy( n => n.Id );
        }
        public string Name
        {
            get { return _name; }
        }

        public int Id
        {
            get { return _id; }
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

        public int Budget
        {
            get { return _budget; }
            set { _budget = value; }
        }

        public int LeaguePoint
        {
            get { return _leaguePoints; }
            set { _leaguePoints = value; }
        }

    }
}