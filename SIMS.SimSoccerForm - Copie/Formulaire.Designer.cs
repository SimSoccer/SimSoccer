namespace SIMS.SimSoccerForm
{
    partial class FormInscription
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInscription));
            this.btValider = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.userControl1 = new SIMS.SimSoccerForm.UserControl1();
            this.SuspendLayout();
            // 
            // btValider
            // 
            this.btValider.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btValider.Location = new System.Drawing.Point(184, 149);
            this.btValider.Name = "btValider";
            this.btValider.Size = new System.Drawing.Size(75, 23);
            this.btValider.TabIndex = 1;
            this.btValider.Text = "Valider";
            this.btValider.UseVisualStyleBackColor = true;
            this.btValider.Click += new System.EventHandler(this.btValider_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point(184, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Retour";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // userControl1
            // 
            this.userControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.userControl1.FirstName = "";
            this.userControl1.LastName = "";
            this.userControl1.Location = new System.Drawing.Point(41, 41);
            this.userControl1.Name = "userControl1";
            this.userControl1.Size = new System.Drawing.Size(399, 340);
            this.userControl1.TabIndex = 0;
            this.userControl1.UserName = "";
            this.userControl1.UserPassword = "";
            // 
            // FormInscription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(526, 383);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btValider);
            this.Controls.Add(this.userControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormInscription";
            this.Text = "Inscription";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }
        #endregion

        private UserControl1 userControl1;
        private System.Windows.Forms.Button btValider;
        private System.Windows.Forms.Button button1;



    }
}

