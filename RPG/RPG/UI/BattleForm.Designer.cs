namespace RPG.UI
{
    partial class BattleForm
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
            this.richTextBoxActionbox = new System.Windows.Forms.RichTextBox();
            this.textBoxChat = new System.Windows.Forms.TextBox();
            this.bnTurnDone = new System.Windows.Forms.Button();
            this.flpCharacters = new System.Windows.Forms.FlowLayoutPanel();
            this.flpNPCs = new System.Windows.Forms.FlowLayoutPanel();
            this.labelBackgroundIGNORE = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBoxActionbox
            // 
            this.richTextBoxActionbox.BackColor = System.Drawing.SystemColors.InfoText;
            this.richTextBoxActionbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxActionbox.ForeColor = System.Drawing.SystemColors.Window;
            this.richTextBoxActionbox.Location = new System.Drawing.Point(531, 202);
            this.richTextBoxActionbox.Name = "richTextBoxActionbox";
            this.richTextBoxActionbox.ReadOnly = true;
            this.richTextBoxActionbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxActionbox.Size = new System.Drawing.Size(404, 487);
            this.richTextBoxActionbox.TabIndex = 26;
            this.richTextBoxActionbox.Text = "Welcome to a Battle!\n\nUse your abilities untill you are out of Turnpoints. Then e" +
    "nd the turn for the NPC to Retaliate - and for you to regain turnpoints!\n";
            this.richTextBoxActionbox.TextChanged += new System.EventHandler(this.richTextBoxActionbox_TextChanged);
            // 
            // textBoxChat
            // 
            this.textBoxChat.AcceptsReturn = true;
            this.textBoxChat.BackColor = System.Drawing.SystemColors.ControlDark;
            this.textBoxChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxChat.ForeColor = System.Drawing.Color.DarkRed;
            this.textBoxChat.Location = new System.Drawing.Point(530, 695);
            this.textBoxChat.MaxLength = 300;
            this.textBoxChat.Name = "textBoxChat";
            this.textBoxChat.ShortcutsEnabled = false;
            this.textBoxChat.Size = new System.Drawing.Size(404, 20);
            this.textBoxChat.TabIndex = 25;
            // 
            // bnTurnDone
            // 
            this.bnTurnDone.BackColor = System.Drawing.Color.DarkRed;
            this.bnTurnDone.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bnTurnDone.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.bnTurnDone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.bnTurnDone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.bnTurnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnTurnDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnTurnDone.ForeColor = System.Drawing.Color.Yellow;
            this.bnTurnDone.Location = new System.Drawing.Point(530, 12);
            this.bnTurnDone.Name = "bnTurnDone";
            this.bnTurnDone.Size = new System.Drawing.Size(405, 44);
            this.bnTurnDone.TabIndex = 24;
            this.bnTurnDone.Text = "I am done! Let the Monster retaliate!";
            this.bnTurnDone.UseVisualStyleBackColor = false;
            this.bnTurnDone.Click += new System.EventHandler(this.bnTurnDone_Click);
            // 
            // flpCharacters
            // 
            this.flpCharacters.BackColor = System.Drawing.Color.Transparent;
            this.flpCharacters.Location = new System.Drawing.Point(12, 12);
            this.flpCharacters.Name = "flpCharacters";
            this.flpCharacters.Size = new System.Drawing.Size(512, 703);
            this.flpCharacters.TabIndex = 22;
            // 
            // flpNPCs
            // 
            this.flpNPCs.BackColor = System.Drawing.Color.Transparent;
            this.flpNPCs.Location = new System.Drawing.Point(531, 65);
            this.flpNPCs.Name = "flpNPCs";
            this.flpNPCs.Size = new System.Drawing.Size(404, 131);
            this.flpNPCs.TabIndex = 23;
            // 
            // labelBackgroundIGNORE
            // 
            this.labelBackgroundIGNORE.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.labelBackgroundIGNORE.BackColor = System.Drawing.Color.Transparent;
            this.labelBackgroundIGNORE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBackgroundIGNORE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBackgroundIGNORE.Location = new System.Drawing.Point(0, 0);
            this.labelBackgroundIGNORE.Name = "labelBackgroundIGNORE";
            this.labelBackgroundIGNORE.Size = new System.Drawing.Size(947, 727);
            this.labelBackgroundIGNORE.TabIndex = 27;
            // 
            // BattleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(947, 727);
            this.Controls.Add(this.richTextBoxActionbox);
            this.Controls.Add(this.textBoxChat);
            this.Controls.Add(this.bnTurnDone);
            this.Controls.Add(this.flpCharacters);
            this.Controls.Add(this.flpNPCs);
            this.Controls.Add(this.labelBackgroundIGNORE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BattleForm";
            this.Text = "BattleForm";
            this.Load += new System.EventHandler(this.BattleForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxActionbox;
        private System.Windows.Forms.TextBox textBoxChat;
        private System.Windows.Forms.Button bnTurnDone;
        private System.Windows.Forms.FlowLayoutPanel flpCharacters;
        private System.Windows.Forms.FlowLayoutPanel flpNPCs;
        private System.Windows.Forms.Label labelBackgroundIGNORE;
    }
}