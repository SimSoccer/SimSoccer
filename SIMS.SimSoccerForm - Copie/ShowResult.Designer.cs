namespace SIMS.SimSoccerForm
{
    partial class ShowResult
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && (components != null) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowResult));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ViewOtherScore = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.MyMatch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(216, 26);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Matches des autres équipes :";
            // 
            // ViewOtherScore
            // 
            this.ViewOtherScore.Location = new System.Drawing.Point(55, 75);
            this.ViewOtherScore.Multiline = true;
            this.ViewOtherScore.Name = "ViewOtherScore";
            this.ViewOtherScore.ReadOnly = true;
            this.ViewOtherScore.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ViewOtherScore.Size = new System.Drawing.Size(285, 127);
            this.ViewOtherScore.TabIndex = 1;
            this.ViewOtherScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ViewOtherScore.TextChanged += new System.EventHandler(this.ViewOtherScore_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(24, 249);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(97, 26);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = "Mon match :";
            // 
            // MyMatch
            // 
            this.MyMatch.Enabled = false;
            this.MyMatch.Location = new System.Drawing.Point(55, 308);
            this.MyMatch.Multiline = true;
            this.MyMatch.Name = "MyMatch";
            this.MyMatch.ReadOnly = true;
            this.MyMatch.Size = new System.Drawing.Size(285, 127);
            this.MyMatch.TabIndex = 3;
            this.MyMatch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ShowResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(418, 506);
            this.Controls.Add(this.MyMatch);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.ViewOtherScore);
            this.Controls.Add(this.textBox1);
            this.Location = new System.Drawing.Point(900, 100);
            this.Name = "ShowResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ShowResult";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShowResult_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox ViewOtherScore;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox MyMatch;
    }
}