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

namespace SIMS.UserManagment
{
    [Serializable]
    public partial class UserControl1 : UserControl 
    {
        
        public UserControl1()
        {
            InitializeComponent();
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

            UserControl1 uc = new UserControl1();
            uc.UserName = userName;
            uc.UserPassword = userPassword;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream( "MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None );
            formatter.Serialize( stream, uc );
            stream.Close();
            //this.UserName = userName;
            //this.UserPassword = userPassword;
    
        }
    }
}
