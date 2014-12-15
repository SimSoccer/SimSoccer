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
        Game _game = new Game("Toto", "Tata");
        ListBox playerList = new ListBox();
        int c;
        Button b;
        Dictionary<string, Button> test = new Dictionary<string, Button>();
        public GDI()
        {
            InitializeComponent();
            for (int i = 0; i < _game.TeamList.Teams[8].TeamPlayers.Count; i++)
            {
                string players = _game.TeamList.Teams[8].TeamPlayers[i].Name;
                int shirtNumber = _game.TeamList.Teams[8].TeamPlayers[i].ShirtNumber;
                listBox1.Items.Add(shirtNumber + " " + Environment.NewLine + players);
                playerList.Items.Add(shirtNumber + " " + Environment.NewLine + players);
            }

        }

        private void GDI_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            this.Paint += new PaintEventHandler(GDI_Paint);
        }

        private void GDI_Paint(object sender, PaintEventArgs e)
        {
            //Brushes the whole field in Green
            //Field f = new Field();
            e.Graphics.FillRectangle(Brushes.DarkGreen, 0, 0, _game.Field.FieldSize.Width, _game.Field.FieldSize.Heigth);

            // Show the field's boxes.
            foreach (Box p in _game.Field.Boxes)
            {
                e.Graphics.DrawRectangle(Pens.WhiteSmoke, p._x, p._y, p._size.Width, p._size.Heigth);
            }

            foreach (Points c in _game.Field.BoxCenterPoint)
            {
                e.Graphics.DrawRectangle(Pens.WhiteSmoke, c.X, c.Y, 1, 1);
            }

            e.Graphics.DrawLine(Pens.Red, _game.Field.Zones.ThrowIn1[0].X, _game.Field.Zones.ThrowIn1[0].Y, _game.Field.Zones.ThrowIn1[10].X, _game.Field.Zones.ThrowIn1[10].Y);
            e.Graphics.DrawLine(Pens.Red, _game.Field.Zones.ThrowIn2[0].X, _game.Field.Zones.ThrowIn2[0].Y, _game.Field.Zones.ThrowIn2[10].X, _game.Field.Zones.ThrowIn2[10].Y);
            e.Graphics.DrawLine(Pens.Red, _game.Field.Zones.BehingGoalLine1[0].X, _game.Field.Zones.BehingGoalLine1[0].Y, _game.Field.Zones.BehingGoalLine1[6].X, _game.Field.Zones.BehingGoalLine1[6].Y);
            e.Graphics.DrawLine(Pens.Red, _game.Field.Zones.BehingGoalLine2[0].X, _game.Field.Zones.BehingGoalLine2[0].Y, _game.Field.Zones.BehingGoalLine2[6].X, _game.Field.Zones.BehingGoalLine2[6].Y);
        }

        private void restartFormationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                }
            }
        }

        private void tmrAppTimer_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by Guénolé K.", "4-4-2 losange window");
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string text = listBox1.GetItemText(listBox1.SelectedItem);
            b.Text = text;

            if (b.Text == "")
                b.Enabled = true;
            else if (b.Text == text)
                b.Enabled = false;

            listBox1.Items.Remove(text);
        }

        private void listBox1_MouseMove(object sender, MouseEventArgs e)
        {
            /* Point p = new Point( e.X, e.Y );
             int index;
             index = listBox1.IndexFromPoint( p );
             if( e.Button == MouseButtons.Left )
                 listBox1.DoDragDrop( listBox1.Items[index].ToString, DragDropEffects.All );*/
        }

        private void button1_DragDrop(object sender, DragEventArgs e)
        {
        }

        private void button1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void button_KeyDown(object sender, KeyEventArgs key)
        {
            // Button 1 Move
            if (key.KeyCode == Keys.Z && button1.Enabled == true)
            {
                button1.Top -= 50;
            }

            if (key.KeyCode == Keys.Q && button1.Enabled == true)
            {
                button1.Left -= 50;
            }

            if (key.KeyCode == Keys.D && button1.Enabled == true)
            {
                button1.Left += 50;
            }

            if (key.KeyCode == Keys.S && button1.Enabled == true)
            {
                button1.Top += 50;
            }

            //Button 2 Move
            if (key.KeyCode == Keys.Z && button1.Enabled == false && button2.Enabled == true)
            {
                button2.Top -= 50;
            }

            if (key.KeyCode == Keys.Q && button1.Enabled == false && button2.Enabled == true)
            {
                button2.Left -= 50;
            }

            if (key.KeyCode == Keys.D && button1.Enabled == false && button2.Enabled == true)
            {
                button2.Left += 50;
            }

            if (key.KeyCode == Keys.S && button1.Enabled == false && button2.Enabled == true)
            {
                button2.Top += 50;
            }

            //Button 3 Move
            if (key.KeyCode == Keys.Z && button2.Enabled == false && button3.Enabled == true)
            {
                button3.Top -= 50;
            }

            if (key.KeyCode == Keys.Q && button2.Enabled == false && button3.Enabled == true)
            {
                button3.Left -= 50;
            }

            if (key.KeyCode == Keys.D && button2.Enabled == false && button3.Enabled == true)
            {
                button3.Left += 50;
            }

            if (key.KeyCode == Keys.S && button2.Enabled == false && button3.Enabled == true)
            {
                button3.Top += 50;
            }

            //Button 4 Move
            if (key.KeyCode == Keys.Z && button3.Enabled == false && button4.Enabled == true)
            {
                button4.Top -= 50;
            }

            if (key.KeyCode == Keys.Q && button3.Enabled == false && button4.Enabled == true)
            {
                button4.Left -= 50;
            }

            if (key.KeyCode == Keys.D && button3.Enabled == false && button4.Enabled == true)
            {
                button4.Left += 50;
            }

            if (key.KeyCode == Keys.S && button3.Enabled == false && button4.Enabled == true)
            {
                button4.Top += 50;
            }

            //Button 5 Move
            if (key.KeyCode == Keys.Z && button4.Enabled == false && button5.Enabled == true)
            {
                button5.Top -= 50;
            }

            if (key.KeyCode == Keys.Q && button4.Enabled == false && button5.Enabled == true)
            {
                button5.Left -= 50;
            }

            if (key.KeyCode == Keys.D && button4.Enabled == false && button5.Enabled == true)
            {
                button5.Left += 50;
            }

            if (key.KeyCode == Keys.S && button4.Enabled == false && button5.Enabled == true)
            {
                button5.Top += 50;
            }

            //Button 6 Move
            if (key.KeyCode == Keys.Z && button5.Enabled == false && button6.Enabled == true)
            {
                button6.Top -= 50;
            }

            if (key.KeyCode == Keys.Q && button5.Enabled == false && button6.Enabled == true)
            {
                button6.Left -= 50;
            }

            if (key.KeyCode == Keys.D && button5.Enabled == false && button6.Enabled == true)
            {
                button6.Left += 50;
            }

            if (key.KeyCode == Keys.S && button5.Enabled == false && button6.Enabled == true)
            {
                button6.Top += 50;
            }

            //Button 7 Move
            if (key.KeyCode == Keys.Z && button6.Enabled == false && button7.Enabled == true)
            {
                button7.Top -= 50;
            }

            if (key.KeyCode == Keys.Q && button6.Enabled == false && button7.Enabled == true)
            {
                button7.Left -= 50;
            }

            if (key.KeyCode == Keys.D && button6.Enabled == false && button7.Enabled == true)
            {
                button7.Left += 50;
            }

            if (key.KeyCode == Keys.S && button6.Enabled == false && button7.Enabled == true)
            {
                button7.Top += 50;
            }

            //Button 8 Move
            if (key.KeyCode == Keys.Z && button7.Enabled == false && button8.Enabled == true)
            {
                button8.Top -= 50;
            }

            if (key.KeyCode == Keys.Q && button7.Enabled == false && button8.Enabled == true)
            {
                button8.Left -= 50;
            }

            if (key.KeyCode == Keys.D && button7.Enabled == false && button8.Enabled == true)
            {
                button8.Left += 50;
            }

            if (key.KeyCode == Keys.S && button7.Enabled == false && button8.Enabled == true)
            {
                button8.Top += 50;
            }

            //Button 9 Move
            if (key.KeyCode == Keys.Z && button8.Enabled == false && button9.Enabled == true)
            {
                button9.Top -= 50;
            }

            if (key.KeyCode == Keys.Q && button8.Enabled == false && button9.Enabled == true)
            {
                button9.Left -= 50;
            }

            if (key.KeyCode == Keys.D && button8.Enabled == false && button9.Enabled == true)
            {
                button9.Left += 50;
            }

            if (key.KeyCode == Keys.S && button8.Enabled == false && button9.Enabled == true)
            {
                button9.Top += 50;
            }

            //Button 10 Move
            if (key.KeyCode == Keys.Z && button9.Enabled == false && button10.Enabled == true)
            {
                button10.Top -= 50;
            }

            if (key.KeyCode == Keys.Q && button9.Enabled == false && button10.Enabled == true)
            {
                button10.Left -= 50;
            }

            if (key.KeyCode == Keys.D && button9.Enabled == false && button10.Enabled == true)
            {
                button10.Left += 50;
            }

            if (key.KeyCode == Keys.S && button9.Enabled == false && button10.Enabled == true)
            {
                button10.Top += 50;
            }

            //Button 11 Move
            if (key.KeyCode == Keys.Z && button10.Enabled == false && button10.Enabled == true)
            {
                button11.Top -= 50;
            }

            if (key.KeyCode == Keys.Q && button10.Enabled == false && button10.Enabled == true)
            {
                button11.Left -= 50;
            }

            if (key.KeyCode == Keys.D && button10.Enabled == false && button10.Enabled == true)
            {
                button11.Left += 50;
            }

            if (key.KeyCode == Keys.S && button10.Enabled == false && button10.Enabled == true)
            {
                button11.Top += 50;
            }
        }
    }
}