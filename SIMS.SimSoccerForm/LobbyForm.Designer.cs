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
            this.btGoToCalendar = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.calendrierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUsernameLobby
            // 
            this.txtUsernameLobby.Enabled = false;
            this.txtUsernameLobby.Location = new System.Drawing.Point(245, 47);
            this.txtUsernameLobby.Name = "txtUsernameLobby";
            this.txtUsernameLobby.Size = new System.Drawing.Size(100, 20);
            this.txtUsernameLobby.TabIndex = 0;
            this.txtUsernameLobby.TextChanged += new System.EventHandler(this.txtUsernameLobby_TextChanged);
            // 
            // btGoToCalendar
            // 
            this.btGoToCalendar.Location = new System.Drawing.Point(81, 47);
            this.btGoToCalendar.Name = "btGoToCalendar";
            this.btGoToCalendar.Size = new System.Drawing.Size(75, 23);
            this.btGoToCalendar.TabIndex = 1;
            this.btGoToCalendar.Text = "Calendrier";
            this.btGoToCalendar.UseVisualStyleBackColor = true;
            this.btGoToCalendar.Click += new System.EventHandler(this.btGoToCalendar_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calendrierToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.profilToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(415, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // calendrierToolStripMenuItem
            // 
            this.calendrierToolStripMenuItem.Name = "calendrierToolStripMenuItem";
            this.calendrierToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.calendrierToolStripMenuItem.Text = "Calendrier";
            this.calendrierToolStripMenuItem.Click += new System.EventHandler(this.btGoToCalendar_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // profilToolStripMenuItem
            // 
            this.profilToolStripMenuItem.Name = "profilToolStripMenuItem";
            this.profilToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.profilToolStripMenuItem.Text = "Profil";
            this.profilToolStripMenuItem.Click += new System.EventHandler(this.profilToolStripMenuItem_Click);
            // 
            // LobbyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(415, 331);
            this.Controls.Add(this.btGoToCalendar);
            this.Controls.Add(this.txtUsernameLobby);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LobbyForm";
            this.Text = "SimSoccer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsernameLobby;
        private System.Windows.Forms.Button btGoToCalendar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem calendrierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profilToolStripMenuItem;
    }
}