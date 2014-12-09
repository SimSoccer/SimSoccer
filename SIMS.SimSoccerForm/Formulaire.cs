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
        /*readonly Game _game;
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
                MessageBox.Show( "Please enter an UserName and an UserPassword." );
            }
            else
            {
                userControl1.Inscription( userControl1.UserName, userControl1.UserPassword );
                this.Hide();
            }
        }
    }
}
