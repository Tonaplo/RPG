namespace RPG
{
    partial class MainWindow
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
            this.btSupport = new System.Windows.Forms.Button();
            this.btAddCharacter = new System.Windows.Forms.Button();
            this.btRandomizeStat = new System.Windows.Forms.Button();
            this.btDisenchant = new System.Windows.Forms.Button();
            this.btExitGame = new System.Windows.Forms.Button();
            this.flpCharacters = new System.Windows.Forms.FlowLayoutPanel();
            this.btBattle = new System.Windows.Forms.Button();
            this.textBoxChat = new System.Windows.Forms.TextBox();
            this.richTextBoxActionbox = new System.Windows.Forms.RichTextBox();
            this.listBoxInventory = new System.Windows.Forms.ListBox();
            this.labelInventory = new System.Windows.Forms.Label();
            this.labelBackgroundIGNORE = new System.Windows.Forms.Label();
            this.btDeleteCharacter = new System.Windows.Forms.Button();
            this.btDisenchantAll = new System.Windows.Forms.Button();
            this.labelCurrentItem = new System.Windows.Forms.Label();
            this.bnOptions = new System.Windows.Forms.Button();
            this.flpQuestBar = new System.Windows.Forms.FlowLayoutPanel();
            this.labelQuestBar = new System.Windows.Forms.Label();
            this.flpQuestBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btSupport
            // 
            this.btSupport.BackColor = System.Drawing.Color.DarkRed;
            this.btSupport.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btSupport.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.btSupport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btSupport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btSupport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSupport.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSupport.ForeColor = System.Drawing.Color.Yellow;
            this.btSupport.Location = new System.Drawing.Point(4, 2);
            this.btSupport.Name = "btSupport";
            this.btSupport.Size = new System.Drawing.Size(160, 35);
            this.btSupport.TabIndex = 10;
            this.btSupport.Text = "Support";
            this.btSupport.UseVisualStyleBackColor = false;
            this.btSupport.Click += new System.EventHandler(this.btNewGame_Click);
            this.btSupport.MouseEnter += new System.EventHandler(this.btSupport_MouseEnter);
            this.btSupport.MouseLeave += new System.EventHandler(this.btSupport_MouseLeave);
            // 
            // btAddCharacter
            // 
            this.btAddCharacter.BackColor = System.Drawing.Color.DarkRed;
            this.btAddCharacter.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btAddCharacter.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.btAddCharacter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btAddCharacter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btAddCharacter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAddCharacter.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddCharacter.ForeColor = System.Drawing.Color.Yellow;
            this.btAddCharacter.Location = new System.Drawing.Point(170, 2);
            this.btAddCharacter.Name = "btAddCharacter";
            this.btAddCharacter.Size = new System.Drawing.Size(160, 35);
            this.btAddCharacter.TabIndex = 11;
            this.btAddCharacter.Text = "Add Character";
            this.btAddCharacter.UseVisualStyleBackColor = false;
            this.btAddCharacter.Click += new System.EventHandler(this.btAddCharacter_Click);
            this.btAddCharacter.MouseEnter += new System.EventHandler(this.btAddCharacter_MouseEnter);
            this.btAddCharacter.MouseLeave += new System.EventHandler(this.btAddCharacter_MouseLeave);
            // 
            // btRandomizeStat
            // 
            this.btRandomizeStat.BackColor = System.Drawing.Color.DarkRed;
            this.btRandomizeStat.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btRandomizeStat.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.btRandomizeStat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btRandomizeStat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btRandomizeStat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRandomizeStat.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRandomizeStat.ForeColor = System.Drawing.Color.Yellow;
            this.btRandomizeStat.Location = new System.Drawing.Point(668, 2);
            this.btRandomizeStat.Name = "btRandomizeStat";
            this.btRandomizeStat.Size = new System.Drawing.Size(160, 35);
            this.btRandomizeStat.TabIndex = 12;
            this.btRandomizeStat.Text = "Randomize Stat";
            this.btRandomizeStat.UseVisualStyleBackColor = false;
            this.btRandomizeStat.Click += new System.EventHandler(this.btRandomizeStat_Click);
            this.btRandomizeStat.MouseEnter += new System.EventHandler(this.btRandomizeStat_MouseEnter);
            this.btRandomizeStat.MouseLeave += new System.EventHandler(this.btRandomizeStat_MouseLeave);
            // 
            // btDisenchant
            // 
            this.btDisenchant.BackColor = System.Drawing.Color.DarkRed;
            this.btDisenchant.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btDisenchant.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.btDisenchant.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btDisenchant.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btDisenchant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDisenchant.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDisenchant.ForeColor = System.Drawing.Color.Yellow;
            this.btDisenchant.Location = new System.Drawing.Point(641, 662);
            this.btDisenchant.Name = "btDisenchant";
            this.btDisenchant.Size = new System.Drawing.Size(170, 44);
            this.btDisenchant.TabIndex = 13;
            this.btDisenchant.Text = "Disenchant Item";
            this.btDisenchant.UseVisualStyleBackColor = false;
            this.btDisenchant.Click += new System.EventHandler(this.btDisenchant_Click);
            this.btDisenchant.MouseEnter += new System.EventHandler(this.btDisenchant_MouseEnter);
            this.btDisenchant.MouseLeave += new System.EventHandler(this.btDisenchant_MouseLeave);
            // 
            // btExitGame
            // 
            this.btExitGame.BackColor = System.Drawing.Color.DarkRed;
            this.btExitGame.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btExitGame.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.btExitGame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btExitGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btExitGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExitGame.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExitGame.ForeColor = System.Drawing.Color.Yellow;
            this.btExitGame.Location = new System.Drawing.Point(834, 2);
            this.btExitGame.Name = "btExitGame";
            this.btExitGame.Size = new System.Drawing.Size(160, 35);
            this.btExitGame.TabIndex = 14;
            this.btExitGame.Text = "Exit Game";
            this.btExitGame.UseVisualStyleBackColor = false;
            this.btExitGame.Click += new System.EventHandler(this.btExitGame_Click);
            this.btExitGame.MouseEnter += new System.EventHandler(this.btExitGame_MouseEnter);
            this.btExitGame.MouseLeave += new System.EventHandler(this.btExitGame_MouseLeave);
            // 
            // flpCharacters
            // 
            this.flpCharacters.BackColor = System.Drawing.Color.Transparent;
            this.flpCharacters.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.flpCharacters.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flpCharacters.Location = new System.Drawing.Point(3, 64);
            this.flpCharacters.Name = "flpCharacters";
            this.flpCharacters.Size = new System.Drawing.Size(350, 642);
            this.flpCharacters.TabIndex = 15;
            // 
            // btBattle
            // 
            this.btBattle.BackColor = System.Drawing.Color.DarkRed;
            this.btBattle.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btBattle.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.btBattle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btBattle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btBattle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBattle.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBattle.ForeColor = System.Drawing.Color.Yellow;
            this.btBattle.Location = new System.Drawing.Point(359, 662);
            this.btBattle.Name = "btBattle";
            this.btBattle.Size = new System.Drawing.Size(276, 44);
            this.btBattle.TabIndex = 19;
            this.btBattle.Text = "Find a battle!";
            this.btBattle.UseVisualStyleBackColor = false;
            this.btBattle.Click += new System.EventHandler(this.bnBattle_Click);
            this.btBattle.MouseEnter += new System.EventHandler(this.btBattle_MouseEnter);
            this.btBattle.MouseLeave += new System.EventHandler(this.bnBattle_MouseLeave);
            // 
            // textBoxChat
            // 
            this.textBoxChat.AcceptsReturn = true;
            this.textBoxChat.BackColor = System.Drawing.SystemColors.ControlDark;
            this.textBoxChat.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxChat.ForeColor = System.Drawing.Color.DarkRed;
            this.textBoxChat.Location = new System.Drawing.Point(359, 629);
            this.textBoxChat.MaxLength = 300;
            this.textBoxChat.Name = "textBoxChat";
            this.textBoxChat.ShortcutsEnabled = false;
            this.textBoxChat.Size = new System.Drawing.Size(276, 22);
            this.textBoxChat.TabIndex = 20;
            this.textBoxChat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxChat_KeyDown);
            // 
            // richTextBoxActionbox
            // 
            this.richTextBoxActionbox.BackColor = System.Drawing.SystemColors.InfoText;
            this.richTextBoxActionbox.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxActionbox.ForeColor = System.Drawing.SystemColors.Window;
            this.richTextBoxActionbox.Location = new System.Drawing.Point(360, 64);
            this.richTextBoxActionbox.Name = "richTextBoxActionbox";
            this.richTextBoxActionbox.ReadOnly = true;
            this.richTextBoxActionbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxActionbox.Size = new System.Drawing.Size(275, 559);
            this.richTextBoxActionbox.TabIndex = 21;
            this.richTextBoxActionbox.Text = "";
            // 
            // listBoxInventory
            // 
            this.listBoxInventory.BackColor = System.Drawing.Color.Black;
            this.listBoxInventory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxInventory.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxInventory.ForeColor = System.Drawing.Color.Yellow;
            this.listBoxInventory.FormattingEnabled = true;
            this.listBoxInventory.ItemHeight = 15;
            this.listBoxInventory.Location = new System.Drawing.Point(641, 107);
            this.listBoxInventory.Name = "listBoxInventory";
            this.listBoxInventory.Size = new System.Drawing.Size(353, 454);
            this.listBoxInventory.TabIndex = 22;
            this.listBoxInventory.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_DrawItem);
            this.listBoxInventory.SelectedIndexChanged += new System.EventHandler(this.listBoxInventory_SelectedIndexChanged);
            this.listBoxInventory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxInventory_KeyDown);
            this.listBoxInventory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxInventory_MouseDoubleClick);
            // 
            // labelInventory
            // 
            this.labelInventory.BackColor = System.Drawing.Color.Transparent;
            this.labelInventory.Font = new System.Drawing.Font("Pericles", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInventory.ForeColor = System.Drawing.Color.Yellow;
            this.labelInventory.Location = new System.Drawing.Point(642, 64);
            this.labelInventory.Name = "labelInventory";
            this.labelInventory.Size = new System.Drawing.Size(346, 35);
            this.labelInventory.TabIndex = 23;
            this.labelInventory.Text = "Inventory";
            this.labelInventory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBackgroundIGNORE
            // 
            this.labelBackgroundIGNORE.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.labelBackgroundIGNORE.BackColor = System.Drawing.Color.Transparent;
            this.labelBackgroundIGNORE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBackgroundIGNORE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBackgroundIGNORE.Location = new System.Drawing.Point(0, 0);
            this.labelBackgroundIGNORE.Name = "labelBackgroundIGNORE";
            this.labelBackgroundIGNORE.Size = new System.Drawing.Size(1000, 716);
            this.labelBackgroundIGNORE.TabIndex = 24;
            // 
            // btDeleteCharacter
            // 
            this.btDeleteCharacter.BackColor = System.Drawing.Color.DarkRed;
            this.btDeleteCharacter.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btDeleteCharacter.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.btDeleteCharacter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btDeleteCharacter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btDeleteCharacter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDeleteCharacter.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDeleteCharacter.ForeColor = System.Drawing.Color.Yellow;
            this.btDeleteCharacter.Location = new System.Drawing.Point(336, 2);
            this.btDeleteCharacter.Name = "btDeleteCharacter";
            this.btDeleteCharacter.Size = new System.Drawing.Size(160, 35);
            this.btDeleteCharacter.TabIndex = 25;
            this.btDeleteCharacter.Text = "Delete Character";
            this.btDeleteCharacter.UseVisualStyleBackColor = false;
            this.btDeleteCharacter.Click += new System.EventHandler(this.btDeleteCharacter_Click);
            this.btDeleteCharacter.MouseEnter += new System.EventHandler(this.btDeleteCharacter_MouseEnter);
            this.btDeleteCharacter.MouseLeave += new System.EventHandler(this.btDeleteCharacter_MouseLeave);
            // 
            // btDisenchantAll
            // 
            this.btDisenchantAll.BackColor = System.Drawing.Color.DarkRed;
            this.btDisenchantAll.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btDisenchantAll.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.btDisenchantAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btDisenchantAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btDisenchantAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDisenchantAll.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDisenchantAll.ForeColor = System.Drawing.Color.Yellow;
            this.btDisenchantAll.Location = new System.Drawing.Point(824, 662);
            this.btDisenchantAll.Name = "btDisenchantAll";
            this.btDisenchantAll.Size = new System.Drawing.Size(170, 44);
            this.btDisenchantAll.TabIndex = 26;
            this.btDisenchantAll.Text = "Disenchant All\r\nNormal and Grand Items";
            this.btDisenchantAll.UseVisualStyleBackColor = false;
            this.btDisenchantAll.Click += new System.EventHandler(this.btDisenchantAll_Click);
            this.btDisenchantAll.MouseEnter += new System.EventHandler(this.btDisenchantAll_MouseEnter);
            this.btDisenchantAll.MouseLeave += new System.EventHandler(this.btDisenchantAll_MouseLeave);
            // 
            // labelCurrentItem
            // 
            this.labelCurrentItem.BackColor = System.Drawing.Color.Transparent;
            this.labelCurrentItem.Font = new System.Drawing.Font("Pericles", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentItem.ForeColor = System.Drawing.Color.Yellow;
            this.labelCurrentItem.Location = new System.Drawing.Point(641, 563);
            this.labelCurrentItem.Name = "labelCurrentItem";
            this.labelCurrentItem.Size = new System.Drawing.Size(353, 96);
            this.labelCurrentItem.TabIndex = 27;
            this.labelCurrentItem.Text = "Nothing Selected!";
            this.labelCurrentItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bnOptions
            // 
            this.bnOptions.BackColor = System.Drawing.Color.DarkRed;
            this.bnOptions.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bnOptions.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.bnOptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.bnOptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.bnOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnOptions.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnOptions.ForeColor = System.Drawing.Color.Yellow;
            this.bnOptions.Location = new System.Drawing.Point(502, 2);
            this.bnOptions.Name = "bnOptions";
            this.bnOptions.Size = new System.Drawing.Size(160, 35);
            this.bnOptions.TabIndex = 28;
            this.bnOptions.Text = "Options";
            this.bnOptions.UseVisualStyleBackColor = false;
            this.bnOptions.Click += new System.EventHandler(this.bnOptions_Click);
            // 
            // flpQuestBar
            // 
            this.flpQuestBar.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.flpQuestBar.BackColor = System.Drawing.Color.Transparent;
            this.flpQuestBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.flpQuestBar.Controls.Add(this.labelQuestBar);
            this.flpQuestBar.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flpQuestBar.ForeColor = System.Drawing.Color.White;
            this.flpQuestBar.Location = new System.Drawing.Point(4, 40);
            this.flpQuestBar.Margin = new System.Windows.Forms.Padding(0);
            this.flpQuestBar.Name = "flpQuestBar";
            this.flpQuestBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flpQuestBar.Size = new System.Drawing.Size(990, 21);
            this.flpQuestBar.TabIndex = 29;
            this.flpQuestBar.WrapContents = false;
            // 
            // labelQuestBar
            // 
            this.labelQuestBar.BackColor = System.Drawing.Color.MidnightBlue;
            this.labelQuestBar.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuestBar.Location = new System.Drawing.Point(0, 0);
            this.labelQuestBar.Margin = new System.Windows.Forms.Padding(0);
            this.labelQuestBar.Name = "labelQuestBar";
            this.labelQuestBar.Size = new System.Drawing.Size(100, 21);
            this.labelQuestBar.TabIndex = 0;
            this.labelQuestBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1000, 716);
            this.Controls.Add(this.flpQuestBar);
            this.Controls.Add(this.bnOptions);
            this.Controls.Add(this.labelCurrentItem);
            this.Controls.Add(this.btDisenchantAll);
            this.Controls.Add(this.btDeleteCharacter);
            this.Controls.Add(this.labelInventory);
            this.Controls.Add(this.listBoxInventory);
            this.Controls.Add(this.richTextBoxActionbox);
            this.Controls.Add(this.textBoxChat);
            this.Controls.Add(this.btBattle);
            this.Controls.Add(this.flpCharacters);
            this.Controls.Add(this.btSupport);
            this.Controls.Add(this.btAddCharacter);
            this.Controls.Add(this.btRandomizeStat);
            this.Controls.Add(this.btDisenchant);
            this.Controls.Add(this.btExitGame);
            this.Controls.Add(this.labelBackgroundIGNORE);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RPG";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.flpQuestBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSupport;
        private System.Windows.Forms.Button btAddCharacter;
        private System.Windows.Forms.Button btRandomizeStat;
        private System.Windows.Forms.Button btDisenchant;
        private System.Windows.Forms.Button btExitGame;
        private System.Windows.Forms.FlowLayoutPanel flpCharacters;
        private System.Windows.Forms.Button btBattle;
        private System.Windows.Forms.TextBox textBoxChat;
        private System.Windows.Forms.RichTextBox richTextBoxActionbox;
        private System.Windows.Forms.ListBox listBoxInventory;
        private System.Windows.Forms.Label labelInventory;
        private System.Windows.Forms.Label labelBackgroundIGNORE;
        private System.Windows.Forms.Button btDeleteCharacter;
        private System.Windows.Forms.Button btDisenchantAll;
        private System.Windows.Forms.Label labelCurrentItem;
        private System.Windows.Forms.Button bnOptions;
        private System.Windows.Forms.FlowLayoutPanel flpQuestBar;
        private System.Windows.Forms.Label labelQuestBar;
    }
}

