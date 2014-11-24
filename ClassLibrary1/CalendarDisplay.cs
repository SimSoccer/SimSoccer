using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawGame
{
    public partial class CalendarDisplay : Form
    {
        public CalendarDisplay()
        {
            InitializeComponent();

            Ligue ligue1 = new Ligue();

            ligue1.CreateTeam("Psg");
            ligue1.CreateTeam("Om");
            ligue1.CreateTeam("Lyon");
            ligue1.CreateTeam("Lorient");
            ligue1.CreateTeam("Bordeaux");
            ligue1.CreateTeam("Lille");
            ligue1.CreateTeam("Lens");
            ligue1.CreateTeam("Fc Nantes");
            ligue1.CreateTeam("Saint Etienne");
            ligue1.CreateTeam("Monaco");
            ligue1.CreateTeam("Stade Rennais Fc");
            ligue1.CreateTeam("Fc Metz");
            ligue1.CreateTeam("Reims");
            ligue1.CreateTeam("Fc Toulouse");
            ligue1.CreateTeam("Ogc Nice");
            ligue1.CreateTeam("Montpellier");
            ligue1.CreateTeam("Bastia");
            ligue1.CreateTeam("Evian-Thonon-Gaillard Fc");
            ligue1.CreateTeam("Stade Malherbe de Caen");
            ligue1.CreateTeam("Guingamp");

            ligue1.fillCalendar();

            foreach (Journee j in ligue1.Calendar.Journees)
                Cjournee.Items.Add(j);

            Cjournee.SelectedIndex = 0;
        }

        private void Cjournee_SelectedIndexChanged(object sender, EventArgs e)
        {
            TMatchs.Text = string.Empty;

            Journee j = Cjournee.Items[Cjournee.SelectedIndex] as Journee;

            if (j != null)
            {
                foreach (Match m in j.Matchs)
                    TMatchs.Text += m.ToString() + "\r\n";
            }
        }

        private void Calendar_Load(object sender, EventArgs e)
        {

        }
    }
}
