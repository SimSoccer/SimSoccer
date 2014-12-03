﻿using System;
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
        readonly Game _game;
        public CalendarDisplay(Game game)
        {
            InitializeComponent();
            _game = game;

            _game.Ligue.fillCalendar();

            
            foreach( Journee j in _game.Ligue.Calendar.Journees )
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

        private void CalendarDisplay_FormClosing( object sender, FormClosingEventArgs e )
        {
            System.Windows.Forms.Application.Exit();
        }

        private void TMatchs_TextChanged(object sender, EventArgs e)
        {

        }

    }
}