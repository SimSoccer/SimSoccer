using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIMS.TeamsManagement
{
    public partial class SelectTeamForm : Form
    {
        public SelectTeamForm()
        {
            InitializeComponent();
        }

        private void button1_Click( object sender, EventArgs e )
        {

        }

        private void SelectTeamForm_Load( object sender, EventArgs e )
        {

        }

        private void pictureBox1_Click( object sender, EventArgs e )
        {
            using( FileStream fs = new FileStream( @"C:\Users\famille\Pictures\Sans titre.png", FileMode.Open ) )
            {
                Logo.Image = Image.FromStream( fs );
                teamName_TextChanged( this, EventArgs.Empty );
            }
            
            
        }

        private void teamName_TextChanged( object sender, EventArgs e )
        {
            teamName.Text = "équipe de merde";
            

        }
    }
}
