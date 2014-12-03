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
using System.Xml.Linq;
using Sims.SimSoccerModel;

namespace SIMS.SimSoccerForm
{
    public partial class SelectTeamForm : Form
    {
        readonly Game _game;
   
        int i = 0;

        public SelectTeamForm(Game game)
        {
            
            InitializeComponent();
            _game = game;
            pictureBox1_Click( this, EventArgs.Empty );
        }
       
        private void Next_Click( object sender, EventArgs e )
        {

            if( i == (_game.TeamList.Teams.Count) - 1 )
            {
                i = 0;
            }
            else
            {
                i++;
            }
            
            pictureBox1_Click( this, EventArgs.Empty );
        }

        private void Previous_Click( object sender, EventArgs e )
        {
            if( i == 0 )
            {
                i = (_game.TeamList.Teams.Count) - 1;
            }
            else
            {
                i--;
            }

            pictureBox1_Click( this, EventArgs.Empty );

        }

        private void SelectTeamForm_Load( object sender, EventArgs e )
        {
            
        }
        
        private void pictureBox1_Click( object sender, EventArgs e )
        {
            using( FileStream fs = new FileStream(_game.TeamList.Teams[i].Logo, FileMode.Open ) )
            {
                Logo.Image = Image.FromStream( fs );
                teamName_TextChanged( this, EventArgs.Empty );
            }           
        }

        private void teamName_TextChanged( object sender, EventArgs e )
        {
            teamName.Text = _game.TeamList.Teams[i].Name;
            teamStadium_TextChanged( this, EventArgs.Empty );
        }

        private void teamStadium_TextChanged( object sender, EventArgs e )
        {
            teamStadium.Text = _game.TeamList.Teams[i].Stadium;
            PlayersBox_TextChanged( this, EventArgs.Empty );
        }

        private void buttoSelect_Click( object sender, EventArgs e )
        {
            CalendarDisplay CD = new CalendarDisplay(_game);
            CD.Show();
            this.Close();
        }
        
        private void PlayersBox_TextChanged( object sender, EventArgs e )
        {
            string Players = "";
            for( int cmpt = 0; cmpt < _game.TeamList.Teams[i].TeamPlayers.Count; cmpt++ )
            {
                Players += _game.TeamList.Teams[i].TeamPlayers[cmpt].Name + "\r\n";
            }
             
            PlayersBox.Text = Players;
        }

        private void button1_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                Next_Click( this, EventArgs.Empty );
            
            } else if(e.KeyCode == Keys.Left || e.KeyCode == Keys.Q)
            {
                Previous_Click(this, EventArgs.Empty);
            }
        }
    }
}
