namespace RPG.UI
{
    partial class MenuBar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btNewGame = new System.Windows.Forms.Button();
            this.btSaveGame = new System.Windows.Forms.Button();
            this.btOptions = new System.Windows.Forms.Button();
            this.btLoadGame = new System.Windows.Forms.Button();
            this.btExitGame = new System.Windows.Forms.Button();
            this.MenuFlowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuFlowPanel
            // 
            this.MenuFlowPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MenuFlowPanel.Controls.Add(this.btNewGame);
            this.MenuFlowPanel.Controls.Add(this.btSaveGame);
            this.MenuFlowPanel.Controls.Add(this.btOptions);
            this.MenuFlowPanel.Controls.Add(this.btLoadGame);
            this.MenuFlowPanel.Controls.Add(this.btExitGame);
            this.MenuFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuFlowPanel.Name = "MenuFlowPanel";
            this.MenuFlowPanel.Size = new System.Drawing.Size(1000, 30);
            this.MenuFlowPanel.TabIndex = 0;
            // 
            // btNewGame
            // 
            this.btNewGame.BackColor = System.Drawing.Color.DarkRed;
            this.btNewGame.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNewGame.Font = new System.Drawing.Font("Jing Jing", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNewGame.ForeColor = System.Drawing.Color.DarkOrange;
            this.btNewGame.Location = new System.Drawing.Point(3, 3);
            this.btNewGame.Name = "btNewGame";
            this.btNewGame.Size = new System.Drawing.Size(194, 25);
            this.btNewGame.TabIndex = 1;
            this.btNewGame.Text = "New Game";
            this.btNewGame.UseVisualStyleBackColor = false;
            // 
            // btSaveGame
            // 
            this.btSaveGame.BackColor = System.Drawing.Color.DarkRed;
            this.btSaveGame.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btSaveGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSaveGame.Font = new System.Drawing.Font("Jing Jing", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSaveGame.ForeColor = System.Drawing.Color.DarkOrange;
            this.btSaveGame.Location = new System.Drawing.Point(203, 3);
            this.btSaveGame.Name = "btSaveGame";
            this.btSaveGame.Size = new System.Drawing.Size(194, 25);
            this.btSaveGame.TabIndex = 2;
            this.btSaveGame.Text = "Save Game";
            this.btSaveGame.UseVisualStyleBackColor = false;
            // 
            // btOptions
            // 
            this.btOptions.BackColor = System.Drawing.Color.DarkRed;
            this.btOptions.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOptions.Font = new System.Drawing.Font("Jing Jing", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOptions.ForeColor = System.Drawing.Color.DarkOrange;
            this.btOptions.Location = new System.Drawing.Point(403, 3);
            this.btOptions.Name = "btOptions";
            this.btOptions.Size = new System.Drawing.Size(194, 25);
            this.btOptions.TabIndex = 3;
            this.btOptions.Text = "Options";
            this.btOptions.UseVisualStyleBackColor = false;
            // 
            // btLoadGame
            // 
            this.btLoadGame.BackColor = System.Drawing.Color.DarkRed;
            this.btLoadGame.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btLoadGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLoadGame.Font = new System.Drawing.Font("Jing Jing", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLoadGame.ForeColor = System.Drawing.Color.DarkOrange;
            this.btLoadGame.Location = new System.Drawing.Point(603, 3);
            this.btLoadGame.Name = "btLoadGame";
            this.btLoadGame.Size = new System.Drawing.Size(194, 25);
            this.btLoadGame.TabIndex = 4;
            this.btLoadGame.Text = "Load Game";
            this.btLoadGame.UseVisualStyleBackColor = false;
            // 
            // btExitGame
            // 
            this.btExitGame.BackColor = System.Drawing.Color.DarkRed;
            this.btExitGame.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btExitGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExitGame.Font = new System.Drawing.Font("Jing Jing", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExitGame.ForeColor = System.Drawing.Color.DarkOrange;
            this.btExitGame.Location = new System.Drawing.Point(803, 3);
            this.btExitGame.Name = "btExitGame";
            this.btExitGame.Size = new System.Drawing.Size(194, 25);
            this.btExitGame.TabIndex = 5;
            this.btExitGame.Text = "Exit Game";
            this.btExitGame.UseVisualStyleBackColor = false;
            // 
            // MenuBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MenuFlowPanel);
            this.Name = "MenuBar";
            this.Size = new System.Drawing.Size(1000, 30);
            this.MenuFlowPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel MenuFlowPanel;
        private System.Windows.Forms.Button btNewGame;
        private System.Windows.Forms.Button btSaveGame;
        private System.Windows.Forms.Button btOptions;
        private System.Windows.Forms.Button btLoadGame;
        private System.Windows.Forms.Button btExitGame;
    }
}
