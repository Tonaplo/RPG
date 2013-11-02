using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RPG.Core.Units;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using RPG.Core;

namespace RPG.UI
{
    public partial class ucNPC : UserControl
    {
        Core.Units.NPC npc;

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

        private void ucNPC_Load(object sender, EventArgs e)
        {
            LoadFont();
            foreach (var item in this.Controls)
            {
                AllocFont(font, (item as Control), (item as Control).Font.Size);
            }
            this.Font = new Font("Arial", 7.15f);
            
        }

        #endregion

        public ucNPC(NPC _npc)
        {
            InitializeComponent();

            this.BackColor = Color.Transparent;
            npc = _npc;
            lbNPCName.Text = npc.UnitName + " the Level " + npc.UnitLevel + " " + npc.TypeOfNPC;
            labelHealthRemaining.Width = flpHealthBar.Width;
            labelHealthRemaining.Text = npc.CurrentHP.IntValue + "/" + npc.BuffedHP.IntValue + " (100%)";

            foreach (var item in _npc.UnitActiveAbilities)
            {
                flpAbilitiesAndPassives.Controls.Add(new ucAbilityIcon(item));
            }

            switch (_npc.TypeOfNPC)
            {
                case EnumMonsterType.Dragon:
                    pictureBoxNPC.Image = Properties.Resources.dragon;
                    break;
                case EnumMonsterType.Humanoid:
                    pictureBoxNPC.Image = Properties.Resources.humanoid;
                    break;
                case EnumMonsterType.Beast:
                    pictureBoxNPC.Image = Properties.Resources.beast;
                    break;
                case EnumMonsterType.Undead:
                    pictureBoxNPC.Image = Properties.Resources.undead;
                    break;
                case EnumMonsterType.Null:
                    break;
                default:
                    break;
            }

        }

        public void Update()
        {
            int width = (int)(flpHealthBar.Width * ((double)npc.CurrentHP.IntValue / (double)npc.BuffedHP.IntValue));
            int percentHP = (int)(((double)npc.CurrentHP.IntValue / (double)npc.BuffedHP.IntValue) * 100);

            labelHealthRemaining.Width = width;

            if (percentHP > 50)
            {
                flpHealthBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
                labelHealthRemaining.BackColor = Color.DarkGreen;
                flpHealthBar.BackColor = Color.DarkRed;

                labelHealthRemaining.Width = width;

                labelHealthRemaining.Text = npc.CurrentHP.IntValue + "/" + npc.BuffedHP.IntValue + " (" + percentHP + "%)";
                labelHealthRemaining.ForeColor = Color.Black;

            }
            else
            {
                width = (flpHealthBar.Width - width);
                flpHealthBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                labelHealthRemaining.BackColor = Color.DarkRed;
                labelHealthRemaining.ForeColor = Color.White;
                flpHealthBar.BackColor = Color.DarkGreen;

                labelHealthRemaining.Width = width;

                if (npc.CurrentHP.IntValue > 0)
                    labelHealthRemaining.Text = npc.CurrentHP.IntValue + "/" + npc.BuffedHP.IntValue + " (" + percentHP + "%)";
                else
                {
                    labelHealthRemaining.Width = flpHealthBar.Width;
                    labelHealthRemaining.BackColor = Color.DarkRed;
                    labelHealthRemaining.ForeColor = Color.White;
                    labelHealthRemaining.Text = "DEAD";
                }
            }
        }
    }
}
