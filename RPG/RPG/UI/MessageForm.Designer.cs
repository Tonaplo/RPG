namespace RPG.UI
{
    partial class MessageForm
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
            this.bnDone = new System.Windows.Forms.Button();
            this.labelText = new System.Windows.Forms.Label();
            this.labelBackgroundIGNORE = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bnDone
            // 
            this.bnDone.BackColor = System.Drawing.Color.DarkRed;
            this.bnDone.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bnDone.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.bnDone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.bnDone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.bnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnDone.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnDone.ForeColor = System.Drawing.Color.Yellow;
            this.bnDone.Location = new System.Drawing.Point(15, 139);
            this.bnDone.Name = "bnDone";
            this.bnDone.Size = new System.Drawing.Size(199, 44);
            this.bnDone.TabIndex = 0;
            this.bnDone.Text = "Ok";
            this.bnDone.UseVisualStyleBackColor = false;
            this.bnDone.Click += new System.EventHandler(this.bnDone_Click);
            // 
            // labelText
            // 
            this.labelText.BackColor = System.Drawing.Color.Transparent;
            this.labelText.Location = new System.Drawing.Point(12, 13);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(202, 123);
            this.labelText.TabIndex = 1;
            this.labelText.Text = "label1";
            this.labelText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBackgroundIGNORE
            // 
            this.labelBackgroundIGNORE.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.labelBackgroundIGNORE.BackColor = System.Drawing.Color.Transparent;
            this.labelBackgroundIGNORE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBackgroundIGNORE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBackgroundIGNORE.Location = new System.Drawing.Point(0, 0);
            this.labelBackgroundIGNORE.Name = "labelBackgroundIGNORE";
            this.labelBackgroundIGNORE.Size = new System.Drawing.Size(228, 199);
            this.labelBackgroundIGNORE.TabIndex = 35;
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(228, 199);
            this.Controls.Add(this.labelText);
            this.Controls.Add(this.bnDone);
            this.Controls.Add(this.labelBackgroundIGNORE);
            this.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Yellow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MessageForm";
            this.Text = "MessageForm";
            this.Load += new System.EventHandler(this.MessageForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bnDone;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Label labelBackgroundIGNORE;
    }
}