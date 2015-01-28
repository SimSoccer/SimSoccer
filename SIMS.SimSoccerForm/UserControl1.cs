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
using System.Threading;

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
            SplashForm splash = new SplashForm();
            splash.Show();
            splash.progressBar1.Value = 40;
            Thread.Sleep( 100 );
            Thread.Sleep( 100 );
            splash.progressBar1.Value = 50;
            Thread.Sleep( 100 );
            Thread.Sleep( 100 );
            Thread.Sleep( 100 );
            splash.progressBar1.Value = 60;
            Game _game = new Game( userName, userPassword, lastName, firstName );
            Thread.Sleep( 100 );
            splash.progressBar1.Value = 70;
            Thread.Sleep( 100 );
            splash.progressBar1.Value = 75;
            Thread.Sleep( 100 );
            Thread.Sleep( 100 );
            splash.progressBar1.Value = 90;
            Thread.Sleep( 100 );
            Thread.Sleep( 100 );
            splash.progressBar1.Value = 95;
            Thread.Sleep( 100 );
            Thread.Sleep( 100 );
            splash.progressBar1.Value = 98;
            Thread.Sleep( 100 );
            Thread.Sleep( 100 );
            splash.progressBar1.Value = 99;
            Thread.Sleep( 100 );
            Thread.Sleep( 100 );
            splash.progressBar1.Value = 100;
            DateTime result = dateTimePicker1.Value;
            _game.SaveProfilToXML( result.ToShortDateString(), _game.Avatar, _game );
            SelectTeamForm ST = new SelectTeamForm( _game );
            ST.Show();
            splash.Close();
        }
    }
}
