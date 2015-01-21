namespace SIMS.SimSoccerForm
{
    partial class StartPage
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
            if( disposing && ( components != null ) )
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartPage));
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.musiqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suivantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.précédentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(235, 502);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = " Appuyez sur \"Entrer\" pour lancer le jeu..";
            this.label1.Click += new System.EventHandler(this.StartPage_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.musiqueToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(920, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // musiqueToolStripMenuItem
            // 
            this.musiqueToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.suivantToolStripMenuItem,
            this.précédentToolStripMenuItem});
            this.musiqueToolStripMenuItem.Name = "musiqueToolStripMenuItem";
            this.musiqueToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.musiqueToolStripMenuItem.Text = "MusicPlayer";
            // 
            // suivantToolStripMenuItem
            // 
            this.suivantToolStripMenuItem.Name = "suivantToolStripMenuItem";
            this.suivantToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.suivantToolStripMenuItem.Text = "Suivant";
            this.suivantToolStripMenuItem.Click += new System.EventHandler(this.suivantToolStripMenuItem_Click);
            // 
            // précédentToolStripMenuItem
            // 
            this.précédentToolStripMenuItem.Name = "précédentToolStripMenuItem";
            this.précédentToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.précédentToolStripMenuItem.Text = "Précédent";
            this.précédentToolStripMenuItem.Click += new System.EventHandler(this.précédentToolStripMenuItem_Click);
            // 
            // StartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(920, 558);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartPage";
            this.Text = "SimSoccer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.StartPage_Load);
            this.Click += new System.EventHandler(this.StartPage_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StartPage_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem musiqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suivantToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem précédentToolStripMenuItem;
    }
}