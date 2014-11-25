using System;
using System.Collections.Generic;
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
            _teamList = new TeamList( this );
            _playerList = new PlayerList( this );
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

       
        public void ToXML()
        {
            _choosenTeam ="teamTest";
            XDocument doc = new XDocument(
                new XElement("Game",
                    new XElement("Save", _userName),
                    new XElement("Password", _userPassword),
                    new XElement("Team", _choosenTeam)));

            doc.Save( @".\..\..\..\SaveOf" + _userName + ".xml" );
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
