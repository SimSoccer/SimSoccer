using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sims.SimSoccerModel;
namespace SIMS.SimSoccerForm
{
    public partial class CheckPasswordForm : Form
    {
        readonly Game _game;
        LoadGameForm _lgf;
        public CheckPasswordForm(Game game, LoadGameForm lgf)
        {
            _game = game;
            _lgf = lgf;
            InitializeComponent();
            this.ActiveControl = txtCheckPassword;
        }

        private void btConnexion_Click( object sender, EventArgs e )
        {
            if( txtCheckPassword.Text == _game.UserPassword )
            {
                LobbyForm LB = new LobbyForm( _game );
                LB.Show();
                this.Close();
                _lgf.Close();
            }
            else
            {
                MessageBox.Show( "Password incorrect" );
                txtCheckPassword.Clear();
            }
        }

        private void CheckPasswordForm_Load( object sender, EventArgs e )
        {

        }

        private void CheckPasswordForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Enter )
            {
                btConnexion_Click( this, EventArgs.Empty );
            }
        }

        private void txtCheckPassword_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Enter )
            {
                btConnexion_Click( this, EventArgs.Empty );
            }
        }
    }
}
