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
        LobbyForm _lobby;
        public UserProfilForm(Game game, LobbyForm lobby)
        {
            _game = game;
            _lobby = lobby;
            InitializeComponent();
            FirstNameText_TextChanged( this, EventArgs.Empty );
            textBox1_TextChanged( this, EventArgs.Empty );
            pictureBox1_Click( this, EventArgs.Empty );
            textBox2_TextChanged( this, EventArgs.Empty );
            textLastName_TextChanged( this, EventArgs.Empty );
            textFirstName_TextChanged( this, EventArgs.Empty );
        }

        

        private void FirstNameText_TextChanged( object sender, EventArgs e )
        {
            FirstNameText.Text = ""+_game.UserName;
        }

        private void textBox1_TextChanged( object sender, EventArgs e )
        {
            textBox1.Text = "" + _game.ChoosenTeam;
            textBox1.Width = (_game.ChoosenTeam.Length)*7;
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
                            _game.SaveProfilToXML( _game.BirthDate, openFileDialog1.FileName, _game );

                        }
                    }
                }
                catch( Exception ex )
                {
                    MessageBox.Show( "Error: Could not read file from disk. Original error: " + ex.Message );
                }
            }
        }

        private void btValidateProfilChanges_Click( object sender, EventArgs e )
        {
           
            
            _lobby.cmptProfil = 0;
            _game.SaveProfilToXML(_game.BirthDate,_game.Avatar, _game );

            this.Close();
        }

        private void UserProfilForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            _lobby.cmptProfil = 0;
        }

        private void textBox2_TextChanged( object sender, EventArgs e )
        {
            const double ApproxDaysPerYear = 365.25;
            DateTime thistime = DateTime.Now;
            DateTime oldtime = Convert.ToDateTime( _game.BirthDate );
            TimeSpan ts = thistime - oldtime;
            int differenceInYears = ts.Days;
            int iYear = (int)(differenceInYears / ApproxDaysPerYear);
            textBox2.Text = ""+iYear;
        }

        private void textLastName_TextChanged( object sender, EventArgs e )
        {
            textLastName.Text = "" + _game.LastName;
        }

        private void textFirstName_TextChanged( object sender, EventArgs e )
        {
            textFirstName.Text = "" + _game.FirstName;
        }

      
    }
}
