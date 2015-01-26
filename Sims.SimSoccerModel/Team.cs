﻿using System;
using System.Collections.Generic;
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
        List<Team> _opponent;
        List<Player> _teamType;
        List<Player> _remplacents;
        List<Player> _reservist;
        readonly Game _game;
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

            _name = e.Attribute("Name").Value;
            TeamTag = e.Element("TeamTag").Value;
            Town = e.Element("Town").Value;
            Stadium = e.Element("Stadium").Value;
            Logo = e.Element("Logo").Value;
            Manager = e.Element("Manager").Value;
            LeagueRanking = int.Parse(e.Element("LeagueRanking").Value);
            Level = int.Parse(e.Element("Level").Value);

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
        public XElement ToXml(int id)
        {
            return new XElement("Team",
                        new XAttribute("Id", id),
                        new XAttribute("Name", Name),
                        new XElement("TeamTag", TeamTag),
                        new XElement("Town", Town),
                        new XElement("Stadium", Stadium),
                        new XElement("Logo", Logo),
                        new XElement("Manager", Manager),
                        new XElement("LeagueRanking", LeagueRanking),
                        new XElement("Level", Level),
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

        public void TransferPlayer(string playerName, string teamName)
        {
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
                                                .Select( tP => tP.Elements() )
                                                .Select( tP => tP.ElementAt( p.Id ) )
                                                .Select( tP => tP.Element( "Player" ) )
                                                .Where( tP => tP.Attribute( "Name" ).Value == playerName );

                                var target2 = doc.Element( "Game" ).Element( "Teams" ).Elements( "Team" )
                                    .Where( sT => sT.Attribute( "Name" ).Value == _game.ChoosenTeam )
                                    .Select( sT => sT.Element( "Players" ) )
                                    .Select( sT => sT.Element( "Reservistes" ) )
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
                                    }
                                }
                                

                                target2.Add( target );
                                target.Remove();
                                doc.Save( @".\..\..\..\user_" + _game.UserName + "_save_" + today.Year + today.Month + today.Day + ".xml" );
                            }
                        }
                    }
                }
            }
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