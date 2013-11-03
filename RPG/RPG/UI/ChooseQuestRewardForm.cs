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
    public partial class ChooseQuestRewardForm : Form
    {
        #region Fields
        EnumQuestRewardType rewardType;
        #endregion
        public ChooseQuestRewardForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackgroundImage = Function.GeneralFunctions.ResizeImage(Properties.Resources.background, labelBackgroundIGNORE.Size);
        }

        #region Properties

        public EnumQuestRewardType ReturnRewardType()
        {
            return rewardType;
        }

        #endregion

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

        private void ChooseQuestRewardForm_Load(object sender, EventArgs e)
        {
            LoadFont();
            foreach (var item in this.Controls)
            {
                AllocFont(font, (item as Control), (item as Control).Font.Size);
            }


        }

        #endregion

        #region Events
        private void bnExperience_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
            rewardType = EnumQuestRewardType.Experience;
        }

        private void bnItem_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
            rewardType = EnumQuestRewardType.Item;
        }

        private void bnDust_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
            rewardType = EnumQuestRewardType.Dust;
        }
        #endregion
    }
}
