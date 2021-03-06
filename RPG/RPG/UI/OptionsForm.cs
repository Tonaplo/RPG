﻿using System;
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
using System.IO;

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

            foreach (var item in _player.ControlledCharacters)
            {
                listBoxChars.Items.Add(item.UnitName);
            }

            foreach (var tem in _player.Settings.PrefChars)
            {
                listBoxChars.SelectedItems.Add(tem);
            }

            comboBoxDifficulty.Items.Add("Very Easy (Level - 4)");
            comboBoxDifficulty.Items.Add("Easy (Level - 2)");
            comboBoxDifficulty.Items.Add("Normal (Level)");
            comboBoxDifficulty.Items.Add("Hard (Level + 2)");
            comboBoxDifficulty.Items.Add("Very Hard (Level + 4)");

            comboBoxDifficulty.SelectedIndex = _player.Settings.PrefDifficulty;

            if (player.Settings.SoundOn)
            {
                radioButtonSoundOn.Checked = true;
                numericUpDownSound.Value = player.Settings.SoundVolume;
                numericUpDownSound.Enabled = true;
            }
            else
            {
                radioButtonSoundOff.Checked = true;
                numericUpDownSound.Enabled = false;
            }

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
            player.Settings.PrefDifficulty = comboBoxDifficulty.SelectedIndex;
            player.Settings.PrefChars.Clear();
            foreach (var item in listBoxChars.SelectedItems)
            {
                player.Settings.PrefChars.Add(item.ToString());
            }
            player.Settings.SoundVolume = (int)numericUpDownSound.Value;
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

        private void radioButtonSound_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == radioButtonSoundOff)
            {
                player.Settings.SoundOn = false;
                numericUpDownSound.Enabled = false;
            }
            else if (sender == radioButtonSoundOn)
            {
                player.Settings.SoundOn = true;
                numericUpDownSound.Value = player.Settings.SoundVolume;
                numericUpDownSound.Enabled = true;
            }

            Function.SoundManager.PlayMain(player.Settings.SoundOn, this, player.Settings.SoundVolume);
        }

        private void numericUpDownSound_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownSound.Value <= 10 || numericUpDownSound.Value >= 0)
                player.Settings.SoundVolume = (int)numericUpDownSound.Value;
            else if (numericUpDownSound.Value > 10)
            {
                player.Settings.SoundVolume = 10;
                numericUpDownSound.Value = 10;
            }
            else
            {
                player.Settings.SoundVolume = 0;
                numericUpDownSound.Value = 0;
            }

            Function.SoundManager.AdjustVolume(player.Settings.SoundVolume);
        }
    }
}
