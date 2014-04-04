using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RPG.Core;
using RPG.Core.Units;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace RPG.UI
{
    public partial class DeleteCharForm : Form
    {
        #region Fields
        Player player;
        Character choosechar;
        #endregion

        public DeleteCharForm(Player _player)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackgroundImage = Function.GeneralFunctions.ResizeImage(Properties.Resources.background, labelBackgroundIGNORE.Size);
            player = _player;


            foreach (var item in player.ControlledCharacters)
            {
                comboBoxChooseChar.Items.Add(item.UnitName);
            }

            comboBoxChooseChar.SelectedIndex = 0;
        }

        public Character ChooseChar()
        {
            return choosechar;
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

        private void DeleteCharForm_Load(object sender, EventArgs e)
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
        /// Returns the character choosen to be deleted
        /// </summary>
        /// <returns></returns>
        public Core.Units.Character ReturnChar()
        {
            return choosechar;
        }

        #endregion

        #region Events

        private void bnCancel_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void comboBoxChooseChar_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCharacterUserControl(comboBoxChooseChar.SelectedIndex);
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            player.Settings.PrefChars.RemoveAll(x => x == choosechar.UnitName);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        #endregion
    }
}
