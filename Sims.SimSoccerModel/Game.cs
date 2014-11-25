using System;
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

        public Game()
        {
            XDocument doc = XDocument.Load( @".\..\..\..\Ligue1Players2.xml" );
            XDocument doc2 = XDocument.Load( @".\..\..\..\Ligue1Teams.xml" );
            _teamList = new TeamList( this, doc2.Root.Element( "Teams" ) );
            _playerList = new PlayerList( this, doc.Root.Element("Players") );
        }

        public Game( string userName, string userPassword )
        {
            _userName = userName;
            _userPassword = userPassword;
        }
        public Game( string choosenTeam , string userName , string userPassword)
        {
            _choosenTeam = choosenTeam;
            _userName = userName;
            _userPassword = userPassword;
        }

        public void GameToXml()
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
            
            Game game = new Game();
            XElement e = game.PlayerList.ToXml();
            XDocument gameSave = new XDocument(
                new XElement("Game",
                    new XElement("Profil",
                        new XAttribute("ID", i),
                        new XElement("UserName", _userName),
                        new XElement("Password", _userPassword)),
                    game.PlayerList.ToXml(),
                    game.TeamList.ToXml()));

            DateTime today = DateTime.Now;
            gameSave.Save( @".\..\..\..\user" + saveNameUserId + "_" + _userName + "_save_" + today.Year + today.Month + today.Day + ".xml" );
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
