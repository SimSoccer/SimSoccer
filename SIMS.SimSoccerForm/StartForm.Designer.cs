namespace SIMS.SimSoccerForm
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.btGoToInscrForm = new System.Windows.Forms.Button();
            this.btGoToLoadGameForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btGoToInscrForm
            // 
            this.btGoToInscrForm.BackColor = System.Drawing.Color.Transparent;
            this.btGoToInscrForm.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btGoToInscrForm.Location = new System.Drawing.Point(84, 35);
            this.btGoToInscrForm.Name = "btGoToInscrForm";
            this.btGoToInscrForm.Size = new System.Drawing.Size(75, 29);
            this.btGoToInscrForm.TabIndex = 0;
            this.btGoToInscrForm.Text = "S\'inscrire";
            this.btGoToInscrForm.UseVisualStyleBackColor = false;
            this.btGoToInscrForm.Click += new System.EventHandler(this.btGoToInscrForm_Click);
            // 
            // btGoToLoadGameForm
            // 
            this.btGoToLoadGameForm.Location = new System.Drawing.Point(84, 84);
            this.btGoToLoadGameForm.Name = "btGoToLoadGameForm";
            this.btGoToLoadGameForm.Size = new System.Drawing.Size(75, 35);
            this.btGoToLoadGameForm.TabIndex = 1;
            this.btGoToLoadGameForm.Text = "Charger Partie";
            this.btGoToLoadGameForm.UseVisualStyleBackColor = true;
            this.btGoToLoadGameForm.Click += new System.EventHandler(this.btGoToLoadGameForm_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btGoToLoadGameForm);
            this.Controls.Add(this.btGoToInscrForm);
            this.Name = "StartForm";
            this.Text = "Accueil";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btGoToInscrForm;
        private System.Windows.Forms.Button btGoToLoadGameForm;
    }
}