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
using System.IO;

namespace SIMS.SimSoccerForm
{
    public partial class TransfertsInterface : Form
    {
        readonly Game _game;
        readonly IReadOnlyCollection<Team> _teams;
        Team _selectedTeam;
        Team _myTeam;
        int i = 0;
        public TransfertsInterface(Game game)
        {
            _game = game;
            _teams = _game.TeamList.Teams;

            foreach( Team t in _teams )
                if( t.Name == _game.ChoosenTeam )
                    _myTeam = t;


            InitializeComponent();
            pictureBox2_Click( this, EventArgs.Empty );
            foreach( Player p in _myTeam.TeamPlayers )
                listBox2.Items.Add( p.Name );

            using( FileStream fs = new FileStream( _myTeam.Logo, FileMode.Open ) )
            {
                pictureBox3.Image = Image.FromStream( fs );
            }

            textBox1.Text = _myTeam.Name;
            textBox2.Text = _myTeam.Budget.ToString();
        }

        private void pictureBox1_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void textBox1_KeyDown( object sender, KeyEventArgs key )
        {
        }

        private void button2_Click( object sender, EventArgs e )
        {
            if( i == ( _game.TeamList.Teams.Count ) - 1 )
                i = 0;
            else
                i++;
            if( _myTeam.Id == i )
                i++;

            pictureBox2_Click( this, EventArgs.Empty ); 
        }

        private void button1_Click( object sender, EventArgs e )
        {
            if( i == 0 )
                i = ( _game.TeamList.Teams.Count ) - 1;
            else
                i--;
            if( _myTeam.Id == i )
                i--;

            pictureBox2_Click( this, EventArgs.Empty );
        }

        private void pictureBox2_Click( object sender, EventArgs e )
        {
            using (FileStream fs = new FileStream(_game.TeamList.Teams[i].Logo, FileMode.Open))
            {
                pictureBox2.Image = Image.FromStream( fs );
                textBox3_TextChanged( this, EventArgs.Empty );
                textBox2_TextChanged( this, EventArgs.Empty );
                textBox4_TextChanged( this, EventArgs.Empty );
            }
        }

        private void textBox2_TextChanged( object sender, EventArgs e )
        { 
            listBox1.Items.Clear();
            foreach( Player p in _game.TeamList.Teams[i].TeamPlayers)
                listBox1.Items.Add( p.Name );
        }

        private void textBox4_TextChanged( object sender, EventArgs e )
        {
            textBox4.Text = _game.TeamList.Teams[i].Budget.ToString();
        }

        private void textBox3_TextChanged( object sender, EventArgs e )
        {
            string teamName = string.Empty;
            teamName = _game.TeamList.Teams[i].Name;
            textBox3.Text = teamName;
            _selectedTeam = _game.TeamList.Teams[i];
        }

        private void button3_Click( object sender, EventArgs e )
        {
            if( listBox1.SelectedItem == null)
                MessageBox.Show( "Veuillez sélectionner un joueur s'il vous plaît.", "Attention!" );
            else
            {
                string playerName = listBox1.SelectedItem.ToString();
                string teamName = textBox3.Text;
                _selectedTeam.TransferPlayer( playerName, _selectedTeam.Name );
            } 

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            textBox2.Clear();
            textBox4.Clear();
            _game.TeamList.Teams.OrderBy( n => n.Id );

            foreach( Player p in _game.TeamList.Teams[i].TeamPlayers )
                listBox1.Items.Add( p.Name );

            foreach( Player p2 in _myTeam.TeamPlayers )
                listBox2.Items.Add( p2.Name );
            textBox2.Text = _myTeam.Budget.ToString();

            textBox4.Text = _game.TeamList.Teams[i].Budget.ToString();
        }
    }
}
