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
    public partial class StartForm : Form
    {
        readonly Game _game;
        public StartForm()
        {
            InitializeComponent();
        }

        private void btGoToInscrForm_Click(object sender, EventArgs e)
        {
            FormInscription uc = new FormInscription();
            uc.Show();
            this.Hide();
        }

        private void btGoToLoadGameForm_Click(object sender, EventArgs e)
        {
            LoadGameForm LG = new LoadGameForm(_game);
            LG.Show();
            this.Hide();
        }

        private void pictureBox1_Click( object sender, EventArgs e )
        {
            FormInscription uc = new FormInscription();

            uc.Show();
            this.Hide();
        }

        private void pictureBox2_Click( object sender, EventArgs e )
        {
            LoadGameForm LG = new LoadGameForm( _game );
            LG.Show();
            this.Hide();
        }

        private void quitterLeJeuToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Application.Exit();
        }

        private void qToolStripMenuItem_Click( object sender, EventArgs e )
        {
            MessageBox.Show( "Équipe composée de Guénolé Tout Seul. La Base", "About" );
        }
    }
}
