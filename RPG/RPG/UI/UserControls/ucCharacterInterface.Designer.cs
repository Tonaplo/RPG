namespace RPG.UI
{
    partial class ucCharacterInterface
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
            this.lbCharName = new System.Windows.Forms.Label();
            this.lbCharStats = new System.Windows.Forms.Label();
            this.lbActiveAbilities = new System.Windows.Forms.Label();
            this.flpAbilitiesAndPassives = new System.Windows.Forms.FlowLayoutPanel();
            this.btCharacter = new System.Windows.Forms.Button();
            this.pictureBoxChar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChar)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCharName
            // 
            this.lbCharName.BackColor = System.Drawing.Color.Transparent;
            this.lbCharName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCharName.Font = new System.Drawing.Font("Pericles", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCharName.ForeColor = System.Drawing.Color.Maroon;
            this.lbCharName.Location = new System.Drawing.Point(0, 0);
            this.lbCharName.Name = "lbCharName";
            this.lbCharName.Size = new System.Drawing.Size(343, 21);
            this.lbCharName.TabIndex = 0;
            this.lbCharName.Text = "<Name of the Character>";
            this.lbCharName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCharStats
            // 
            this.lbCharStats.BackColor = System.Drawing.Color.Transparent;
            this.lbCharStats.Font = new System.Drawing.Font("Pericles", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCharStats.ForeColor = System.Drawing.Color.Yellow;
            this.lbCharStats.Location = new System.Drawing.Point(91, 28);
            this.lbCharStats.Name = "lbCharStats";
            this.lbCharStats.Size = new System.Drawing.Size(108, 120);
            this.lbCharStats.TabIndex = 2;
            this.lbCharStats.Text = "Class: XX\r\n\r\nHealth: XX/YY\r\nStrength: XX\r\nAgility: XX\r\nIntellect: XX\r\nArmor: XX";
            // 
            // lbActiveAbilities
            // 
            this.lbActiveAbilities.BackColor = System.Drawing.Color.Transparent;
            this.lbActiveAbilities.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbActiveAbilities.Font = new System.Drawing.Font("Pericles", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbActiveAbilities.ForeColor = System.Drawing.Color.Yellow;
            this.lbActiveAbilities.Location = new System.Drawing.Point(205, 23);
            this.lbActiveAbilities.Name = "lbActiveAbilities";
            this.lbActiveAbilities.Size = new System.Drawing.Size(135, 21);
            this.lbActiveAbilities.TabIndex = 4;
            this.lbActiveAbilities.Text = "Active Abilities:";
            this.lbActiveAbilities.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpAbilitiesAndPassives
            // 
            this.flpAbilitiesAndPassives.AllowDrop = true;
            this.flpAbilitiesAndPassives.AutoScroll = true;
            this.flpAbilitiesAndPassives.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpAbilitiesAndPassives.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpAbilitiesAndPassives.Location = new System.Drawing.Point(205, 47);
            this.flpAbilitiesAndPassives.Name = "flpAbilitiesAndPassives";
            this.flpAbilitiesAndPassives.Size = new System.Drawing.Size(135, 72);
            this.flpAbilitiesAndPassives.TabIndex = 6;
            // 
            // btCharacter
            // 
            this.btCharacter.BackColor = System.Drawing.Color.DarkRed;
            this.btCharacter.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btCharacter.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.btCharacter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btCharacter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btCharacter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCharacter.Font = new System.Drawing.Font("Pericles", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCharacter.ForeColor = System.Drawing.Color.Yellow;
            this.btCharacter.Location = new System.Drawing.Point(205, 125);
            this.btCharacter.Name = "btCharacter";
            this.btCharacter.Size = new System.Drawing.Size(137, 23);
            this.btCharacter.TabIndex = 14;
            this.btCharacter.Text = "Character";
            this.btCharacter.UseVisualStyleBackColor = false;
            this.btCharacter.Click += new System.EventHandler(this.btAbilities_Click);
            // 
            // pictureBoxChar
            // 
            this.pictureBoxChar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxChar.Location = new System.Drawing.Point(5, 28);
            this.pictureBoxChar.Name = "pictureBoxChar";
            this.pictureBoxChar.Size = new System.Drawing.Size(80, 120);
            this.pictureBoxChar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxChar.TabIndex = 1;
            this.pictureBoxChar.TabStop = false;
            // 
            // ucCharacterInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.btCharacter);
            this.Controls.Add(this.flpAbilitiesAndPassives);
            this.Controls.Add(this.lbActiveAbilities);
            this.Controls.Add(this.lbCharStats);
            this.Controls.Add(this.pictureBoxChar);
            this.Controls.Add(this.lbCharName);
            this.Font = new System.Drawing.Font("Pericles", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucCharacterInterface";
            this.Size = new System.Drawing.Size(343, 154);
            this.Load += new System.EventHandler(this.ucCharacterInterface_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbCharName;
        private System.Windows.Forms.PictureBox pictureBoxChar;
        private System.Windows.Forms.Label lbCharStats;
        private System.Windows.Forms.Label lbActiveAbilities;
        private System.Windows.Forms.FlowLayoutPanel flpAbilitiesAndPassives;
        private System.Windows.Forms.Button btCharacter;
    }
}
