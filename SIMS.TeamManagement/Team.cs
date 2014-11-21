﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SIMS.TeamsManagement
{
    public class Team
    {
        readonly string _name;
        readonly TeamList _owner;
        readonly List<Player> _players;
        string _teamTag;
        string _town;
        string _stadium, _logo, _manager;
        int _leagueRanking; 
        int _level;

        internal Team( TeamList owner, string name )
        {
            _owner = owner;
            _name = name;
            _players = new List<Player>();
        }

        public Game Game
        {
            get { return _owner.Game; }
        }

        internal Team( TeamList owner, XElement e )
        {
            _owner = owner;
            _name = e.Attribute( "Name" ).Value;
            TeamTag = e.Element( "TeamTag" ).Value;
            Town = e.Element( "Town" ).Value;
            Stadium = e.Element( "Stadium" ).Value;
            Logo = e.Element( "Logo" ).Value;
            Manager = e.Element( "Manager" ).Value;
            LeagueRanking = int.Parse( e.Element( "LeagueRanking" ).Value );
            Level = int.Parse( e.Element( "Level" ).Value );
            // Players
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
                                new XAttribute( "Id", _players.Select( p => Game.PlayerList.Players.IndexOf( p ) ) ))));
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
    }
}
