﻿namespace SIMS.SimSoccerForm
{
    partial class LobbyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LobbyForm));
            this.txtUsernameLobby = new System.Windows.Forms.TextBox();
            this.btOpenProfile = new System.Windows.Forms.Button();
            this.btOpenCalendar = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.PictureBox();
            this.currentJourney = new System.Windows.Forms.TextBox();
            this.playJourney = new System.Windows.Forms.Button();
            this.btFormation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btExit)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUsernameLobby
            // 
            this.txtUsernameLobby.Enabled = false;
            this.txtUsernameLobby.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsernameLobby.Location = new System.Drawing.Point(626, 27);
            this.txtUsernameLobby.Name = "txtUsernameLobby";
            this.txtUsernameLobby.Size = new System.Drawing.Size(222, 38);
            this.txtUsernameLobby.TabIndex = 0;
            this.txtUsernameLobby.TextChanged += new System.EventHandler(this.txtUsernameLobby_TextChanged);
            // 
            // btOpenProfile
            // 
            this.btOpenProfile.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btOpenProfile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btOpenProfile.BackgroundImage")));
            this.btOpenProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btOpenProfile.Font = new System.Drawing.Font("Impact", 50F);
            this.btOpenProfile.ForeColor = System.Drawing.Color.White;
            this.btOpenProfile.Location = new System.Drawing.Point(0, 95);
            this.btOpenProfile.Name = "btOpenProfile";
            this.btOpenProfile.Size = new System.Drawing.Size(848, 163);
            this.btOpenProfile.TabIndex = 3;
            this.btOpenProfile.Text = "PROFIL";
            this.btOpenProfile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btOpenProfile.UseVisualStyleBackColor = false;
            this.btOpenProfile.Click += new System.EventHandler(this.btOpenProfile_Click);
            // 
            // btOpenCalendar
            // 
            this.btOpenCalendar.AutoSize = true;
            this.btOpenCalendar.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btOpenCalendar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btOpenCalendar.BackgroundImage")));
            this.btOpenCalendar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btOpenCalendar.Font = new System.Drawing.Font("Impact", 50F);
            this.btOpenCalendar.ForeColor = System.Drawing.Color.White;
            this.btOpenCalendar.Location = new System.Drawing.Point(0, 276);
            this.btOpenCalendar.Name = "btOpenCalendar";
            this.btOpenCalendar.Size = new System.Drawing.Size(848, 163);
            this.btOpenCalendar.TabIndex = 4;
            this.btOpenCalendar.Text = "CALENDRIER";
            this.btOpenCalendar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btOpenCalendar.UseVisualStyleBackColor = false;
            this.btOpenCalendar.Click += new System.EventHandler(this.btOpenCalendar_Click);
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.Transparent;
            this.btExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btExit.BackgroundImage")));
            this.btExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btExit.Location = new System.Drawing.Point(1100, 600);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(235, 129);
            this.btExit.TabIndex = 5;
            this.btExit.TabStop = false;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // currentJourney
            // 
            this.currentJourney.Location = new System.Drawing.Point(129, 27);
            this.currentJourney.Name = "currentJourney";
            this.currentJourney.Size = new System.Drawing.Size(100, 20);
            this.currentJourney.TabIndex = 6;
            this.currentJourney.TextChanged += new System.EventHandler(this.currentJourney_TextChanged);
            // 
            // playJourney
            // 
            this.playJourney.Location = new System.Drawing.Point(285, 27);
            this.playJourney.Name = "playJourney";
            this.playJourney.Size = new System.Drawing.Size(75, 23);
            this.playJourney.TabIndex = 7;
            this.playJourney.Text = "Play journey";
            this.playJourney.UseVisualStyleBackColor = true;
            this.playJourney.Click += new System.EventHandler(this.playJourney_Click);
            // 
            // btFormation
            // 
            this.btFormation.Location = new System.Drawing.Point(251, 494);
            this.btFormation.Name = "btFormation";
            this.btFormation.Size = new System.Drawing.Size(151, 49);
            this.btFormation.TabIndex = 8;
            this.btFormation.Text = "FORMATION";
            this.btFormation.UseVisualStyleBackColor = true;
            this.btFormation.Click += new System.EventHandler(this.btFormation_Click);
            // 
            // LobbyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(848, 742);
            this.Controls.Add(this.btFormation);
            this.Controls.Add(this.playJourney);
            this.Controls.Add(this.currentJourney);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btOpenCalendar);
            this.Controls.Add(this.btOpenProfile);
            this.Controls.Add(this.txtUsernameLobby);
            this.Name = "LobbyForm";
            this.Text = "SimSoccer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.btExit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsernameLobby;
        private System.Windows.Forms.Button btOpenProfile;
        private System.Windows.Forms.Button btOpenCalendar;
        private System.Windows.Forms.PictureBox btExit;
        private System.Windows.Forms.TextBox currentJourney;
        private System.Windows.Forms.Button playJourney;
        private System.Windows.Forms.Button btFormation;
    }
}