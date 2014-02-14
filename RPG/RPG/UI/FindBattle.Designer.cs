namespace RPG.UI
{
    partial class FindBattle
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
            this.labelBackgroundIGNORE = new System.Windows.Forms.Label();
            this.btMulti = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.bnLocalMulti = new System.Windows.Forms.Button();
            this.bnSingle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelBackgroundIGNORE
            // 
            this.labelBackgroundIGNORE.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.labelBackgroundIGNORE.BackColor = System.Drawing.Color.Transparent;
            this.labelBackgroundIGNORE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBackgroundIGNORE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBackgroundIGNORE.Location = new System.Drawing.Point(0, 0);
            this.labelBackgroundIGNORE.Name = "labelBackgroundIGNORE";
            this.labelBackgroundIGNORE.Size = new System.Drawing.Size(284, 262);
            this.labelBackgroundIGNORE.TabIndex = 23;
            // 
            // btMulti
            // 
            this.btMulti.BackColor = System.Drawing.Color.DarkRed;
            this.btMulti.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btMulti.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.btMulti.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btMulti.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btMulti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMulti.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMulti.ForeColor = System.Drawing.Color.Black;
            this.btMulti.Location = new System.Drawing.Point(12, 198);
            this.btMulti.Name = "btMulti";
            this.btMulti.Size = new System.Drawing.Size(260, 23);
            this.btMulti.TabIndex = 24;
            this.btMulti.Text = "Online Multi Player (Unavailable)";
            this.btMulti.UseVisualStyleBackColor = false;
            this.btMulti.Click += new System.EventHandler(this.btSinglePlayer_Click);
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
            this.bnCancel.Location = new System.Drawing.Point(12, 227);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(260, 23);
            this.bnCancel.TabIndex = 25;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = false;
            this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
            // 
            // bnLocalMulti
            // 
            this.bnLocalMulti.BackColor = System.Drawing.Color.DarkRed;
            this.bnLocalMulti.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bnLocalMulti.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.bnLocalMulti.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.bnLocalMulti.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.bnLocalMulti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnLocalMulti.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnLocalMulti.ForeColor = System.Drawing.Color.Yellow;
            this.bnLocalMulti.Location = new System.Drawing.Point(12, 169);
            this.bnLocalMulti.Name = "bnLocalMulti";
            this.bnLocalMulti.Size = new System.Drawing.Size(260, 23);
            this.bnLocalMulti.TabIndex = 26;
            this.bnLocalMulti.Text = "Local Multi Player";
            this.bnLocalMulti.UseVisualStyleBackColor = false;
            this.bnLocalMulti.Click += new System.EventHandler(this.bnLocalMulti_Click);
            // 
            // bnSingle
            // 
            this.bnSingle.BackColor = System.Drawing.Color.DarkRed;
            this.bnSingle.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bnSingle.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.bnSingle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.bnSingle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.bnSingle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnSingle.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnSingle.ForeColor = System.Drawing.Color.Yellow;
            this.bnSingle.Location = new System.Drawing.Point(12, 140);
            this.bnSingle.Name = "bnSingle";
            this.bnSingle.Size = new System.Drawing.Size(260, 23);
            this.bnSingle.TabIndex = 27;
            this.bnSingle.Text = "Single Player";
            this.bnSingle.UseVisualStyleBackColor = false;
            this.bnSingle.Click += new System.EventHandler(this.bnSingle_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Pericles", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 128);
            this.label1.TabIndex = 28;
            this.label1.Text = "Choose your Battle Mode:\r\n\r\nSingle player for Solo play\r\nLocal for Solo play with" +
    " multiple characters\r\nOnline to play with others";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FindBattle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bnSingle);
            this.Controls.Add(this.bnLocalMulti);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.btMulti);
            this.Controls.Add(this.labelBackgroundIGNORE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FindBattle";
            this.Text = "FindBattle";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelBackgroundIGNORE;
        private System.Windows.Forms.Button btMulti;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Button bnLocalMulti;
        private System.Windows.Forms.Button bnSingle;
        private System.Windows.Forms.Label label1;
    }
}