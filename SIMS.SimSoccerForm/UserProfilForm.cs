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
    public partial class UserProfilForm : Form
    {
        readonly Game _game;
        public UserProfilForm(Game game)
        {
            _game = game;
            InitializeComponent();
            FirstNameText_TextChanged( this, EventArgs.Empty );
            textBox1_TextChanged( this, EventArgs.Empty );
            pictureBox1_Click( this, EventArgs.Empty );
        }

        private void FirstNameText_TextChanged( object sender, EventArgs e )
        {
            FirstNameText.Text = ""+_game.UserName;
        }

        private void textBox1_TextChanged( object sender, EventArgs e )
        {
            textBox1.Text = "" + _game.ChoosenTeam;
            this.AutoSize = true;    
        }

        private void pictureBox1_Click( object sender, EventArgs e )
        {
            this.pictureBox1.Image = Image.FromFile( _game.Avatar ); 

        }

        private void btChangeAvatar_Click( object sender, EventArgs e )
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter= "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
           // openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if( openFileDialog1.ShowDialog() == DialogResult.OK )
            {
                try
                {
                    if( (myStream = openFileDialog1.OpenFile()) != null )
                    {
                        using( myStream )
                        {
                            Image image = Image.FromFile( openFileDialog1.FileName );
                            pictureBox1.Image = image;
                            _game.SaveAvatarToXML( openFileDialog1.FileName, _game );

                        }
                    }
                }
                catch( Exception ex )
                {
                    MessageBox.Show( "Error: Could not read file from disk. Original error: " + ex.Message );
                }
            }
        }

      
    }
}
