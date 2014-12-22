using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        #endregion

        internal Player(PlayerList owner, string name)
        {
            _owner = owner;
            _name = name;
        }

        public Game Game
        {
            get { return _owner.Game; }
        }

        public Player(PlayerList owner, XElement e)
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
            _position = new Points();
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
    }
}