namespace SIMS.SimSoccerForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mercatoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transfertsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aProposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.léquipeSimSoccerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btOpenRanking = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btExit)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUsernameLobby
            // 
            this.txtUsernameLobby.Enabled = false;
            this.txtUsernameLobby.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsernameLobby.Location = new System.Drawing.Point(626, 38);
            this.txtUsernameLobby.Name = "txtUsernameLobby";
            this.txtUsernameLobby.Size = new System.Drawing.Size(222, 38);
            this.txtUsernameLobby.TabIndex = 0;
            this.txtUsernameLobby.TextChanged += new System.EventHandler(this.txtUsernameLobby_TextChanged);
            // 
            // btOpenProfile
            // 
            this.btOpenProfile.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btOpenProfile.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btOpenProfile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btOpenProfile.BackgroundImage")));
            this.btOpenProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btOpenProfile.Font = new System.Drawing.Font("Impact", 50F);
            this.btOpenProfile.ForeColor = System.Drawing.Color.White;
            this.btOpenProfile.Location = new System.Drawing.Point(0, 95);
            this.btOpenProfile.Name = "btOpenProfile";
            this.btOpenProfile.Size = new System.Drawing.Size(888, 116);
            this.btOpenProfile.TabIndex = 3;
            this.btOpenProfile.Text = "PROFIL";
            this.btOpenProfile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btOpenProfile.UseVisualStyleBackColor = false;
            this.btOpenProfile.Click += new System.EventHandler(this.btOpenProfile_Click);
            // 
            // btOpenCalendar
            // 
            this.btOpenCalendar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btOpenCalendar.AutoSize = true;
            this.btOpenCalendar.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btOpenCalendar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btOpenCalendar.BackgroundImage")));
            this.btOpenCalendar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btOpenCalendar.Font = new System.Drawing.Font("Impact", 50F);
            this.btOpenCalendar.ForeColor = System.Drawing.Color.White;
            this.btOpenCalendar.Location = new System.Drawing.Point(0, 230);
            this.btOpenCalendar.Name = "btOpenCalendar";
            this.btOpenCalendar.Size = new System.Drawing.Size(888, 105);
            this.btOpenCalendar.TabIndex = 4;
            this.btOpenCalendar.Text = "CALENDRIER";
            this.btOpenCalendar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btOpenCalendar.UseVisualStyleBackColor = false;
            this.btOpenCalendar.Click += new System.EventHandler(this.btOpenCalendar_Click);
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExit.BackColor = System.Drawing.Color.Transparent;
            this.btExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btExit.BackgroundImage")));
            this.btExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btExit.Location = new System.Drawing.Point(964, 38);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(49, 49);
            this.btExit.TabIndex = 5;
            this.btExit.TabStop = false;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // currentJourney
            // 
            this.currentJourney.Location = new System.Drawing.Point(129, 38);
            this.currentJourney.Name = "currentJourney";
            this.currentJourney.Size = new System.Drawing.Size(100, 20);
            this.currentJourney.TabIndex = 6;
            this.currentJourney.TextChanged += new System.EventHandler(this.currentJourney_TextChanged);
            // 
            // playJourney
            // 
            this.playJourney.Location = new System.Drawing.Point(285, 38);
            this.playJourney.Name = "playJourney";
            this.playJourney.Size = new System.Drawing.Size(98, 23);
            this.playJourney.TabIndex = 7;
            this.playJourney.Text = "Jouer journée";
            this.playJourney.UseVisualStyleBackColor = true;
            this.playJourney.Click += new System.EventHandler(this.playJourney_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("Impact", 50F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 358);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(888, 100);
            this.button1.TabIndex = 4;
            this.button1.Text = "FORMATION";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btFormation_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mercatoToolStripMenuItem,
            this.aProposToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1025, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mercatoToolStripMenuItem
            // 
            this.mercatoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transfertsToolStripMenuItem,
            this.aideToolStripMenuItem});
            this.mercatoToolStripMenuItem.Name = "mercatoToolStripMenuItem";
            this.mercatoToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.mercatoToolStripMenuItem.Text = "Mercato";
            // 
            // transfertsToolStripMenuItem
            // 
            this.transfertsToolStripMenuItem.Name = "transfertsToolStripMenuItem";
            this.transfertsToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.transfertsToolStripMenuItem.Text = "Transferts";
            this.transfertsToolStripMenuItem.Click += new System.EventHandler(this.transfertsToolStripMenuItem_Click);
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            this.aideToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.aideToolStripMenuItem.Text = "Aide";
            // 
            // aProposToolStripMenuItem
            // 
            this.aProposToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.léquipeSimSoccerToolStripMenuItem});
            this.aProposToolStripMenuItem.Name = "aProposToolStripMenuItem";
            this.aProposToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.aProposToolStripMenuItem.Text = "A propos";
            // 
            // léquipeSimSoccerToolStripMenuItem
            // 
            this.léquipeSimSoccerToolStripMenuItem.Name = "léquipeSimSoccerToolStripMenuItem";
            this.léquipeSimSoccerToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.léquipeSimSoccerToolStripMenuItem.Text = "L\'équipe SimSoccer";
            // 
            // btOpenRanking
            // 
            this.btOpenRanking.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btOpenRanking.AutoSize = true;
            this.btOpenRanking.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btOpenRanking.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btOpenRanking.BackgroundImage")));
            this.btOpenRanking.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btOpenRanking.Font = new System.Drawing.Font("Impact", 50F);
            this.btOpenRanking.ForeColor = System.Drawing.Color.White;
            this.btOpenRanking.Location = new System.Drawing.Point(0, 474);
            this.btOpenRanking.Name = "btOpenRanking";
            this.btOpenRanking.Size = new System.Drawing.Size(888, 100);
            this.btOpenRanking.TabIndex = 9;
            this.btOpenRanking.Text = "CLASSEMENT";
            this.btOpenRanking.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btOpenRanking.UseVisualStyleBackColor = false;
            this.btOpenRanking.Click += new System.EventHandler(this.btOpenRanking_Click);
            // 
            // LobbyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1025, 632);
            this.Controls.Add(this.btOpenRanking);
            this.Controls.Add(this.playJourney);
            this.Controls.Add(this.currentJourney);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btOpenCalendar);
            this.Controls.Add(this.btOpenProfile);
            this.Controls.Add(this.txtUsernameLobby);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LobbyForm";
            this.Text = "SimSoccer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.btExit)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mercatoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transfertsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aProposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem léquipeSimSoccerToolStripMenuItem;
        private System.Windows.Forms.Button btOpenRanking;
    }
}