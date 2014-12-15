﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Sims.SimSoccerModel
{
    public class Game
    {
        readonly TeamList _teamList;
        readonly PlayerList _playerList;
        readonly Ligue _ligue;
        string _userName;
        string _userPassword;
        string _birthDate;
        string _choosenTeam;
        string _avatar;
        private   XElement xElement;
        readonly Field _field;

        public PlayerList PlayerList
        {
            get { return _playerList; }
        }

        public Field Field
        {
            get { return _field; }
        }
        public TeamList TeamList
        {
            get { return _teamList; }
        }

        public Ligue Ligue
        {
            get { return _ligue; }
        }
        public string UserName
        {
            get { return _userName; }
        }
        public string UserPassword
        {
            get { return _userPassword; }
        }

        public string BirthDate
        {
            get { return _birthDate; }
        }
        public string Avatar
        {
            get { return _avatar; }
        }
        public string ChoosenTeam
        {
            get { return _choosenTeam; }
            set { _choosenTeam = value; }
        }

        public Game()
        {
            XDocument doc = XDocument.Load( @".\..\..\..\Ligue1Players2.xml" );
            XDocument doc2 = XDocument.Load( @".\..\..\..\Ligue1Teams.xml" );
            XDocument doc3 = XDocument.Load(@".\..\..\..\Tactics.xml");
            _teamList = new TeamList( this, doc2.Root.Element( "Teams" ) );
            _playerList = new PlayerList( this, doc.Root.Element("Player") );
        }
        public Game( string userName )
        {
            _userName = userName;
            XDocument doc = XDocument.Load( @".\..\..\..\user_" + userName + "*" );
        }
        public Game( string userName, string userPassword )
        {
            _userName = userName;
            _userPassword = userPassword;
            XDocument doc = XDocument.Load( @".\..\..\..\Ligue1Players2.xml" );
            XDocument doc2 = XDocument.Load( @".\..\..\..\Ligue1Teams.xml" );
            XDocument doc3 = XDocument.Load(@".\..\..\..\Tactics.xml");
            _playerList = new PlayerList( this, doc.Root.Element( "Players" ) );
            _teamList = new TeamList( this, doc2.Root.Element( "Teams" ) );
            _ligue = new Ligue(this,2014);
            _avatar =  @".\..\..\..\avatar.jpg";
            _field = new Field();
        }

        public Game( XElement e )
        {
            // TODO: Complete member initialization
            this.xElement = e;
            _userName = e.Element( "UserName" ).Value;
            _userPassword = e.Element( "Password" ).Value;
            _choosenTeam = e.Element( "ChosenTeam" ).Value;
            _avatar = e.Element( "Avatar" ).Value;
            _birthDate = e.Element( "BirthDate" ).Value;
            XDocument doc = XDocument.Load( @".\..\..\..\Ligue1Players2.xml" );
            XDocument doc2 = XDocument.Load( @".\..\..\..\Ligue1Teams.xml" );
            _playerList = new PlayerList( this, doc.Root.Element( "Players" ) );
            _teamList = new TeamList( this, doc2.Root.Element( "Teams" ) );
            _ligue = new Ligue( this, 2014 );
            
        }

      

        public void GameToXml(Game game)
        {
            int i;
            string saveNameUserId;
            string userNumber = @".\..\..\..\UserNumber.xml";
            if( File.Exists( userNumber ) == false )
            {
                i = 0;
                XDocument un = new XDocument(
                new XElement( "Game",
                    new XElement( "UserNumber",
                        new XElement( "Number", ++i) ) ) );
                un.Save( @".\..\..\..\UserNumber.xml" );
                i = 0;
                saveNameUserId = i.ToString();
            }
            else
            {
                XDocument doc2 = XDocument.Load( @".\..\..\..\UserNumber.xml" );
                i = int.Parse( doc2.Root.Element( "UserNumber" ).Value );
                XDocument un = new XDocument(
                new XElement( "Game",
                    new XElement( "UserNumber",
                        new XElement( "Number", i + 1 ) ) ) );
                un.Save( @".\..\..\..\UserNumber.xml" );
                if( i < 10 )
                {
                    saveNameUserId = "0" + i.ToString();
                }
                else
                    saveNameUserId = i.ToString();

            }

            DateTime today = DateTime.Now;

            XDocument gameSave = new XDocument(
                new XElement("Game",
                    new XElement("Profil",
                        new XAttribute("ID", i),
                        new XElement("UserName", _userName),
                        new XElement("Password", _userPassword),
                        new XElement("BirthDate", today),
                        new XElement("Avatar", _avatar),
                        new XElement("ChosenTeam", "")),
                    game.TeamList.ToXml(),
                    new XElement("FreePlayers",
                        new XElement("TheFreePlayer"))));

            _birthDate = today.ToShortDateString();
            gameSave.Save( @".\..\..\..\user_" + _userName + "_save_" + today.Year + today.Month + today.Day + ".xml" );
        }
        public void SaveProfilToXML(string birthDate, string avatar, Game game )
        {
            _avatar = avatar;
            _birthDate = birthDate;
            DateTime today = DateTime.Now;

            var doc = XElement.Load( @".\..\..\..\user_" + UserName + "_save_" + today.Year + today.Month + today.Day + ".xml" );
            var target = doc
                 .Elements( "Profil" )
                 .Single();

            target.Element( "Avatar" ).Value = _avatar;
            target.Element( "BirthDate" ).Value = _birthDate;
            doc.Save( @".\..\..\..\user_" + UserName + "_save_" + today.Year + today.Month + today.Day + ".xml" );

        }
        public void ToXML( string ChoosenTeam, Game game)
        {
            _choosenTeam = ChoosenTeam;


            DateTime today = DateTime.Now;

            var doc = XElement.Load( @".\..\..\..\user_" + UserName + "_save_" + today.Year + today.Month + today.Day + ".xml" );
            var target = doc
                 .Elements( "Profil" )
                 .Single();

            target.Element( "ChosenTeam" ).Value = _choosenTeam;

            doc.Save( @".\..\..\..\user_" + UserName + "_save_" + today.Year + today.Month + today.Day + ".xml" );
        }
    }
}
