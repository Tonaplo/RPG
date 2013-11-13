namespace RPG.UI.UserControls
{
    partial class ucCharacterBattle
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
            this.lbCharStats = new System.Windows.Forms.Label();
            this.comboBoxAbilities = new System.Windows.Forms.ComboBox();
            this.lbTurnpoints = new System.Windows.Forms.Label();
            this.checkBoxPlayer1 = new System.Windows.Forms.CheckBox();
            this.checkBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.checkBoxPlayer3 = new System.Windows.Forms.CheckBox();
            this.checkBoxPlayer4 = new System.Windows.Forms.CheckBox();
            this.pictureBoxChar = new System.Windows.Forms.PictureBox();
            this.checkBoxEnemy = new System.Windows.Forms.CheckBox();
            this.groupBoxTargets = new System.Windows.Forms.GroupBox();
            this.btAttack = new System.Windows.Forms.Button();
            this.labelAbilityDescription = new System.Windows.Forms.Label();
            this.flpHealthBar = new System.Windows.Forms.FlowLayoutPanel();
            this.labelHealthRemaining = new System.Windows.Forms.Label();
            this.lbBuffs = new System.Windows.Forms.Label();
            this.flpBuffsAndDebuffs = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChar)).BeginInit();
            this.groupBoxTargets.SuspendLayout();
            this.flpHealthBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbCharStats
            // 
            this.lbCharStats.BackColor = System.Drawing.Color.Transparent;
            this.lbCharStats.Font = new System.Drawing.Font("Pericles", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCharStats.ForeColor = System.Drawing.Color.Yellow;
            this.lbCharStats.Location = new System.Drawing.Point(89, 27);
            this.lbCharStats.Name = "lbCharStats";
            this.lbCharStats.Size = new System.Drawing.Size(109, 125);
            this.lbCharStats.TabIndex = 5;
            this.lbCharStats.Text = "Class: XX\r\n\r\nHealth: XX/YY\r\nStrength: XX\r\nAgility: XX\r\nIntellect: XX\r\nArmor: XX";
            // 
            // comboBoxAbilities
            // 
            this.comboBoxAbilities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAbilities.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAbilities.ForeColor = System.Drawing.Color.DarkRed;
            this.comboBoxAbilities.FormattingEnabled = true;
            this.comboBoxAbilities.Location = new System.Drawing.Point(249, 57);
            this.comboBoxAbilities.Name = "comboBoxAbilities";
            this.comboBoxAbilities.Size = new System.Drawing.Size(124, 23);
            this.comboBoxAbilities.TabIndex = 6;
            this.comboBoxAbilities.SelectedIndexChanged += new System.EventHandler(this.comboBoxAbilities_SelectedIndexChanged);
            // 
            // lbTurnpoints
            // 
            this.lbTurnpoints.BackColor = System.Drawing.Color.Transparent;
            this.lbTurnpoints.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTurnpoints.Font = new System.Drawing.Font("Pericles", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTurnpoints.ForeColor = System.Drawing.Color.Yellow;
            this.lbTurnpoints.Location = new System.Drawing.Point(248, 35);
            this.lbTurnpoints.Name = "lbTurnpoints";
            this.lbTurnpoints.Size = new System.Drawing.Size(124, 19);
            this.lbTurnpoints.TabIndex = 8;
            this.lbTurnpoints.Text = "Turnpoints";
            this.lbTurnpoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBoxPlayer1
            // 
            this.checkBoxPlayer1.AutoSize = true;
            this.checkBoxPlayer1.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxPlayer1.Font = new System.Drawing.Font("Pericles", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPlayer1.ForeColor = System.Drawing.Color.Yellow;
            this.checkBoxPlayer1.Location = new System.Drawing.Point(6, 19);
            this.checkBoxPlayer1.Name = "checkBoxPlayer1";
            this.checkBoxPlayer1.Size = new System.Drawing.Size(59, 14);
            this.checkBoxPlayer1.TabIndex = 10;
            this.checkBoxPlayer1.Text = "Player 1";
            this.checkBoxPlayer1.UseVisualStyleBackColor = false;
            this.checkBoxPlayer1.CheckedChanged += new System.EventHandler(this.checkBoxPlayer1_CheckedChanged);
            // 
            // checkBoxPlayer2
            // 
            this.checkBoxPlayer2.AutoSize = true;
            this.checkBoxPlayer2.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxPlayer2.Font = new System.Drawing.Font("Pericles", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPlayer2.ForeColor = System.Drawing.Color.Yellow;
            this.checkBoxPlayer2.Location = new System.Drawing.Point(71, 19);
            this.checkBoxPlayer2.Name = "checkBoxPlayer2";
            this.checkBoxPlayer2.Size = new System.Drawing.Size(61, 14);
            this.checkBoxPlayer2.TabIndex = 11;
            this.checkBoxPlayer2.Text = "Player 2";
            this.checkBoxPlayer2.UseVisualStyleBackColor = false;
            this.checkBoxPlayer2.CheckedChanged += new System.EventHandler(this.checkBoxPlayer2_CheckedChanged);
            // 
            // checkBoxPlayer3
            // 
            this.checkBoxPlayer3.AutoSize = true;
            this.checkBoxPlayer3.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxPlayer3.Font = new System.Drawing.Font("Pericles", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPlayer3.ForeColor = System.Drawing.Color.Yellow;
            this.checkBoxPlayer3.Location = new System.Drawing.Point(5, 39);
            this.checkBoxPlayer3.Name = "checkBoxPlayer3";
            this.checkBoxPlayer3.Size = new System.Drawing.Size(60, 14);
            this.checkBoxPlayer3.TabIndex = 12;
            this.checkBoxPlayer3.Text = "Player 3";
            this.checkBoxPlayer3.UseVisualStyleBackColor = false;
            this.checkBoxPlayer3.CheckedChanged += new System.EventHandler(this.checkBoxPlayer3_CheckedChanged);
            // 
            // checkBoxPlayer4
            // 
            this.checkBoxPlayer4.AutoSize = true;
            this.checkBoxPlayer4.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxPlayer4.Font = new System.Drawing.Font("Pericles", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPlayer4.ForeColor = System.Drawing.Color.Yellow;
            this.checkBoxPlayer4.Location = new System.Drawing.Point(71, 39);
            this.checkBoxPlayer4.Name = "checkBoxPlayer4";
            this.checkBoxPlayer4.Size = new System.Drawing.Size(61, 14);
            this.checkBoxPlayer4.TabIndex = 13;
            this.checkBoxPlayer4.Text = "Player 4";
            this.checkBoxPlayer4.UseVisualStyleBackColor = false;
            this.checkBoxPlayer4.CheckedChanged += new System.EventHandler(this.checkBoxPlayer4_CheckedChanged);
            // 
            // pictureBoxChar
            // 
            this.pictureBoxChar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxChar.Location = new System.Drawing.Point(3, 27);
            this.pictureBoxChar.Name = "pictureBoxChar";
            this.pictureBoxChar.Size = new System.Drawing.Size(80, 125);
            this.pictureBoxChar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxChar.TabIndex = 4;
            this.pictureBoxChar.TabStop = false;
            // 
            // checkBoxEnemy
            // 
            this.checkBoxEnemy.AutoSize = true;
            this.checkBoxEnemy.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEnemy.Font = new System.Drawing.Font("Pericles", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxEnemy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkBoxEnemy.Location = new System.Drawing.Point(39, 59);
            this.checkBoxEnemy.Name = "checkBoxEnemy";
            this.checkBoxEnemy.Size = new System.Drawing.Size(53, 14);
            this.checkBoxEnemy.TabIndex = 14;
            this.checkBoxEnemy.Text = "Enemy";
            this.checkBoxEnemy.UseVisualStyleBackColor = false;
            this.checkBoxEnemy.CheckedChanged += new System.EventHandler(this.checkBoxEnemy_CheckedChanged);
            // 
            // groupBoxTargets
            // 
            this.groupBoxTargets.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxTargets.Controls.Add(this.checkBoxPlayer1);
            this.groupBoxTargets.Controls.Add(this.checkBoxEnemy);
            this.groupBoxTargets.Controls.Add(this.checkBoxPlayer2);
            this.groupBoxTargets.Controls.Add(this.checkBoxPlayer4);
            this.groupBoxTargets.Controls.Add(this.checkBoxPlayer3);
            this.groupBoxTargets.Location = new System.Drawing.Point(249, 76);
            this.groupBoxTargets.Name = "groupBoxTargets";
            this.groupBoxTargets.Size = new System.Drawing.Size(123, 77);
            this.groupBoxTargets.TabIndex = 15;
            this.groupBoxTargets.TabStop = false;
            // 
            // btAttack
            // 
            this.btAttack.BackColor = System.Drawing.Color.DarkRed;
            this.btAttack.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btAttack.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.btAttack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btAttack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btAttack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAttack.Font = new System.Drawing.Font("Pericles", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAttack.ForeColor = System.Drawing.Color.Yellow;
            this.btAttack.Location = new System.Drawing.Point(248, 3);
            this.btAttack.Name = "btAttack";
            this.btAttack.Size = new System.Drawing.Size(123, 22);
            this.btAttack.TabIndex = 16;
            this.btAttack.Text = "Attack!";
            this.btAttack.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAttack.UseVisualStyleBackColor = false;
            this.btAttack.Click += new System.EventHandler(this.btAttack_Click);
            // 
            // labelAbilityDescription
            // 
            this.labelAbilityDescription.BackColor = System.Drawing.Color.Transparent;
            this.labelAbilityDescription.Font = new System.Drawing.Font("Pericles", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAbilityDescription.ForeColor = System.Drawing.Color.Yellow;
            this.labelAbilityDescription.Location = new System.Drawing.Point(377, 0);
            this.labelAbilityDescription.Name = "labelAbilityDescription";
            this.labelAbilityDescription.Size = new System.Drawing.Size(120, 155);
            this.labelAbilityDescription.TabIndex = 17;
            this.labelAbilityDescription.Text = "label1";
            this.labelAbilityDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpHealthBar
            // 
            this.flpHealthBar.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.flpHealthBar.BackColor = System.Drawing.Color.DarkRed;
            this.flpHealthBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.flpHealthBar.Controls.Add(this.labelHealthRemaining);
            this.flpHealthBar.Location = new System.Drawing.Point(4, 3);
            this.flpHealthBar.Margin = new System.Windows.Forms.Padding(0);
            this.flpHealthBar.Name = "flpHealthBar";
            this.flpHealthBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flpHealthBar.Size = new System.Drawing.Size(194, 21);
            this.flpHealthBar.TabIndex = 18;
            this.flpHealthBar.WrapContents = false;
            // 
            // labelHealthRemaining
            // 
            this.labelHealthRemaining.BackColor = System.Drawing.Color.DarkGreen;
            this.labelHealthRemaining.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHealthRemaining.Location = new System.Drawing.Point(0, 0);
            this.labelHealthRemaining.Margin = new System.Windows.Forms.Padding(0);
            this.labelHealthRemaining.Name = "labelHealthRemaining";
            this.labelHealthRemaining.Size = new System.Drawing.Size(100, 21);
            this.labelHealthRemaining.TabIndex = 0;
            this.labelHealthRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbBuffs
            // 
            this.lbBuffs.BackColor = System.Drawing.Color.Transparent;
            this.lbBuffs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbBuffs.Font = new System.Drawing.Font("Pericles", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBuffs.ForeColor = System.Drawing.Color.Yellow;
            this.lbBuffs.Location = new System.Drawing.Point(201, 0);
            this.lbBuffs.Name = "lbBuffs";
            this.lbBuffs.Size = new System.Drawing.Size(41, 25);
            this.lbBuffs.TabIndex = 19;
            this.lbBuffs.Text = "Buffs:";
            this.lbBuffs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpBuffsAndDebuffs
            // 
            this.flpBuffsAndDebuffs.AllowDrop = true;
            this.flpBuffsAndDebuffs.AutoScroll = true;
            this.flpBuffsAndDebuffs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpBuffsAndDebuffs.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpBuffsAndDebuffs.Location = new System.Drawing.Point(201, 28);
            this.flpBuffsAndDebuffs.Name = "flpBuffsAndDebuffs";
            this.flpBuffsAndDebuffs.Size = new System.Drawing.Size(41, 124);
            this.flpBuffsAndDebuffs.TabIndex = 20;
            // 
            // ucCharacterBattle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.flpBuffsAndDebuffs);
            this.Controls.Add(this.lbBuffs);
            this.Controls.Add(this.comboBoxAbilities);
            this.Controls.Add(this.flpHealthBar);
            this.Controls.Add(this.labelAbilityDescription);
            this.Controls.Add(this.btAttack);
            this.Controls.Add(this.groupBoxTargets);
            this.Controls.Add(this.lbTurnpoints);
            this.Controls.Add(this.lbCharStats);
            this.Controls.Add(this.pictureBoxChar);
            this.Font = new System.Drawing.Font("Pericles", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucCharacterBattle";
            this.Size = new System.Drawing.Size(500, 155);
            this.Load += new System.EventHandler(this.ucCharacterBattle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChar)).EndInit();
            this.groupBoxTargets.ResumeLayout(false);
            this.groupBoxTargets.PerformLayout();
            this.flpHealthBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbCharStats;
        private System.Windows.Forms.PictureBox pictureBoxChar;
        private System.Windows.Forms.ComboBox comboBoxAbilities;
        private System.Windows.Forms.Label lbTurnpoints;
        private System.Windows.Forms.CheckBox checkBoxPlayer1;
        private System.Windows.Forms.CheckBox checkBoxPlayer2;
        private System.Windows.Forms.CheckBox checkBoxPlayer3;
        private System.Windows.Forms.CheckBox checkBoxPlayer4;
        private System.Windows.Forms.CheckBox checkBoxEnemy;
        private System.Windows.Forms.GroupBox groupBoxTargets;
        private System.Windows.Forms.Button btAttack;
        private System.Windows.Forms.Label labelAbilityDescription;
        private System.Windows.Forms.FlowLayoutPanel flpHealthBar;
        private System.Windows.Forms.Label labelHealthRemaining;
        private System.Windows.Forms.Label lbBuffs;
        private System.Windows.Forms.FlowLayoutPanel flpBuffsAndDebuffs;

    }
}
