using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RPG.Core;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace RPG
{
    public partial class LoginForm : Form
    {
        List<Player> playerList = new List<Player>();
        //The player that's about to log in or be created.
        Player loginPlayer = new Player(null, null);
        public LoginForm(List<Player> _playerList)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImage = Function.GeneralFunctions.ResizeImage(Properties.Resources.background, labelBackgroundIGNORE.Size);
            playerList = _playerList;
        }

        #region Properties

        public Player ReturnedPlayer()
        {
            return loginPlayer;
        }

        public List<Player> ReturnedPlayerList()
        {
            return playerList;
        }

        #endregion

        #region Functions

        #region Font Stuff
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbfont, uint cbfont, IntPtr pdv, [In] ref uint pcFonts);
        FontFamily ff;
        Font font;

        private void LoadFont()
        {
            byte[] fontArray = Properties.Resources.Pericl;
            int dataLength = Properties.Resources.Pericl.Length;

            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);

            Marshal.Copy(fontArray, 0, ptrData, dataLength);

            uint cFonts = 0;

            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            PrivateFontCollection pfc = new PrivateFontCollection();

            pfc.AddMemoryFont(ptrData, dataLength);

            Marshal.FreeCoTaskMem(ptrData);

            ff = pfc.Families[0];
            font = new Font(ff, 13f, FontStyle.Regular);
        }

        private void AllocFont(Font f, Control c, float size)
        {
            FontStyle fontStyle = FontStyle.Regular;
            c.Font = new Font(ff, size, fontStyle);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            LoadFont();
            foreach (var item in this.Controls)
            {
                AllocFont(font, (item as Control), (item as Control).Font.Size);
            }

            
        }

        #endregion

        /// <summary>
        /// Checks if the Username is already taken, returning false if it is not take and true if it is.
        /// </summary>
        /// <param name="_username"></param>
        /// <returns></returns>
        private bool IsUsernameTaken(string _username)
        {
            if(playerList.Any(x => x.UserName.ToLower() == _username.ToLower()))
                return true;
            else
                return false;
        }

        private bool UserExists(string _username, string _password)
        {
            if (playerList.Any(x => x.UserName.ToLower() == _username.ToLower()))
            {
                Player potentialLoginPlayer = playerList.Find(x => x.UserName.ToLower() == _username.ToLower());
                if (potentialLoginPlayer.Password.ToLower() == _password.ToLower())
                {
                    loginPlayer = potentialLoginPlayer;
                    return true;
                }
                else
                {
                    RPG.UI.MessageForm mes = new RPG.UI.MessageForm("The password does not match the Username!");
                    mes.ShowDialog();
                    return false;
                }
            }
            else
            {
                RPG.UI.MessageForm mes = new RPG.UI.MessageForm("No user with that username found!");
                mes.ShowDialog();
                return false;
            }
        }

        #endregion

        #region Events

        private void btLogin_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            if (UserExists(textBoxPlayerName.Text, textBoxPassword.Text))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void textBoxPlayerName_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxPlayerName.Text = "";
        }

        private void textBoxPassword_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxPassword.Text = "";
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            textBoxPassword.PasswordChar = '*';
        }

        private void btNewUser_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            if (Function.GeneralFunctions.CheckTextForNonLettersAndNonDigits(textBoxPassword.Text) && Function.GeneralFunctions.CheckTextForNonLettersAndNonDigits(textBoxPlayerName.Text))
            {
                if (!IsUsernameTaken(textBoxPlayerName.Text))
                {
                    loginPlayer.UserName = textBoxPlayerName.Text;
                    loginPlayer.Password = textBoxPassword.Text;
                    playerList.Add(loginPlayer);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    RPG.UI.MessageForm mes = new RPG.UI.MessageForm("That Username is already taken.");
                    mes.ShowDialog();
                }
            }
            else
            {
                RPG.UI.MessageForm mes = new RPG.UI.MessageForm("You may only use letters and digits for your Username and/or Password.");
                mes.ShowDialog();
            }
        }

        private void bnExit_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        #endregion
        
        
    }
}
