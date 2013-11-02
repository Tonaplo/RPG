namespace RPG.UI
{
    partial class DeleteCharForm
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
            this.comboBoxChooseChar = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanelBattleChar = new System.Windows.Forms.FlowLayoutPanel();
            this.bnCancel = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.labelBackgroundIGNORE = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.comboBoxChooseChar.Size = new System.Drawing.Size(343, 23);
            this.comboBoxChooseChar.TabIndex = 23;
            this.comboBoxChooseChar.SelectedIndexChanged += new System.EventHandler(this.comboBoxChooseChar_SelectedIndexChanged);
            // 
            // flowLayoutPanelBattleChar
            // 
            this.flowLayoutPanelBattleChar.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanelBattleChar.Name = "flowLayoutPanelBattleChar";
            this.flowLayoutPanelBattleChar.Size = new System.Drawing.Size(344, 155);
            this.flowLayoutPanelBattleChar.TabIndex = 22;
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
            this.bnCancel.Location = new System.Drawing.Point(196, 208);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(163, 23);
            this.bnCancel.TabIndex = 25;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = false;
            this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
            // 
            // btDelete
            // 
            this.btDelete.BackColor = System.Drawing.Color.DarkRed;
            this.btDelete.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btDelete.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.btDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDelete.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDelete.ForeColor = System.Drawing.Color.Yellow;
            this.btDelete.Location = new System.Drawing.Point(13, 208);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(163, 23);
            this.btDelete.TabIndex = 24;
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = false;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // labelBackgroundIGNORE
            // 
            this.labelBackgroundIGNORE.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.labelBackgroundIGNORE.BackColor = System.Drawing.Color.Transparent;
            this.labelBackgroundIGNORE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBackgroundIGNORE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBackgroundIGNORE.Location = new System.Drawing.Point(0, 0);
            this.labelBackgroundIGNORE.Name = "labelBackgroundIGNORE";
            this.labelBackgroundIGNORE.Size = new System.Drawing.Size(371, 244);
            this.labelBackgroundIGNORE.TabIndex = 26;
            // 
            // DeleteCharForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(371, 244);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.comboBoxChooseChar);
            this.Controls.Add(this.flowLayoutPanelBattleChar);
            this.Controls.Add(this.labelBackgroundIGNORE);
            this.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeleteCharForm";
            this.Text = "DeleteCharForm";
            this.Load += new System.EventHandler(this.DeleteCharForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxChooseChar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBattleChar;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Label labelBackgroundIGNORE;
    }
}