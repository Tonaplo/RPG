namespace RPG.UI
{
    partial class OptionsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bnOk = new System.Windows.Forms.Button();
            this.labelBackgroundIGNORE = new System.Windows.Forms.Label();
            this.labelDifficultyLevel = new System.Windows.Forms.Label();
            this.comboBoxDifficulty = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxChooseChar = new System.Windows.Forms.ComboBox();
            this.bnAbandon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bnOk
            // 
            this.bnOk.BackColor = System.Drawing.Color.DarkRed;
            this.bnOk.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bnOk.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.bnOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.bnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.bnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnOk.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnOk.ForeColor = System.Drawing.Color.Yellow;
            this.bnOk.Location = new System.Drawing.Point(45, 206);
            this.bnOk.Name = "bnOk";
            this.bnOk.Size = new System.Drawing.Size(174, 35);
            this.bnOk.TabIndex = 29;
            this.bnOk.Text = "OK";
            this.bnOk.UseVisualStyleBackColor = false;
            this.bnOk.Click += new System.EventHandler(this.bnOK_Click);
            // 
            // labelBackgroundIGNORE
            // 
            this.labelBackgroundIGNORE.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.labelBackgroundIGNORE.BackColor = System.Drawing.Color.Transparent;
            this.labelBackgroundIGNORE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBackgroundIGNORE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBackgroundIGNORE.Location = new System.Drawing.Point(0, 0);
            this.labelBackgroundIGNORE.Name = "labelBackgroundIGNORE";
            this.labelBackgroundIGNORE.Size = new System.Drawing.Size(260, 267);
            this.labelBackgroundIGNORE.TabIndex = 30;
            // 
            // labelDifficultyLevel
            // 
            this.labelDifficultyLevel.BackColor = System.Drawing.Color.Transparent;
            this.labelDifficultyLevel.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDifficultyLevel.ForeColor = System.Drawing.Color.Yellow;
            this.labelDifficultyLevel.Location = new System.Drawing.Point(45, 12);
            this.labelDifficultyLevel.Name = "labelDifficultyLevel";
            this.labelDifficultyLevel.Size = new System.Drawing.Size(174, 22);
            this.labelDifficultyLevel.TabIndex = 31;
            this.labelDifficultyLevel.Text = "Standard Difficulty Level:";
            this.labelDifficultyLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxDifficulty
            // 
            this.comboBoxDifficulty.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.comboBoxDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDifficulty.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDifficulty.ForeColor = System.Drawing.Color.Yellow;
            this.comboBoxDifficulty.FormattingEnabled = true;
            this.comboBoxDifficulty.Location = new System.Drawing.Point(45, 37);
            this.comboBoxDifficulty.Name = "comboBoxDifficulty";
            this.comboBoxDifficulty.Size = new System.Drawing.Size(174, 23);
            this.comboBoxDifficulty.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(45, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 22);
            this.label1.TabIndex = 33;
            this.label1.Text = "Standard Battle Character:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxChooseChar
            // 
            this.comboBoxChooseChar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.comboBoxChooseChar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChooseChar.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxChooseChar.ForeColor = System.Drawing.Color.Yellow;
            this.comboBoxChooseChar.FormattingEnabled = true;
            this.comboBoxChooseChar.Location = new System.Drawing.Point(45, 101);
            this.comboBoxChooseChar.Name = "comboBoxChooseChar";
            this.comboBoxChooseChar.Size = new System.Drawing.Size(174, 23);
            this.comboBoxChooseChar.TabIndex = 34;
            // 
            // bnAbandon
            // 
            this.bnAbandon.BackColor = System.Drawing.Color.DarkRed;
            this.bnAbandon.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bnAbandon.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.bnAbandon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.bnAbandon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.bnAbandon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnAbandon.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnAbandon.ForeColor = System.Drawing.Color.Yellow;
            this.bnAbandon.Location = new System.Drawing.Point(45, 141);
            this.bnAbandon.Name = "bnAbandon";
            this.bnAbandon.Size = new System.Drawing.Size(174, 24);
            this.bnAbandon.TabIndex = 35;
            this.bnAbandon.Text = "Abandon Current Quest";
            this.bnAbandon.UseVisualStyleBackColor = false;
            this.bnAbandon.Click += new System.EventHandler(this.bnAbandon_Click);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(260, 267);
            this.Controls.Add(this.bnAbandon);
            this.Controls.Add(this.comboBoxChooseChar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxDifficulty);
            this.Controls.Add(this.labelDifficultyLevel);
            this.Controls.Add(this.bnOk);
            this.Controls.Add(this.labelBackgroundIGNORE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OptionsForm";
            this.Text = "OptionsForm";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bnOk;
        private System.Windows.Forms.Label labelBackgroundIGNORE;
        private System.Windows.Forms.Label labelDifficultyLevel;
        private System.Windows.Forms.ComboBox comboBoxDifficulty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxChooseChar;
        private System.Windows.Forms.Button bnAbandon;
    }
}