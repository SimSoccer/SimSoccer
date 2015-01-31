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
using System.Xml.Linq;

namespace SIMS.SimSoccerForm
{
    public partial class LobbyForm : Form
    {
        Game _game;
        
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

            _game.SaveTheGame( _game.Journey );
            //_game.SaveProfilToXML( _game.BirthDate, _game.Avatar, _game, _game.Journey );
            Application.Exit();
        }

        public void currentJourney_TextChanged( object sender, EventArgs e )
        {
            currentJourney.Text = "journée " + (_game.Journey + 1);
        }

        private void playJourney_Click( object sender, EventArgs e )
        {
            if( _game.GameOver == false )
            {
                _game.Ligue.Calendar.MatchDay[_game.Journey].playJourney();
                ShowResult SR = new ShowResult( _game, this );
                SR.Show();
                _game.Ranking.getRanking();
            }
            else if( _game.GameOver == true && _game.Reached == false )
            {
                MessageBox.Show( "Vous avez perdu !!!! Objectifs, non atteints ! Game Over.." );
            }
            else if( _game.GameOver == true && _game.Reached == true )
            {
                int season = _game.Season + 1;
                DateTime today = DateTime.Now;
                XDocument doc = XDocument.Load( @".\..\..\..\user_" + _game.UserName + "_save_" + today.Year + today.Month + today.Day + ".xml" );
                _game = new Game( _game.UserName, _game.UserPassword, _game.LastName, _game.FirstName, season, doc.Root, _game.ChoosenTeam );
                LobbyForm f = new LobbyForm( _game );
                f.Show();
                this.Close();
            }
        }

        private void btFormation_Click( object sender, EventArgs e )
        {
            Formation formation = new Formation( _game );
            formation.Show();
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
