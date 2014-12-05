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
            this.SuspendLayout();
            // 
            // txtUsernameLobby
            // 
            this.txtUsernameLobby.Enabled = false;
            this.txtUsernameLobby.Location = new System.Drawing.Point(303, 12);
            this.txtUsernameLobby.Name = "txtUsernameLobby";
            this.txtUsernameLobby.Size = new System.Drawing.Size(100, 20);
            this.txtUsernameLobby.TabIndex = 0;
            this.txtUsernameLobby.TextChanged += new System.EventHandler(this.txtUsernameLobby_TextChanged);
            // 
            // btGoToCalendar
            // 
            this.btGoToCalendar.Location = new System.Drawing.Point(81, 21);
            this.btGoToCalendar.Name = "btGoToCalendar";
            this.btGoToCalendar.Size = new System.Drawing.Size(75, 23);
            this.btGoToCalendar.TabIndex = 1;
            this.btGoToCalendar.Text = "Calendrier";
            this.btGoToCalendar.UseVisualStyleBackColor = true;
            this.btGoToCalendar.Click += new System.EventHandler(this.btGoToCalendar_Click);
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
            this.Name = "LobbyForm";
            this.Text = "SimSoccer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsernameLobby;
        private System.Windows.Forms.Button btGoToCalendar;
    }
}