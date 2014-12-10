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
            //Brushes the whole field in Green
            Field f = new Field();
            e.Graphics.FillRectangle( Brushes.DarkGreen, 0, 0, f.FieldSize.Width, f.FieldSize.Heigth );

            // Show the field's boxes.
            foreach( Box p in f.Boxes )
            {
                e.Graphics.DrawRectangle( Pens.WhiteSmoke, p._x, p._y, p._size.Width, p._size.Heigth );
            }

            foreach( Points c in f.BoxCenterPoint )
            {
                e.Graphics.DrawRectangle( Pens.WhiteSmoke, c.X, c.Y, 1, 1 );
            }

            Points one = new Points(1000,600);
            if( f.Zones.ThrowIn1.Contains( one ) )
            {
                listBox1.Items.Add( true );
            }
            e.Graphics.DrawLine( Pens.Red, f.Zones.ThrowIn1[0].X, f.Zones.ThrowIn1[0].Y, f.Zones.ThrowIn1[10].X, f.Zones.ThrowIn1[10].Y );
            e.Graphics.DrawLine( Pens.Red, f.Zones.ThrowIn2[0].X, f.Zones.ThrowIn2[0].Y, f.Zones.ThrowIn2[10].X, f.Zones.ThrowIn2[10].Y );
            e.Graphics.DrawLine( Pens.Red, f.Zones.BehingGoalLine1[0].X, f.Zones.BehingGoalLine1[0].Y, f.Zones.BehingGoalLine1[6].X, f.Zones.BehingGoalLine1[6].Y );
            e.Graphics.DrawLine( Pens.Red, f.Zones.BehingGoalLine2[0].X, f.Zones.BehingGoalLine2[0].Y, f.Zones.BehingGoalLine2[6].X, f.Zones.BehingGoalLine2[6].Y );
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

        private void button1_KeyDown( object sender, KeyEventArgs key )
        {
            if( key.KeyCode == Keys.Z)
            {
                button1.Top -= 100;
            }

            if( key.KeyCode == Keys.Q )
            {
                button1.Left -= 100;
            }

            if( key.KeyCode == Keys.D )
            {
                button1.Left += 100;
            }

            if( key.KeyCode == Keys.S )
            {
                button1.Top += 100;
            }
            if( key.KeyCode == Keys.Z && button1.Enabled == false)
            {
                button2.Top -= 100;
            }

            if( key.KeyCode == Keys.Q && button1.Enabled == false )
            {
                button2.Left -= 100;
            }

            if( key.KeyCode == Keys.D && button1.Enabled == false )
            {
                button2.Left += 100;
            }

            if( key.KeyCode == Keys.S && button1.Enabled == false )
            {
                button2.Top += 100;
            }
        }

        private void listBox1_MouseMove( object sender, MouseEventArgs e )
        {
           /* Point p = new Point( e.X, e.Y );
            int index;
            index = listBox1.IndexFromPoint( p );
            if( e.Button == MouseButtons.Left )
                listBox1.DoDragDrop( listBox1.Items[index].ToString, DragDropEffects.All );*/
        }

        private void button1_DragDrop( object sender, DragEventArgs e )
        {
        }

        private void button1_DragEnter( object sender, DragEventArgs e )
        {
            e.Effect = DragDropEffects.All;
        }
    }
}
