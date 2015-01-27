using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIMS.SimSoccerForm
{
    public partial class StartPage : Form
    {
        int i = 0;
        SoundPlayer player1;
        int m = 0;
        List<string> songs;

        public StartPage()
        {
            InitializeComponent();
            songs = new List<string>();
            songs.Add( @".\..\..\..\Musics\Kid_Cudi_-_Pursuit_Of_Happiness_ft.wav" );
            songs.Add( @".\..\..\..\Musics\Kenny_Price_-_The_Shortest_Song_In_The_World.wav" );
            songs.Add( @".\..\..\..\Musics\HotNiggasInstrumental.wav" );
            songs.Add( @".\..\..\..\Musics\Kanka_-_Melomania.wav" );
            songs.Add( @".\..\..\..\Musics\Beyonc_-_Drunk_in_Love_Explicit_ft_.wav" );
            songs.Add( @".\..\..\..\Musics\drake-king-leon_hoodcelebritys.wav" );
            player1 = new SoundPlayer();
            player1.SoundLocation = songs[m];
        }

        private void StartPage_Load( object sender, EventArgs e )
        {
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            timer1.Start();
            this.DoubleBuffered = true;
            player1.Play();      
        }

        private void StartPage_Click( object sender, EventArgs e )
        {
            StartForm startForm = new StartForm();
            startForm.Show();
            this.Hide();
        }

        private void timer1_Tick( object sender, EventArgs e )
        {
            if( label1.Visible != false && i < 2 )
            {
                label1.Visible = false;
            }
            else if( label1.Visible == false && i >= 2 && i < 4 )
            {
                label1.Visible = true;
            }
            else if( i == 4 )
                i = 0;
            i++;

        }

        private void StartPage_KeyDown( object sender, KeyEventArgs key )
        {
            if( key.KeyCode == Keys.Enter )
            {
                StartForm startForm = new StartForm();
                startForm.Show();
                this.Hide();
            }
        }

        private void suivantToolStripMenuItem_Click( object sender, EventArgs e )
        {
            m++;
            if( m == songs.Count || m > songs.Count )
            {
                m = 0;
                player1.SoundLocation = songs[m];
                player1.Play();
            }
            else if( m < songs.Count )
            {
                player1.SoundLocation = songs[m];
                player1.Play();
            }
        }

        private void précédentToolStripMenuItem_Click( object sender, EventArgs e )
        {
            m--;
            if( m == 0 || m < 0 )
            {
                m = 0;
                player1.SoundLocation = songs[m];
                player1.Play();
            }
            else if( m > 0 )
            {
                player1.SoundLocation = songs[m];
                player1.Play();
            }
        }

        private void stopToolStripMenuItem_Click( object sender, EventArgs e )
        {
            player1.Stop();
        }
    }
}
