using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIMS.UserManagment
{
    public partial class FormInscription : Form
    {
        
        public FormInscription()
        {
            InitializeComponent();
            

        }

        private void btValider_Click( object sender, EventArgs e )
        {
            userControl1.Inscription( "cuchot", "123456" );


        }

        private void btLire_Click( object sender, EventArgs e )
        {
            MessageBox.Show( "Name : " + userControl1.UserName + " - Password : " + userControl1.UserPassword );
        }

        


        
        
    }
}
