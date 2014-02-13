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
            Function.SoundManager.PlayButtonSound();
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
            tt.Show(Properties.Resources.AbilitiesDescriptionAnyMeleeAttack, checkBoxAll1, 5000);
        }

        private void checkBoxAll2_MouseHover(object sender, EventArgs e)
        {
                tt.ToolTipTitle = "Battle Regeneration";
                tt.Show(Properties.Resources.AbilitiesDescriptionAnyBattleRegeneration, checkBoxAll2, 5000);
        }

        private void checkBoxAll3_MouseHover(object sender, EventArgs e)
        {
                tt.ToolTipTitle = "Empowerment";
                tt.Show(Properties.Resources.AbilitiesDescriptionAnyEmpowerment, checkBoxAll3, 5000);
        }

        private void checkBoxAll4_MouseHover(object sender, EventArgs e)
        {
                tt.ToolTipTitle = "Invigorate";
                tt.Show(Properties.Resources.AbilitiesDescriptionAnyInvigorate, checkBoxAll4, 5000);
        }

        private void checkBoxAll5_MouseHover(object sender, EventArgs e)
        {
                tt.ToolTipTitle = "Double Swing";
                tt.Show(Properties.Resources.AbilitiesDescriptionAnyDoubleSwing, checkBoxAll5, 5000);
        }

        private void checkBoxAll6_MouseHover(object sender, EventArgs e)
        {
                tt.ToolTipTitle = "Opportunity";
                tt.Show(Properties.Resources.AbilitiesDescriptionAnyOpportunity, checkBoxAll6, 5000);
        }

        private void checkBoxAll7_MouseHover(object sender, EventArgs e)
        {
                tt.ToolTipTitle = "Totalitarism";
                tt.Show(Properties.Resources.AbilitiesDescriptionAnyTotalitarism, checkBoxAll7, 5000);
        }

        private void checkBoxAll8_MouseHover(object sender, EventArgs e)
        {
                tt.ToolTipTitle = "Ascend";
                tt.Show(Properties.Resources.AbilitiesDescriptionAnyAscend, checkBoxAll8, 5000);
        }

        #endregion

        #region Classes checkbox events

        private void checkBoxClass1_MouseHover(object sender, EventArgs e)
        {
            switch (character.CharClass)
            {
                case EnumCharClass.Warrior:
                    tt.ToolTipTitle = "Strength";
                    tt.Show(Properties.Resources.AbilitiesDescriptionWarriorStrength, checkBoxClass1, 5000);
                    break;
                case EnumCharClass.Paladin:
                    tt.ToolTipTitle = "Wrath";
                    tt.Show(Properties.Resources.AbilitiesDescriptionPaladinWrath, checkBoxClass1, 5000);
                    break;
                case EnumCharClass.Wizard:
                    tt.ToolTipTitle = "Fireball";
                    tt.Show(Properties.Resources.AbilitiesDescriptionWizardFireball, checkBoxClass1, 5000);
                    break;
                case EnumCharClass.Thief:
                    tt.ToolTipTitle = "Quick Attack";
                    tt.Show(Properties.Resources.AbilitiesDescriptionThiefQuickAttack, checkBoxClass1, 5000);
                    break;
                case EnumCharClass.Caretaker:
                    tt.ToolTipTitle = "Body Slam";
                    tt.Show(Properties.Resources.AbilitiesDescriptionCaretakerBodySlam, checkBoxClass1, 5000);
                    break;
                case EnumCharClass.Synergist:
                    tt.ToolTipTitle = "Duality";
                    tt.Show(Properties.Resources.AbilitiesDescriptionSynergistDuality, checkBoxClass1, 5000);
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
                    tt.Show(Properties.Resources.AbilitiesDescriptionWarriorPowerStrike, checkBoxClass2, 5000);
                    break;
                case EnumCharClass.Paladin:
                    tt.ToolTipTitle = "Justice";
                    tt.Show(Properties.Resources.AbilitiesDescriptionPaladinJustice, checkBoxClass2, 5000);
                    break;
                case EnumCharClass.Wizard:
                    tt.ToolTipTitle = "Heal";
                    tt.Show(Properties.Resources.AbilitiesDescriptionWizardHeal, checkBoxClass2, 5000);
                    break;
                case EnumCharClass.Thief:
                    tt.ToolTipTitle = "Borrow Weapon";
                    tt.Show(Properties.Resources.AbilitiesDescriptionThiefBorrowWeapon, checkBoxClass2, 5000);
                    break;
                case EnumCharClass.Caretaker:
                    tt.ToolTipTitle = "Sacrifice";
                    tt.Show(Properties.Resources.AbilitiesDescriptionCaretakerSacrifice, checkBoxClass2, 5000);
                    break;
                case EnumCharClass.Synergist:
                    tt.ToolTipTitle = "Agile Mind";
                    tt.Show(Properties.Resources.AbilitiesDescriptionSynergistAgileMind, checkBoxClass2, 5000);
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
                    tt.Show(Properties.Resources.AbilitiesDescriptionWarriorBlindRage, checkBoxClass3, 5000);
                    break;
                case EnumCharClass.Paladin:
                    tt.ToolTipTitle = "Serenity";
                    tt.Show(Properties.Resources.AbilitiesDescriptionPaladinSerenity, checkBoxClass3, 5000);
                    break;
                case EnumCharClass.Wizard:
                    tt.ToolTipTitle = "Flame Comet";
                    tt.Show(Properties.Resources.AbilitiesDescriptionWizardFlameComet, checkBoxClass3, 5000);
                    break;
                case EnumCharClass.Thief:
                    tt.ToolTipTitle = "Bloodstealer";
                    tt.Show(Properties.Resources.AbilitiesDescriptionThiefBloodStealer, checkBoxClass3, 5000);
                    break;
                case EnumCharClass.Caretaker:
                    tt.ToolTipTitle = "Lifeforce";
                    tt.Show(Properties.Resources.AbilitiesDescriptionCaretakerLifeForce, checkBoxClass3, 5000);
                    break;
                case EnumCharClass.Synergist:
                    tt.ToolTipTitle = "Balance";
                    tt.Show(Properties.Resources.AbilitiesDescriptionSynergistBalance, checkBoxClass3, 5000);
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
                    tt.Show(Properties.Resources.AbilitiesDescriptionWarriorRampage, checkBoxClass4, 5000);
                    break;
                case EnumCharClass.Paladin:
                    tt.ToolTipTitle = "Raise Spirit";
                    tt.Show(Properties.Resources.AbilitiesDescriptionPaladinRaiseSpirit, checkBoxClass4, 5000);
                    break;
                case EnumCharClass.Wizard:
                    tt.ToolTipTitle = "Revitalize";
                    tt.Show(Properties.Resources.AbilitiesDescriptionWizardRevitalize, checkBoxClass4, 5000);
                    break;
                case EnumCharClass.Thief:
                    tt.ToolTipTitle = "Copycat";
                    tt.Show(Properties.Resources.AbilitiesDescriptionThiefCopyCat, checkBoxClass4, 5000);
                    break;
                case EnumCharClass.Caretaker:
                    tt.ToolTipTitle = "Zeal of Humanity";
                    tt.Show(Properties.Resources.AbilitiesDescriptionCaretakerZealOfHumanity, checkBoxClass4, 5000);
                    break;
                case EnumCharClass.Synergist:
                    tt.ToolTipTitle = "Mental Agility";
                    tt.Show(Properties.Resources.AbilitiesDescriptionSynergistMentalAgility, checkBoxClass4, 5000);
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
                    tt.Show(Properties.Resources.AbilitiesDescriptionWarriorRoar, checkBoxClass5, 5000);
                    break;
                case EnumCharClass.Paladin:
                    tt.ToolTipTitle = "Prayer";
                    tt.Show(Properties.Resources.AbilitiesDescriptionPaladinPrayer, checkBoxClass5, 5000);
                    break;
                case EnumCharClass.Wizard:
                    tt.ToolTipTitle = "Brilliance";
                    tt.Show(Properties.Resources.AbilitiesDescriptionWizardBrilliance, checkBoxClass5, 5000);
                    break;
                case EnumCharClass.Thief:
                    tt.ToolTipTitle = "Swiftness";
                    tt.Show(Properties.Resources.AbilitiesDescriptionThiefSwiftness, checkBoxClass5, 5000);
                    break;
                case EnumCharClass.Caretaker:
                    tt.ToolTipTitle = "Action";
                    tt.Show(Properties.Resources.AbilitiesDescriptionCaretakerAction, checkBoxClass5, 5000);
                    break;
                case EnumCharClass.Synergist:
                    tt.ToolTipTitle = "Align";
                    tt.Show(Properties.Resources.AbilitiesDescriptionSynergistAlign, checkBoxClass5, 5000);
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
                    tt.Show(Properties.Resources.AbilitiesDescriptionWarriorInfuriate, checkBoxClass6, 5000);
                    break;
                case EnumCharClass.Paladin:
                    tt.ToolTipTitle = "Blessing";
                    tt.Show(Properties.Resources.AbilitiesDescriptionPaladinBlessing, checkBoxClass6, 5000);
                    break;
                case EnumCharClass.Wizard:
                    tt.ToolTipTitle = "Archon";
                    tt.Show(Properties.Resources.AbilitiesDescriptionWizardArchon, checkBoxClass6, 5000);
                    break;
                case EnumCharClass.Thief:
                    tt.ToolTipTitle = "Envenom";
                    tt.Show(Properties.Resources.AbilitiesDescriptionThiefEnvenom, checkBoxClass6, 5000);
                    break;
                case EnumCharClass.Caretaker:
                    tt.ToolTipTitle = "Lifeblood";
                    tt.Show(Properties.Resources.AbilitiesDescriptionCaretakerLifeblood, checkBoxClass6, 5000);
                    break;
                case EnumCharClass.Synergist:
                    tt.ToolTipTitle = "Collapsed Equality";
                    tt.Show(Properties.Resources.AbilitiesDescriptionSynergistCollapsedEquality, checkBoxClass6, 5000);
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
                    tt.Show(Properties.Resources.AbilitiesDescriptionWarriorExecution, checkBoxClass7, 5000);
                    break;
                case EnumCharClass.Paladin:
                    tt.ToolTipTitle = "Desperate Plea";
                    tt.Show(Properties.Resources.AbilitiesDescriptionPaladinDesperatePlea, checkBoxClass7, 5000);
                    break;
                case EnumCharClass.Wizard:
                    tt.ToolTipTitle = "Inferno";
                    tt.Show(Properties.Resources.AbilitiesDescriptionWizardInferno, checkBoxClass7, 5000);
                    break;
                case EnumCharClass.Thief:
                    tt.ToolTipTitle = "Dirty Tricks";
                    tt.Show(Properties.Resources.AbilitiesDescriptionThiefDirtyTricks, checkBoxClass7, 5000);
                    break;
                case EnumCharClass.Caretaker:
                    tt.ToolTipTitle = "Power and Dexterity";
                    tt.Show(Properties.Resources.AbilitiesDescriptionCaretakerPowerAndDexterity, checkBoxClass7, 5000);
                    break;
                case EnumCharClass.Synergist:
                    tt.ToolTipTitle = "Synergy";
                    tt.Show(Properties.Resources.AbilitiesDescriptionSynergistSynergy, checkBoxClass7, 5000);
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
                    tt.Show(Properties.Resources.AbilitiesDescriptionWarriorInsanity, checkBoxClass8, 5000);
                    break;
                case EnumCharClass.Paladin:
                    tt.ToolTipTitle = "The Power of Faith";
                    tt.Show(Properties.Resources.AbilitiesDescriptionPaladinThePowerOfFaith, checkBoxClass8, 5000);
                    break;
                case EnumCharClass.Wizard:
                    tt.ToolTipTitle = "Oracle";
                    tt.Show(Properties.Resources.AbilitiesDescriptionWizardOracle, checkBoxClass8, 5000);
                    break;
                case EnumCharClass.Thief:
                    tt.ToolTipTitle = "Flurry";
                    tt.Show(Properties.Resources.AbilitiesDescriptionThiefFlurry, checkBoxClass8, 5000);
                    break;
                case EnumCharClass.Caretaker:
                    tt.ToolTipTitle = "Deathdefiance";
                    tt.Show(Properties.Resources.AbilitiesDescriptionCaretakerDeathdefiance, checkBoxClass8, 5000);
                    break;
                case EnumCharClass.Synergist:
                    tt.ToolTipTitle = "Complete Balance";
                    tt.Show(Properties.Resources.AbilitiesDescriptionSynergistCompleteBalance, checkBoxClass8, 5000);
                    break;
                default:
                    break;
            }
        }
        #endregion

        private void btAutoLevel_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
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
            Function.SoundManager.PlayButtonSound();
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
            Function.SoundManager.PlayButtonSound();
            character.BaseIntellingence.IntValue = 1;
            character.BaseStrength.IntValue = 1;
            character.BaseAgility.IntValue = 1;
            character.UnUsedAttributePoints.IntValue = ((character.UnitLevel-1) * 4);
            character.ResetChar();
            SetAttributeLabels();
        }

        #endregion

        
    }
}
