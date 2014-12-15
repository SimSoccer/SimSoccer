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

namespace SimulationMatchEssaie
{
    public partial class SoccerSimulator : Form
    {
        Game _game = new Game( "Toto", "Tata" );

        public SoccerSimulator()
        {
            InitializeComponent();
        }

        private void SoccerSimulator_Load( object sender, EventArgs e )
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
            #region Manage Drawn Field
            //Brushes the whole field in Green
            //Field f = new Field();
            e.Graphics.FillRectangle( Brushes.DarkGreen, 0, 0, _game.Field.FieldSize.Width, _game.Field.FieldSize.Heigth );

            // Show the field's boxes.
            foreach( Box p in _game.Field.Boxes )
            {
                e.Graphics.DrawRectangle( Pens.WhiteSmoke, p._x, p._y, p._size.Width, p._size.Heigth );
            }

            /*
            foreach( Points c in _game.Field.BoxCenterPoint )
            {
                e.Graphics.DrawRectangle( Pens.WhiteSmoke, c.X, c.Y, 1, 1 );
            }
            */
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
            Image player = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\images\PlayerOne.png" );
            Image ball = Image.FromFile( @"C:\Users\Guenole\Desktop\SimSoccer2\ball.png" );
            e.Graphics.DrawImage( player, _game.Field.MiddleField.X - 20, _game.Field.MiddleField.Y - 70, 35, 70 );
            e.Graphics.DrawImage( ball, _game.Field.MiddleField.X - 15, _game.Field.MiddleField.Y - 15, 20, 20 );

            #endregion

        }

    }
}
