﻿using System;
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
        Team _searchedTeam;
        int i = 0;
        public TransfertsInterface(Game game)
        {
            _game = game;
            _teams = _game.TeamList.Teams;
            InitializeComponent();
            pictureBox2_Click( this, EventArgs.Empty );
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
            {
                i = 0;
            }
            else
            {
                i++;
            }

            pictureBox2_Click( this, EventArgs.Empty );
        }

        private void button1_Click( object sender, EventArgs e )
        {
            if( i == 0 )
            {
                i = ( _game.TeamList.Teams.Count ) - 1;
            }
            else
            {
                i--;
            }

            pictureBox2_Click( this, EventArgs.Empty );
        }

        private void pictureBox2_Click( object sender, EventArgs e )
        {
            using (FileStream fs = new FileStream(_game.TeamList.Teams[i].Logo, FileMode.Open))
            {
                pictureBox2.Image = Image.FromStream( fs );
                textBox3_TextChanged( this, EventArgs.Empty );
                textBox2_TextChanged( this, EventArgs.Empty );
            }
        }

        private void textBox2_TextChanged( object sender, EventArgs e )
        {
            string Players = string.Empty;

            for( int cmpt = 0; cmpt < _game.TeamList.Teams[i].TeamPlayers.Count; cmpt++ )
            {
                Players += _game.TeamList.Teams[i].TeamPlayers[cmpt].Name + "\r\n";
            }

            textBox2.Text = Players;
        }

        private void textBox3_TextChanged( object sender, EventArgs e )
        {
            string teamName = string.Empty;
            teamName = _game.TeamList.Teams[i].Name;
            textBox3.Text = teamName;
        }

    }
}
