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

           /*for( int t = 0; t < f.Points.Count; t++ )
                listBox1.Items.Add( f.Points[t].X + ", " + f.Points[t].Y );*/

            listBox1.Items.Add( f.Points.Count );
            listBox1.Items.Add( f.Points[1].X + ", " + f.Points[8].Y );


                
        }

        private void GDI_Load( object sender, EventArgs e )
        {
            this.DoubleBuffered = true;
            this.Paint += new PaintEventHandler(GDI_Paint);
        }

        private void GDI_Paint( object sender, PaintEventArgs e )
        {
            Pen whitePen = new Pen( Color.White, 5 );
            e.Graphics.FillRectangle( Brushes.DarkGreen, 120, 3, 1100, 700 );
            e.Graphics.DrawRectangle( whitePen, 120, 3, 1100, 700 );
            e.Graphics.DrawRectangle( whitePen, new Rectangle( 120, 260, 55, 150 ) );
            e.Graphics.DrawRectangle( whitePen, 1055, 150, 165, 403 );
            e.Graphics.DrawRectangle( whitePen, new Rectangle( 1164, 260, 55, 150 ) );
            e.Graphics.DrawRectangle( whitePen, 120, 150, 165, 403 );
            e.Graphics.DrawEllipse( whitePen, 570, 235, 200, 200 );
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

        private void listBox1_DragDrop( object sender, DragEventArgs e )
        {

        }

        private void listBox1_Click( object sender, EventArgs e )
        {
            
        }

    }
}
