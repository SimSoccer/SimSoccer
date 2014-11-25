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
        readonly TeamList _teamList;
   
        int i = 0;

        public SelectTeamForm()
        {
            
            InitializeComponent();
            
            
            _game = new Game();

            XDocument doc = XDocument.Load( @".\..\..\..\Ligue1Teams.xml" );
             _teamList = new TeamList( _game, doc.Root.Element( "Teams" ) );
             pictureBox1_Click( this, EventArgs.Empty );
            
        }

       
        private void Next_Click( object sender, EventArgs e )
        {

            if( i == (_teamList.Teams.Count) - 1 )
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
                i = (_teamList.Teams.Count) - 1;
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
            using( FileStream fs = new FileStream(_teamList.Teams[i].Logo, FileMode.Open ) )
            {
                Logo.Image = Image.FromStream( fs );
                teamName_TextChanged( this, EventArgs.Empty );
            }           
        }

        private void teamName_TextChanged( object sender, EventArgs e )
        {
            teamName.Text = _teamList.Teams[i].Name;
            teamStadium_TextChanged( this, EventArgs.Empty );
        }

        private void teamStadium_TextChanged( object sender, EventArgs e )
        {
            teamStadium.Text = _teamList.Teams[i].Stadium;
            PlayersBox_TextChanged( this, EventArgs.Empty );
        }

        private void buttoSelect_Click( object sender, EventArgs e )
        {
           /* UserControl1 aa = new UserControl1();
            aa.UserName = this._game.UserName;
            aa.UserPassword = this._game.UserPassword;
            Game game = new Game( teamName.Text, aa.UserName, aa.UserPassword );
            game.ToXML( teamName.Text, _game );*/

            _game.ChoosenTeam = _teamList.Teams[i].Name;
            this.Close();
            
        }
        
        private void PlayersBox_TextChanged( object sender, EventArgs e )
        {
            string Players = "";
            for( int cmpt = 0; cmpt < _teamList.Teams[i].TeamPlayers.Count; cmpt++ )
            {
                Players += _teamList.Teams[i].TeamPlayers[cmpt] + "\r\n";
            }
             
            PlayersBox.Text = Players;
        }

        
    }
}
