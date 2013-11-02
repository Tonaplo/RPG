namespace RPG
{
    partial class LoginForm
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
            this.btNewUser = new System.Windows.Forms.Button();
            this.btLogin = new System.Windows.Forms.Button();
            this.textBoxPlayerName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bnExit = new System.Windows.Forms.Button();
            this.labelBackgroundIGNORE = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btNewUser
            // 
            this.btNewUser.BackColor = System.Drawing.Color.DarkRed;
            this.btNewUser.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btNewUser.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.btNewUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btNewUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btNewUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNewUser.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNewUser.ForeColor = System.Drawing.Color.Yellow;
            this.btNewUser.Location = new System.Drawing.Point(12, 230);
            this.btNewUser.Name = "btNewUser";
            this.btNewUser.Size = new System.Drawing.Size(260, 26);
            this.btNewUser.TabIndex = 18;
            this.btNewUser.Text = "New User";
            this.btNewUser.UseVisualStyleBackColor = false;
            this.btNewUser.Click += new System.EventHandler(this.btNewUser_Click);
            // 
            // btLogin
            // 
            this.btLogin.BackColor = System.Drawing.Color.DarkRed;
            this.btLogin.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btLogin.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.btLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLogin.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLogin.ForeColor = System.Drawing.Color.Yellow;
            this.btLogin.Location = new System.Drawing.Point(12, 198);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(260, 26);
            this.btLogin.TabIndex = 19;
            this.btLogin.Text = "Login";
            this.btLogin.UseVisualStyleBackColor = false;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // textBoxPlayerName
            // 
            this.textBoxPlayerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.textBoxPlayerName.Font = new System.Drawing.Font("Pericles", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPlayerName.ForeColor = System.Drawing.Color.Yellow;
            this.textBoxPlayerName.Location = new System.Drawing.Point(12, 48);
            this.textBoxPlayerName.Name = "textBoxPlayerName";
            this.textBoxPlayerName.Size = new System.Drawing.Size(260, 28);
            this.textBoxPlayerName.TabIndex = 20;
            this.textBoxPlayerName.Text = "Username";
            this.textBoxPlayerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPlayerName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxPlayerName_MouseClick);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.textBoxPassword.Font = new System.Drawing.Font("Pericles", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.ForeColor = System.Drawing.Color.Yellow;
            this.textBoxPassword.Location = new System.Drawing.Point(12, 82);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(260, 28);
            this.textBoxPassword.TabIndex = 21;
            this.textBoxPassword.Text = "Password";
            this.textBoxPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPassword.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxPassword_MouseClick);
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.BackColor = System.Drawing.Color.Transparent;
            this.labelLogin.Font = new System.Drawing.Font("Pericles", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogin.ForeColor = System.Drawing.Color.Yellow;
            this.labelLogin.Location = new System.Drawing.Point(12, 9);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(253, 23);
            this.labelLogin.TabIndex = 22;
            this.labelLogin.Text = "Welcome to <The Game>";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Pericles", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(12, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 76);
            this.label1.TabIndex = 23;
            this.label1.Text = "Please enter your Username and Password. \r\nIf you are a new user, simply enter th" +
    "e details and click \'New User\'.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bnExit
            // 
            this.bnExit.BackColor = System.Drawing.Color.DarkRed;
            this.bnExit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bnExit.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.bnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.bnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.bnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnExit.Font = new System.Drawing.Font("Pericles", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnExit.ForeColor = System.Drawing.Color.Yellow;
            this.bnExit.Location = new System.Drawing.Point(12, 262);
            this.bnExit.Name = "bnExit";
            this.bnExit.Size = new System.Drawing.Size(260, 26);
            this.bnExit.TabIndex = 24;
            this.bnExit.Text = "Exit";
            this.bnExit.UseVisualStyleBackColor = false;
            this.bnExit.Click += new System.EventHandler(this.bnExit_Click);
            // 
            // labelBackgroundIGNORE
            // 
            this.labelBackgroundIGNORE.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.labelBackgroundIGNORE.BackColor = System.Drawing.Color.Transparent;
            this.labelBackgroundIGNORE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBackgroundIGNORE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBackgroundIGNORE.Location = new System.Drawing.Point(0, 0);
            this.labelBackgroundIGNORE.Name = "labelBackgroundIGNORE";
            this.labelBackgroundIGNORE.Size = new System.Drawing.Size(284, 300);
            this.labelBackgroundIGNORE.TabIndex = 25;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(284, 300);
            this.Controls.Add(this.bnExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxPlayerName);
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.btNewUser);
            this.Controls.Add(this.labelBackgroundIGNORE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btNewUser;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.TextBox textBoxPlayerName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bnExit;
        private System.Windows.Forms.Label labelBackgroundIGNORE;

    }
}