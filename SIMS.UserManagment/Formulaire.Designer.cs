namespace SIMS.UserManagment
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
            this.btValider = new System.Windows.Forms.Button();
            this.btLire = new System.Windows.Forms.Button();
            this.userControl1 = new SIMS.UserManagment.UserControl1();
            this.SuspendLayout();
            // 
            // btValider
            // 
            this.btValider.Location = new System.Drawing.Point(323, 56);
            this.btValider.Name = "btValider";
            this.btValider.Size = new System.Drawing.Size(75, 23);
            this.btValider.TabIndex = 1;
            this.btValider.Text = "Valider";
            this.btValider.UseVisualStyleBackColor = true;
            this.btValider.Click += new System.EventHandler(this.btValider_Click);
            // 
            // btLire
            // 
            this.btLire.Location = new System.Drawing.Point(323, 107);
            this.btLire.Name = "btLire";
            this.btLire.Size = new System.Drawing.Size(75, 23);
            this.btLire.TabIndex = 2;
            this.btLire.Text = "Lire";
            this.btLire.UseVisualStyleBackColor = true;
            this.btLire.Click += new System.EventHandler(this.btLire_Click);
            // 
            // userControl1
            // 
            this.userControl1.Location = new System.Drawing.Point(3, 14);
            this.userControl1.Name = "userControl1";
            this.userControl1.Size = new System.Drawing.Size(249, 181);
            this.userControl1.TabIndex = 0;
            this.userControl1.UserName = "";
            this.userControl1.UserPassword = "";
            // 
            // FormInscription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 343);
            this.Controls.Add(this.btLire);
            this.Controls.Add(this.btValider);
            this.Controls.Add(this.userControl1);
            this.Name = "FormInscription";
            this.Text = "Inscription";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControl1 userControl1;
        private System.Windows.Forms.Button btValider;
        private System.Windows.Forms.Button btLire;



    }
}

