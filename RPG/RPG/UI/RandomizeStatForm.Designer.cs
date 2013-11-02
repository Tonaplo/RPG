namespace RPG.UI
{
    partial class RandomizeStatForm
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
            this.listBoxGear = new System.Windows.Forms.ListBox();
            this.labelInventory = new System.Windows.Forms.Label();
            this.labelGearOfChar = new System.Windows.Forms.Label();
            this.listBoxInventory = new System.Windows.Forms.ListBox();
            this.labelChosenItemIGNORE = new System.Windows.Forms.Label();
            this.labelChosenItem = new System.Windows.Forms.Label();
            this.labelDust = new System.Windows.Forms.Label();
            this.comboBoxAttribute = new System.Windows.Forms.ComboBox();
            this.btRandomize = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.labelChange = new System.Windows.Forms.Label();
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
            this.comboBoxChooseChar.Location = new System.Drawing.Point(12, 12);
            this.comboBoxChooseChar.Name = "comboBoxChooseChar";
            this.comboBoxChooseChar.Size = new System.Drawing.Size(174, 23);
            this.comboBoxChooseChar.TabIndex = 22;
            this.comboBoxChooseChar.SelectedIndexChanged += new System.EventHandler(this.comboBoxChooseChar_SelectedIndexChanged);
            // 
            // listBoxGear
            // 
            this.listBoxGear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.listBoxGear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxGear.FormattingEnabled = true;
            this.listBoxGear.ItemHeight = 15;
            this.listBoxGear.Location = new System.Drawing.Point(12, 56);
            this.listBoxGear.Name = "listBoxGear";
            this.listBoxGear.Size = new System.Drawing.Size(174, 124);
            this.listBoxGear.TabIndex = 23;
            this.listBoxGear.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxGear_DrawItem);
            this.listBoxGear.SelectedIndexChanged += new System.EventHandler(this.listBoxGear_SelectedIndexChanged);
            // 
            // labelInventory
            // 
            this.labelInventory.BackColor = System.Drawing.Color.Transparent;
            this.labelInventory.ForeColor = System.Drawing.Color.Yellow;
            this.labelInventory.Location = new System.Drawing.Point(12, 186);
            this.labelInventory.Name = "labelInventory";
            this.labelInventory.Size = new System.Drawing.Size(174, 15);
            this.labelInventory.TabIndex = 24;
            this.labelInventory.Text = "Inventory:";
            this.labelInventory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGearOfChar
            // 
            this.labelGearOfChar.BackColor = System.Drawing.Color.Transparent;
            this.labelGearOfChar.ForeColor = System.Drawing.Color.Yellow;
            this.labelGearOfChar.Location = new System.Drawing.Point(12, 38);
            this.labelGearOfChar.Name = "labelGearOfChar";
            this.labelGearOfChar.Size = new System.Drawing.Size(174, 15);
            this.labelGearOfChar.TabIndex = 25;
            this.labelGearOfChar.Text = "Gear of x";
            this.labelGearOfChar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBoxInventory
            // 
            this.listBoxInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.listBoxInventory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxInventory.FormattingEnabled = true;
            this.listBoxInventory.ItemHeight = 15;
            this.listBoxInventory.Location = new System.Drawing.Point(15, 212);
            this.listBoxInventory.Name = "listBoxInventory";
            this.listBoxInventory.Size = new System.Drawing.Size(174, 259);
            this.listBoxInventory.TabIndex = 26;
            this.listBoxInventory.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxInventory_DrawItem);
            this.listBoxInventory.SelectedIndexChanged += new System.EventHandler(this.listBoxInventory_SelectedIndexChanged);
            // 
            // labelChosenItemIGNORE
            // 
            this.labelChosenItemIGNORE.BackColor = System.Drawing.Color.Transparent;
            this.labelChosenItemIGNORE.ForeColor = System.Drawing.Color.Yellow;
            this.labelChosenItemIGNORE.Location = new System.Drawing.Point(192, 38);
            this.labelChosenItemIGNORE.Name = "labelChosenItemIGNORE";
            this.labelChosenItemIGNORE.Size = new System.Drawing.Size(147, 18);
            this.labelChosenItemIGNORE.TabIndex = 27;
            this.labelChosenItemIGNORE.Text = "Chosen Item:";
            this.labelChosenItemIGNORE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelChosenItem
            // 
            this.labelChosenItem.BackColor = System.Drawing.Color.Transparent;
            this.labelChosenItem.Font = new System.Drawing.Font("Pericles", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChosenItem.ForeColor = System.Drawing.Color.Gold;
            this.labelChosenItem.Location = new System.Drawing.Point(192, 56);
            this.labelChosenItem.Name = "labelChosenItem";
            this.labelChosenItem.Size = new System.Drawing.Size(147, 145);
            this.labelChosenItem.TabIndex = 28;
            // 
            // labelDust
            // 
            this.labelDust.BackColor = System.Drawing.Color.Transparent;
            this.labelDust.ForeColor = System.Drawing.Color.Yellow;
            this.labelDust.Location = new System.Drawing.Point(192, 15);
            this.labelDust.Name = "labelDust";
            this.labelDust.Size = new System.Drawing.Size(147, 20);
            this.labelDust.TabIndex = 29;
            this.labelDust.Text = "Dust:";
            // 
            // comboBoxAttribute
            // 
            this.comboBoxAttribute.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.comboBoxAttribute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAttribute.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAttribute.ForeColor = System.Drawing.Color.Yellow;
            this.comboBoxAttribute.FormattingEnabled = true;
            this.comboBoxAttribute.Location = new System.Drawing.Point(195, 212);
            this.comboBoxAttribute.Name = "comboBoxAttribute";
            this.comboBoxAttribute.Size = new System.Drawing.Size(147, 23);
            this.comboBoxAttribute.TabIndex = 30;
            // 
            // btRandomize
            // 
            this.btRandomize.BackColor = System.Drawing.Color.DarkRed;
            this.btRandomize.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btRandomize.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.btRandomize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btRandomize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btRandomize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRandomize.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRandomize.ForeColor = System.Drawing.Color.Yellow;
            this.btRandomize.Location = new System.Drawing.Point(195, 415);
            this.btRandomize.Name = "btRandomize";
            this.btRandomize.Size = new System.Drawing.Size(144, 25);
            this.btRandomize.TabIndex = 31;
            this.btRandomize.Text = "Randomize";
            this.btRandomize.UseVisualStyleBackColor = false;
            this.btRandomize.Click += new System.EventHandler(this.btRandomize_Click);
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.DarkRed;
            this.btExit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btExit.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.btExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExit.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExit.ForeColor = System.Drawing.Color.Yellow;
            this.btExit.Location = new System.Drawing.Point(195, 446);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(144, 25);
            this.btExit.TabIndex = 32;
            this.btExit.Text = "Exit";
            this.btExit.UseVisualStyleBackColor = false;
            this.btExit.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // labelChange
            // 
            this.labelChange.BackColor = System.Drawing.Color.Transparent;
            this.labelChange.Font = new System.Drawing.Font("Pericles", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChange.ForeColor = System.Drawing.Color.Gold;
            this.labelChange.Location = new System.Drawing.Point(195, 273);
            this.labelChange.Name = "labelChange";
            this.labelChange.Size = new System.Drawing.Size(147, 139);
            this.labelChange.TabIndex = 33;
            // 
            // labelBackgroundIGNORE
            // 
            this.labelBackgroundIGNORE.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.labelBackgroundIGNORE.BackColor = System.Drawing.Color.Transparent;
            this.labelBackgroundIGNORE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBackgroundIGNORE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBackgroundIGNORE.Location = new System.Drawing.Point(0, 0);
            this.labelBackgroundIGNORE.Name = "labelBackgroundIGNORE";
            this.labelBackgroundIGNORE.Size = new System.Drawing.Size(351, 490);
            this.labelBackgroundIGNORE.TabIndex = 34;
            // 
            // RandomizeStatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(351, 490);
            this.Controls.Add(this.labelChange);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btRandomize);
            this.Controls.Add(this.comboBoxAttribute);
            this.Controls.Add(this.labelDust);
            this.Controls.Add(this.labelChosenItem);
            this.Controls.Add(this.labelChosenItemIGNORE);
            this.Controls.Add(this.listBoxInventory);
            this.Controls.Add(this.labelGearOfChar);
            this.Controls.Add(this.labelInventory);
            this.Controls.Add(this.listBoxGear);
            this.Controls.Add(this.comboBoxChooseChar);
            this.Controls.Add(this.labelBackgroundIGNORE);
            this.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RandomizeStatForm";
            this.Text = "RandomizeStatForm";
            this.Load += new System.EventHandler(this.RandomizeStatForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxChooseChar;
        private System.Windows.Forms.ListBox listBoxGear;
        private System.Windows.Forms.Label labelInventory;
        private System.Windows.Forms.Label labelGearOfChar;
        private System.Windows.Forms.ListBox listBoxInventory;
        private System.Windows.Forms.Label labelChosenItemIGNORE;
        private System.Windows.Forms.Label labelChosenItem;
        private System.Windows.Forms.Label labelDust;
        private System.Windows.Forms.ComboBox comboBoxAttribute;
        private System.Windows.Forms.Button btRandomize;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Label labelChange;
        private System.Windows.Forms.Label labelBackgroundIGNORE;
    }
}