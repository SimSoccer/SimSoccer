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

namespace SIMS.SimSoccerForm
{
    public partial class RankingDisplay : Form
    {

        readonly Game _game;
        LobbyForm _lobby;

        public RankingDisplay(Game game, LobbyForm lobby)
        {
            InitializeComponent();
            _game = game;

            Dictionary<string, int> board = new Dictionary<string,int>();

           board = game.Ranking.getRanking();
           int j = 1;
           foreach( KeyValuePair<string,int> item in board )
           {
               dataGridView1.Rows.Add( item.Key, item.Value, j );
               j++;
           }

           dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.YellowGreen;
           dataGridView1.Rows[1].DefaultCellStyle.BackColor = Color.YellowGreen;
           dataGridView1.Rows[2].DefaultCellStyle.BackColor = Color.YellowGreen;

           dataGridView1.Rows[17].DefaultCellStyle.BackColor = Color.OrangeRed;
           dataGridView1.Rows[18].DefaultCellStyle.BackColor = Color.OrangeRed;
           dataGridView1.Rows[19].DefaultCellStyle.BackColor = Color.OrangeRed;

           if( dataGridView1.RowCount > 0 && dataGridView1.ColumnCount > 0 )
           {
               dataGridView1.CurrentCell = this.dataGridView1[0, 0];
               this.dataGridView1.CurrentCell.Selected = false;
           }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
