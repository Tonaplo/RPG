using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RPG.Core;
using RPG.Function;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace RPG
{
    public partial class CharacterCreationForm : Form
    {

        #region Fields
        Core.Units.Character returnedCharacter = null;
        int classchoice = 0;
        Core.EnumCharClass finalclass = Core.EnumCharClass.Warrior;
        Size temp = new Size();
        Player player;
        #endregion
        public CharacterCreationForm(Player _player)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackgroundImage = GeneralFunctions.ResizeImage(Properties.Resources.background, labelBackgroundIGNORE.Size);

            this.player = _player;
        }

        public Core.Units.Character ReturnCharacter()
        {
            return returnedCharacter;
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

        private void CharacterCreationForm_Load(object sender, EventArgs e)
        {
            LoadFont();
            foreach (var item in this.Controls)
            {
                AllocFont(font, (item as Control), (item as Control).Font.Size);
            }

            this.Font = new Font("Microsoft Sans Serif", 8.0f);
        }

        #endregion

        #region Functions used to switch between choosen character class

        private void pictureBoxRightArrow_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            UpdateClassSelection(1);
        }

        private void pictureBoxLeftArrow_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            UpdateClassSelection(-1);
        }

        private void UpdateClassSelection(int modifier)
        {
            classchoice += modifier;

            if (classchoice == -1)
                classchoice = 5;
            else if (classchoice == 6)
                classchoice = 0;

            switch (classchoice)
            {
                case 0:
                    finalclass = Core.EnumCharClass.Warrior;
                    labelClassDescription.Text = finalclass.ToString() + "\n\nA pure Strength class, dealing uncontrollable damage to whatever is around him.";
                    pictureBoxClass.Image = Properties.Resources.warrior;
                    break;
                case 1:
                    finalclass = Core.EnumCharClass.Paladin;
                    labelClassDescription.Text = finalclass.ToString() + "\n\nA hybrid Strength/Intellect Class, focusing on healing while dealing damage.";
                    pictureBoxClass.Image = Properties.Resources.paladin;
                    break;
                case 2:
                    finalclass = Core.EnumCharClass.Wizard;
                    labelClassDescription.Text = finalclass.ToString() + "\n\nA pure Intellect class, who deals great amounts of magical damage or heals grivieus wounds.";
                    pictureBoxClass.Image = Properties.Resources.wizard;
                    break;
                case 3:
                    finalclass = Core.EnumCharClass.Thief;
                    labelClassDescription.Text = finalclass.ToString() + "\n\nA pure Agility Class, dealing damage with his weapon and agility, and ''borrows'' equipment from his allies.";
                    pictureBoxClass.Image = Properties.Resources.thief;
                    break;
                case 4:
                    finalclass = Core.EnumCharClass.Caretaker;
                    labelClassDescription.Text = finalclass.ToString() + "\n\nA hybrid Strength/Agility Class, he deals damage and heals based on his health.";
                    pictureBoxClass.Image = Properties.Resources.caretaker;
                    break;
                case 5:
                    finalclass = Core.EnumCharClass.Synergist;
                    labelClassDescription.Text = finalclass.ToString() + "\n\nA hybrid Agility/Intellect Class, always seeking to perfect balance between stats to deal devasteting damage to enemies.";
                    pictureBoxClass.Image = Properties.Resources.synergist;
                    break;
                default:
                    RPG.UI.MessageForm mes = new RPG.UI.MessageForm("An error occured!");
                    mes.ShowDialog();
                    break;
            }

        }
        #endregion

        #region Functions to make the clicking of the arrows look good
        private void pictureBoxRightArrow_MouseDown(object sender, MouseEventArgs e)
        {
            temp.Height = 35;
            temp.Width = 45;
            pictureBoxRightArrow.Size = temp;
        }

        private void pictureBoxRightArrow_MouseUp(object sender, MouseEventArgs e)
        {
            temp.Height = 40;
            temp.Width = 50;
            pictureBoxRightArrow.Size = temp;
        }

        private void pictureBoxLeftArrow_MouseDown(object sender, MouseEventArgs e)
        {
            temp.Height = 35;
            temp.Width = 45;
            pictureBoxLeftArrow.Size = temp;
        }

        private void pictureBoxLeftArrow_MouseUp(object sender, MouseEventArgs e)
        {
            temp.Height = 40;
            temp.Width = 50;
            pictureBoxLeftArrow.Size = temp;
        }
        #endregion

        #endregion

        #region Events

        private void btCancel_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            if (this.player.ControlledCharacters.Count != 0)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            else
            {
                RPG.UI.MessageForm mes = new RPG.UI.MessageForm("You must to have at least one character.");
                mes.ShowDialog();
            }
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            if (textBoxCharacterName.Text != "" && GeneralFunctions.CheckTextForNonLetters(textBoxCharacterName.Text))
            {
                if (!this.player.ControlledCharacters.Any(x => x.UnitName.ToLower().Equals(textBoxCharacterName.Text.ToLower())))
                {
                    returnedCharacter = new Core.Units.Character(textBoxCharacterName.Text, 1, 10, 10, finalclass, 0, 1, 1, 1, 1, 0, 0, null);
                    returnedCharacter.CharGear = GiveCharGear(returnedCharacter);
                    returnedCharacter.AddActiveAbility(new Core.Abilities.MeleeAttack(returnedCharacter, "", "", null, EnumAbilityClassReq.ANY));
                    returnedCharacter.AddPassiveAbility(new Core.Abilities.MeleeAttack(returnedCharacter, "", "", null, EnumAbilityClassReq.ANY));

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    RPG.UI.MessageForm mes = new RPG.UI.MessageForm("You already have a character with that name!");
                    mes.ShowDialog();
                }
            }
            else if (textBoxCharacterName.Text != "")
            {
                RPG.UI.MessageForm mes = new RPG.UI.MessageForm("Please only use Letters for you Character Name");
                mes.ShowDialog();
            }
            else
            {
                RPG.UI.MessageForm mes = new RPG.UI.MessageForm("Please choose a suitable name!");
                mes.ShowDialog();
            }
        }

        private Core.Units.Gear GiveCharGear(Core.Units.Character character)
        {
            Core.Units.Gear gear = new Core.Units.Gear();

            switch (character.CharClass)
            {
                case RPG.Core.EnumCharClass.Warrior:
                    gear.AddOrRemoveWeapon(new RPG.Core.Items.Weapon("Warrior's Axe",EnumItemType.Weapon, EnumItemQuality.Normal, 1, Core.Items.EnumWeaponType.Axe, 1), true);
                    gear.AddOrRemoveChestArmor(new RPG.Core.Items.Armor("Warrior's Chestarmor",EnumItemType.Armor, EnumItemQuality.Normal, 1, Core.Items.EnumArmorType.Chestarmor, 1), true);
                    break;
                case RPG.Core.EnumCharClass.Paladin:
                    gear.AddOrRemoveWeapon(new RPG.Core.Items.Weapon("Paladin's Sword", EnumItemType.Weapon, EnumItemQuality.Normal, 1, Core.Items.EnumWeaponType.Sword, 1), true);
                    gear.AddOrRemoveChestArmor(new RPG.Core.Items.Armor("Paladin's Chestarmor", EnumItemType.Armor, EnumItemQuality.Normal, 1, Core.Items.EnumArmorType.Chestarmor, 1), true);
                    break;
                case RPG.Core.EnumCharClass.Wizard:
                    gear.AddOrRemoveWeapon(new RPG.Core.Items.Weapon("Wizard's Staff", EnumItemType.Weapon, EnumItemQuality.Normal, 1, Core.Items.EnumWeaponType.Staff, 1), true);
                    gear.AddOrRemoveChestArmor(new RPG.Core.Items.Armor("Wizard's Chestarmor", EnumItemType.Armor, EnumItemQuality.Normal, 1, Core.Items.EnumArmorType.Chestarmor, 1), true);
                    break;
                case RPG.Core.EnumCharClass.Thief:
                    gear.AddOrRemoveWeapon(new RPG.Core.Items.Weapon("Thief's Dagger", EnumItemType.Weapon, EnumItemQuality.Normal, 1, Core.Items.EnumWeaponType.Dagger, 1), true);
                    gear.AddOrRemoveChestArmor(new RPG.Core.Items.Armor("Thief's Chestarmor", EnumItemType.Armor, EnumItemQuality.Normal, 1, Core.Items.EnumArmorType.Chestarmor, 1), true);
                    break;
                case RPG.Core.EnumCharClass.Caretaker:
                    gear.AddOrRemoveWeapon(new RPG.Core.Items.Weapon("Caretaker's Mace", EnumItemType.Weapon, EnumItemQuality.Normal, 1, Core.Items.EnumWeaponType.Mace, 1), true);
                    gear.AddOrRemoveChestArmor(new RPG.Core.Items.Armor("Caretaker's Chestarmor", EnumItemType.Armor, EnumItemQuality.Normal, 1, Core.Items.EnumArmorType.Chestarmor, 1), true);
                    break;
                case RPG.Core.EnumCharClass.Synergist:
                    gear.AddOrRemoveWeapon(new RPG.Core.Items.Weapon("Synergist's Bow", EnumItemType.Weapon, EnumItemQuality.Normal, 1, Core.Items.EnumWeaponType.Bow, 1), true);
                    gear.AddOrRemoveChestArmor(new RPG.Core.Items.Armor("Synergist's Chestarmor", EnumItemType.Armor, EnumItemQuality.Normal, 1, Core.Items.EnumArmorType.Chestarmor, 1), true);
                    break;
                default:
                    break;
            }

            gear.AddOrRemoveBattleCharm(new Core.Items.BattleCharm("Copper Coin", EnumItemType.Battlecharm, EnumItemQuality.Normal, 1), true);
            gear.AddOrRemoveBattleCharm(new Core.Items.BattleCharm("Metal Coin", EnumItemType.Battlecharm, EnumItemQuality.Normal, 1), true);
            gear.BattleCharms[0].AddAttributeToItem(EnumAttributeType.Health, 1);
            gear.BattleCharms[1].AddAttributeToItem(EnumAttributeType.Health, 1);
            gear.AddOrRemoveHeadArmor(new Core.Items.Armor("Headcloth", EnumItemType.Armor, EnumItemQuality.Normal, 1, Core.Items.EnumArmorType.Headarmor, 0), true);
            gear.AddOrRemoveLegArmor(new Core.Items.Armor("Loincloth", EnumItemType.Armor, EnumItemQuality.Normal, 1, Core.Items.EnumArmorType.Legarmor, 0), true);

            return gear;
        }

        private void textBoxCharacterName_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxCharacterName.Text = "";
        }

        #endregion
    }
}
