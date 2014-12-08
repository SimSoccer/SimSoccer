using Sims.SimSoccerModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GraphicsFormsEssai
{
    public partial class GDI : Form
    {
        Game _game = new Game( "Toto", "Tata" );
        ListBox playerList = new ListBox();
        public GDI()
        {
            InitializeComponent();


            for( int i = 0; i < _game.TeamList.Teams[15].TeamPlayers.Count; i++ ) 
            {
                string players = _game.TeamList.Teams[15].TeamPlayers[i].Name;
                int shirtNumber = _game.TeamList.Teams[15].TeamPlayers[i].ShirtNumber;
                listBox1.Items.Add( shirtNumber + " " + Environment.NewLine  + players );
                playerList.Items.Add( shirtNumber + " " + Environment.NewLine + players );
            }

            Field f = new Field();
            listBox1.Items.Add( f.Boxes.Count );
            listBox1.Items.Add( f.BoxPoints.Count );
            listBox1.Items.Add( f.AllPoints.Count );

        }

        private void GDI_Load( object sender, EventArgs e )
        {
            this.DoubleBuffered = true;
            this.Paint += new PaintEventHandler(GDI_Paint);
        }

        private void GDI_Paint( object sender, PaintEventArgs e )
        {
             Field f = new Field();
             e.Graphics.FillRectangle( Brushes.DarkGreen, 0, 0, f.FieldSize.Width, f.FieldSize.Heigth );

             for( int t = 0; t < f.AllPoints.Count; t++ )
                 e.Graphics.DrawRectangle( Pens.Black, f.AllPoints[t].X, f.AllPoints[t].Y, 1,1 );

             foreach( Box c in f.Boxes )
             {
                 e.Graphics.DrawRectangle( Pens.WhiteSmoke, c._x, c._y, c._size.Width, c._size.Heigth );
             }
        }

        private void restartFormationToolStripMenuItem_Click( object sender, EventArgs e )
        {
            foreach( Control c in this.Controls )
            {
                if( c is Button )
                {
                    Button b = ( Button )c;
                    b.Enabled = true;
                }
            }
        }

        private void tmrAppTimer_Tick( object sender, EventArgs e )
        {
            this.Refresh();
        }

        private void exitToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem1_Click( object sender, EventArgs e )
        {
            MessageBox.Show( "Made by Guénolé K.", "4-4-2 losange window" );
        }

        private void button_click( object sender, EventArgs e )
        {
            Button b = ( Button )sender;
            string text = listBox1.GetItemText( listBox1.SelectedItem );
            b.Text = text;

            if( b.Text == "" )
                b.Enabled = true;
            else if( b.Text == text )
                b.Enabled = false;

            listBox1.Items.Remove( text );
        }
    }
}
