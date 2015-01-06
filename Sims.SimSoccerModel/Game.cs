using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Drawing;

namespace Sims.SimSoccerModel
{
    public class Game
    {
        public Match _match;
        readonly TeamList _teamList;
        readonly PlayerList _playerList;
        readonly Ligue _ligue;
        string _userName;
        string _userPassword;
        string _lastName;
        string _firstName;
        string _birthDate;
        string _choosenTeam;
        string _avatar;
        private XElement xElement;
        readonly Field _field;
        Graphics _graphic;

        public Graphics Graphic
        {
            get { return _graphic; }
            set { _graphic = value; }
        }
        readonly FormationList _formation;
        public Random _rnd;
        int _journey;

        public Random Rnd
        {
            get { return _rnd; }
        }



        public PlayerList PlayerList
        {
            get { return _playerList; }
        }

        public Field Field
        {
            get { return _field; }
        }

        public FormationList FormationList
        {
            get { return _formation; }
        }
        public TeamList TeamList
        {
            get { return _teamList; }
        }

        public Match Match
        {
            get { return _match; }
        }

        public Ligue Ligue
        {
            get { return _ligue; }
        }
        public int Journey
        {
            get { return _journey; }
            set { _journey = value; }
        }
        public string UserName
        {
            get { return _userName; }
        }
        public string LastName
        {
            get { return _lastName; }
        }
        public string FirstName
        {
            get { return _firstName; }
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
            XDocument doc3 = XDocument.Load( @".\..\..\..\Tactics.xml" );
            _teamList = new TeamList( this, doc2.Root.Element( "Teams" ) );
            _playerList = new PlayerList( this, doc.Root.Element( "Players" ) );
            _formation = new FormationList( this, doc3.Root.Element( "Tactics" ) );

        }

        public Game( string userName )
        {
            _userName = userName;
            XDocument doc = XDocument.Load( @".\..\..\..\user_" + userName + "*" );
        }

        public Game( string userName, string userPassword, string lastName, string firstName )
        {
            _userName = userName;
            _userPassword = userPassword;
            _lastName = lastName;
            _firstName = firstName;
            _journey = 0;
            XDocument doc = XDocument.Load( @".\..\..\..\Ligue1Players2.xml" );
            XDocument doc2 = XDocument.Load( @".\..\..\..\Ligue1Teams.xml" );
            XDocument doc3 = XDocument.Load( @".\..\..\..\Tactics.xml" );
            _playerList = new PlayerList( this, doc.Root.Element( "Players" ) );
            _teamList = new TeamList( this, doc2.Root.Element( "Teams" ) );
            _formation = new FormationList( this, doc3.Root.Element( "Tactics" ) );
            _ligue = new Ligue( this, 2014 );
            _rnd = new Random();
            _avatar = @".\..\..\..\avatar.jpg";
            _field = new Field();
            _ligue.fillCalendar();
        }

        public Game( XElement e )
        {
            // TODO: Complete member initialization
            this.xElement = e;
            _userName = e.Element( "UserName" ).Value;
            _userPassword = e.Element( "Password" ).Value;
            _lastName = e.Element( "LastName" ).Value;
            _firstName = e.Element( "FirstName" ).Value;
            _choosenTeam = e.Element( "ChosenTeam" ).Value;
            _avatar = e.Element( "Avatar" ).Value;
            _birthDate = e.Element( "BirthDate" ).Value;
            _journey = Convert.ToInt32( e.Element( "Journey" ).Value );
            XDocument doc = XDocument.Load( @".\..\..\..\Ligue1Players2.xml" );
            XDocument doc2 = XDocument.Load( @".\..\..\..\Ligue1Teams.xml" );
            XDocument doc3 = XDocument.Load( @".\..\..\..\Tactics.xml" );
            _playerList = new PlayerList( this, doc.Root.Element( "Players" ) );
            _teamList = new TeamList( this, doc2.Root.Element( "Teams" ) );
            _formation = new FormationList( this, doc3.Root.Element( "Tactics" ) );
            _ligue = new Ligue( this, 2014 );
            _field = new Field();
            _rnd = new Random();
            _ligue.fillCalendar();
        }

        public void GameToXml( Game game )
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
                        new XElement( "Number", ++i ) ) ) );
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
                new XElement( "Game",
                    new XElement( "Profil",
                        new XAttribute( "ID", i ),
                        new XElement( "UserName", _userName ),
                        new XElement( "Password", _userPassword ),
                        new XElement( "LastName", _lastName ),
                        new XElement( "FirstName", _firstName ),
                        new XElement( "BirthDate", today ),
                        new XElement( "Avatar", _avatar ),
                        new XElement( "ChosenTeam", "" ),
                        new XElement( "Journey", _journey ) ),
                    game.TeamList.ToXml(),
                    new XElement( "FreePlayers",
                        new XElement( "TheFreePlayer" ) ) ) );

            _birthDate = today.ToShortDateString();
            gameSave.Save( @".\..\..\..\user_" + _userName + "_save_" + today.Year + today.Month + today.Day + ".xml" );
        }
        public void SaveProfilToXML( string birthDate, string avatar, Game game )
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
        public void ToXML( string ChoosenTeam, Game game )
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
        public void Transfer( Game game, Player p )
        {
            DateTime today = DateTime.Now;

            var doc = XElement.Load( @".\..\..\..\user_" + UserName + "_save_" + today.Year + today.Month + today.Day + ".xml" );
            var target = doc
                 .Elements( "Teams" ).Elements( "Players" )
                 .Single();

            target.Element( "Player" ).Value = _choosenTeam;
            //target.Attribute( "Name" ).Value = p;

            doc.Save( @".\..\..\..\user_" + UserName + "_save_" + today.Year + today.Month + today.Day + ".xml" );
            doc.Save( @".\..\..\..\user_" + UserName + "_save_" + today.Year + today.Month + today.Day + ".xml" );
        }

        public int RndGauss( int nb1, int nb2 )
        {

            double nbGoal1 = Rnd.NextDouble();
            double nbGoal2 = Rnd.NextDouble();

            double randStdNormal = Math.Sqrt( -2.0 * Math.Log( nbGoal1 ) ) * Math.Sin( 2.0 * Math.PI * nbGoal2 );
            double RandNbGoal = nb1 + nb2 * randStdNormal;
            RandNbGoal += 4;

            int nbGoal = Convert.ToInt32( RandNbGoal );

            if( nbGoal < 0 ) nbGoal = 0;
            else if( nbGoal > 8 ) nbGoal = 8;

            return nbGoal;

        }

        public void SaveProfilToXML( string birthDate, string avatar, Game _game, int journey )
        {
            _avatar = avatar;
            _birthDate = birthDate;
            _journey = journey;
            DateTime today = DateTime.Now;

            var doc = XElement.Load( @".\..\..\..\user_" + UserName + "_save_" + today.Year + today.Month + today.Day + ".xml" );
            var target = doc
                 .Elements( "Profil" )
                 .Single();

            target.Element( "Avatar" ).Value = _avatar;
            target.Element( "BirthDate" ).Value = _birthDate;
            target.Element( "Journey" ).Value = _journey.ToString();
            doc.Save( @".\..\..\..\user_" + UserName + "_save_" + today.Year + today.Month + today.Day + ".xml" );
        }


        public void SaveMyTeamToXML( string formation, Game game )
        {
            DateTime today = DateTime.Now;

            var doc = XElement.Load( @".\..\..\..\user_" + UserName + "_save_" + today.Year + today.Month + today.Day + ".xml" );
            var target = doc
                 .Elements( "Teams" ).Elements( "Team" ).Where( t => t.Attribute( "Name" ).Value == _choosenTeam )
                 .Single();

            target.Element( "Formation" ).Value = formation;

            // Summarry
            // BY THE MOMENT IN COMMENT BY DEFAULT
            // Here are lines to remove the "Titulaire" element in the player team
            // Will have to save the actual element. Will have to save the new PlayerList.
            // With new TeamType, Replacants and reservists playerList in the XML
            // Summary

            /*
            var target2 = doc
                 .Elements( "Teams" ).Elements( "Team" ).Where( t => t.Attribute( "Name" ).Value == _choosenTeam ).Elements( "Players" ).Elements("Titulaire");

            target2.Remove();*/

            doc.Save( @".\..\..\..\user_" + UserName + "_save_" + today.Year + today.Month + today.Day + ".xml" );
        }
    }
}
