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
            this.bnAbandon = new System.Windows.Forms.Button();
            this.listBoxChars = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButtonSoundOn = new System.Windows.Forms.RadioButton();
            this.radioButtonSoundOff = new System.Windows.Forms.RadioButton();
            this.numericUpDownSound = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSound)).BeginInit();
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
            this.bnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnOk.ForeColor = System.Drawing.Color.Yellow;
            this.bnOk.Location = new System.Drawing.Point(45, 278);
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
            this.labelBackgroundIGNORE.Size = new System.Drawing.Size(260, 334);
            this.labelBackgroundIGNORE.TabIndex = 30;
            // 
            // labelDifficultyLevel
            // 
            this.labelDifficultyLevel.BackColor = System.Drawing.Color.Transparent;
            this.labelDifficultyLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.comboBoxDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDifficulty.ForeColor = System.Drawing.Color.Yellow;
            this.comboBoxDifficulty.FormattingEnabled = true;
            this.comboBoxDifficulty.Location = new System.Drawing.Point(45, 37);
            this.comboBoxDifficulty.Name = "comboBoxDifficulty";
            this.comboBoxDifficulty.Size = new System.Drawing.Size(174, 21);
            this.comboBoxDifficulty.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(45, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 22);
            this.label1.TabIndex = 33;
            this.label1.Text = "Standard Battle Character:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bnAbandon
            // 
            this.bnAbandon.BackColor = System.Drawing.Color.DarkRed;
            this.bnAbandon.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bnAbandon.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.bnAbandon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.bnAbandon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.bnAbandon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnAbandon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnAbandon.ForeColor = System.Drawing.Color.Yellow;
            this.bnAbandon.Location = new System.Drawing.Point(45, 239);
            this.bnAbandon.Name = "bnAbandon";
            this.bnAbandon.Size = new System.Drawing.Size(174, 24);
            this.bnAbandon.TabIndex = 35;
            this.bnAbandon.Text = "Abandon Current Quest";
            this.bnAbandon.UseVisualStyleBackColor = false;
            this.bnAbandon.Click += new System.EventHandler(this.bnAbandon_Click);
            // 
            // listBoxChars
            // 
            this.listBoxChars.FormattingEnabled = true;
            this.listBoxChars.Location = new System.Drawing.Point(45, 86);
            this.listBoxChars.Name = "listBoxChars";
            this.listBoxChars.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxChars.Size = new System.Drawing.Size(174, 69);
            this.listBoxChars.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(43, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 22);
            this.label2.TabIndex = 38;
            this.label2.Text = "Sound Volume:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(151, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 22);
            this.label3.TabIndex = 39;
            this.label3.Text = "Sound:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(151, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 22);
            this.label4.TabIndex = 40;
            this.label4.Text = "On";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(151, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 22);
            this.label5.TabIndex = 41;
            this.label5.Text = "Off";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButtonSoundOn
            // 
            this.radioButtonSoundOn.AutoSize = true;
            this.radioButtonSoundOn.Location = new System.Drawing.Point(205, 185);
            this.radioButtonSoundOn.Name = "radioButtonSoundOn";
            this.radioButtonSoundOn.Size = new System.Drawing.Size(14, 13);
            this.radioButtonSoundOn.TabIndex = 42;
            this.radioButtonSoundOn.TabStop = true;
            this.radioButtonSoundOn.UseVisualStyleBackColor = true;
            this.radioButtonSoundOn.CheckedChanged += new System.EventHandler(this.radioButtonSound_CheckedChanged);
            // 
            // radioButtonSoundOff
            // 
            this.radioButtonSoundOff.AutoSize = true;
            this.radioButtonSoundOff.Location = new System.Drawing.Point(205, 207);
            this.radioButtonSoundOff.Name = "radioButtonSoundOff";
            this.radioButtonSoundOff.Size = new System.Drawing.Size(14, 13);
            this.radioButtonSoundOff.TabIndex = 43;
            this.radioButtonSoundOff.TabStop = true;
            this.radioButtonSoundOff.UseVisualStyleBackColor = true;
            this.radioButtonSoundOff.CheckedChanged += new System.EventHandler(this.radioButtonSound_CheckedChanged);
            // 
            // numericUpDownSound
            // 
            this.numericUpDownSound.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.numericUpDownSound.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownSound.ForeColor = System.Drawing.Color.Yellow;
            this.numericUpDownSound.Location = new System.Drawing.Point(68, 185);
            this.numericUpDownSound.Name = "numericUpDownSound";
            this.numericUpDownSound.Size = new System.Drawing.Size(50, 29);
            this.numericUpDownSound.TabIndex = 44;
            this.numericUpDownSound.ValueChanged += new System.EventHandler(this.numericUpDownSound_ValueChanged);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(260, 334);
            this.Controls.Add(this.numericUpDownSound);
            this.Controls.Add(this.radioButtonSoundOff);
            this.Controls.Add(this.radioButtonSoundOn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxChars);
            this.Controls.Add(this.bnAbandon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxDifficulty);
            this.Controls.Add(this.labelDifficultyLevel);
            this.Controls.Add(this.bnOk);
            this.Controls.Add(this.labelBackgroundIGNORE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OptionsForm";
            this.Text = "OptionsForm";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSound)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnOk;
        private System.Windows.Forms.Label labelBackgroundIGNORE;
        private System.Windows.Forms.Label labelDifficultyLevel;
        private System.Windows.Forms.ComboBox comboBoxDifficulty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bnAbandon;
        private System.Windows.Forms.ListBox listBoxChars;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButtonSoundOn;
        private System.Windows.Forms.RadioButton radioButtonSoundOff;
        private System.Windows.Forms.NumericUpDown numericUpDownSound;
    }
}