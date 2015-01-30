namespace SIMS.SimSoccerForm
{
    partial class SelectTeamForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectTeamForm));
            this.button1 = new System.Windows.Forms.Button();
            this.previous = new System.Windows.Forms.Button();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.teamName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelStadium = new System.Windows.Forms.Label();
            this.teamStadium = new System.Windows.Forms.TextBox();
            this.buttoSelect = new System.Windows.Forms.Button();
            this.PlayersBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Next_Click);
            this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button1_KeyDown);
            // 
            // previous
            // 
            this.previous.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.previous, "previous");
            this.previous.Name = "previous";
            this.previous.UseVisualStyleBackColor = false;
            this.previous.Click += new System.EventHandler(this.Previous_Click);
            // 
            // Logo
            // 
            this.Logo.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.Logo, "Logo");
            this.Logo.Name = "Logo";
            this.Logo.TabStop = false;
            this.Logo.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // teamName
            // 
            resources.ApplyResources(this.teamName, "teamName");
            this.teamName.Name = "teamName";
            this.teamName.TextChanged += new System.EventHandler(this.teamName_TextChanged);
            // 
            // labelName
            // 
            resources.ApplyResources(this.labelName, "labelName");
            this.labelName.BackColor = System.Drawing.SystemColors.Control;
            this.labelName.ForeColor = System.Drawing.Color.Black;
            this.labelName.Name = "labelName";
            // 
            // labelStadium
            // 
            resources.ApplyResources(this.labelStadium, "labelStadium");
            this.labelStadium.Name = "labelStadium";
            // 
            // teamStadium
            // 
            resources.ApplyResources(this.teamStadium, "teamStadium");
            this.teamStadium.Name = "teamStadium";
            this.teamStadium.TextChanged += new System.EventHandler(this.teamStadium_TextChanged);
            // 
            // buttoSelect
            // 
            resources.ApplyResources(this.buttoSelect, "buttoSelect");
            this.buttoSelect.Name = "buttoSelect";
            this.buttoSelect.UseVisualStyleBackColor = true;
            this.buttoSelect.Click += new System.EventHandler(this.buttoSelect_Click);
            // 
            // PlayersBox
            // 
            resources.ApplyResources(this.PlayersBox, "PlayersBox");
            this.PlayersBox.Name = "PlayersBox";
            this.PlayersBox.ReadOnly = true;
            this.PlayersBox.TextChanged += new System.EventHandler(this.PlayersBox_TextChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // textBox3
            // 
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.ForeColor = System.Drawing.Color.Gold;
            this.textBox3.Name = "textBox3";
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // SelectTeamForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PlayersBox);
            this.Controls.Add(this.buttoSelect);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.teamStadium);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelStadium);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.teamName);
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.previous);
            this.Controls.Add(this.button1);
            this.KeyPreview = true;
            this.Name = "SelectTeamForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SelectTeamForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button previous;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelStadium;
        private System.Windows.Forms.TextBox teamStadium;
        private System.Windows.Forms.TextBox teamName;
        private System.Windows.Forms.Button buttoSelect;
        private System.Windows.Forms.TextBox PlayersBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
    }
}