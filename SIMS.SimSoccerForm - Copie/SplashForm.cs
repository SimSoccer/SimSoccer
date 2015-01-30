using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIMS.SimSoccerForm
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        private void SplashForm_Load( object sender, System.EventArgs e )
        {
            // Start the BackgroundWorker.
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork( object sender, DoWorkEventArgs e )
        {
            for( int i = 1; i <= 100; i++ )
            {
                // Wait 100 milliseconds.
                Thread.Sleep( 100 );
                // Report progress.
                backgroundWorker1.WorkerReportsProgress = true;
                backgroundWorker1.ReportProgress( i );
            }
        }

        private void backgroundWorker1_ProgressChanged( object sender, ProgressChangedEventArgs e )
        {
            // Change the value of the ProgressBar to the BackgroundWorker progress.
            progressBar1.Value = e.ProgressPercentage;
            // Set the text.
            this.Text = e.ProgressPercentage.ToString();
        }

        private void progressBar1_Click( object sender, EventArgs e )
        {

        }
    }
}
