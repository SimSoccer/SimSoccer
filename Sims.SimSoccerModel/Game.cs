﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sims.SimSoccerModel
{
    public class Game
    {
        readonly TeamList _teamList;
        readonly PlayerList _playerList;
        string _userName;
        string _userPassword;
        string _choosenTeam;
        int _id;

        public PlayerList PlayerList
        {
            get { return _playerList; }
        }

        public TeamList TeamList
        {
            get { return _teamList; }
        }
        public string UserName
        {
            get { return _userName; }
        }
        public string UserPassword
        {
            get { return _userPassword; }
        }
        public string ChoosenTeam
        {
            get { return _choosenTeam; }
            set { _choosenTeam = value; }
        }

        public int ID
        {
            get { return _id; }
        }
        public Game()
        {
            XDocument doc = XDocument.Load( @".\..\..\..\Ligue1Players2.xml" );
            XDocument doc2 = XDocument.Load( @".\..\..\..\Ligue1Teams.xml" );
            _teamList = new TeamList( this, doc2.Root.Element( "Teams" ) );
            _playerList = new PlayerList( this, doc.Root.Element("Players") );
        }

        public Game( int id, string userName, string userPassword )
        {
            _userName = userName;
            _userPassword = userPassword;
            _id = id;
        }
        public Game( string choosenTeam , string userName , string userPassword)
        {
            _choosenTeam = choosenTeam;
            _userName = userName;
            _userPassword = userPassword;
        }

        public void GameToXml()
        {
            
            Game game = new Game();
            XElement e = game.PlayerList.ToXml();
            XDocument gameSave = new XDocument(
                new XElement("Game",
                    new XElement("Profil",
                        new XAttribute("ID", _id),
                        new XElement("UserName", _userName),
                        new XElement("Password", _userPassword)),
                    game.PlayerList.ToXml(),
                    game.TeamList.ToXml()));

            DateTime today = DateTime.Now;
            gameSave.Save( @".\..\..\..\user_" + _userName + "_save_" + today.Year + today.Month + today.Day + ".xml" );
        }

       
        public void ToXML()
        {
            int i;
            string userNumber = @".\..\..\..\UserNumber.xml";
            if( File.Exists(userNumber) == false )
            {
                i = 0;
                XDocument un = new XDocument(
                new XElement( "Game",
                    new XElement( "UserNumber",
                        new XElement( "Number", i ) ) ) );
                un.Save( @".\..\..\..\UserNumber.xml" );
                _id = i;
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
                _id = i + 1;
            }

            _choosenTeam = "teamTest";
            XDocument doc = new XDocument(
                new XElement( "Game",
                    new XElement( "Profil",
                        new XAttribute( "Id", _id ),
                        new XElement( "Save", _userName ),
                        new XElement( "Password", _userPassword ),
                        new XElement( "Team", _choosenTeam ) ) ) );
            DateTime today = DateTime.Now;
            doc.Save( @".\..\..\..\user_" + _userName + "_save_" + today.Year + today.Month + today.Day + ".xml" );
        }

        public void ToXML( string ChoosenTeam, Game game)
        {
            _choosenTeam = ChoosenTeam;
            
            XDocument doc = new XDocument(
                new XElement( "Game",
                    new XElement( "Save", _userName ),
                    new XElement( "Password", _userPassword ),
                    new XElement( "Team", _choosenTeam ) ) );
          doc.Save( @".\..\..\..\SaveOf" + _userName + ".xml" );
        }
    }
}
