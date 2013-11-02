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

namespace RPG.UI
{
    public partial class ChangeGearForm : Form
    {
        Item theItem;
        Item toBeReplaced;
        Player player;
        int battleCharmIndex = 0;
        Core.Units.Character selectedChar;

        public ChangeGearForm(Item _item, Player _player)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackgroundImage = RPG.Function.GeneralFunctions.ResizeImage(Properties.Resources.background, labelBackgroundIGNORE.Size);
            this.theItem = _item;
            this.player = _player;
            this.selectedChar = player.ControlledCharacters[0];

            foreach (var item in player.ControlledCharacters)
            {
                comboBoxChooseChar.Items.Add(item.UnitName);
            }

            this.labelCurrentItem.Text = Function.GeneralFunctions.ReturnItemLabelString(theItem);
            labelCurrentItem.ForeColor = Function.GeneralFunctions.ReturnProperColorForItem(theItem);

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

        private void ChangeGearForm_Load(object sender, EventArgs e)
        {
            LoadFont();
            foreach (var item in this.Controls)
            {
                AllocFont(font, (item as Control), (item as Control).Font.Size);
            }

            this.Font = new Font("Microsoft Sans Serif", 8.0f);
        }

        #endregion

        private void SetLabelsAndPictures(int index)
        {

            foreach (var character in player.ControlledCharacters)
            {
                if (character.UnitName.Equals(comboBoxChooseChar.Items[index]))
                {
                    selectedChar = character;
                    break;
                }
            }

            this.pictureBoxChar.Image = Function.GeneralFunctions.ReturnImageForClass(selectedChar);

            if(selectedChar != null)
            {
                switch (theItem.ItemType)
                {
                    case EnumItemType.Weapon:
                        toBeReplaced = selectedChar.CharGear.Weapon;
                        break;
                    case EnumItemType.Armor:
                        if ((theItem as Core.Items.Armor).ArmorType == Core.Items.EnumArmorType.Chestarmor)
                            toBeReplaced = selectedChar.CharGear.ChestArmor;
                        else if ((theItem as Core.Items.Armor).ArmorType == Core.Items.EnumArmorType.Headarmor)
                            toBeReplaced = selectedChar.CharGear.HeadArmor;
                        else if ((theItem as Core.Items.Armor).ArmorType == Core.Items.EnumArmorType.Legarmor)
                            toBeReplaced = selectedChar.CharGear.LegArmor;
                        break;
                    case EnumItemType.Battlecharm:
                        try
                        {
                            toBeReplaced = selectedChar.CharGear.BattleCharms[battleCharmIndex];
                        }
                        catch (Exception exp)
                        {
                            toBeReplaced = null;
                        }
                        finally { }
                        break;
                    default:
                        break;
                }

                this.labelEquippedItem.Text = Function.GeneralFunctions.ReturnItemLabelString(toBeReplaced);

                if (toBeReplaced != null)
                {
                    labelEquippedItem.ForeColor = Function.GeneralFunctions.ReturnProperColorForItem(toBeReplaced);

                    if (toBeReplaced.ItemType == EnumItemType.Battlecharm)
                        this.labelEquippedItem.Text += Environment.NewLine + "Click here to see the next battlecharm!";
                }

                labelCharacterStats.Text = selectedChar.CharClass +
                                "\nLevel: " + selectedChar.UnitLevel +
                                "\nXP: " + selectedChar.CharCurrentXP + "/" + selectedChar.CharXPToLevel +
                                "\nHealth: " + selectedChar.CurrentHP.IntValue + "/" + selectedChar.BuffedHP.IntValue +
                                "\nStrength: " + selectedChar.BuffedStrength.IntValue +
                                "\nAgility: " + selectedChar.BuffedAgility.IntValue +
                                "\nIntellect: " + selectedChar.BuffedIntellingence.IntValue +
                                "\nMelee: " + selectedChar.BuffedAttackDamage.IntValue +
                                "\nArmor: " + selectedChar.BuffedArmor.IntValue;


            }
            else
            {
                RPG.UI.MessageForm mes = new MessageForm("Something truly horrible happened!");
                mes.ShowDialog();
            }
        }

        private bool BattleCharmNeedsNewName()
        {
            Core.Items.BattleCharm old = (Core.Items.BattleCharm)selectedChar.CharGear.BattleCharms.Find(x => x.ItemName != toBeReplaced.ItemName);

            if(old.ItemName == theItem.ItemName)
                return true;
            else
                return false;
        }

        private bool CheckEpochalBattleCharms()
        {
            if (theItem.ItemType == EnumItemType.Battlecharm)
            {
                Core.Items.BattleCharm old = (Core.Items.BattleCharm)selectedChar.CharGear.BattleCharms.Find(x => x.ItemName != toBeReplaced.ItemName);

                if (old.ItemQuality == EnumItemQuality.Epochal && theItem.ItemQuality == EnumItemQuality.Epochal)
                {
                    if (old.ItemName == theItem.ItemName)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }

        #endregion

        #region Events
        private void comboBoxChooseChar_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetLabelsAndPictures(comboBoxChooseChar.SelectedIndex);
        }

        private void btEquip_Click(object sender, EventArgs e)
        {
            Function.SoundManagerClass.PlayButtonSound();
            if (!(theItem.ItemLevel >= 60 && selectedChar.UnitLevel < 60))
            {
                if ((selectedChar.UnitLevel + 4) >= theItem.ItemLevel)
                {
                    if (!CheckEpochalBattleCharms())
                    {
                        if (theItem.ItemType == EnumItemType.Battlecharm)
                        {
                            string oldname = theItem.ItemName;
                            while (BattleCharmNeedsNewName())
                            {
                                theItem.ItemName = Function.ItemGeneration.RandomizeNewName(theItem);
                            }
                            if (oldname != theItem.ItemName)
                            {
                                RPG.UI.MessageForm mes = new MessageForm("Because " + selectedChar.UnitName + " already had a Battlecharm with the name " + oldname + " the new battlecharm was renamed to " + theItem.ItemName + "!");
                                mes.ShowDialog();
                            }
                        }

                        var temp = this.player.InventoryOfPlayer.Find(x => x.Equals(theItem));
                        this.player.InventoryOfPlayer.Remove(temp);
                        if (toBeReplaced != null)
                            this.player.InventoryOfPlayer.Add(toBeReplaced);

                        switch (theItem.ItemType)
                        {
                            case EnumItemType.Weapon:
                                selectedChar.CharGear.AddOrRemoveWeapon((theItem as Core.Items.Weapon), true);
                                break;
                            case EnumItemType.Armor:
                                if ((theItem as Core.Items.Armor).ArmorType == Core.Items.EnumArmorType.Chestarmor)
                                    selectedChar.CharGear.AddOrRemoveChestArmor((theItem as Core.Items.Armor), true);
                                else if ((theItem as Core.Items.Armor).ArmorType == Core.Items.EnumArmorType.Headarmor)
                                    selectedChar.CharGear.AddOrRemoveHeadArmor((theItem as Core.Items.Armor), true);
                                else if ((theItem as Core.Items.Armor).ArmorType == Core.Items.EnumArmorType.Legarmor)
                                    selectedChar.CharGear.AddOrRemoveLegArmor((theItem as Core.Items.Armor), true);
                                break;
                            case EnumItemType.Battlecharm:
                                try
                                {
                                    selectedChar.CharGear.AddOrRemoveBattleCharm((toBeReplaced as Core.Items.BattleCharm), false);
                                }
                                catch (Exception exp) { }
                                finally
                                {
                                    selectedChar.CharGear.AddOrRemoveBattleCharm((theItem as Core.Items.BattleCharm), true);
                                }
                                break;
                            default:
                                break;
                        }

                        RPG.UI.MessageForm messe = new MessageForm("Equipped " + theItem.ItemName + "!");
                        messe.ShowDialog();
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                    {
                        RPG.UI.MessageForm mes = new MessageForm("You are not allowed to have two instances of the same Epochal Battlecharms equipped!");
                        mes.ShowDialog();
                    }
                }
                else
                {
                    RPG.UI.MessageForm mes = new MessageForm(selectedChar.UnitName + " is 5 or more levels lower than " + theItem.ItemName + "'s item level and is not allowed to equip it!");
                    mes.ShowDialog();
                }
            }
            else
            {
                RPG.UI.MessageForm mes = new MessageForm(selectedChar.UnitName + " must be level 60 to equip level 60+ items!");
                mes.ShowDialog();
            }
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            Function.SoundManagerClass.PlayButtonSound();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void labelEquippedItem_Click(object sender, EventArgs e)
        {
            if (theItem.ItemType == EnumItemType.Battlecharm)
            {
                if(battleCharmIndex == 0)
                    battleCharmIndex = 1;
                else
                    battleCharmIndex = 0;

                SetLabelsAndPictures(comboBoxChooseChar.SelectedIndex);
            }
        }

        #endregion
    }
}
