namespace RPG
{
    partial class FindLocalBattleForm
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
            this.btSinglePlayer = new System.Windows.Forms.Button();
            this.flowLayoutPanelBattleChar = new System.Windows.Forms.FlowLayoutPanel();
            this.bnCancel = new System.Windows.Forms.Button();
            this.comboBoxChooseChar = new System.Windows.Forms.ComboBox();
            this.labelBackgroundIGNORE = new System.Windows.Forms.Label();
            this.comboBoxDifficulty = new System.Windows.Forms.ComboBox();
            this.bnAddChar = new System.Windows.Forms.Button();
            this.bnRemoveChar = new System.Windows.Forms.Button();
            this.labelSelectedChars = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btSinglePlayer
            // 
            this.btSinglePlayer.BackColor = System.Drawing.Color.DarkRed;
            this.btSinglePlayer.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btSinglePlayer.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.btSinglePlayer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btSinglePlayer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btSinglePlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSinglePlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSinglePlayer.ForeColor = System.Drawing.Color.Yellow;
            this.btSinglePlayer.Location = new System.Drawing.Point(11, 336);
            this.btSinglePlayer.Name = "btSinglePlayer";
            this.btSinglePlayer.Size = new System.Drawing.Size(170, 35);
            this.btSinglePlayer.TabIndex = 17;
            this.btSinglePlayer.Text = "Battle!";
            this.btSinglePlayer.UseVisualStyleBackColor = false;
            this.btSinglePlayer.Click += new System.EventHandler(this.btSinglePlayer_Click);
            // 
            // flowLayoutPanelBattleChar
            // 
            this.flowLayoutPanelBattleChar.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelBattleChar.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanelBattleChar.Name = "flowLayoutPanelBattleChar";
            this.flowLayoutPanelBattleChar.Size = new System.Drawing.Size(350, 155);
            this.flowLayoutPanelBattleChar.TabIndex = 19;
            // 
            // bnCancel
            // 
            this.bnCancel.BackColor = System.Drawing.Color.DarkRed;
            this.bnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bnCancel.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.bnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.bnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.bnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnCancel.ForeColor = System.Drawing.Color.Yellow;
            this.bnCancel.Location = new System.Drawing.Point(193, 336);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(169, 35);
            this.bnCancel.TabIndex = 20;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = false;
            this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
            // 
            // comboBoxChooseChar
            // 
            this.comboBoxChooseChar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.comboBoxChooseChar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChooseChar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxChooseChar.ForeColor = System.Drawing.Color.Yellow;
            this.comboBoxChooseChar.FormattingEnabled = true;
            this.comboBoxChooseChar.Location = new System.Drawing.Point(12, 179);
            this.comboBoxChooseChar.Name = "comboBoxChooseChar";
            this.comboBoxChooseChar.Size = new System.Drawing.Size(169, 21);
            this.comboBoxChooseChar.TabIndex = 21;
            this.comboBoxChooseChar.SelectedIndexChanged += new System.EventHandler(this.comboBoxChooseChar_SelectedIndexChanged);
            // 
            // labelBackgroundIGNORE
            // 
            this.labelBackgroundIGNORE.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.labelBackgroundIGNORE.BackColor = System.Drawing.Color.Transparent;
            this.labelBackgroundIGNORE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBackgroundIGNORE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBackgroundIGNORE.Location = new System.Drawing.Point(0, 0);
            this.labelBackgroundIGNORE.Name = "labelBackgroundIGNORE";
            this.labelBackgroundIGNORE.Size = new System.Drawing.Size(375, 377);
            this.labelBackgroundIGNORE.TabIndex = 22;
            // 
            // comboBoxDifficulty
            // 
            this.comboBoxDifficulty.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.comboBoxDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDifficulty.ForeColor = System.Drawing.Color.Yellow;
            this.comboBoxDifficulty.FormattingEnabled = true;
            this.comboBoxDifficulty.Location = new System.Drawing.Point(193, 179);
            this.comboBoxDifficulty.Name = "comboBoxDifficulty";
            this.comboBoxDifficulty.Size = new System.Drawing.Size(169, 21);
            this.comboBoxDifficulty.TabIndex = 26;
            // 
            // bnAddChar
            // 
            this.bnAddChar.BackColor = System.Drawing.Color.DarkRed;
            this.bnAddChar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bnAddChar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.bnAddChar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.bnAddChar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.bnAddChar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnAddChar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnAddChar.ForeColor = System.Drawing.Color.Yellow;
            this.bnAddChar.Location = new System.Drawing.Point(12, 208);
            this.bnAddChar.Name = "bnAddChar";
            this.bnAddChar.Size = new System.Drawing.Size(170, 23);
            this.bnAddChar.TabIndex = 27;
            this.bnAddChar.Text = "Add Character";
            this.bnAddChar.UseVisualStyleBackColor = false;
            this.bnAddChar.Click += new System.EventHandler(this.bnAddChar_Click);
            // 
            // bnRemoveChar
            // 
            this.bnRemoveChar.BackColor = System.Drawing.Color.DarkRed;
            this.bnRemoveChar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bnRemoveChar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.bnRemoveChar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.bnRemoveChar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.bnRemoveChar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnRemoveChar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnRemoveChar.ForeColor = System.Drawing.Color.Yellow;
            this.bnRemoveChar.Location = new System.Drawing.Point(192, 208);
            this.bnRemoveChar.Name = "bnRemoveChar";
            this.bnRemoveChar.Size = new System.Drawing.Size(170, 23);
            this.bnRemoveChar.TabIndex = 28;
            this.bnRemoveChar.Text = "Remove Character";
            this.bnRemoveChar.UseVisualStyleBackColor = false;
            this.bnRemoveChar.Click += new System.EventHandler(this.bnRemoveChar_Click);
            // 
            // labelSelectedChars
            // 
            this.labelSelectedChars.BackColor = System.Drawing.Color.Transparent;
            this.labelSelectedChars.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectedChars.ForeColor = System.Drawing.Color.Yellow;
            this.labelSelectedChars.Location = new System.Drawing.Point(12, 234);
            this.labelSelectedChars.Name = "labelSelectedChars";
            this.labelSelectedChars.Size = new System.Drawing.Size(350, 98);
            this.labelSelectedChars.TabIndex = 29;
            this.labelSelectedChars.Text = "Battling Characters:";
            this.labelSelectedChars.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FindLocalBattleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(375, 377);
            this.Controls.Add(this.labelSelectedChars);
            this.Controls.Add(this.bnRemoveChar);
            this.Controls.Add(this.bnAddChar);
            this.Controls.Add(this.comboBoxDifficulty);
            this.Controls.Add(this.comboBoxChooseChar);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.flowLayoutPanelBattleChar);
            this.Controls.Add(this.btSinglePlayer);
            this.Controls.Add(this.labelBackgroundIGNORE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FindLocalBattleForm";
            this.Text = "FindBattleForm";
            this.Load += new System.EventHandler(this.FindBattleForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btSinglePlayer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBattleChar;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.ComboBox comboBoxChooseChar;
        private System.Windows.Forms.Label labelBackgroundIGNORE;
        private System.Windows.Forms.ComboBox comboBoxDifficulty;
        private System.Windows.Forms.Button bnAddChar;
        private System.Windows.Forms.Button bnRemoveChar;
        private System.Windows.Forms.Label labelSelectedChars;
    }
}