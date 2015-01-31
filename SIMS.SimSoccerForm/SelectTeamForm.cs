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
            pictureBox1_Click(this, EventArgs.Empty);
        }

        private void Next_Click(object sender, EventArgs e)
        {

            if (i == (_game.TeamList.Teams.Count) - 1)
            {
                i = 0;
            }
            else
            {
                i++;
            }

            pictureBox1_Click(this, EventArgs.Empty);
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                i = (_game.TeamList.Teams.Count) - 1;
            }
            else
            {
                i--;
            }

            pictureBox1_Click(this, EventArgs.Empty);

        }

        private void SelectTeamForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream(_game.TeamList.Teams[i].Logo, FileMode.Open))
            {
                Logo.Image = Image.FromStream(fs);
                teamName_TextChanged(this, EventArgs.Empty);
            }
        }

        private void teamName_TextChanged(object sender, EventArgs e)
        {
            teamName.Text = _game.TeamList.Teams[i].Name;
            teamStadium_TextChanged(this, EventArgs.Empty);
        }

        private void teamStadium_TextChanged(object sender, EventArgs e)
        {
            teamStadium.Text = _game.TeamList.Teams[i].Stadium;
            PlayersBox_TextChanged(this, EventArgs.Empty);
            textBox3_TextChanged( this, EventArgs.Empty );
        }

        private void buttoSelect_Click(object sender, EventArgs e)
        {
            _game.ToXML(_game.TeamList.Teams[i].Name, _game);
            LobbyForm LF = new LobbyForm(_game);
            LF.Show();

            this.Close();
        }

        private void PlayersBox_TextChanged(object sender, EventArgs e)
        {
            string Players = string.Empty;
            for (int cmpt = 0; cmpt < _game.TeamList.Teams[i].TeamPlayers.Count; cmpt++)
            {
                Players += _game.TeamList.Teams[i].TeamPlayers[cmpt].Name + "\r\n";
            }

            PlayersBox.Text = Players;
            textBox1_TextChanged(this, EventArgs.Empty);
            textBox4_TextChanged( this, EventArgs.Empty );
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                Next_Click(this, EventArgs.Empty);

            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Q)
            {
                Previous_Click(this, EventArgs.Empty);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string Players2 = string.Empty;
            for (int cmpt = 0; cmpt < _game.TeamList.Teams[i].TeamType.Count; cmpt++)
            {
                Players2 += _game.TeamList.Teams[i].TeamType[cmpt].Name + "\r\n";
            }
            textBox1.Text = Players2;
        }

        private void textBox3_TextChanged( object sender, EventArgs e )
        {
            textBox3.Text = _game.TeamList.Teams[i].Level.ToString();
        }

        private void textBox4_TextChanged( object sender, EventArgs e )
        {
            foreach( Team t in _game.TeamList.Teams )
            {
                if( _game.TeamList.Teams[i].Name == t.Name )
                {
                    #region Cases' Gestion
                    int objectif = t.Objectif;

                    switch( objectif )
                    {
                        case 1:
                            textBox4.Text = "C'est champion ou rien !";
                            break;
                        case 2:
                            textBox4.Text = "Ici, nous jouons pour être dans les 3 premiers, être en Champion's League.";
                            break;
                        case 3:
                            textBox4.Text = "Vous devez être dans les 5 premiers. L'Europa League nous attend.";
                            break;
                        case 4:
                            textBox4.Text = "Allez, nous voulons le haut du tableau, les 10 premières place.";
                            break;
                        case 5:
                            textBox4.Text = "Soyons honnêtes et modestes, essayons d'être entre la 10e et 15e place.";
                            break;
                        case 6:
                            textBox4.Text = "Évitons la zone rouge pour être sauvés ! Évitions les 3 dernières places !";
                            break;
                        default:
                            break;
                    #endregion
                    }

                }
            }
        }
    }
}