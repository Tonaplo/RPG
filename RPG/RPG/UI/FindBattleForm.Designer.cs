namespace RPG
{
    partial class FindBattleForm
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
            this.bnMultiplayer = new System.Windows.Forms.Button();
            this.flowLayoutPanelBattleChar = new System.Windows.Forms.FlowLayoutPanel();
            this.bnCancel = new System.Windows.Forms.Button();
            this.comboBoxChooseChar = new System.Windows.Forms.ComboBox();
            this.labelBackgroundIGNORE = new System.Windows.Forms.Label();
            this.labelNumberOfPlayer1 = new System.Windows.Forms.Label();
            this.labelNumberOfPlayer2 = new System.Windows.Forms.Label();
            this.comboBoxNumberOfPlayers = new System.Windows.Forms.ComboBox();
            this.comboBoxDifficulty = new System.Windows.Forms.ComboBox();
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
            this.btSinglePlayer.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSinglePlayer.ForeColor = System.Drawing.Color.Yellow;
            this.btSinglePlayer.Location = new System.Drawing.Point(193, 179);
            this.btSinglePlayer.Name = "btSinglePlayer";
            this.btSinglePlayer.Size = new System.Drawing.Size(163, 23);
            this.btSinglePlayer.TabIndex = 17;
            this.btSinglePlayer.Text = "Find Single Player Battle";
            this.btSinglePlayer.UseVisualStyleBackColor = false;
            this.btSinglePlayer.Click += new System.EventHandler(this.btSinglePlayer_Click);
            // 
            // bnMultiplayer
            // 
            this.bnMultiplayer.BackColor = System.Drawing.Color.DarkRed;
            this.bnMultiplayer.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bnMultiplayer.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.bnMultiplayer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.bnMultiplayer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.bnMultiplayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnMultiplayer.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnMultiplayer.ForeColor = System.Drawing.Color.Yellow;
            this.bnMultiplayer.Location = new System.Drawing.Point(193, 208);
            this.bnMultiplayer.Name = "bnMultiplayer";
            this.bnMultiplayer.Size = new System.Drawing.Size(163, 23);
            this.bnMultiplayer.TabIndex = 18;
            this.bnMultiplayer.Text = "Find MultiPlayer Battle";
            this.bnMultiplayer.UseVisualStyleBackColor = false;
            this.bnMultiplayer.Click += new System.EventHandler(this.bnMultiplayer_Click);
            // 
            // flowLayoutPanelBattleChar
            // 
            this.flowLayoutPanelBattleChar.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelBattleChar.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanelBattleChar.Name = "flowLayoutPanelBattleChar";
            this.flowLayoutPanelBattleChar.Size = new System.Drawing.Size(344, 155);
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
            this.bnCancel.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnCancel.ForeColor = System.Drawing.Color.Yellow;
            this.bnCancel.Location = new System.Drawing.Point(193, 237);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(163, 23);
            this.bnCancel.TabIndex = 20;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = false;
            this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
            // 
            // comboBoxChooseChar
            // 
            this.comboBoxChooseChar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.comboBoxChooseChar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChooseChar.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxChooseChar.ForeColor = System.Drawing.Color.Yellow;
            this.comboBoxChooseChar.FormattingEnabled = true;
            this.comboBoxChooseChar.Location = new System.Drawing.Point(13, 179);
            this.comboBoxChooseChar.Name = "comboBoxChooseChar";
            this.comboBoxChooseChar.Size = new System.Drawing.Size(174, 23);
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
            this.labelBackgroundIGNORE.Size = new System.Drawing.Size(368, 270);
            this.labelBackgroundIGNORE.TabIndex = 22;
            // 
            // labelNumberOfPlayer1
            // 
            this.labelNumberOfPlayer1.BackColor = System.Drawing.Color.Transparent;
            this.labelNumberOfPlayer1.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberOfPlayer1.ForeColor = System.Drawing.Color.Yellow;
            this.labelNumberOfPlayer1.Location = new System.Drawing.Point(12, 213);
            this.labelNumberOfPlayer1.Name = "labelNumberOfPlayer1";
            this.labelNumberOfPlayer1.Size = new System.Drawing.Size(81, 18);
            this.labelNumberOfPlayer1.TabIndex = 23;
            this.labelNumberOfPlayer1.Text = "Group with";
            this.labelNumberOfPlayer1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelNumberOfPlayer2
            // 
            this.labelNumberOfPlayer2.BackColor = System.Drawing.Color.Transparent;
            this.labelNumberOfPlayer2.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberOfPlayer2.ForeColor = System.Drawing.Color.Yellow;
            this.labelNumberOfPlayer2.Location = new System.Drawing.Point(137, 214);
            this.labelNumberOfPlayer2.Name = "labelNumberOfPlayer2";
            this.labelNumberOfPlayer2.Size = new System.Drawing.Size(50, 18);
            this.labelNumberOfPlayer2.TabIndex = 24;
            this.labelNumberOfPlayer2.Text = "players";
            this.labelNumberOfPlayer2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboBoxNumberOfPlayers
            // 
            this.comboBoxNumberOfPlayers.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.comboBoxNumberOfPlayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNumberOfPlayers.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxNumberOfPlayers.ForeColor = System.Drawing.Color.Yellow;
            this.comboBoxNumberOfPlayers.FormattingEnabled = true;
            this.comboBoxNumberOfPlayers.Location = new System.Drawing.Point(99, 208);
            this.comboBoxNumberOfPlayers.Name = "comboBoxNumberOfPlayers";
            this.comboBoxNumberOfPlayers.Size = new System.Drawing.Size(32, 23);
            this.comboBoxNumberOfPlayers.TabIndex = 25;
            // 
            // comboBoxDifficulty
            // 
            this.comboBoxDifficulty.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.comboBoxDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDifficulty.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDifficulty.ForeColor = System.Drawing.Color.Yellow;
            this.comboBoxDifficulty.FormattingEnabled = true;
            this.comboBoxDifficulty.Location = new System.Drawing.Point(12, 234);
            this.comboBoxDifficulty.Name = "comboBoxDifficulty";
            this.comboBoxDifficulty.Size = new System.Drawing.Size(174, 23);
            this.comboBoxDifficulty.TabIndex = 26;
            // 
            // FindBattleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(368, 270);
            this.Controls.Add(this.comboBoxDifficulty);
            this.Controls.Add(this.comboBoxNumberOfPlayers);
            this.Controls.Add(this.labelNumberOfPlayer2);
            this.Controls.Add(this.labelNumberOfPlayer1);
            this.Controls.Add(this.comboBoxChooseChar);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.flowLayoutPanelBattleChar);
            this.Controls.Add(this.bnMultiplayer);
            this.Controls.Add(this.btSinglePlayer);
            this.Controls.Add(this.labelBackgroundIGNORE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FindBattleForm";
            this.Text = "FindBattleForm";
            this.Load += new System.EventHandler(this.FindBattleForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btSinglePlayer;
        private System.Windows.Forms.Button bnMultiplayer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBattleChar;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.ComboBox comboBoxChooseChar;
        private System.Windows.Forms.Label labelBackgroundIGNORE;
        private System.Windows.Forms.Label labelNumberOfPlayer1;
        private System.Windows.Forms.Label labelNumberOfPlayer2;
        private System.Windows.Forms.ComboBox comboBoxNumberOfPlayers;
        private System.Windows.Forms.ComboBox comboBoxDifficulty;
    }
}