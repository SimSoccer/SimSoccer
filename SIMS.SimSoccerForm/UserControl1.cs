using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Sims.SimSoccerModel;
using System.Xml.Linq;

namespace SIMS.SimSoccerForm
{
    
    public partial class UserControl1 : UserControl 
    {
        //readonly Game _game;
        public UserControl1()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        public string UserName
        {
            get
            {
                return txtName.Text;
            }
            set
            {
                txtName.Text = value;
            }
        }
        public string UserPassword
        {
            get
            {
                return txtPassword.Text;
            }
            set
            {
                txtPassword.Text = value;
            }
        }
        public string FirstName
        {
            get
            {
                return textFirstName.Text;
            }
            set
            {
                textFirstName.Text = value;
            }
        }
        public string LastName
        {
            get
            {
                return textLastName.Text;
            }
            set
            {
                textLastName.Text = value;
            }
        }
        public void Inscription( string userName, string userPassword, string lastName, string firstName)
        {
            Game _game = new Game( userName, userPassword, lastName , firstName );
            //_game.GameToXml(_game);
            DateTime result = dateTimePicker1.Value;
            _game.SaveProfilToXML( result.ToShortDateString(), _game.Avatar, _game );
            SelectTeamForm ST = new SelectTeamForm( _game );
            ST.Show();
        }
    }
}
