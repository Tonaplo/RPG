using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RPG.Core;
using RPG.UI;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace RPG
{
    public partial class FindBattleForm : Form
    {

        #region Fields
        Player player;
        Core.Units.Character choosechar;
        bool singleplayer = false;
        #endregion
        public FindBattleForm(Player _player)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackgroundImage = Function.GeneralFunctions.ResizeImage(Properties.Resources.background, labelBackgroundIGNORE.Size);
            player = _player;

            for (int i = 1; i < 4; i++)
            {
                comboBoxNumberOfPlayers.Items.Add(i);
            }

            comboBoxNumberOfPlayers.SelectedIndex = 0;

            comboBoxChooseChar.Items.Add("None");

            int y = 1;
            
            foreach (var item in _player.ControlledCharacters)
            {
                comboBoxChooseChar.Items.Add(item.UnitName);
                if (item.UnitName == player.PrefChar)
                    comboBoxChooseChar.SelectedIndex = y;

                y++;
            }

            if(player.PrefChar == "None")
                comboBoxChooseChar.SelectedIndex = 1;

            SetCharacterUserControl(comboBoxChooseChar.SelectedIndex);

            comboBoxDifficulty.Items.Add("Very Easy (Level - 4)");
            comboBoxDifficulty.Items.Add("Easy (Level - 2)");
            comboBoxDifficulty.Items.Add("Normal (Level)");
            comboBoxDifficulty.Items.Add("Hard (Level + 2)");
            comboBoxDifficulty.Items.Add("Very Hard (Level + 4)");

            comboBoxDifficulty.SelectedIndex = _player.PrefDifficulty;

        }

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

        private void FindBattleForm_Load(object sender, EventArgs e)
        {
            LoadFont();
            foreach (var item in this.Controls)
            {
                AllocFont(font, (item as Control), (item as Control).Font.Size);
            }

            
        }

        #endregion

        private void SetCharacterUserControl(int index)
        {
            flowLayoutPanelBattleChar.Controls.Clear();

            foreach (var character in player.ControlledCharacters)
            {
                if (character.UnitName.Equals(comboBoxChooseChar.Items[index]))
                {
                    choosechar = character;
                    break;
                }
            }

            if (choosechar != null)
                flowLayoutPanelBattleChar.Controls.Add(new ucCharacterInterface(choosechar, false));
            else
            {
                RPG.UI.MessageForm mes = new RPG.UI.MessageForm("Something truly horrible happened!");
                mes.ShowDialog();
            }
        }

        /// <summary>
        /// Returns the character choosen to Battle
        /// </summary>
        /// <returns></returns>
        public Core.Units.Character ReturnChar()
        {
            return choosechar;
        }

        /// <summary>
        /// Returns the difficulty of the coming battle
        /// </summary>
        /// <returns>-4 is very easy, -2 is easy, 0 is normal, 2 is hard, 4 is very hard</returns>
        public int ReturnDifficulty()
        {
            switch (comboBoxDifficulty.SelectedIndex)
            {
                case 0:
                    return -4;
                case 1:
                    return -2;
                case 2:
                    return 0;
                case 3:
                    return 2;
                case 4:
                    return 4;
                default:
                    return 0;
            }
            
        }

        /// <summary>
        /// This function returns true if singleplayer was choosen
        /// </summary>
        /// <returns></returns>
        public bool ReturnPlayMode()
        {
            return singleplayer;
        }
        #endregion

        #region Events

        private void bnCancel_Click(object sender, EventArgs e)
        {
            Function.SoundManagerClass.PlayButtonSound();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void comboBoxChooseChar_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCharacterUserControl(comboBoxChooseChar.SelectedIndex);
        }

        private void btSinglePlayer_Click(object sender, EventArgs e)
        {
            Function.SoundManagerClass.PlayButtonSound();
            if (choosechar.UnitActiveAbilities.Count > 0)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                singleplayer = true;
                this.Close();
            }
            else
            {
                MessageForm mes = new MessageForm("That character has not choosen any active skills!");
                mes.ShowDialog();
            }
        }

        public bool Singleplayer
        {
            get { return singleplayer; }
        }

        private void bnMultiplayer_Click(object sender, EventArgs e)
        {
            Function.SoundManagerClass.PlayButtonSound();
            if (choosechar.UnitActiveAbilities.Count > 0)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                singleplayer = false;
                this.Close();
            }
            else
            {
                MessageForm mes = new MessageForm("That character has not choosen any active skills!");
                mes.ShowDialog();
            }
        }

        #endregion
    }
}
