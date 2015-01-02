using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Drawing;

namespace Sims.SimSoccerModel
{
    public class Player
    {
        #region attribute
        readonly PlayerList _owner;
        int _id;
        int _shirtNumber;
        readonly string _name;
        readonly string _nationality;
        string _poste;
        float _height;
        int _weight;
        readonly string _birthDate;
        readonly string _birthPlace;
        string _previousClub;
        string _actualClub;
        int _stats;
        string _status;
        int _formState;
        bool _injury;
        int _mental;
        int _financialValue;
        string _actualTeamTag;
        Points _position;
        Image _image;
        Game _game;
        public Rectangle _player;
        public Points _playerPosition;
        public Rectangle _ball;
        public Points _ballPosition;
        public int _count = 0;
        public int _i = 0;
        bool _gotTheBall;
        Points _finalObjectif;
        #endregion

        public Game TheGame
        {
            get { return _game; }
        }
        internal Player(PlayerList owner, string name)
        {
            _owner = owner;
            _name = name;
        }


        public Game Game
        {
            get { return _owner.Game; }
        }

        public Player(PlayerList owner, XElement e, Image i )
        {
            _id = int.Parse(e.Attribute("Id").Value);
            _name = e.Attribute("Name").Value;
            ShirtNumber = int.Parse(e.Element("ShirtNumber").Value);
            _nationality = e.Element("Nationality").Value;
            Poste = e.Element("Poste").Value;
            Height = float.Parse(e.Element("Height").Value);
            Weight = int.Parse(e.Element("Weight").Value);
            _birthDate = e.Element("BirthDate").Value;
            _birthPlace = e.Element("BirthPlace").Value;
            PreviousClub = e.Element("PreviousClub").Value;
            ActualClub = e.Element("ActualClub").Value;
            Stats = int.Parse(e.Element("Stats").Value);
            FormState = int.Parse(e.Element("FormState").Value);
            Injury = bool.Parse(e.Element("Injury").Value);
            Mental = int.Parse(e.Element("Mental").Value);
            FinancialValue = int.Parse(e.Element("FinancialValue").Value);
            ActualTeamTag = e.Element("ActualTeamTag").Value;
            _status = e.Element("Status").Value;
            _image = i;
        }

        public Player( XDocument d, Image i )
        {
            _id = int.Parse( d.Root.Element("Players").Element("Player").Attribute( "Id" ).Value );
            _name = d.Root.Element("Players").Element("Player").Attribute( "Name" ).Value;
            ShirtNumber = int.Parse( d.Root.Element("Players").Element("Player").Element( "ShirtNumber" ).Value );
            _nationality = d.Root.Element("Players").Element("Player").Element( "Nationality" ).Value;
            Poste = d.Root.Element("Players").Element("Player").Element( "Poste" ).Value;
            Height = float.Parse( d.Root.Element("Players").Element("Player").Element( "Height" ).Value );
            Weight = int.Parse( d.Root.Element("Players").Element("Player").Element( "Weight" ).Value );
            _birthDate = d.Root.Element("Players").Element("Player").Element( "BirthDate" ).Value;
            _birthPlace = d.Root.Element("Players").Element("Player").Element( "BirthPlace" ).Value;
            PreviousClub = d.Root.Element("Players").Element("Player").Element( "PreviousClub" ).Value;
            ActualClub = d.Root.Element("Players").Element("Player").Element( "ActualClub" ).Value;
            Stats = int.Parse( d.Root.Element("Players").Element("Player").Element( "Stats" ).Value );
            FormState = int.Parse( d.Root.Element("Players").Element("Player").Element( "FormState" ).Value );
            Injury = bool.Parse( d.Root.Element("Players").Element("Player").Element( "Injury" ).Value );
            Mental = int.Parse( d.Root.Element("Players").Element("Player").Element( "Mental" ).Value );
            FinancialValue = int.Parse( d.Root.Element("Players").Element("Player").Element( "FinancialValue" ).Value );
            ActualTeamTag = d.Root.Element("Players").Element("Player").Element( "ActualTeamTag" ).Value;
            _status = d.Root.Element("Players").Element("Player").Element( "Status" ).Value;
            _image = i;
        }

        public void DrawPlayer( Game game, Image playerImage, Point p, Points player, Point ball, Points nextPoint, int i, int count)
        {
            _i = i;
            _count = count;
            _game = game;
            System.Drawing.Size size = new System.Drawing.Size(35,70);
            _player = new Rectangle( p, size );
            _playerPosition = new Points( ( float )p.X, ( float )p.Y );
            _ballPosition = new Points((float)ball.X, (float)ball.Y);

            if( nextPoint.X > player.X )
            {
                if( _i == 0 )
                    playerImage = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\PlayerOne.png" );
                else if( _i == 1 )
                    playerImage = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\PlayerMoveRight1.png" );
                else if( _i == 2 )
                    playerImage = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\PlayerMoveRight2.png" );
                else if( _i == 3 )
                    playerImage = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\p1Shoot.png" );
                else if( _i == 4 )
                    playerImage = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\p5shoot.png" );
                else if( _i == 5 )
                    playerImage = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\p1Stand.png" );
                else throw new InvalidOperationException( "Le nombre a été dépassé : " + _i );
            }
            else if( nextPoint.X == player.X && nextPoint.Y > player.Y )
            {
                size = new System.Drawing.Size( 31, 70 );
                _player = new Rectangle( p, size );
                if( _i == 0 )
                    playerImage = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\PlayerOne.png" );
                else if( _i == 1 )
                    playerImage = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\PlayerMoveDown1.png" );
                else if( _i == 2 )
                    playerImage = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\PlayerMoveDown2.png" );
                else if( _i == 3 )
                    playerImage = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\p1Shoot.png" );
                else if( _i == 4 )
                    playerImage = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\p5shoot.png" );
                else if( _i == 5 )
                    playerImage = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\p1Stand.png" );
                else throw new InvalidOperationException( "Le nombre a été dépassé : " + _i );
            }
            else if( nextPoint.X == player.X && nextPoint.Y < player.Y )
            {
                size = new System.Drawing.Size( 31, 70 );
                _player = new Rectangle( p, size );
                if( _i == 0 )
                    playerImage = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\PlayerOne.png" );
                else if( _i == 1 )
                    playerImage = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\PlayerMoveUp1.png" );
                else if( _i == 2 )
                    playerImage = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\PlayerMoveUp2.png" );
                else if( _i == 3 )
                    playerImage = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\p1Shoot.png" );
                else if( _i == 4 )
                    playerImage = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\p5shoot.png" );
                else if( _i == 5 )
                    playerImage = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\p1Stand.png" );
                else throw new InvalidOperationException( "Le nombre a été dépassé : " + _i );
            }
            else if( nextPoint.X < player.X )
            {
                if( _i == 0 )
                    playerImage = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\PlayerOne.png" );
                else if( _i == 1 )
                    playerImage = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\PlayerMoveLeft1.png" );
                else if( _i == 2 )
                    playerImage = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\PlayerMoveLeft2.png" );
                else if( _i == 3 )
                    playerImage = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\p1Shoot.png" );
                else if( _i == 4 )
                    playerImage = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\p5shoot.png" );
                else if( _i == 5 )
                    playerImage = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\p1Stand.png" );
                else throw new InvalidOperationException( "Le nombre a été dépassé : " + _i );
            }

            _game.Graphic.DrawImage(playerImage, _player);
        }

        public double Move(Points objectif)
        {
            Points playerPoint = _playerPosition;
            Points _objectif = objectif;

            double distance = playerPoint.Distance( _objectif );
            return distance;
        }

        public Points PointToObjectif( Points ball, Points finalObjectif )
        {
            float x = this.PlayerPosition.X;
            float y = this.PlayerPosition.Y;
            _finalObjectif = finalObjectif;

            if( this.PlayerPosition.X == ball.X && this.PlayerPosition.Y == ball.Y - 50 )
                _gotTheBall = true;

            Points vector = new Points( ( ball.X - x ), ( ball.Y - y - 50 ) );
            Points myNewPoint = new Points();

            
            if( vector.Y == 0 && vector.X < 0 )
            {
                myNewPoint.X = x -= 5;
                myNewPoint.Y = y;
            }
            else if( vector.X > 0 && vector.Y == 0 )
            {
                myNewPoint.Y = y;
                myNewPoint.X = x += 5;
            }
            else if( vector.X < 0 && vector.Y == 0 )
            {
                myNewPoint.Y = y;
                myNewPoint.X = x -= 5;
            }
            else if( vector.Y == 0 && vector.X > 0 )
            {
                myNewPoint.Y = y += 5;
                myNewPoint.X = x;
            }
            else if( vector.X == 0 && vector.Y < 0 )
            {
                myNewPoint.Y = y -= 5;
                myNewPoint.X = x;
            }
            else if( vector.X == 0 && vector.Y > 0 )
            {
                myNewPoint.Y = y += 5;
                myNewPoint.X = x;
            }
            else if( vector.X == x && vector.Y < 0 )
            {
                myNewPoint.X = x += 0;
                myNewPoint.Y = y -= 5;
            }
            else if( vector.Y < 0 && vector.X < 0 )
            {
                myNewPoint.X = x -= 5;
                myNewPoint.Y = y -= 5;
            }
            else if( vector.Y < 0 && vector.X != 0 )
            {
                myNewPoint.Y = y -= 5;
                myNewPoint.X = x += 5;
            }
            else if( vector.X < 0 && vector.Y != 0 )
            {
                myNewPoint.Y = y += 5;
                myNewPoint.X = x -= 5;
            }
            else if( vector.X != 0 && vector.Y != 0 )
            {
                myNewPoint.X = x += 5;
                myNewPoint.Y = y += 5;
            }
            return myNewPoint;
        }


        public XElement ToXml(int id)
        {
            return new XElement("Player",
            new XAttribute("Id", id),
            new XAttribute("Name", Name),
            new XElement("ShirtNumber", ShirtNumber),
            new XElement("Nationality", Nationality),
            new XElement("Post", Poste),
            new XElement("Height", Height),
            new XElement("BirthDate", BirthDate),
            new XElement("BirthPlace", BirthPlace),
            new XElement("PreviousClub", PreviousClub),
            new XElement("ActualClub", ActualClub),
            new XElement("Stats", Stats),
            new XElement("FormState", FormState),
            new XElement("Injury", Injury),
            new XElement("Mental", Mental),
            new XElement("FinancialValue", FinancialValue),
            new XElement("ActualTeamTag", ActualTeamTag),
            new XElement("Status", Status));
        }

        public Image Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public int Id
        {
            get { return _id; }
        }

        public Points Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public int ShirtNumber
        {
            get { return _shirtNumber; }
            set { _shirtNumber = value; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string Nationality
        {
            get { return _nationality; }
        }

        public string Poste
        {
            get { return _poste; }
            set { _poste = value; }
        }

        public float Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public string BirthDate
        {
            get { return _birthDate; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public string BirthPlace
        {
            get { return _birthPlace; }
        }

        public string PreviousClub
        {
            get { return _previousClub; }
            set { _previousClub = value; }
        }

        public string ActualClub
        {
            get { return _actualClub; }
            set { _actualClub = value; }
        }

        public int Stats
        {
            get { return _stats; }
            set { _stats = value; }
        }

        public int FormState
        {
            get { return _formState; }
            set { _formState = value; }
        }

        /// <summary>
        /// Have an injuried player
        /// </summary>
        public void IsInjuried()
        {
            if (_formState < 50) _injury = true;
        }
        public bool Injury
        {
            get { return _injury; }
            set { _injury = value; }
        }

        public int Mental
        {
            get { return _mental; }
            set { _mental = value; }
        }

        public int FinancialValue
        {
            get { return _financialValue; }
            set { _financialValue = value; }
        }

        public string ActualTeamTag
        {
            get { return _actualTeamTag; }
            set { _actualTeamTag = value; }
        }

        public Points PlayerPosition
        {
            get { return _playerPosition; }
            set { _playerPosition = value; }
        }
        public float PlayerPositionX
        {
            get { return this.PlayerPosition.X; }
            set { _playerPosition.X = value; }
        }

        public float PlayerPositionY
        {
            get { return this.PlayerPosition.Y; }
            set { _playerPosition.Y = value; }
        }

        public bool GotTheBall
        {
            get { return _gotTheBall; }
            set { _gotTheBall = value; }
        }

    }
}