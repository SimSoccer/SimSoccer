using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace SIMS.PlayersManagement
{
    public class Player
    {
        int _id; int _shirtNumber;
        string _name, _nationality;
        string _poste; float _height;
        int _weight;
        string _birthDate; string _birthPlace;
        string _previousClub; string _actualClub;
        int _stats; int _formState;
        bool _injury; int _mental; int _financialValue;


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int ShirtNumber
        {
            get { return _shirtNumber; }
            set { _shirtNumber = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Nationality
        {
            get { return _nationality; }
            set { _nationality = value; }
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
            set { _birthDate = value; }
        }

        public string BirthPlace
        {
            get { return _birthPlace; }
            set { _birthDate = value; }
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