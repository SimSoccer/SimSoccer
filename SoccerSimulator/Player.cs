using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SoccerSimulator
{
    class Player
    {
        int _id; int _shirtNumber;
        string _name; string _nationality;
        string _poste; float _height;
        float _weight;
        string _birthDate; string _birthPlace;
        string _previousClub; string _actualClub;
        int _stats; int _formState;
        bool _injury; int _mental; int _financialValue;

        public void CreateDictionary()
        {
            XDocument xdoc = XDocument.Load( @"C:\Users\Guenole\Documents\GitHub\SimSoccer\SimSoccer\Ligue1FrenchPlayers" );
            var query = xdoc.Descendants( "Players" )
                            .Elements()
                            .ToDictionary( r => r.Attribute( "Id" ).Value,
                                         r => r.Value );
        }
        //readonly Dictionary<int, Animal> _animals;

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