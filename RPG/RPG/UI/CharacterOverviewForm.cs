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
using RPG.Core.Units;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace RPG.UI
{
    public partial class CharacterOverviewForm : Form
    {
        Character character;
        ToolTip tt = new ToolTip();
        public CharacterOverviewForm(Character _char)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackgroundImage = Function.GeneralFunctions.ResizeImage(Properties.Resources.background, labelBackgroundIGNORE.Size);

            character = _char;
            this.labelClassAbilities.Text = character.CharClass.ToString().ToLower() + " abilities:";

            this.labelCharHeader.Text = this.character.UnitName + Environment.NewLine
                                        + this.character.CharClass.ToString().ToLower() + Environment.NewLine
                                        + "Level: " + this.character.UnitLevel;

            SetAttributeLabels();

            #region Set Gear Labels:
            this.pictureBoxChar.Image = Function.GeneralFunctions.ReturnImageForClass(character);
            if (this.character.CharGear.BattleCharms.Count > 0)
            {
                this.labelGearBCharm1Text.Text = Function.GeneralFunctions.ReturnItemLabelString(this.character.CharGear.BattleCharms[0]);
                this.labelGearBCharm1Text.ForeColor = Function.GeneralFunctions.ReturnProperColorForItem(this.character.CharGear.BattleCharms[0]);
            }
            else
            {
                this.labelGearBCharm1Text.Text = Function.GeneralFunctions.ReturnItemLabelString(null);
            }

            if (this.character.CharGear.BattleCharms.Count > 1)
            {
                this.labelGearBCharm2Text.Text = Function.GeneralFunctions.ReturnItemLabelString(this.character.CharGear.BattleCharms[1]);
                this.labelGearBCharm2Text.ForeColor = Function.GeneralFunctions.ReturnProperColorForItem(this.character.CharGear.BattleCharms[1]);
            }
            else
            {
                this.labelGearBCharm2Text.Text = Function.GeneralFunctions.ReturnItemLabelString(null);
            }

            this.labelGearChestText.Text = Function.GeneralFunctions.ReturnItemLabelString(this.character.CharGear.ChestArmor);
            this.labelGearChestText.ForeColor = Function.GeneralFunctions.ReturnProperColorForItem(this.character.CharGear.ChestArmor);
            

            this.labelGearHeadText.Text = Function.GeneralFunctions.ReturnItemLabelString(this.character.CharGear.HeadArmor);
            this.labelGearHeadText.ForeColor = Function.GeneralFunctions.ReturnProperColorForItem(this.character.CharGear.HeadArmor);
            
            this.labelGearLegText.Text = Function.GeneralFunctions.ReturnItemLabelString(this.character.CharGear.LegArmor);
            this.labelGearLegText.ForeColor = Function.GeneralFunctions.ReturnProperColorForItem(this.character.CharGear.LegArmor);
            
            this.labelGearWeaponText.Text = Function.GeneralFunctions.ReturnItemLabelString(this.character.CharGear.Weapon);
            this.labelGearWeaponText.ForeColor = Function.GeneralFunctions.ReturnProperColorForItem(this.character.CharGear.Weapon);
            #endregion

            #region Set all checkbox images
            checkBoxAll1.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.questionmark, new Size(20, 20));
            checkBoxAll2.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.questionmark, new Size(20, 20));
            checkBoxAll3.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.questionmark, new Size(20, 20));
            checkBoxAll4.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.questionmark, new Size(20, 20));
            checkBoxAll5.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.questionmark, new Size(20, 20));
            checkBoxAll6.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.questionmark, new Size(20, 20));
            checkBoxAll7.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.questionmark, new Size(20, 20));
            checkBoxAll8.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.questionmark, new Size(20, 20));
            checkBoxClass1.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.questionmark, new Size(20, 20));
            checkBoxClass2.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.questionmark, new Size(20, 20));
            checkBoxClass3.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.questionmark, new Size(20, 20));
            checkBoxClass4.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.questionmark, new Size(20, 20));
            checkBoxClass5.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.questionmark, new Size(20, 20));
            checkBoxClass6.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.questionmark, new Size(20, 20));
            checkBoxClass7.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.questionmark, new Size(20, 20));
            checkBoxClass8.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.questionmark, new Size(20, 20));
            #endregion

            comboBoxAttributes.Items.Add("Strength");
            comboBoxAttributes.Items.Add("Agility");
            comboBoxAttributes.Items.Add("Intellect");

            comboBoxAttributes.SelectedIndex = 0;

            EnabledUnlockedCheckboxes();
            SetAbilitiesMain();
            SetCheckBoxesFromStart();
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

        private void CharacterOverviewForm_Load(object sender, EventArgs e)
        {
            LoadFont();
            foreach (var item in this.Controls)
            {
                AllocFont(font, (item as Control), (item as Control).Font.Size);
            }

            
        }

        #endregion

        /// <summary>
        /// Finds out if more than 4 checkboxes are checked. Return false if not and true is more than 4 are checked.
        /// </summary>
        /// <returns></returns>
        private bool CheckNumberOfCheckedBoxes()
        {
            int number = 0;

            foreach (var item in groupBoxAllClasses.Controls)
            {
                if ((item as CheckBox).Checked)
                    number++;
            }

            foreach (var item in groupBoxClass.Controls)
            {
                if ((item as CheckBox).Checked)
                    number++;
            }

            if (number < 5)
                return false;
            else
                return true;
        }

        private void EnabledUnlockedCheckboxes()
        {
            if (this.character.UnitLevel >= 1)
                this.checkBoxAll1.Enabled = true;

            if (this.character.UnitLevel >= 2)
                this.checkBoxClass1.Enabled = true;

            if (this.character.UnitLevel >= 5)
                this.checkBoxAll2.Enabled = true;

            if (this.character.UnitLevel >= 8)
                this.checkBoxClass2.Enabled = true;

            if (this.character.UnitLevel >= 10)
                this.checkBoxAll3.Enabled = true;

            if (this.character.UnitLevel >= 15)
                this.checkBoxClass3.Enabled = true;

            if (this.character.UnitLevel >= 20)
                this.checkBoxAll4.Enabled = true;

            if (this.character.UnitLevel >= 25)
                this.checkBoxClass4.Enabled = true;

            if (this.character.UnitLevel >= 30)
                this.checkBoxAll5.Enabled = true;

            if (this.character.UnitLevel >= 35)
                this.checkBoxClass5.Enabled = true;

            if (this.character.UnitLevel >= 40)
                this.checkBoxAll6.Enabled = true;

            if (this.character.UnitLevel >= 45)
                this.checkBoxClass6.Enabled = true;

            if (this.character.UnitLevel >= 50)
                this.checkBoxAll7.Enabled = true;

            if (this.character.UnitLevel >= 55)
                this.checkBoxClass7.Enabled = true;

            if (this.character.UnitLevel >= 57)
                this.checkBoxAll8.Enabled = true;

            if (this.character.UnitLevel >= 60)
                this.checkBoxClass8.Enabled = true;
        }

        private void SetNewCharacterAbilities()
        {
            character.UnitActiveAbilities.Clear();

            foreach (var item in groupBoxAllClasses.Controls)
            {
                if ((item as CheckBox).Checked == true)
                {
                    character.AddActiveAbility(this.character.UnitPassiveAbilities.Find(x => x.AbilityName == (item as CheckBox).Text));
                }
            }

            foreach (var item in groupBoxClass.Controls)
            {
                if ((item as CheckBox).Checked == true)
                {
                    character.AddActiveAbility(this.character.UnitPassiveAbilities.Find(x => x.AbilityName == (item as CheckBox).Text));
                }
            }
        }

        private void SetCheckBoxesFromStart()
        {
            foreach (var item in groupBoxAllClasses.Controls)
            {
                if (character.UnitActiveAbilities.Any(x => x.AbilityName == (item as CheckBox).Text))
                {
                    (item as CheckBox).Checked = true;
                }
            }

            foreach (var item in groupBoxClass.Controls)
            {
                if (this.character.UnitActiveAbilities.Any(x => x.AbilityName == (item as CheckBox).Text))
                {
                    (item as CheckBox).Checked = true;
                }
            }
        }

        private void SetAttributeLabels()
        {
            this.labelBaseAttributes.Text = Function.GeneralFunctions.ReturnCharBaseString(this.character);
            this.labelBuffedAttributes.Text = Function.GeneralFunctions.ReturnCharInterfaceString(this.character);
            this.labelLevelAttribute.Text = "You have " + character.UnUsedAttributePoints.IntValue + " unused Attribute points left!";
        }

        #region Set abilities on Checkboxes Functions

        private void SetAbilitiesMain()
        {
            SetAbilitiesAllClasses();

            switch (this.character.CharClass)
            {
                case EnumCharClass.Warrior:
                    SetAbilitiesWarrior();
                    break;
                case EnumCharClass.Paladin:
                    SetAbilitiesPaladin();
                    break;
                case EnumCharClass.Wizard:
                    SetAbilitiesWizard();
                    break;
                case EnumCharClass.Thief:
                    SetAbilitiesThief();
                    break;
                case EnumCharClass.Caretaker:
                    SetAbilitiesCaretaker();
                    break;
                case EnumCharClass.Synergist:
                    SetAbilitiesSynergist();
                    break;
                default:
                    break;
            }
        }

        private void SetAbilitiesAllClasses()
        {
            if (checkBoxAll1.Enabled == true)
            {
                checkBoxAll1.Text = "Melee Attack";
                checkBoxAll1.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.meleeattack, new Size(20, 20));
            }
            if (checkBoxAll2.Enabled == true)
            {
                checkBoxAll2.Text = "Battle Regeneration";
                checkBoxAll2.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.meleeattack, new Size(20, 20));
            }
            if (checkBoxAll3.Enabled == true)
            {
                checkBoxAll3.Text = "Empowerment";
                checkBoxAll3.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.meleeattack, new Size(20, 20));
            }
            if (checkBoxAll4.Enabled == true)
            {
                checkBoxAll4.Text = "Invigorate";
                checkBoxAll4.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.meleeattack, new Size(20, 20));
            }
            if (checkBoxAll5.Enabled == true)
            {
                checkBoxAll5.Text = "Double Swing";
                checkBoxAll5.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.meleeattack, new Size(20, 20));
            }
            if (checkBoxAll6.Enabled == true)
            {
                checkBoxAll6.Text = "Opportunity";
                checkBoxAll6.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.meleeattack, new Size(20, 20));
            }
            if (checkBoxAll7.Enabled == true)
            {
                checkBoxAll7.Text = "Totalitarism";
                checkBoxAll7.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.meleeattack, new Size(20, 20));
            }
            if (checkBoxAll8.Enabled == true)
            {
                checkBoxAll8.Text = "Ascend";
                checkBoxAll8.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.meleeattack, new Size(20, 20));
            }
        }

        private void SetAbilitiesWarrior()
        {
            if (checkBoxClass1.Enabled == true)
            {
                checkBoxClass1.Text = "Strength";
                checkBoxClass1.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.strength, new Size(20, 20));
            }
            if (checkBoxClass2.Enabled == true)
            {
                checkBoxClass2.Text = "Power Strike";
                checkBoxClass2.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.strength, new Size(20, 20));
            }
            if (checkBoxClass3.Enabled == true)
            {
                checkBoxClass3.Text = "Blind Rage";
                checkBoxClass3.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.strength, new Size(20, 20));
            }
            if (checkBoxClass4.Enabled == true)
            {
                checkBoxClass4.Text = "Rampage";
                checkBoxClass4.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.strength, new Size(20, 20));
            }
            if (checkBoxClass5.Enabled == true)
            {
                checkBoxClass5.Text = "Roar";
                checkBoxClass5.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.strength, new Size(20, 20));
            }
            if (checkBoxClass6.Enabled == true)
            {
                checkBoxClass6.Text = "Infuriate";
                checkBoxClass6.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.strength, new Size(20, 20));
            }
            if (checkBoxClass7.Enabled == true)
            {
                checkBoxClass7.Text = "Execution";
                checkBoxClass7.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.strength, new Size(20, 20));
            }
            if (checkBoxClass8.Enabled == true)
            {
                checkBoxClass8.Text = "Insanity";
                checkBoxClass8.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.strength, new Size(20, 20));
            }
        }

        private void SetAbilitiesWizard()
        {
            if (checkBoxClass1.Enabled == true)
            {
                checkBoxClass1.Text = "Fireball";
                checkBoxClass1.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.fireball, new Size(20, 20));
            }
            if (checkBoxClass2.Enabled == true)
            {
                checkBoxClass2.Text = "Heal";
                checkBoxClass2.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.heal, new Size(20, 20));
            }
            if (checkBoxClass3.Enabled == true)
            {
                checkBoxClass3.Text = "Flame Comet";
                checkBoxClass3.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.fireball, new Size(20, 20));
            }
            if (checkBoxClass4.Enabled == true)
            {
                checkBoxClass4.Text = "Revitalize";
                checkBoxClass4.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.heal, new Size(20, 20));
            }
            if (checkBoxClass5.Enabled == true)
            {
                checkBoxClass5.Text = "Brilliance";
                checkBoxClass5.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.heal, new Size(20, 20));
            }
            if (checkBoxClass6.Enabled == true)
            {
                checkBoxClass6.Text = "Archon";
                checkBoxClass6.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.heal, new Size(20, 20));
            }
            if (checkBoxClass7.Enabled == true)
            {
                checkBoxClass7.Text = "Inferno";
                checkBoxClass7.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.fireball, new Size(20, 20));
            }
            if (checkBoxClass8.Enabled == true)
            {
                checkBoxClass8.Text = "Oracle";
                checkBoxClass8.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.heal, new Size(20, 20));
            }
        }

        private void SetAbilitiesPaladin()
        {
            if (checkBoxClass1.Enabled == true)
            {
                checkBoxClass1.Text = "Wrath";
                checkBoxClass1.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.wrath, new Size(20, 20));
            }
            if (checkBoxClass2.Enabled == true)
            {
                checkBoxClass2.Text = "Justice";
                checkBoxClass2.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.wrath, new Size(20, 20));
            }
            if (checkBoxClass3.Enabled == true)
            {
                checkBoxClass3.Text = "Serenity";
                checkBoxClass3.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.wrath, new Size(20, 20));
            }
            if (checkBoxClass4.Enabled == true)
            {
                checkBoxClass4.Text = "Raise Spirit";
                checkBoxClass4.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.wrath, new Size(20, 20));
            }
            if (checkBoxClass5.Enabled == true)
            {
                checkBoxClass5.Text = "Prayer";
                checkBoxClass5.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.wrath, new Size(20, 20));
            }
            if (checkBoxClass6.Enabled == true)
            {
                checkBoxClass6.Text = "Blessing";
                checkBoxClass6.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.wrath, new Size(20, 20));
            }
            if (checkBoxClass7.Enabled == true)
            {
                checkBoxClass7.Text = "Desperate Plea";
                checkBoxClass7.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.wrath, new Size(20, 20));
            }
            if (checkBoxClass8.Enabled == true)
            {
                checkBoxClass8.Text = "The Power of Faith";
                checkBoxClass8.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.wrath, new Size(20, 20));
            }
        }

        private void SetAbilitiesThief()
        {
            if (checkBoxClass1.Enabled == true)
            {
                checkBoxClass1.Text = "Quick Attack";
                checkBoxClass1.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.quickattack, new Size(20, 20));
            }
            if (checkBoxClass2.Enabled == true)
            {
                checkBoxClass2.Text = "Borrow Weapon";
                checkBoxClass2.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.quickattack, new Size(20, 20));
            }
            if (checkBoxClass3.Enabled == true)
            {
                checkBoxClass3.Text = "Bloodstealer";
                checkBoxClass3.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.quickattack, new Size(20, 20));
            }
            if (checkBoxClass4.Enabled == true)
            {
                checkBoxClass4.Text = "Copycat";
                checkBoxClass4.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.quickattack, new Size(20, 20));
            }
            if (checkBoxClass5.Enabled == true)
            {
                checkBoxClass5.Text = "Swiftness";
                checkBoxClass5.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.quickattack, new Size(20, 20));
            }
            if (checkBoxClass6.Enabled == true)
            {
                checkBoxClass6.Text = "Envenom";
                checkBoxClass6.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.quickattack, new Size(20, 20));
            }
            if (checkBoxClass7.Enabled == true)
            {
                checkBoxClass7.Text = "Dirty Tricks";
                checkBoxClass7.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.quickattack, new Size(20, 20));
            }
            if (checkBoxClass8.Enabled == true)
            {
                checkBoxClass8.Text = "Flurry";
                checkBoxClass8.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.quickattack, new Size(20, 20));
            }
        }

        private void SetAbilitiesCaretaker()
        {
            if (checkBoxClass1.Enabled == true)
            {
                checkBoxClass1.Text = "Body Slam";
                checkBoxClass1.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.bodyslam, new Size(20, 20));
            }
            if (checkBoxClass2.Enabled == true)
            {
                checkBoxClass2.Text = "Sacrifice";
                checkBoxClass2.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.bodyslam, new Size(20, 20));
            }
            if (checkBoxClass3.Enabled == true)
            {
                checkBoxClass3.Text = "Lifeforce";
                checkBoxClass3.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.bodyslam, new Size(20, 20));
            }
            if (checkBoxClass4.Enabled == true)
            {
                checkBoxClass4.Text = "Zeal of Humanity";
                checkBoxClass4.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.bodyslam, new Size(20, 20));
            }
            if (checkBoxClass5.Enabled == true)
            {
                checkBoxClass5.Text = "Action";
                checkBoxClass5.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.bodyslam, new Size(20, 20));
            }
            if (checkBoxClass6.Enabled == true)
            {
                checkBoxClass6.Text = "Lifeblood";
                checkBoxClass6.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.bodyslam, new Size(20, 20));
            }
            if (checkBoxClass7.Enabled == true)
            {
                checkBoxClass7.Text = "Power and Dexterity";
                checkBoxClass7.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.bodyslam, new Size(20, 20));
            }
            if (checkBoxClass8.Enabled == true)
            {
                checkBoxClass8.Text = "Deathdefiance";
                checkBoxClass8.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.bodyslam, new Size(20, 20));
            }
        }

        private void SetAbilitiesSynergist()
        {
            if (checkBoxClass1.Enabled == true)
            {
                checkBoxClass1.Text = "Duality";
                checkBoxClass1.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.duality, new Size(20, 20));
            }
            if (checkBoxClass2.Enabled == true)
            {
                checkBoxClass2.Text = "Agile Mind";
                checkBoxClass2.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.duality, new Size(20, 20));
            }
            if (checkBoxClass3.Enabled == true)
            {
                checkBoxClass3.Text = "Balance";
                checkBoxClass3.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.duality, new Size(20, 20));
            }
            if (checkBoxClass4.Enabled == true)
            {
                checkBoxClass4.Text = "Mental Agility";
                checkBoxClass4.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.duality, new Size(20, 20));
            }
            if (checkBoxClass5.Enabled == true)
            {
                checkBoxClass5.Text = "Align";
                checkBoxClass5.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.duality, new Size(20, 20));
            }
            if (checkBoxClass6.Enabled == true)
            {
                checkBoxClass6.Text = "Collapsed Equality";
                checkBoxClass6.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.duality, new Size(20, 20));
            }
            if (checkBoxClass7.Enabled == true)
            {
                checkBoxClass7.Text = "Synergy";
                checkBoxClass7.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.duality, new Size(20, 20));
            }
            if (checkBoxClass8.Enabled == true)
            {
                checkBoxClass8.Text = "Complete Balance";
                checkBoxClass8.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.duality, new Size(20, 20));
            }
        }

        #endregion

        #endregion

        #region Events
        private void btDone_Click(object sender, EventArgs e)
        {
            Function.SoundManagerClass.PlayButtonSound();
            if (!this.CheckNumberOfCheckedBoxes())
            {
                SetNewCharacterAbilities();
                this.Close();
            }
            else
            {
                UI.MessageForm mes = new MessageForm("You have selected more than 4 active skills!");
                mes.ShowDialog();
            }
        }

        #region All Classes checkbox events

        private void checkBoxAll1_MouseHover(object sender, EventArgs e)
        {
            tt.ToolTipTitle = "Melee Attack";
            tt.Show("Deal damage to the target for 85% of the units attack.", checkBoxAll1, 5000);
        }

        private void checkBoxAll2_MouseHover(object sender, EventArgs e)
        {
                tt.ToolTipTitle = "Battle Regeneration";
                tt.Show("Heals the caster for 100% of the casters level.", checkBoxAll2, 5000);
        }

        private void checkBoxAll3_MouseHover(object sender, EventArgs e)
        {
                tt.ToolTipTitle = "Empowerment";
                tt.Show("Increase the highest stat of the caster by 20%.", checkBoxAll3, 5000);
        }

        private void checkBoxAll4_MouseHover(object sender, EventArgs e)
        {
                tt.ToolTipTitle = "Invigorate";
                tt.Show("Increase the Maximum Health of the caster by 5% of Highest Stat.", checkBoxAll4, 5000);
        }

        private void checkBoxAll5_MouseHover(object sender, EventArgs e)
        {
                tt.ToolTipTitle = "Double Swing";
                tt.Show("Deal damage equal to 275% of the units attack.", checkBoxAll5, 5000);
        }

        private void checkBoxAll6_MouseHover(object sender, EventArgs e)
        {
                tt.ToolTipTitle = "Opportunity";
                tt.Show("Increases a random of your stats by 15%.", checkBoxAll6, 5000);
        }

        private void checkBoxAll7_MouseHover(object sender, EventArgs e)
        {
                tt.ToolTipTitle = "Totalitarism";
                tt.Show("Deals all of the units stats combined in damage.", checkBoxAll7, 5000);
        }

        private void checkBoxAll8_MouseHover(object sender, EventArgs e)
        {
                tt.ToolTipTitle = "Ascend";
                tt.Show("Increases all of the units stats by 15, including max health and attack.", checkBoxAll8, 5000);
        }

        #endregion

        #region Classes checkbox events

        private void checkBoxClass1_MouseHover(object sender, EventArgs e)
        {
            switch (character.CharClass)
            {
                case EnumCharClass.Warrior:
                    tt.ToolTipTitle = "Strength";
                    tt.Show("Deal damage to the target based on the 50% of the strength of the Warrior.", checkBoxClass1, 5000);
                    break;
                case EnumCharClass.Paladin:
                    tt.ToolTipTitle = "Wrath";
                    tt.Show("Deals 50% of the Paladins strength in damage.", checkBoxClass1, 5000);
                    break;
                case EnumCharClass.Wizard:
                    tt.ToolTipTitle = "Fireball";
                    tt.Show("This ability deals damage to the 1 target, based on 50% of the Wizards intellect.", checkBoxClass1, 5000);
                    break;
                case EnumCharClass.Thief:
                    tt.ToolTipTitle = "Quick Attack";
                    tt.Show("Swiftly injure the target for 50% of the casters agility.", checkBoxClass1, 5000);
                    break;
                case EnumCharClass.Caretaker:
                    tt.ToolTipTitle = "Body Slam";
                    tt.Show("Deals 20% of the Caretakers maximum health in damage to the target.", checkBoxClass1, 5000);
                    break;
                case EnumCharClass.Synergist:
                    tt.ToolTipTitle = "Duality";
                    tt.Show("Deals 25% of the Synergists combined intellect and agility in damage.", checkBoxClass1, 5000);
                    break;
                default:
                    break;
            }
        }

        private void checkBoxClass2_MouseHover(object sender, EventArgs e)
        {
            switch (character.CharClass)
            {
                case EnumCharClass.Warrior:
                    tt.ToolTipTitle = "Power Strike";
                    tt.Show("Deal damage to the target based on 70% attack damage and 10% of the Warriors strength.", checkBoxClass2, 5000);
                    break;
                case EnumCharClass.Paladin:
                    tt.ToolTipTitle = "Justice";
                    tt.Show("Deals 40% of the Paladins strength in damage and heals him for 30% of his intellect.", checkBoxClass2, 5000);
                    break;
                case EnumCharClass.Wizard:
                    tt.ToolTipTitle = "Heal";
                    tt.Show("This Ability heals the target player for an amount equal to 25% of the Wizards Intellect.", checkBoxClass2, 5000);
                    break;
                case EnumCharClass.Thief:
                    tt.ToolTipTitle = "Borrow Weapon";
                    tt.Show("The Thief uses the best attack of his allies together with his own, dealing 45% of their combined damage.", checkBoxClass2, 5000);
                    break;
                case EnumCharClass.Caretaker:
                    tt.ToolTipTitle = "Sacrifice";
                    tt.Show("Deals 85% of the Caretakers agility in damage, but takes damage equal to the difference between strength and agility.", checkBoxClass2, 5000);
                    break;
                case EnumCharClass.Synergist:
                    tt.ToolTipTitle = "Agile Mind";
                    tt.Show("Deals damage for 55% of the Synergists Agility, but subtracts the difference between Agility and Intellect from the damage.", checkBoxClass2, 5000);
                    break;
                default:
                    break;
            }
        }

        private void checkBoxClass3_MouseHover(object sender, EventArgs e)
        {
            switch (character.CharClass)
            {
                case EnumCharClass.Warrior:
                    tt.ToolTipTitle = "Blind Rage";
                    tt.Show("Deals anywhere between 175 and 75% of the Warriors strength in damage.", checkBoxClass3, 5000);
                    break;
                case EnumCharClass.Paladin:
                    tt.ToolTipTitle = "Serenity";
                    tt.Show("Heals a random ally and deals damage to the target for 40% of the Paladins intellect.", checkBoxClass3, 5000);
                    break;
                case EnumCharClass.Wizard:
                    tt.ToolTipTitle = "Flame Comet";
                    tt.Show("Deals damage to the target for 110% of the Wizards intellect.", checkBoxClass3, 5000);
                    break;
                case EnumCharClass.Thief:
                    tt.ToolTipTitle = "Bloodstealer";
                    tt.Show("Deals 100% of the Thiefs agility in damage and heals him for 10% of the damage dealt.", checkBoxClass3, 5000);
                    break;
                case EnumCharClass.Caretaker:
                    tt.ToolTipTitle = "Lifeforce";
                    tt.Show("Deals 90% of the Caretakers health deficit in damage to the target AND the Caretaker.", checkBoxClass3, 5000);
                    break;
                case EnumCharClass.Synergist:
                    tt.ToolTipTitle = "Balance";
                    tt.Show("Of Agility and Intellect, increases lowest stat by 15% and highest by 10%.", checkBoxClass3, 5000);
                    break;
                default:
                    break;
            }
        }

        private void checkBoxClass4_MouseHover(object sender, EventArgs e)
        {
            switch (character.CharClass)
            {
                case EnumCharClass.Warrior:
                    tt.ToolTipTitle = "Rampage";
                    tt.Show("The Warriors deals 135% of his  strength in damage, but takes 10% damage of the damage himself.", checkBoxClass4, 5000);
                    break;
                case EnumCharClass.Paladin:
                    tt.ToolTipTitle = "Raise Spirit";
                    tt.Show("The Paladin heals the target for 25% of his combined strength and intellect.", checkBoxClass4, 5000);
                    break;
                case EnumCharClass.Wizard:
                    tt.ToolTipTitle = "Revitalize";
                    tt.Show("The Wizard heals the target for 50% of her intellect.", checkBoxClass4, 5000);
                    break;
                case EnumCharClass.Thief:
                    tt.ToolTipTitle = "Copycat";
                    tt.Show("Deals 95% of the Thiefs allies' highest stat in damage.", checkBoxClass4, 5000);
                    break;
                case EnumCharClass.Caretaker:
                    tt.ToolTipTitle = "Zeal of Humanity";
                    tt.Show("Heals target ally for 75% of the Caretakers strength, but injures himself for 50% of the amount healed.", checkBoxClass4, 5000);
                    break;
                case EnumCharClass.Synergist:
                    tt.ToolTipTitle = "Mental Agility";
                    tt.Show("Deals 115% of the Synergists Intellect in damage, subtracting the difference between Intellect and Agility.", checkBoxClass4, 5000);
                    break;
                default:
                    break;
            }
        }

        private void checkBoxClass5_MouseHover(object sender, EventArgs e)
        {
            switch (character.CharClass)
            {
                case EnumCharClass.Warrior:
                    tt.ToolTipTitle = "Roar";
                    tt.Show("Increases the strength of the Warrior by 40%.", checkBoxClass5, 5000);
                    break;
                case EnumCharClass.Paladin:
                    tt.ToolTipTitle = "Prayer";
                    tt.Show("Increases the strength and intellect of the Paladin by 20%.", checkBoxClass5, 5000);
                    break;
                case EnumCharClass.Wizard:
                    tt.ToolTipTitle = "Brilliance";
                    tt.Show("Increases the intellect of the Wizard by 40%.", checkBoxClass5, 5000);
                    break;
                case EnumCharClass.Thief:
                    tt.ToolTipTitle = "Swiftness";
                    tt.Show("Increases the agility of the Thief by 40%", checkBoxClass5, 5000);
                    break;
                case EnumCharClass.Caretaker:
                    tt.ToolTipTitle = "Action";
                    tt.Show("Increases the strength and agility of the Caretaker by 20%.", checkBoxClass5, 5000);
                    break;
                case EnumCharClass.Synergist:
                    tt.ToolTipTitle = "Align";
                    tt.Show("Increases the intellect and agility of the Synergist by 20%.", checkBoxClass5, 5000);
                    break;
                default:
                    break;
            }
        }

        private void checkBoxClass6_MouseHover(object sender, EventArgs e)
        {
            switch (character.CharClass)
            {
                case EnumCharClass.Warrior:
                    tt.ToolTipTitle = "Infuriate";
                    tt.Show("Increases the Warriors attack by 25% of the Warriors health deficit.", checkBoxClass6, 5000);
                    break;
                case EnumCharClass.Paladin:
                    tt.ToolTipTitle = "Blessing";
                    tt.Show("Increases the target allys' highest stat by 40%:", checkBoxClass6, 5000);
                    break;
                case EnumCharClass.Wizard:
                    tt.ToolTipTitle = "Archon";
                    tt.Show("Reduces maximum health by 60%, but increases intellect by 300%.", checkBoxClass6, 5000);
                    break;
                case EnumCharClass.Thief:
                    tt.ToolTipTitle = "Envenom";
                    tt.Show("Increases the Attack of the Thief by 10%.", checkBoxClass6, 5000);
                    break;
                case EnumCharClass.Caretaker:
                    tt.ToolTipTitle = "Lifeblood";
                    tt.Show("The Caretaker heals a target ally to full, but takes the allys' health deficit in damage.", checkBoxClass6, 5000);
                    break;
                case EnumCharClass.Synergist:
                    tt.ToolTipTitle = "Collapsed Equality";
                    tt.Show("Heals all allies for 50/37/25 % of the Synergists Intellect, but reduces intellect by 20%.", checkBoxClass6, 5000);
                    break;
                default:
                    break;
            }
        }

        private void checkBoxClass7_MouseHover(object sender, EventArgs e)
        {
            switch (character.CharClass)
            {
                case EnumCharClass.Warrior:
                    tt.ToolTipTitle = "Execution";
                    tt.Show("Deals 750% attack damage if the target dies from this. Otherwise, deals 150% Weapon Damage.", checkBoxClass7, 5000);
                    break;
                case EnumCharClass.Paladin:
                    tt.ToolTipTitle = "Desperate Plea";
                    tt.Show("Heals the target for 75% of their maximum health, but decreases their maximum health by 20%.", checkBoxClass7, 5000);
                    break;
                case EnumCharClass.Wizard:
                    tt.ToolTipTitle = "Inferno";
                    tt.Show("Deals damage to the target for 280% of the Wizards intellect.", checkBoxClass7, 5000);
                    break;
                case EnumCharClass.Thief:
                    tt.ToolTipTitle = "Dirty Tricks";
                    tt.Show("Deals 250% of the Thiefs agility and 40% of his attack as damage to the target.", checkBoxClass7, 5000);
                    break;
                case EnumCharClass.Caretaker:
                    tt.ToolTipTitle = "Power and Dexterity";
                    tt.Show("Deals 140% of the Caretakers combined Strength and Agility to the target.", checkBoxClass7, 5000);
                    break;
                case EnumCharClass.Synergist:
                    tt.ToolTipTitle = "Synergy";
                    tt.Show("Deals 145% of the Synergists combined intellect and agility as damage, but subtracts difference between them from this amount", checkBoxClass7, 5000);
                    break;
                default:
                    break;
            }
        }

        private void checkBoxClass8_MouseHover(object sender, EventArgs e)
        {
            switch (character.CharClass)
            {
                case EnumCharClass.Warrior:
                    tt.ToolTipTitle = "Insanity";
                    tt.Show("The Warrior deals 350% of his strength in damage to the target, but injures of his allies for 15% of the damage dealt.", checkBoxClass8, 5000);
                    break;
                case EnumCharClass.Paladin:
                    tt.ToolTipTitle = "The Power of Faith";
                    tt.Show("Heals the paladin to full health, but reduces all his stats by 10%.", checkBoxClass8, 5000);
                    break;
                case EnumCharClass.Wizard:
                    tt.ToolTipTitle = "Oracle";
                    tt.Show("Heals all allies for 55/40/30 % of the Wizards Intellect. Percentage is dependant on number of valid targets.", checkBoxClass8, 5000);
                    break;
                case EnumCharClass.Thief:
                    tt.ToolTipTitle = "Flurry";
                    tt.Show("Deals 10% of the Thiefs Attack to the target, 10% of his agility times.", checkBoxClass8, 5000);
                    break;
                case EnumCharClass.Caretaker:
                    tt.ToolTipTitle = "Deathdefiance";
                    tt.Show("Splits the Caretakers health deficit as healing between all allies.", checkBoxClass8, 5000);
                    break;
                case EnumCharClass.Synergist:
                    tt.ToolTipTitle = "Complete Balance";
                    tt.Show("Aligns all allies health to be at the average percentage and heals them for 8% of the Synergists agility and intellect.", checkBoxClass8, 5000);
                    break;
                default:
                    break;
            }
        }
        #endregion

        private void btAutoLevel_Click(object sender, EventArgs e)
        {
            Function.SoundManagerClass.PlayButtonSound();
            int newlevel = character.UnitLevel + 1;

            while (character.UnitLevel != newlevel)
            {
                character.CharRecieveXP(1);
            }

            SetAttributeLabels();
            EnabledUnlockedCheckboxes();
            SetAbilitiesMain();
            SetCheckBoxesFromStart();
        }

        private void btAddToAttribute_Click(object sender, EventArgs e)
        {
            Function.SoundManagerClass.PlayButtonSound();
            if (character.UnUsedAttributePoints.IntValue > 0)
            {
                if (comboBoxAttributes.SelectedItem.ToString().ToLower() == "strength")
                {
                    if (character.BaseStrength.IntValue < character.UnitLevel * 3)
                    {
                        character.UnUsedAttributePoints.IntValue--;
                        character.BaseStrength.IntValue++;
                        character.ResetChar();
                    }
                    else
                    {
                        MessageForm mes = new MessageForm("Your Base Strength is too high to be incremented at this moment!");
                        mes.ShowDialog();
                    }
                }
                else if (comboBoxAttributes.SelectedItem.ToString().ToLower() == "agility")
                {
                    if (character.BaseAgility.IntValue < character.UnitLevel * 3)
                    {
                        character.UnUsedAttributePoints.IntValue--;
                        character.BaseAgility.IntValue++;
                        character.ResetChar();
                    }
                    else
                    {
                        MessageForm mes = new MessageForm("Your Base Agility is too high to be incremented at this moment!");
                        mes.ShowDialog();
                    }

                }
                else if (comboBoxAttributes.SelectedItem.ToString().ToLower() == "intellect")
                {
                    if (character.BaseIntellingence.IntValue < character.UnitLevel * 3)
                    {
                        character.UnUsedAttributePoints.IntValue--;
                        character.BaseIntellingence.IntValue++;
                        character.ResetChar();
                    }
                    else
                    {
                        MessageForm mes = new MessageForm("Your Base Intellect is too high to be incremented at this moment!");
                        mes.ShowDialog();
                    }
                }
                SetAttributeLabels();
            }
            else
            {
                MessageForm mes = new MessageForm("You dont have any unused Attribute Points!");
                mes.ShowDialog();
            }
        }

        private void btResetStats_Click(object sender, EventArgs e)
        {
            Function.SoundManagerClass.PlayButtonSound();
            character.BaseIntellingence.IntValue = 1;
            character.BaseStrength.IntValue = 1;
            character.BaseAgility.IntValue = 1;
            character.UnUsedAttributePoints.IntValue = ((character.UnitLevel-1) * 4);
            SetAttributeLabels();
        }

        #endregion

        
    }
}
