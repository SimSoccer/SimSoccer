﻿namespace SIMS.SimSoccerForm
{
    partial class CalendarDisplay
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarDisplay));
            this.Cjournee = new System.Windows.Forms.ComboBox();
            this.TMatchs = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Cjournee
            // 
            this.Cjournee.FormattingEnabled = true;
            this.Cjournee.Location = new System.Drawing.Point(117, 12);
            this.Cjournee.Name = "Cjournee";
            this.Cjournee.Size = new System.Drawing.Size(192, 21);
            this.Cjournee.TabIndex = 0;
            this.Cjournee.SelectedIndexChanged += new System.EventHandler(this.Cjournee_SelectedIndexChanged);
            // 
            // TMatchs
            // 
            this.TMatchs.BackColor = System.Drawing.Color.AliceBlue;
            this.TMatchs.ForeColor = System.Drawing.Color.Black;
            this.TMatchs.Location = new System.Drawing.Point(22, 114);
            this.TMatchs.Multiline = true;
            this.TMatchs.Name = "TMatchs";
            this.TMatchs.ReadOnly = true;
            this.TMatchs.Size = new System.Drawing.Size(375, 284);
            this.TMatchs.TabIndex = 1;
            this.TMatchs.TextChanged += new System.EventHandler(this.TMatchs_TextChanged);
            // 
            // CalendarDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(418, 506);
            this.Controls.Add(this.TMatchs);
            this.Controls.Add(this.Cjournee);
            this.Location = new System.Drawing.Point(900, 100);
            this.Name = "CalendarDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Calendrier";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CalendarDisplay_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Cjournee;
        private System.Windows.Forms.TextBox TMatchs;
    }
}

