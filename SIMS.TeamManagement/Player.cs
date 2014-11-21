using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SIMS.TeamsManagement
{
    class Player
    {
        readonly int _id; 
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
        int _formState;
        bool _injury; 
        int _mental; 
        int _financialValue;
        PlayerList _owner;

        public Player( PlayerList owner, int id, string name, string nationality, string birthDate, string birthPlace )
        {
            _id = id;
            _nationality = nationality;
            _birthDate = birthDate;
            _birthPlace = birthPlace;
            _owner = owner;
        }

        public Game Game
        {
            get { return _owner.Game; }
        }

        internal Player( PlayerList owner, XElement e )
        {
            _name = e.Attribute( "Name" ).Value;
            ShirtNumber = int.Parse(e.Element( "ShirtNumber" ).Value);
            _nationality = e.Element( "Nationality" ).Value;
            Poste = e.Element( "Poste" ).Value;
            Height = float.Parse(e.Element( "Height" ).Value);
            Weight = int.Parse( e.Element( "Weight" ).Value );
            _birthDate = e.Element( "BirthDate" ).Value;
            _birthPlace = e.Element( "BirthPlace" ).Value;
            PreviousClub = e.Element( "PreviousClub" ).Value;
            ActualClub = e.Element( "ActualClub" ).Value;
            Stats = int.Parse(e.Element( "Stats" ).Value);
            FormState = int.Parse(e.Element( "FormState" ).Value);
            Injury = bool.Parse(e.Element( "Injury" ).Value);
            Mental = int.Parse(e.Element( "Mental" ).Value);
            FinancialValue = int.Parse( e.Element( "FinancialValue" ).Value );
        }

        public XElement ToXml( int id )
        {
            return new XElement( "Player",
            new XAttribute( "Id", id ),
            new XAttribute( "Name", Name ),
            new XElement( "ShirtNumber", ShirtNumber ),
            new XElement( "Nationality", Nationality ),
            new XElement( "Post", Poste ),
            new XElement( "Height", Height ),
            new XElement( "BirthDate", BirthDate ),
            new XElement( "BirthPlace", BirthPlace ),
            new XElement( "PreviousClub", PreviousClub ),
            new XElement( "ActualClub", ActualClub ),
            new XElement( "Stats", Stats ),
            new XElement( "FormState", FormState ),
            new XElement( "Injury", Injury ),
            new XElement( "Mental", Mental ),
            new XElement( "FinancialValue", FinancialValue ) );
        }

        public int Id
        {
            get { return _id; }
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
            if( _formState < 50 ) _injury = true;
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
    }
}
