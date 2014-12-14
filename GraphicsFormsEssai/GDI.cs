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
using System.Reflection;

namespace GraphicsFormsEssai
{
    public partial class GDI : Form
    {
        Game _game = new Game( "Toto", "Tata" );
        ListBox playerList = new ListBox();
        Dictionary<string, Button> test = new Dictionary<string, Button>();

        public GDI()
        {
            InitializeComponent();

            NewGDI( this );
        }

        private void NewGDI( GDI newone )
        {
            listBox1.Items.Add( "Joueurs de votre équipe : " );
            listBox2.Items.Add( "Titulaires : " );
            for( int i = 0; i < _game.TeamList.Teams[8].TeamPlayers.Count; i++ )
            {
                string players = _game.TeamList.Teams[8].TeamPlayers[i].Name;
                string shirtNumber = _game.TeamList.Teams[8].TeamPlayers[i].Poste;
                listBox1.Items.Add( shirtNumber + " " + Environment.NewLine + players );
                playerList.Items.Add( shirtNumber + " " + Environment.NewLine + players );
            }

            listBox1.Items.Add( "" );
            listBox1.Items.Add( "Zones : " );
            listBox1.Items.Add( "Violet => Goalkipper's Zone" );
            listBox1.Items.Add( "Blue => Defense players' Zone" );
            listBox1.Items.Add( "Pink => Middlefield players' Zone" );
            listBox1.Items.Add( "Red => Strikers' Zone" );

            button1.Text = "Gardien";
            button12.Text = "Recommencer";
            comboBox1.Text = "Formations";
        }

        private void GDI_Load( object sender, EventArgs e )
        {
            this.DoubleBuffered = true;
            this.Paint += new PaintEventHandler( GDI_Paint );
        }
        
        /// <summary>
        /// Draw the whole field in the form. Can show different points.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GDI_Paint( object sender, PaintEventArgs e )
        {
            //Brushes the whole field in Green
            //Field f = new Field();
            e.Graphics.FillRectangle( Brushes.DarkGreen, 0, 0, _game.Field.FieldSize.Width, _game.Field.FieldSize.Heigth );

            // Show the field's boxes.
            foreach( Box p in _game.Field.Boxes )
            {
                e.Graphics.DrawRectangle( Pens.WhiteSmoke, p._x, p._y, p._size.Width, p._size.Heigth );
            }

            foreach( Points c in _game.Field.BoxCenterPoint )
            {
                e.Graphics.DrawRectangle( Pens.WhiteSmoke, c.X, c.Y, 1, 1 );
            }

            #region Show Different Zones
            // Here you will be able to screen the zones

            /*
            // Here to show Goal Zone in the field
            foreach( Points c in _game.Field.Zones.GoalZonePoints )
            {
                e.Graphics.DrawRectangle( Pens.BlueViolet, c.X, c.Y, 1, 1 );
            }

            // Here to show Defense Zone in the field
            foreach( Points c in _game.Field.Zones.DefenseZonePoints )
            {
                e.Graphics.DrawRectangle( Pens.Blue, c.X, c.Y, 1, 1 );
            }

            // Here to show Middle Zone in the field
            foreach( Points c in _game.Field.Zones.MiddleZonePoints )
            {
                e.Graphics.DrawRectangle( Pens.White, c.X, c.Y, 1, 1 );
            }

            // Here to show Strike Zone in the field
            foreach( Points c in _game.Field.Zones.StrikeZonePoints )
            {
                e.Graphics.DrawRectangle( Pens.Red, c.X, c.Y, 1, 1 );
            }
            */
            #endregion

            // Draw the throw in lines and the behind goal lines.
            e.Graphics.DrawLine( Pens.Red, _game.Field.Zones.ThrowIn1[0].X, _game.Field.Zones.ThrowIn1[0].Y, _game.Field.Zones.ThrowIn1[10].X, _game.Field.Zones.ThrowIn1[10].Y );
            e.Graphics.DrawLine( Pens.Red, _game.Field.Zones.ThrowIn2[0].X, _game.Field.Zones.ThrowIn2[0].Y, _game.Field.Zones.ThrowIn2[10].X, _game.Field.Zones.ThrowIn2[10].Y );
            e.Graphics.DrawLine( Pens.Red, _game.Field.Zones.BehingGoalLine1[0].X, _game.Field.Zones.BehingGoalLine1[0].Y, _game.Field.Zones.BehingGoalLine1[6].X, _game.Field.Zones.BehingGoalLine1[6].Y );
            e.Graphics.DrawLine( Pens.Red, _game.Field.Zones.BehingGoalLine2[0].X, _game.Field.Zones.BehingGoalLine2[0].Y, _game.Field.Zones.BehingGoalLine2[6].X, _game.Field.Zones.BehingGoalLine2[6].Y );
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

        /// <summary>
        /// Add the selected player name in the chosen button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_click( object sender, EventArgs e )
        {
            Button b = ( Button )sender;
            string text = listBox1.GetItemText( listBox1.SelectedItem );
            b.Text = text;

            if( b.Text == "" )
                b.Enabled = true;
            else if( b.Text == text )
            {
                b.Enabled = false;
                listBox2.Items.Add( text );
                b.BackColor = Color.SaddleBrown;
            }
        }

        /// <summary>
        /// Move a button with Keys. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="key"></param>
        private void button_KeyDown( object sender, KeyEventArgs key )
        {
            #region Move Buttons
            // Button 1 Move
            if( key.KeyCode == Keys.Z && button1.Enabled == true )
            {
                button1.Top -= 50;
            }

            if( key.KeyCode == Keys.Q && button1.Enabled == true )
            {
                button1.Left -= 50;
            }

            if( key.KeyCode == Keys.D && button1.Enabled == true )
            {
                button1.Left += 50;
            }

            if( key.KeyCode == Keys.S && button1.Enabled == true )
            {
                button1.Top += 50;
            }

            //Button 2 Move
            if( key.KeyCode == Keys.Z && button1.Enabled == false && button2.Enabled == true )
            {
                button2.Top -= 50;
            }

            if( key.KeyCode == Keys.Q && button1.Enabled == false && button2.Enabled == true )
            {
                button2.Left -= 50;
            }

            if( key.KeyCode == Keys.D && button1.Enabled == false && button2.Enabled == true )
            {
                button2.Left += 50;
            }

            if( key.KeyCode == Keys.S && button1.Enabled == false && button2.Enabled == true )
            {
                button2.Top += 50;
            }

            //Button 3 Move
            if( key.KeyCode == Keys.Z && button2.Enabled == false && button3.Enabled == true )
            {
                button3.Top -= 50;
            }

            if( key.KeyCode == Keys.Q && button2.Enabled == false && button3.Enabled == true )
            {
                button3.Left -= 50;
            }

            if( key.KeyCode == Keys.D && button2.Enabled == false && button3.Enabled == true )
            {
                button3.Left += 50;
            }

            if( key.KeyCode == Keys.S && button2.Enabled == false && button3.Enabled == true )
            {
                button3.Top += 50;
            }

            //Button 4 Move
            if( key.KeyCode == Keys.Z && button3.Enabled == false && button4.Enabled == true )
            {
                button4.Top -= 50;
            }

            if( key.KeyCode == Keys.Q && button3.Enabled == false && button4.Enabled == true )
            {
                button4.Left -= 50;
            }

            if( key.KeyCode == Keys.D && button3.Enabled == false && button4.Enabled == true )
            {
                button4.Left += 50;
            }

            if( key.KeyCode == Keys.S && button3.Enabled == false && button4.Enabled == true )
            {
                button4.Top += 50;
            }

            //Button 5 Move
            if( key.KeyCode == Keys.Z && button4.Enabled == false && button5.Enabled == true )
            {
                button5.Top -= 50;
            }

            if( key.KeyCode == Keys.Q && button4.Enabled == false && button5.Enabled == true )
            {
                button5.Left -= 50;
            }

            if( key.KeyCode == Keys.D && button4.Enabled == false && button5.Enabled == true )
            {
                button5.Left += 50;
            }

            if( key.KeyCode == Keys.S && button4.Enabled == false && button5.Enabled == true )
            {
                button5.Top += 50;
            }

            //Button 6 Move
            if( key.KeyCode == Keys.Z && button5.Enabled == false && button6.Enabled == true )
            {
                button6.Top -= 50;
            }

            if( key.KeyCode == Keys.Q && button5.Enabled == false && button6.Enabled == true )
            {
                button6.Left -= 50;
            }

            if( key.KeyCode == Keys.D && button5.Enabled == false && button6.Enabled == true )
            {
                button6.Left += 50;
            }

            if( key.KeyCode == Keys.S && button5.Enabled == false && button6.Enabled == true )
            {
                button6.Top += 50;
            }

            //Button 7 Move
            if( key.KeyCode == Keys.Z && button6.Enabled == false && button7.Enabled == true )
            {
                button7.Top -= 50;
            }

            if( key.KeyCode == Keys.Q && button6.Enabled == false && button7.Enabled == true )
            {
                button7.Left -= 50;
            }

            if( key.KeyCode == Keys.D && button6.Enabled == false && button7.Enabled == true )
            {
                button7.Left += 50;
            }

            if( key.KeyCode == Keys.S && button6.Enabled == false && button7.Enabled == true )
            {
                button7.Top += 50;
            }

            //Button 8 Move
            if( key.KeyCode == Keys.Z && button7.Enabled == false && button8.Enabled == true )
            {
                button8.Top -= 50;
            }

            if( key.KeyCode == Keys.Q && button7.Enabled == false && button8.Enabled == true )
            {
                button8.Left -= 50;
            }

            if( key.KeyCode == Keys.D && button7.Enabled == false && button8.Enabled == true )
            {
                button8.Left += 50;
            }

            if( key.KeyCode == Keys.S && button7.Enabled == false && button8.Enabled == true )
            {
                button8.Top += 50;
            }

            //Button 9 Move
            if( key.KeyCode == Keys.Z && button8.Enabled == false && button9.Enabled == true )
            {
                button9.Top -= 50;
            }

            if( key.KeyCode == Keys.Q && button8.Enabled == false && button9.Enabled == true )
            {
                button9.Left -= 50;
            }

            if( key.KeyCode == Keys.D && button8.Enabled == false && button9.Enabled == true )
            {
                button9.Left += 50;
            }

            if( key.KeyCode == Keys.S && button8.Enabled == false && button9.Enabled == true )
            {
                button9.Top += 50;
            }

            //Button 10 Move
            if( key.KeyCode == Keys.Z && button9.Enabled == false && button10.Enabled == true )
            {
                button10.Top -= 50;
            }

            if( key.KeyCode == Keys.Q && button9.Enabled == false && button10.Enabled == true )
            {
                button10.Left -= 50;
            }

            if( key.KeyCode == Keys.D && button9.Enabled == false && button10.Enabled == true )
            {
                button10.Left += 50;
            }

            if( key.KeyCode == Keys.S && button9.Enabled == false && button10.Enabled == true )
            {
                button10.Top += 50;
            }

            //Button 11 Move
            if( key.KeyCode == Keys.Z && button10.Enabled == false && button10.Enabled == true )
            {
                button11.Top -= 50;
            }

            if( key.KeyCode == Keys.Q && button10.Enabled == false && button10.Enabled == true )
            {
                button11.Left -= 50;
            }

            if( key.KeyCode == Keys.D && button10.Enabled == false && button10.Enabled == true )
            {
                button11.Left += 50;
            }

            if( key.KeyCode == Keys.S && button10.Enabled == false && button10.Enabled == true )
            {
                button11.Top += 50;
            }
            #endregion
        }

        /// <summary>
        /// Chose a formation and change the buttons' position.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged( object sender, EventArgs e )
        {
            #region Cases' Gestion
            string formation = comboBox1.SelectedItem.ToString();
            string caseSwitch = formation;

            switch( caseSwitch )
            {
                case "4-4-2 losange":
                    button1.Location = new Point( 0, 275 );
                    button2.Location = new Point( 150, 475 );
                    button3.Location = new Point( 150, 375 );
                    button4.Location = new Point( 150, 175 );
                    button5.Location = new Point( 150, 75 );
                    button6.Location = new Point( 350, 275 );
                    button7.Location = new Point( 500, 125 );
                    button8.Location = new Point( 500, 425 );
                    button9.Location = new Point( 650, 275 );
                    button10.Location = new Point( 800, 175 );
                    button11.Location = new Point( 800, 375 );
                    break;
                case "4-4-2":
                    button1.Location = new Point( 0, 275 );
                    button2.Location = new Point( 150, 475 );
                    button3.Location = new Point( 150, 375 );
                    button4.Location = new Point( 150, 175 );
                    button5.Location = new Point( 150, 75 );
                    button6.Location = new Point( 400, 200 );
                    button7.Location = new Point( 500, 95 );
                    button8.Location = new Point( 400, 350 );
                    button9.Location = new Point( 500, 455 );
                    button10.Location = new Point( 800, 175 );
                    button11.Location = new Point( 800, 375 );
                    break;
                case "4-3-3":
                    button1.Location = new Point( 0, 275 );
                    button2.Location = new Point( 150, 475 );
                    button3.Location = new Point( 150, 375 );
                    button4.Location = new Point( 150, 175 );
                    button5.Location = new Point( 150, 75 );
                    button6.Location = new Point( 350, 275 );
                    button7.Location = new Point( 500, 175 );
                    button8.Location = new Point( 500, 375 );
                    button9.Location = new Point( 700, 475 );
                    button10.Location = new Point( 700, 75 );
                    button11.Location = new Point( 800, 275 );
                    break;
                case "4-2-3-1":
                    button1.Location = new Point( 0, 275 );
                    button2.Location = new Point( 150, 475 );
                    button3.Location = new Point( 150, 375 );
                    button4.Location = new Point( 150, 175 );
                    button5.Location = new Point( 150, 75 );
                    button6.Location = new Point( 350, 175 );
                    button7.Location = new Point( 350, 375 );
                    button8.Location = new Point( 600, 450 );
                    button9.Location = new Point( 600, 275 );
                    button10.Location = new Point( 600, 100 );
                    button11.Location = new Point( 800, 275 );
                    break;
                case "5-3-2":
                    button1.Location = new Point( 0, 275 );
                    button2.Location = new Point( 250, 500 );
                    button3.Location = new Point( 150, 375 );
                    button4.Location = new Point( 150, 175 );
                    button5.Location = new Point( 250, 50 );
                    button6.Location = new Point( 150, 275 );
                    button7.Location = new Point( 500, 125 );
                    button8.Location = new Point( 500, 425 );
                    button9.Location = new Point( 400, 275 );
                    button10.Location = new Point( 800, 175 );
                    button11.Location = new Point( 800, 375 );
                    break;
                case "5-4-1":
                    button1.Location = new Point( 0, 275 );
                    button2.Location = new Point( 250, 500 );
                    button3.Location = new Point( 150, 375 );
                    button4.Location = new Point( 150, 175 );
                    button5.Location = new Point( 250, 50 );
                    button6.Location = new Point( 150, 275 );
                    button7.Location = new Point( 550, 100 );
                    button8.Location = new Point( 400, 350 );
                    button9.Location = new Point( 400, 200 );
                    button10.Location = new Point( 550, 450 );
                    button11.Location = new Point( 800, 275 );
                    break;
                case "3-5-2":
                    button1.Location = new Point( 0, 275 );
                    button2.Location = new Point( 450, 450 );
                    button3.Location = new Point( 150, 375 );
                    button4.Location = new Point( 150, 275 );
                    button5.Location = new Point( 150, 175 );
                    button6.Location = new Point( 450, 200 );
                    button7.Location = new Point( 450, 100 );
                    button8.Location = new Point( 450, 350 );
                    button9.Location = new Point( 650, 275 );
                    button10.Location = new Point( 800, 175 );
                    button11.Location = new Point( 800, 375 );
                    break;
                default:
                    break;
            }
            #endregion
        }


        private void ManageListBox1WithButtonsPlayers()
        {
            string a = listBox1.SelectedItem.ToString();

            #region Mange listBox1 names
            if( a == button1.Text )
            {
                button1.Enabled = true;
                listBox2.Items.Remove( a );
                button1.BackColor = Color.Transparent;
                button1.Text = "Gardien";
            }
            if( a == button2.Text )
            {
                button2.Enabled = true;
                listBox2.Items.Remove( a );
                button2.BackColor = Color.Transparent;
                button2.Text = "";
            }
            if( a == button3.Text )
            {
                button3.Enabled = true;
                listBox2.Items.Remove( a );
                button3.BackColor = Color.Transparent;
                button3.Text = "";
            }
            if( a == button4.Text )
            {
                button4.Enabled = true;
                listBox2.Items.Remove( a );
                button4.BackColor = Color.Transparent;
                button4.Text = "";
            }
            if( a == button5.Text )
            {
                button5.Enabled = true;
                listBox2.Items.Remove( a );
                button5.BackColor = Color.Transparent;
                button5.Text = "";
            }
            if( a == button6.Text )
            {
                button6.Enabled = true;
                listBox2.Items.Remove( a );
                button6.BackColor = Color.Transparent;
                button6.Text = "";
            }
            if( a == button7.Text )
            {
                button7.Enabled = true;
                listBox2.Items.Remove( a );
                button7.BackColor = Color.Transparent;
                button7.Text = "";
            }
            if( a == button8.Text )
            {
                button8.Enabled = true;
                listBox2.Items.Remove( a );
                button8.BackColor = Color.Transparent;
                button8.Text = "";
            }
            if( a == button9.Text )
            {
                button9.Enabled = true;
                listBox2.Items.Remove( a );
                button9.BackColor = Color.Transparent;
                button9.Text = "";
            }
            if( a == button10.Text )
            {
                button10.Enabled = true;
                listBox2.Items.Remove( a );
                button10.BackColor = Color.Transparent;
                button10.Text = "";
            }
            if( a == button11.Text )
            {
                button11.Enabled = true;
                listBox2.Items.Remove( a );
                button11.BackColor = Color.Transparent;
                button11.Text = "";
            }
            #endregion
        }

        /// <summary>
        /// Re-activate the button if user want to change the player's position.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectedIndexChanged( object sender, EventArgs e )
        {
            ManageListBox1WithButtonsPlayers();
        }

        /// <summary>
        /// Reset the GDI in its initial form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button12_Click( object sender, EventArgs e )
        {
            foreach( Control c in this.Controls )
            {
                if( c is Button )
                {
                    Button b = ( Button )c;
                    b.Enabled = true;
                    b.Text = "";
                    b.BackColor = Color.White;
                }
                if( c is ListBox )
                {
                    ListBox l = ( ListBox )c;
                    l.Items.Clear();
                }
            }
            NewGDI( this );
        }

    }
}
