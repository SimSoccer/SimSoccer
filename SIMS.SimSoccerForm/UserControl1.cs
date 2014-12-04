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
        readonly Game _game;
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
        public void Inscription( string userName, string userPassword )
        {
            Game _game = new Game( userName, userPassword );
            _game.GameToXml(_game);
            SelectTeamForm ST = new SelectTeamForm( _game );
            ST.Show();
        }
    }
}
