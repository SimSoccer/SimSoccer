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

        private void btGoToInscrForm_Click( object sender, EventArgs e )
        {
            FormInscription uc = new FormInscription();

            uc.Show();
            this.Hide();
            
        }

        private void btGoToLoadGameForm_Click( object sender, EventArgs e )
        {
            LoadGameForm LG = new LoadGameForm(_game);
            LG.Show();
            this.Hide();
        }
    }
}
