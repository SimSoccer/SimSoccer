﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphicsFormsEssai;
using Sims.SimSoccerModel;

namespace SIMS.SimSoccerForm
{
    public partial class LobbyForm : Form
    {
        readonly Game _game;
        
        
        public int cmptCalendar = 0;
        public int cmptProfil = 0;
        public LobbyForm( Game game )
        {
            _game = game;
            InitializeComponent();
            txtUsernameLobby_TextChanged( this, EventArgs.Empty );
            currentJourney_TextChanged( this, EventArgs.Empty );
        }

        private void txtUsernameLobby_TextChanged( object sender, EventArgs e )
        {
            txtUsernameLobby.Text = "Bonjour " + _game.UserName;
        }

       

        private void exitToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Application.Exit();
        }

        

        private void btOpenProfile_Click( object sender, EventArgs e )
        {
            if( cmptProfil == 0 )
            {
                UserProfilForm UPF = new UserProfilForm( _game, this );
                UPF.Show();
                cmptProfil++;
            }
            else
            {
                MessageBox.Show( "Le profil est déjà ouvert." );
            }
        }

        private void btOpenCalendar_Click( object sender, EventArgs e )
        {
            if( cmptCalendar == 0 )
            {
                CalendarDisplay CD = new CalendarDisplay( _game, this );
                CD.Show();
                cmptCalendar++;
            }
            else
            {
                MessageBox.Show( "Le calendrier est déjà ouvert." );
            }
        }

        private void btExit_Click( object sender, EventArgs e )
        {

            _game.SaveTheGame();
            Application.Exit();
        }

        public void currentJourney_TextChanged( object sender, EventArgs e )
        {
            currentJourney.Text = "journée " + (_game.Journey + 1);
        }

        private void playJourney_Click( object sender, EventArgs e )
        {
            _game.Ligue.Calendar.MatchDay[_game.Journey].playJourney();
            ShowResult SR = new ShowResult( _game, this );
            SR.Show();
        }

        private void btFormation_Click( object sender, EventArgs e )
        {
            GDI myGDI = new GDI( _game );
            myGDI.Show();
        }

        private void transfertsToolStripMenuItem_Click( object sender, EventArgs e )
        {
            TransfertsInterface transfertInterface = new TransfertsInterface(_game);
            transfertInterface.Show();
        }

        private void btOpenRanking_Click( object sender, EventArgs e )
        {
            RankingDisplay RD = new RankingDisplay(_game, this);
            RD.Show();
        }
    }
}
