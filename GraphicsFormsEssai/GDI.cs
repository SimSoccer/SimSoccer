using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsFormsEssai
{
    public partial class GDI : Form
    {
        public GDI()
        {
            InitializeComponent();
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

        private void tmrAppTimer_Tick( object sender, EventArgs e )
        {
            this.Refresh();
        }
    }
}
