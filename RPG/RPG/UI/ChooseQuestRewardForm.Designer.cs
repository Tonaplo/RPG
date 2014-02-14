namespace RPG.UI
{
    partial class ChooseQuestRewardForm
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
            this.labelNumberOfPlayer1 = new System.Windows.Forms.Label();
            this.bnItem = new System.Windows.Forms.Button();
            this.bnExperience = new System.Windows.Forms.Button();
            this.bnDust = new System.Windows.Forms.Button();
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
            this.labelBackgroundIGNORE.Size = new System.Drawing.Size(284, 198);
            this.labelBackgroundIGNORE.TabIndex = 24;
            // 
            // labelNumberOfPlayer1
            // 
            this.labelNumberOfPlayer1.BackColor = System.Drawing.Color.Transparent;
            this.labelNumberOfPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberOfPlayer1.ForeColor = System.Drawing.Color.Yellow;
            this.labelNumberOfPlayer1.Location = new System.Drawing.Point(10, 8);
            this.labelNumberOfPlayer1.Name = "labelNumberOfPlayer1";
            this.labelNumberOfPlayer1.Size = new System.Drawing.Size(263, 73);
            this.labelNumberOfPlayer1.TabIndex = 25;
            this.labelNumberOfPlayer1.Text = "Congratulations!\r\nYou completed your current quest!\r\nPlease choose what reward yo" +
    "u want to receive:\r\n";
            this.labelNumberOfPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bnItem
            // 
            this.bnItem.BackColor = System.Drawing.Color.DarkRed;
            this.bnItem.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bnItem.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.bnItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.bnItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.bnItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnItem.ForeColor = System.Drawing.Color.Yellow;
            this.bnItem.Location = new System.Drawing.Point(10, 120);
            this.bnItem.Name = "bnItem";
            this.bnItem.Size = new System.Drawing.Size(263, 30);
            this.bnItem.TabIndex = 26;
            this.bnItem.Text = "High Quality Items";
            this.bnItem.UseVisualStyleBackColor = false;
            this.bnItem.Click += new System.EventHandler(this.bnItem_Click);
            // 
            // bnExperience
            // 
            this.bnExperience.BackColor = System.Drawing.Color.DarkRed;
            this.bnExperience.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bnExperience.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.bnExperience.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.bnExperience.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.bnExperience.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnExperience.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnExperience.ForeColor = System.Drawing.Color.Yellow;
            this.bnExperience.Location = new System.Drawing.Point(10, 84);
            this.bnExperience.Name = "bnExperience";
            this.bnExperience.Size = new System.Drawing.Size(263, 30);
            this.bnExperience.TabIndex = 27;
            this.bnExperience.Text = "Experience for all character";
            this.bnExperience.UseVisualStyleBackColor = false;
            this.bnExperience.Click += new System.EventHandler(this.bnExperience_Click);
            // 
            // bnDust
            // 
            this.bnDust.BackColor = System.Drawing.Color.DarkRed;
            this.bnDust.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bnDust.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.bnDust.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.bnDust.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.bnDust.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnDust.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnDust.ForeColor = System.Drawing.Color.Yellow;
            this.bnDust.Location = new System.Drawing.Point(10, 156);
            this.bnDust.Name = "bnDust";
            this.bnDust.Size = new System.Drawing.Size(263, 30);
            this.bnDust.TabIndex = 28;
            this.bnDust.Text = "Dust for Stat Randomization";
            this.bnDust.UseVisualStyleBackColor = false;
            this.bnDust.Click += new System.EventHandler(this.bnDust_Click);
            // 
            // ChooseQuestRewardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(284, 198);
            this.Controls.Add(this.bnDust);
            this.Controls.Add(this.bnExperience);
            this.Controls.Add(this.bnItem);
            this.Controls.Add(this.labelNumberOfPlayer1);
            this.Controls.Add(this.labelBackgroundIGNORE);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChooseQuestRewardForm";
            this.Text = "ChooseQuestRewardForm";
            this.Load += new System.EventHandler(this.ChooseQuestRewardForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelBackgroundIGNORE;
        private System.Windows.Forms.Label labelNumberOfPlayer1;
        private System.Windows.Forms.Button bnItem;
        private System.Windows.Forms.Button bnExperience;
        private System.Windows.Forms.Button bnDust;
    }
}