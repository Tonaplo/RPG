﻿namespace RPG.UI
{
    partial class ChangeGearForm
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
            this.bnCancel = new System.Windows.Forms.Button();
            this.btEquip = new System.Windows.Forms.Button();
            this.labelEquippedItem = new System.Windows.Forms.Label();
            this.labelCurrentItem = new System.Windows.Forms.Label();
            this.labelCharacterStats = new System.Windows.Forms.Label();
            this.pictureBoxChar = new System.Windows.Forms.PictureBox();
            this.labelBackgroundIGNORE = new System.Windows.Forms.Label();
            this.labelCurrentTitle = new System.Windows.Forms.Label();
            this.labelNewItemTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChar)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxChooseChar
            // 
            this.comboBoxChooseChar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.comboBoxChooseChar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChooseChar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxChooseChar.ForeColor = System.Drawing.Color.Yellow;
            this.comboBoxChooseChar.FormattingEnabled = true;
            this.comboBoxChooseChar.Location = new System.Drawing.Point(10, 120);
            this.comboBoxChooseChar.Name = "comboBoxChooseChar";
            this.comboBoxChooseChar.Size = new System.Drawing.Size(212, 21);
            this.comboBoxChooseChar.TabIndex = 22;
            this.comboBoxChooseChar.SelectedIndexChanged += new System.EventHandler(this.comboBoxChooseChar_SelectedIndexChanged);
            // 
            // bnCancel
            // 
            this.bnCancel.BackColor = System.Drawing.Color.DarkRed;
            this.bnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bnCancel.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.bnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.bnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.bnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnCancel.ForeColor = System.Drawing.Color.Yellow;
            this.bnCancel.Location = new System.Drawing.Point(119, 357);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(95, 39);
            this.bnCancel.TabIndex = 24;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = false;
            this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
            // 
            // btEquip
            // 
            this.btEquip.BackColor = System.Drawing.Color.DarkRed;
            this.btEquip.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btEquip.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.btEquip.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btEquip.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btEquip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEquip.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEquip.ForeColor = System.Drawing.Color.Yellow;
            this.btEquip.Location = new System.Drawing.Point(10, 357);
            this.btEquip.Name = "btEquip";
            this.btEquip.Size = new System.Drawing.Size(95, 39);
            this.btEquip.TabIndex = 25;
            this.btEquip.Text = "Equip";
            this.btEquip.UseVisualStyleBackColor = false;
            this.btEquip.Click += new System.EventHandler(this.btEquip_Click);
            // 
            // labelEquippedItem
            // 
            this.labelEquippedItem.BackColor = System.Drawing.Color.Transparent;
            this.labelEquippedItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEquippedItem.ForeColor = System.Drawing.Color.Yellow;
            this.labelEquippedItem.Location = new System.Drawing.Point(11, 170);
            this.labelEquippedItem.Name = "labelEquippedItem";
            this.labelEquippedItem.Size = new System.Drawing.Size(94, 184);
            this.labelEquippedItem.TabIndex = 26;
            this.labelEquippedItem.Text = "label1";
            this.labelEquippedItem.Click += new System.EventHandler(this.labelEquippedItem_Click);
            // 
            // labelCurrentItem
            // 
            this.labelCurrentItem.BackColor = System.Drawing.Color.Transparent;
            this.labelCurrentItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentItem.ForeColor = System.Drawing.Color.Yellow;
            this.labelCurrentItem.Location = new System.Drawing.Point(120, 170);
            this.labelCurrentItem.Name = "labelCurrentItem";
            this.labelCurrentItem.Size = new System.Drawing.Size(94, 184);
            this.labelCurrentItem.TabIndex = 27;
            this.labelCurrentItem.Text = "label1";
            // 
            // labelCharacterStats
            // 
            this.labelCharacterStats.BackColor = System.Drawing.Color.Transparent;
            this.labelCharacterStats.ForeColor = System.Drawing.Color.Yellow;
            this.labelCharacterStats.Location = new System.Drawing.Point(84, 10);
            this.labelCharacterStats.Name = "labelCharacterStats";
            this.labelCharacterStats.Size = new System.Drawing.Size(134, 104);
            this.labelCharacterStats.TabIndex = 28;
            this.labelCharacterStats.Text = "label1";
            // 
            // pictureBoxChar
            // 
            this.pictureBoxChar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxChar.Location = new System.Drawing.Point(10, 10);
            this.pictureBoxChar.Name = "pictureBoxChar";
            this.pictureBoxChar.Size = new System.Drawing.Size(69, 104);
            this.pictureBoxChar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxChar.TabIndex = 23;
            this.pictureBoxChar.TabStop = false;
            // 
            // labelBackgroundIGNORE
            // 
            this.labelBackgroundIGNORE.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.labelBackgroundIGNORE.BackColor = System.Drawing.Color.Transparent;
            this.labelBackgroundIGNORE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBackgroundIGNORE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBackgroundIGNORE.Location = new System.Drawing.Point(0, 0);
            this.labelBackgroundIGNORE.Name = "labelBackgroundIGNORE";
            this.labelBackgroundIGNORE.Size = new System.Drawing.Size(228, 408);
            this.labelBackgroundIGNORE.TabIndex = 29;
            // 
            // labelCurrentTitle
            // 
            this.labelCurrentTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelCurrentTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentTitle.ForeColor = System.Drawing.Color.Yellow;
            this.labelCurrentTitle.Location = new System.Drawing.Point(11, 144);
            this.labelCurrentTitle.Name = "labelCurrentTitle";
            this.labelCurrentTitle.Size = new System.Drawing.Size(94, 26);
            this.labelCurrentTitle.TabIndex = 30;
            this.labelCurrentTitle.Text = "Current Item:";
            this.labelCurrentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNewItemTitle
            // 
            this.labelNewItemTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelNewItemTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewItemTitle.ForeColor = System.Drawing.Color.Yellow;
            this.labelNewItemTitle.Location = new System.Drawing.Point(120, 144);
            this.labelNewItemTitle.Name = "labelNewItemTitle";
            this.labelNewItemTitle.Size = new System.Drawing.Size(94, 26);
            this.labelNewItemTitle.TabIndex = 31;
            this.labelNewItemTitle.Text = "New Item:";
            this.labelNewItemTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChangeGearForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(228, 408);
            this.Controls.Add(this.labelNewItemTitle);
            this.Controls.Add(this.labelCurrentTitle);
            this.Controls.Add(this.labelCharacterStats);
            this.Controls.Add(this.labelCurrentItem);
            this.Controls.Add(this.labelEquippedItem);
            this.Controls.Add(this.btEquip);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.pictureBoxChar);
            this.Controls.Add(this.comboBoxChooseChar);
            this.Controls.Add(this.labelBackgroundIGNORE);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChangeGearForm";
            this.Text = "ChangeGearForm";
            this.Load += new System.EventHandler(this.ChangeGearForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxChooseChar;
        private System.Windows.Forms.PictureBox pictureBoxChar;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Button btEquip;
        private System.Windows.Forms.Label labelEquippedItem;
        private System.Windows.Forms.Label labelCurrentItem;
        private System.Windows.Forms.Label labelCharacterStats;
        private System.Windows.Forms.Label labelBackgroundIGNORE;
        private System.Windows.Forms.Label labelCurrentTitle;
        private System.Windows.Forms.Label labelNewItemTitle;
    }
}