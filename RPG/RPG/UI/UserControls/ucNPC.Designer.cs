namespace RPG.UI
{
    partial class ucNPC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbNPCName = new System.Windows.Forms.Label();
            this.flpAbilitiesAndPassives = new System.Windows.Forms.FlowLayoutPanel();
            this.lbAbilities = new System.Windows.Forms.Label();
            this.pictureBoxNPC = new System.Windows.Forms.PictureBox();
            this.flpHealthBar = new System.Windows.Forms.FlowLayoutPanel();
            this.labelHealthRemaining = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNPC)).BeginInit();
            this.flpHealthBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbNPCName
            // 
            this.lbNPCName.BackColor = System.Drawing.Color.Transparent;
            this.lbNPCName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbNPCName.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNPCName.ForeColor = System.Drawing.Color.Maroon;
            this.lbNPCName.Location = new System.Drawing.Point(105, 0);
            this.lbNPCName.Name = "lbNPCName";
            this.lbNPCName.Size = new System.Drawing.Size(290, 22);
            this.lbNPCName.TabIndex = 1;
            this.lbNPCName.Text = "<Name of the NPC>";
            this.lbNPCName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpAbilitiesAndPassives
            // 
            this.flpAbilitiesAndPassives.Location = new System.Drawing.Point(105, 74);
            this.flpAbilitiesAndPassives.Name = "flpAbilitiesAndPassives";
            this.flpAbilitiesAndPassives.Size = new System.Drawing.Size(290, 60);
            this.flpAbilitiesAndPassives.TabIndex = 8;
            // 
            // lbAbilities
            // 
            this.lbAbilities.BackColor = System.Drawing.Color.Transparent;
            this.lbAbilities.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbAbilities.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAbilities.ForeColor = System.Drawing.Color.Yellow;
            this.lbAbilities.Location = new System.Drawing.Point(105, 56);
            this.lbAbilities.Name = "lbAbilities";
            this.lbAbilities.Size = new System.Drawing.Size(290, 15);
            this.lbAbilities.TabIndex = 7;
            this.lbAbilities.Text = "Abilities:";
            this.lbAbilities.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxNPC
            // 
            this.pictureBoxNPC.Location = new System.Drawing.Point(1, 3);
            this.pictureBoxNPC.Name = "pictureBoxNPC";
            this.pictureBoxNPC.Size = new System.Drawing.Size(98, 131);
            this.pictureBoxNPC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxNPC.TabIndex = 0;
            this.pictureBoxNPC.TabStop = false;
            // 
            // flpHealthBar
            // 
            this.flpHealthBar.BackColor = System.Drawing.Color.DarkRed;
            this.flpHealthBar.Controls.Add(this.labelHealthRemaining);
            this.flpHealthBar.Location = new System.Drawing.Point(105, 26);
            this.flpHealthBar.Name = "flpHealthBar";
            this.flpHealthBar.Size = new System.Drawing.Size(290, 27);
            this.flpHealthBar.TabIndex = 9;
            // 
            // labelHealthRemaining
            // 
            this.labelHealthRemaining.BackColor = System.Drawing.Color.DarkGreen;
            this.labelHealthRemaining.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHealthRemaining.Location = new System.Drawing.Point(0, 0);
            this.labelHealthRemaining.Margin = new System.Windows.Forms.Padding(0);
            this.labelHealthRemaining.Name = "labelHealthRemaining";
            this.labelHealthRemaining.Size = new System.Drawing.Size(100, 27);
            this.labelHealthRemaining.TabIndex = 1;
            this.labelHealthRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucNPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.flpHealthBar);
            this.Controls.Add(this.flpAbilitiesAndPassives);
            this.Controls.Add(this.lbAbilities);
            this.Controls.Add(this.lbNPCName);
            this.Controls.Add(this.pictureBoxNPC);
            this.Font = new System.Drawing.Font("Pericles", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucNPC";
            this.Size = new System.Drawing.Size(400, 140);
            this.Load += new System.EventHandler(this.ucNPC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNPC)).EndInit();
            this.flpHealthBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxNPC;
        private System.Windows.Forms.Label lbNPCName;
        private System.Windows.Forms.FlowLayoutPanel flpAbilitiesAndPassives;
        private System.Windows.Forms.Label lbAbilities;
        private System.Windows.Forms.FlowLayoutPanel flpHealthBar;
        private System.Windows.Forms.Label labelHealthRemaining;
    }
}
