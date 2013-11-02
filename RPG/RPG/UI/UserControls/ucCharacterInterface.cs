using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using RPG.Core.Units;

namespace RPG.UI
{
    public partial class ucCharacterInterface : UserControl
    {

        #region Fields
        Core.Units.Character character = null;
        #endregion
        public ucCharacterInterface(Core.Units.Character _character, bool _withGear)
        {
            InitializeComponent();
            character = _character;
            lbCharName.Text = character.UnitName;
            this.BackColor = Color.Transparent;

            character.ResetChar();

            lbCharStats.Text = Function.GeneralFunctions.ReturnCharInterfaceString(this.character);

            pictureBoxChar.Image = Function.GeneralFunctions.ReturnImageForClass(character);

            if (!_withGear)
            {
                btCharacter.Enabled = false;
                btCharacter.Visible = false;
                flpAbilitiesAndPassives.Height += 31;
            }

            foreach (var item in _character.UnitActiveAbilities)
            {
                this.flpAbilitiesAndPassives.Controls.Add(new ucAbilityIcon(item));
            }
        }

        #region Font Stuff
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbfont, uint cbfont, IntPtr pdv, [In] ref uint pcFonts);
        FontFamily ff;
        Font font;

        public Character Character()
        {
            return character;
        }

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

        private void ucCharacterInterface_Load(object sender, EventArgs e)
        {
            LoadFont();
            foreach (var item in this.Controls)
            {
                AllocFont(font, (item as Control), (item as Control).Font.Size);
            }
            this.Font = new Font("Arial", 7.15f);
        }

        #endregion

        public void Update()
        {
            character.ResetChar();

            lbCharStats.Text = Function.GeneralFunctions.ReturnCharInterfaceString(this.character);
                                
            flpAbilitiesAndPassives.Controls.Clear();

            foreach (var item in character.UnitActiveAbilities)
            {
                this.flpAbilitiesAndPassives.Controls.Add(new ucAbilityIcon(item));
            }
        }

        private void btAbilities_Click(object sender, EventArgs e)
        {
            CharacterOverviewForm cof = new CharacterOverviewForm(character);
            cof.ShowDialog();
            this.Update();
        }
    }
}
