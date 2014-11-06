using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           // MessageBox.Show( "Texte", "Titre", MessageBoxButtons.RetryCancel,
    //MessageBoxIcon.Error );
        }

        private void m_myTestButton_Click( object sender, EventArgs e )
        {
            
	m_myTestButton.Text = "Bha NON TAMER!";

        }

        private void textBox1_TextChanged( object sender, EventArgs e )
        {

        }

        private void label3_Click( object sender, EventArgs e )
        {

        }
    }
}
