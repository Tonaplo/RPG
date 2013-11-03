using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RPG;
using RPG.Core;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace RPG.UI
{
    public partial class RandomizeStatForm : Form
    {
        #region Fields
        Player player;
        Core.Units.Character selectedCharacter;
        Item choosenItem;
        #endregion

        public RandomizeStatForm(Player _player)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackgroundImage = RPG.Function.GeneralFunctions.ResizeImage(Properties.Resources.background, labelBackgroundIGNORE.Size);

            player = _player;

            UpdateDustRemaining();

            foreach (var item in this.player.ControlledCharacters)
            {
                comboBoxChooseChar.Items.Add(item.UnitName);
            }

            foreach (var item in player.InventoryOfPlayer)
            {
                listBoxInventory.Items.Add(item.ItemName);
            }

            comboBoxChooseChar.SelectedIndex = 0;
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

        private void RandomizeStatForm_Load(object sender, EventArgs e)
        {
            LoadFont();
            foreach (var item in this.Controls)
            {
                AllocFont(font, (item as Control), (item as Control).Font.Size);
            }

            
        }

        #endregion

        private void UpdateDustRemaining()
        {
            labelDust.Text = "Dust: " + this.player.Dust.ToString();
        }

        private void SetListBoxGear()
        {
            listBoxGear.Items.Clear();
            if(selectedCharacter.CharGear.HeadArmor != null)
                listBoxGear.Items.Add(selectedCharacter.CharGear.HeadArmor.ItemName);
            if(selectedCharacter.CharGear.ChestArmor != null)
                listBoxGear.Items.Add(selectedCharacter.CharGear.ChestArmor.ItemName);
            if(selectedCharacter.CharGear.LegArmor != null)
                listBoxGear.Items.Add(selectedCharacter.CharGear.LegArmor.ItemName);
            if(selectedCharacter.CharGear.Weapon != null)
                listBoxGear.Items.Add(selectedCharacter.CharGear.Weapon.ItemName);

            
            foreach (var item in selectedCharacter.CharGear.BattleCharms)
            {
                listBoxGear.Items.Add(item.ItemName);
            }

            labelGearOfChar.Text = "Gear of " + selectedCharacter.UnitName + ":";

        }

        private void SetChoosenItemLabel()
        {
            if (choosenItem != null)
            {
                comboBoxAttribute.Items.Clear();

                string temp = "";

                foreach (var item in choosenItem.stats)
                {
                    temp += item.Type + ": " + item.IntValue.ToString() + Environment.NewLine;
                    comboBoxAttribute.Items.Add(item.Type);
                }
                comboBoxAttribute.SelectedIndex = 0;

                labelChosenItem.Text = choosenItem.ItemName + Environment.NewLine + Environment.NewLine
                                        + "Dust Cost: " + choosenItem.ItemLevel + Environment.NewLine + temp;

                labelChosenItem.ForeColor = Function.GeneralFunctions.ReturnProperColorForItem(choosenItem);
            }
        }
        #endregion

        #region Events

        private void comboBoxChooseChar_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCharacter = this.player.ControlledCharacters[comboBoxChooseChar.SelectedIndex];
            SetListBoxGear();
        }

        private void listBoxGear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemName = listBoxGear.SelectedItem.ToString();

            if (selectedCharacter.CharGear.BattleCharms.Any(x => x.ItemName.Equals(itemName)))
                choosenItem = selectedCharacter.CharGear.BattleCharms.Find(x => x.ItemName.Equals(itemName));
            else if (selectedCharacter.CharGear.ChestArmor != null && selectedCharacter.CharGear.ChestArmor.ItemName.Equals(itemName))
                choosenItem = selectedCharacter.CharGear.ChestArmor;
            else if (selectedCharacter.CharGear.HeadArmor != null && selectedCharacter.CharGear.HeadArmor.ItemName.Equals(itemName))
                choosenItem = selectedCharacter.CharGear.HeadArmor;
            else if (selectedCharacter.CharGear.LegArmor != null && selectedCharacter.CharGear.LegArmor.ItemName.Equals(itemName))
                choosenItem = selectedCharacter.CharGear.LegArmor;
            else if (selectedCharacter.CharGear.Weapon != null && selectedCharacter.CharGear.Weapon.ItemName.Equals(itemName))
                choosenItem = selectedCharacter.CharGear.Weapon;

            SetChoosenItemLabel();
        }

        private void listBoxInventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            choosenItem = this.player.InventoryOfPlayer[listBoxInventory.SelectedIndex];

            SetChoosenItemLabel();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btRandomize_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            if (choosenItem != null && player.Dust >= choosenItem.ItemLevel)
            {
                if (comboBoxAttribute.SelectedIndex != -1)
                {
                    this.player.Dust -= choosenItem.ItemLevel;
                    UpdateDustRemaining();
                    Random r = new Random(DateTime.Now.Millisecond);
                    int oldValue = choosenItem.stats.Find(x => x.Type.Equals(comboBoxAttribute.SelectedItem)).IntValue;
                    int newValue = r.Next(0, choosenItem.ItemLevel+1);

                    choosenItem.stats.Find(x => x.Type.Equals(comboBoxAttribute.SelectedItem)).IntValue = newValue;

                    labelChange.Text = choosenItem.ItemName + "'s " + choosenItem.stats.Find(x => x.Type.Equals(comboBoxAttribute.SelectedItem)).Type
                                        + " got changed from " + oldValue + " to " + newValue + "!" + Environment.NewLine + Environment.NewLine
                                        + "That's a change of " + (newValue - oldValue);
                    int index = comboBoxAttribute.SelectedIndex;
                    SetChoosenItemLabel();
                    comboBoxAttribute.SelectedIndex = index;
                }
            }
            else if (choosenItem == null)
            {
                RPG.UI.MessageForm mes = new RPG.UI.MessageForm("Choose and Item to change!");
                mes.ShowDialog();
            }
            else
            {
                RPG.UI.MessageForm mes = new RPG.UI.MessageForm("You dont have enough dust! Disenchant more items!");
                mes.ShowDialog();
            }
        }

        private void listBoxGear_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index > -1)
            {
                Item currentItem = new Item();
                if (e.Index == 0)
                    currentItem = selectedCharacter.CharGear.HeadArmor;
                else if (e.Index == 1)
                    currentItem = selectedCharacter.CharGear.ChestArmor;
                else if (e.Index == 2)
                    currentItem = selectedCharacter.CharGear.LegArmor;
                else if (e.Index == 3)
                    currentItem = selectedCharacter.CharGear.Weapon;
                else if (e.Index == 4)
                    currentItem = selectedCharacter.CharGear.BattleCharms[0];
                else if (e.Index == 5)
                    currentItem = selectedCharacter.CharGear.BattleCharms[1];

                e.DrawBackground();
                Graphics yourObj = e.Graphics;
                Color forecolor = Function.GeneralFunctions.ReturnProperColorForItem(currentItem);

                using (SolidBrush fbr = new SolidBrush(forecolor))
                    e.Graphics.DrawString(currentItem.ItemName, e.Font, fbr, e.Bounds, StringFormat.GenericDefault);

                //yourObj.DrawString("",new Font(Fon(new SolidBrush(Color.Red), e.Bounds);

                e.DrawFocusRectangle();
            }
        }

        private void listBoxInventory_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index > -1)
            {
                var currentItem = this.player.InventoryOfPlayer[e.Index];
                e.DrawBackground();
                Graphics yourObj = e.Graphics;
                Color forecolor = Function.GeneralFunctions.ReturnProperColorForItem(currentItem);

                using (SolidBrush fbr = new SolidBrush(forecolor))
                    e.Graphics.DrawString(currentItem.ItemName, e.Font, fbr, e.Bounds, StringFormat.GenericDefault);

                //yourObj.DrawString("",new Font(Fon(new SolidBrush(Color.Red), e.Bounds);

                e.DrawFocusRectangle();
            }
        }

        #endregion

    }
}
