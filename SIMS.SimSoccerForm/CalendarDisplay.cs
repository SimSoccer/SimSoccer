using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIMS.SimSoccerForm;
using Sims.SimSoccerModel;

namespace SIMS.SimSoccerForm
{
    public partial class CalendarDisplay : Form
    {
        public CalendarDisplay()
        {
            InitializeComponent();

            Ligue ligue1 = new Ligue();

            ligue1.CreateTeam();
            ligue1.fillCalendar();

            foreach( Journee j in ligue1.Calendar.Journees )
                Cjournee.Items.Add( j );

            Cjournee.SelectedIndex = 0;
        }

        private void Cjournee_SelectedIndexChanged( object sender, EventArgs e )
        {
            TMatchs.Text = string.Empty;

            Journee j = Cjournee.Items[Cjournee.SelectedIndex] as Journee;

            if( j != null )
            {

                foreach( Match m in j.Matchs )
                    TMatchs.Text += m.ToString() + "\r\n";
            }
        }

        private void Calendar_Load( object sender, EventArgs e )
        {
        }
    }
}
