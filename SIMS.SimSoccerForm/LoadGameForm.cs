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
using Sims.SimSoccerModel;

namespace SIMS.SimSoccerForm
{
    public partial class LoadGameForm : Form
    {
        readonly Game _game;
       // List<string> _items = new List<string>();
        public LoadGameForm(Game game)
        {
            InitializeComponent();

            _game = game;


            string folderPath = @".\..\..\..\";
            DirectoryInfo dir = new DirectoryInfo( folderPath );
            FileInfo[] files = dir.GetFiles( "user_*", SearchOption.TopDirectoryOnly );

            string[] fileNames = files.Select( f => f.Name ).ToArray();
            
            for( int i = 0; i < files.Length; i++ )
                listBox1.Items.Add( files[i] );
            
            listBox1.DataSource = _game;
            
                       
        }

        private void btBackToStartForm_Click( object sender, EventArgs e )
        {
            StartForm SF = new StartForm();
            SF.Show();
            this.Close();
        }

        private void btLoadGame_Click( object sender, EventArgs e )
        {

        }



        
    }
}
