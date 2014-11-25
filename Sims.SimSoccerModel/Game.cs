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
        int _id;

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
            _teamList = new TeamList( this );
            _playerList = new PlayerList( this );
        }
        public Game( int id, string userName, string userPassword )
        {
            _userName = userName;
            _userPassword = userPassword;
            _id = id;
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

        public TeamList CreateTeam() 
        {
            var t = 0;
            TeamList tl = new TeamList(this);
            return tl;
        }
    }
}
