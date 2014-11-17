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

namespace SoccerSimulator
{
    public class Player
    {
        string _id; string _shirtNumber;
        string _name, _nationality;
        string _poste; string _height;
        string _weight;
        string _birthDate; string _birthPlace;
        string _previousClub; string _actualClub;
        string _stats; string _formState;
        string _injury; string _mental; string _financialValue;


        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string ShirtNumber
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

        public string Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public string Weight
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

        public string Stats
        {
            get { return _stats; }
            set { _stats = value; }
        }

        public string FormState
        {
            get { return _formState; }
            set { _formState = value; }
        }

        /// <summary>
        /// Have an injuried player
        /// </summary>
        public void IsInjuried()
        {
            if( _formState == "50" ) _injury = "true";
        }
        public string Injury
        {
            get { return _injury; }
            set { _injury = value; }
        }

        public string Mental
        {
            get { return _mental; }
            set { _mental = value; }
        }

        public string FinancialValue
        {
            get { return _financialValue; }
            set { _financialValue = value; }
        }
        
    }
}