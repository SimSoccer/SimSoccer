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
        Dictionary<string, string> _players;
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
            /*var doc = XDocument.Load( @"C:\Users\Guenole\Documents\GitHub\RealSimSoccer\SimSoccer\Ligue1Players.xml" );

            Console.WriteLine( doc );*/

            var doc = XDocument.Load( @"C:\Users\Guenole\Documents\GitHub\RealSimSoccer\SimSoccer\Ligue1Players.xml" );
            var rootNodes = doc.Root.DescendantNodes().OfType<XElement>().DescendantNodes().OfType<XAttribute>();
            var keyValuePairs = from n in rootNodes
                                select new
                                {
                                    TagName = n.Name,
                                    TagValue = n.Value
                                };

            Dictionary<string, string> allItems = new Dictionary<string, string>();
            foreach( var token in keyValuePairs )
            {
                allItems.Add( token.TagName.ToString(), token.TagValue.ToString() );
            }
            _players = allItems;
            Console.WriteLine( allItems );
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
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