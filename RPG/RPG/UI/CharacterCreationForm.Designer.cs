namespace RPG
{
    partial class CharacterCreationForm
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
            this.btCreate = new System.Windows.Forms.Button();
            this.textBoxCharacterName = new System.Windows.Forms.TextBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.pictureBoxLeftArrow = new System.Windows.Forms.PictureBox();
            this.pictureBoxRightArrow = new System.Windows.Forms.PictureBox();
            this.labelClassDescription = new System.Windows.Forms.Label();
            this.labelBackgroundIGNORE = new System.Windows.Forms.Label();
            this.pictureBoxClass = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeftArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRightArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClass)).BeginInit();
            this.SuspendLayout();
            // 
            // btCreate
            // 
            this.btCreate.BackColor = System.Drawing.Color.DarkRed;
            this.btCreate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btCreate.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.btCreate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btCreate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCreate.ForeColor = System.Drawing.Color.Yellow;
            this.btCreate.Location = new System.Drawing.Point(12, 392);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(130, 34);
            this.btCreate.TabIndex = 14;
            this.btCreate.Text = "Create Character";
            this.btCreate.UseVisualStyleBackColor = false;
            this.btCreate.Click += new System.EventHandler(this.btCreate_Click);
            // 
            // textBoxCharacterName
            // 
            this.textBoxCharacterName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.textBoxCharacterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCharacterName.ForeColor = System.Drawing.Color.Red;
            this.textBoxCharacterName.Location = new System.Drawing.Point(60, 12);
            this.textBoxCharacterName.MaxLength = 15;
            this.textBoxCharacterName.Name = "textBoxCharacterName";
            this.textBoxCharacterName.Size = new System.Drawing.Size(180, 20);
            this.textBoxCharacterName.TabIndex = 15;
            this.textBoxCharacterName.Text = "Name";
            this.textBoxCharacterName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxCharacterName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxCharacterName_MouseClick);
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.Color.DarkRed;
            this.btCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btCancel.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.btCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.ForeColor = System.Drawing.Color.Yellow;
            this.btCancel.Location = new System.Drawing.Point(158, 392);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(130, 34);
            this.btCancel.TabIndex = 16;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // pictureBoxLeftArrow
            // 
            this.pictureBoxLeftArrow.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLeftArrow.Image = global::RPG.Properties.Resources.arrowLeft;
            this.pictureBoxLeftArrow.InitialImage = null;
            this.pictureBoxLeftArrow.Location = new System.Drawing.Point(12, 133);
            this.pictureBoxLeftArrow.Name = "pictureBoxLeftArrow";
            this.pictureBoxLeftArrow.Size = new System.Drawing.Size(50, 40);
            this.pictureBoxLeftArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLeftArrow.TabIndex = 18;
            this.pictureBoxLeftArrow.TabStop = false;
            this.pictureBoxLeftArrow.Click += new System.EventHandler(this.pictureBoxLeftArrow_Click);
            this.pictureBoxLeftArrow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxLeftArrow_MouseDown);
            this.pictureBoxLeftArrow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxLeftArrow_MouseUp);
            // 
            // pictureBoxRightArrow
            // 
            this.pictureBoxRightArrow.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxRightArrow.Image = global::RPG.Properties.Resources.arrowRight;
            this.pictureBoxRightArrow.InitialImage = null;
            this.pictureBoxRightArrow.Location = new System.Drawing.Point(238, 133);
            this.pictureBoxRightArrow.Name = "pictureBoxRightArrow";
            this.pictureBoxRightArrow.Size = new System.Drawing.Size(50, 40);
            this.pictureBoxRightArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRightArrow.TabIndex = 17;
            this.pictureBoxRightArrow.TabStop = false;
            this.pictureBoxRightArrow.Click += new System.EventHandler(this.pictureBoxRightArrow_Click);
            this.pictureBoxRightArrow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxRightArrow_MouseDown);
            this.pictureBoxRightArrow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxRightArrow_MouseUp);
            // 
            // labelClassDescription
            // 
            this.labelClassDescription.BackColor = System.Drawing.Color.Transparent;
            this.labelClassDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClassDescription.ForeColor = System.Drawing.Color.Yellow;
            this.labelClassDescription.Location = new System.Drawing.Point(12, 283);
            this.labelClassDescription.Name = "labelClassDescription";
            this.labelClassDescription.Size = new System.Drawing.Size(276, 106);
            this.labelClassDescription.TabIndex = 19;
            this.labelClassDescription.Text = "WARRIOR\r\n\r\nA pure Strength class, dealing uncontrollable damage to whatever is ar" +
    "ound him.\"";
            this.labelClassDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelBackgroundIGNORE
            // 
            this.labelBackgroundIGNORE.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.labelBackgroundIGNORE.BackColor = System.Drawing.Color.Transparent;
            this.labelBackgroundIGNORE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBackgroundIGNORE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBackgroundIGNORE.Location = new System.Drawing.Point(0, 0);
            this.labelBackgroundIGNORE.Name = "labelBackgroundIGNORE";
            this.labelBackgroundIGNORE.Size = new System.Drawing.Size(300, 438);
            this.labelBackgroundIGNORE.TabIndex = 0;
            // 
            // pictureBoxClass
            // 
            this.pictureBoxClass.Image = global::RPG.Properties.Resources.warrior;
            this.pictureBoxClass.Location = new System.Drawing.Point(68, 40);
            this.pictureBoxClass.Name = "pictureBoxClass";
            this.pictureBoxClass.Size = new System.Drawing.Size(160, 240);
            this.pictureBoxClass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxClass.TabIndex = 20;
            this.pictureBoxClass.TabStop = false;
            // 
            // CharacterCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(300, 438);
            this.Controls.Add(this.pictureBoxClass);
            this.Controls.Add(this.labelClassDescription);
            this.Controls.Add(this.pictureBoxLeftArrow);
            this.Controls.Add(this.pictureBoxRightArrow);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.textBoxCharacterName);
            this.Controls.Add(this.btCreate);
            this.Controls.Add(this.labelBackgroundIGNORE);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CharacterCreationForm";
            this.Text = "CharacterCreationForm";
            this.Load += new System.EventHandler(this.CharacterCreationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeftArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRightArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCreate;
        private System.Windows.Forms.TextBox textBoxCharacterName;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.PictureBox pictureBoxRightArrow;
        private System.Windows.Forms.PictureBox pictureBoxLeftArrow;
        private System.Windows.Forms.Label labelClassDescription;
        private System.Windows.Forms.Label labelBackgroundIGNORE;
        private System.Windows.Forms.PictureBox pictureBoxClass;
    }
}