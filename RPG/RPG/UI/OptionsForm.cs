using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using RPG.Core;

namespace RPG.UI
{
    public partial class OptionsForm : Form
    {
        #region Field
        Player player;
        #endregion

        public OptionsForm(Player _player)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackgroundImage = Function.GeneralFunctions.ResizeImage(Properties.Resources.background, labelBackgroundIGNORE.Size);

            player = _player;

            comboBoxChooseChar.Items.Add("None");
            int i = 1;
            foreach (var item in _player.ControlledCharacters)
            {
                comboBoxChooseChar.Items.Add(item.UnitName);
                if (item.UnitName == player.PrefChar)
                    comboBoxChooseChar.SelectedIndex = i;

                i++;
            }

            if (player.PrefChar == "None")
                comboBoxChooseChar.SelectedIndex = 0;

            comboBoxDifficulty.Items.Add("Very Easy (Level - 4)");
            comboBoxDifficulty.Items.Add("Easy (Level - 2)");
            comboBoxDifficulty.Items.Add("Normal (Level)");
            comboBoxDifficulty.Items.Add("Hard (Level + 2)");
            comboBoxDifficulty.Items.Add("Very Hard (Level + 4)");

            comboBoxDifficulty.SelectedIndex = _player.PrefDifficulty;
        }

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

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            LoadFont();
            foreach (var item in this.Controls)
            {
                AllocFont(font, (item as Control), (item as Control).Font.Size);
            }


        }

        #endregion

        private void bnOK_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            player.PrefDifficulty = comboBoxDifficulty.SelectedIndex;
            player.PrefChar = comboBoxChooseChar.SelectedItem.ToString();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void bnAbandon_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            player.CurrentQuest = null;
            MessageForm mes = new MessageForm("You abandomed your quest!");
            mes.ShowDialog();
        }


    }
}
