using Sims.SimSoccerModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIMS.SimSoccerForm
{
    public partial class FormInscription : Form
    {
        /* readonly Game _game;
         readonly TeamList _teamList;
         readonly PlayerList _playerList;*/
        public FormInscription()
        {
            InitializeComponent();
            

        }
        
        private void btValider_Click( object sender, EventArgs e )
        {
            if( userControl1.UserName.Length == 0 || userControl1.UserPassword.Length == 0)
            {
                MessageBox.Show( "Veuillez entrer un nom d'utilisateur et un mot de passe." );
                userControl1.UserName = "";
                userControl1.UserPassword = "";
            }
            else if( userControl1.UserName.Length < 3 )
            {
                MessageBox.Show( "Nom d'utilisateur trop court. Minimum 3 caractères." );
                userControl1.UserName = "";
            }
            else if( userControl1.UserPassword.Length < 6 )
            {
                MessageBox.Show( "Mot de passe trop court. Minimum 6 caractères." );
                userControl1.UserPassword = "";
                
            }
            else
            {
                userControl1.Inscription( userControl1.UserName, userControl1.UserPassword , userControl1.LastName, userControl1.FirstName);
                this.Hide();
            }
        }

        private void button1_Click( object sender, EventArgs e )
        {
            StartForm startForm = new StartForm();
            startForm.Show();
            this.Close();
        }
    }
}
