namespace SIMS.SimSoccerForm
{
    partial class LoadGameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadGameForm));
            this.btLoadGame = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btBackToStartForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btLoadGame
            // 
            this.btLoadGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btLoadGame.Location = new System.Drawing.Point(386, 209);
            this.btLoadGame.Name = "btLoadGame";
            this.btLoadGame.Size = new System.Drawing.Size(75, 23);
            this.btLoadGame.TabIndex = 0;
            this.btLoadGame.Text = "Charger";
            this.btLoadGame.UseVisualStyleBackColor = true;
            this.btLoadGame.Click += new System.EventHandler(this.btLoadGame_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBox1.BackColor = System.Drawing.SystemColors.Window;
            this.listBox1.Location = new System.Drawing.Point(147, 173);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(233, 147);
            this.listBox1.TabIndex = 0;
            this.listBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown);
            // 
            // btBackToStartForm
            // 
            this.btBackToStartForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btBackToStartForm.Location = new System.Drawing.Point(386, 251);
            this.btBackToStartForm.Name = "btBackToStartForm";
            this.btBackToStartForm.Size = new System.Drawing.Size(75, 23);
            this.btBackToStartForm.TabIndex = 1;
            this.btBackToStartForm.Text = "Retour";
            this.btBackToStartForm.UseVisualStyleBackColor = true;
            this.btBackToStartForm.Click += new System.EventHandler(this.btBackToStartForm_Click);
            // 
            // LoadGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(598, 441);
            this.Controls.Add(this.btBackToStartForm);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btLoadGame);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoadGameForm";
            this.Text = "Charger une partie";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btLoadGame;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btBackToStartForm;
    }
}