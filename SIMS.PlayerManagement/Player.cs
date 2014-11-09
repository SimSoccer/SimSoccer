using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SoccerSimulator
{
    public class Player
    {
        readonly Dictionary<string, Player> _player;

        int _id; int _shirtNumber;
        string _name; string _nationality;
        string _poste; float _height;
        float _weight;
        string _birthDate; string _birthPlace;
        string _previousClub; string _actualClub;
        int _stats; int _formState;
        bool _injury; int _mental; int _financialValue;

        // need a parameterless constructor for serialization
        public Player()
        {
          //  XDocument.Load( @"C:\Users\Guenole\Documents\GitHub\RealSimSoccer\SimSoccer\Ligue1FrenchPlayers.xml" ).Descendants( "Id" ).Descendants()
   // .ToDictionary( element => element.Name, element => element.Value );
            /*
            //Try to work with this
            string s = "<data><resource key=\"123\">foo</resource><resource key=\"456\">bar</resource><resource key=\"789\">bar</resource></data>";
            XmlDocument xml = new XmlDocument();
            xml.LoadXml( s );
            XmlNodeList resources = xml.SelectNodes( "data/resource" );
            SortedDictionary<string, string> dictionary = new SortedDictionary<string, string>();
            foreach( XmlNode node in resources )
            {
                dictionary.Add( node.Attributes["key"].Value, node.InnerText );

            }*/

            string myxml = @"C:\Users\Guenole\Documents\GitHub\RealSimSoccer\SimSoccer\Ligue1FrenchPlayers.xml";
            XElement patternDoc = XElement.Load( myxml );
            List<string> values = new List<string>();
            foreach( var element in patternDoc.Elements( "Id" ) )
            {
                values.Add( element.Value );
            }
        }

        public Dictionary<string, string> element { get; set; }
        //readonly Dictionary<int, Animal> _animals;*/

        public int Id
        {
            get { return _id; }
        }

        public int ShirtNumber
        {
            get { return _shirtNumber; }
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
        }

        public float Height
        {
            get { return _height; }
        }

        public float Weight
        {
            get { return _weight; }
        }

        public string BirthDate
        {
            get { return _birthDate; }
        }

        public string BirthPlace
        {
            get { return _birthPlace; }
        }

        public string PreviousClub
        {
            get { return _previousClub; }
        }

        public string ActualClub
        {
            get { return _actualClub; }
        }

        public int Stats
        {
            get { return _stats; }
        }

        public int FormState
        {
            get { return _formState; }
        }

        /// <summary>
        /// Have an injuried player
        /// </summary>
        public void IsInjuried()
        {
            if( _formState < 50 ) _injury = true;
        }
        public bool Injury
        {
            get { return _injury; }
        }

        public int Mental
        {
            get { return _mental; }
        }

        public int FinancialValue
        {
            get { return _financialValue; }
        }
    }
}