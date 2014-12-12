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
    public partial class LobbyForm : Form
    {
        readonly Game _game;
        public LobbyForm(Game game)
        {
            _game = game;
            
            InitializeComponent();
            txtUsernameLobby_TextChanged(this, EventArgs.Empty);
        }

        private void txtUsernameLobby_TextChanged( object sender, EventArgs e )
        {
            txtUsernameLobby.Text = "Bonjour "+_game.UserName;
        }

        private void btGoToCalendar_Click( object sender, EventArgs e )
        {
            
            CalendarDisplay CD = new CalendarDisplay(_game);
            CD.Show(); 
        }

        private void exitToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Application.Exit();
        }

        private void profilToolStripMenuItem_Click( object sender, EventArgs e )
        {
            UserProfilForm UPF = new UserProfilForm( _game );
            UPF.Show();
        }
    }
}
