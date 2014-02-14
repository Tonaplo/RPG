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
                checkBoxAll1.Text = Properties.Resources.AbilitiesTitleAnyMeleeAttack;
                checkBoxAll1.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.meleeattack, new Size(20, 20));
            }
            if (checkBoxAll2.Enabled == true)
            {
                checkBoxAll2.Text = Properties.Resources.AbilitiesTitleAnyBattleRegeneration;
                checkBoxAll2.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.meleeattack, new Size(20, 20));
            }
            if (checkBoxAll3.Enabled == true)
            {
                checkBoxAll3.Text = Properties.Resources.AbilitiesTitleAnyEmpowerment;
                checkBoxAll3.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.meleeattack, new Size(20, 20));
            }
            if (checkBoxAll4.Enabled == true)
            {
                checkBoxAll4.Text = Properties.Resources.AbilitiesTitleAnyInvigorate;
                checkBoxAll4.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.meleeattack, new Size(20, 20));
            }
            if (checkBoxAll5.Enabled == true)
            {
                checkBoxAll5.Text = Properties.Resources.AbilitiesTitleAnyDoubleSwing;
                checkBoxAll5.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.meleeattack, new Size(20, 20));
            }
            if (checkBoxAll6.Enabled == true)
            {
                checkBoxAll6.Text = Properties.Resources.AbilitiesTitleAnyOpportunity;
                checkBoxAll6.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.meleeattack, new Size(20, 20));
            }
            if (checkBoxAll7.Enabled == true)
            {
                checkBoxAll7.Text = Properties.Resources.AbilitiesTitleAnyTotalitarism;
                checkBoxAll7.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.meleeattack, new Size(20, 20));
            }
            if (checkBoxAll8.Enabled == true)
            {
                checkBoxAll8.Text = Properties.Resources.AbilitiesTitleAnyAscend;
                checkBoxAll8.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.meleeattack, new Size(20, 20));
            }
        }

        private void SetAbilitiesWarrior()
        {
            if (checkBoxClass1.Enabled == true)
            {
                checkBoxClass1.Text = Properties.Resources.AbilitiesTitleWarriorStrength;
                checkBoxClass1.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.strength, new Size(20, 20));
            }
            if (checkBoxClass2.Enabled == true)
            {
                checkBoxClass2.Text = Properties.Resources.AbilitiesTitleWarriorPowerStrike;
                checkBoxClass2.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.strength, new Size(20, 20));
            }
            if (checkBoxClass3.Enabled == true)
            {
                checkBoxClass3.Text = Properties.Resources.AbilitiesTitleWarriorBlindRage;
                checkBoxClass3.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.strength, new Size(20, 20));
            }
            if (checkBoxClass4.Enabled == true)
            {
                checkBoxClass4.Text = Properties.Resources.AbilitiesTitleWarriorRampage;
                checkBoxClass4.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.strength, new Size(20, 20));
            }
            if (checkBoxClass5.Enabled == true)
            {
                checkBoxClass5.Text = Properties.Resources.AbilitiesTitleWarriorRoar;
                checkBoxClass5.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.strength, new Size(20, 20));
            }
            if (checkBoxClass6.Enabled == true)
            {
                checkBoxClass6.Text = Properties.Resources.AbilitiesTitleWarriorInfuriate;
                checkBoxClass6.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.strength, new Size(20, 20));
            }
            if (checkBoxClass7.Enabled == true)
            {
                checkBoxClass7.Text = Properties.Resources.AbilitiesTitleWarriorExecution;
                checkBoxClass7.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.strength, new Size(20, 20));
            }
            if (checkBoxClass8.Enabled == true)
            {
                checkBoxClass8.Text = Properties.Resources.AbilitiesTitleWarriorInsanity;
                checkBoxClass8.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.strength, new Size(20, 20));
            }
        }

        private void SetAbilitiesWizard()
        {
            if (checkBoxClass1.Enabled == true)
            {
                checkBoxClass1.Text = Properties.Resources.AbilitiesTitleWizardFireball;
                checkBoxClass1.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.fireball, new Size(20, 20));
            }
            if (checkBoxClass2.Enabled == true)
            {
                checkBoxClass2.Text = Properties.Resources.AbilitiesTitleWizardHeal;
                checkBoxClass2.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.heal, new Size(20, 20));
            }
            if (checkBoxClass3.Enabled == true)
            {
                checkBoxClass3.Text = Properties.Resources.AbilitiesTitleWizardFlameComet;
                checkBoxClass3.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.fireball, new Size(20, 20));
            }
            if (checkBoxClass4.Enabled == true)
            {
                checkBoxClass4.Text = Properties.Resources.AbilitiesTitleWizardRevitalize;
                checkBoxClass4.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.heal, new Size(20, 20));
            }
            if (checkBoxClass5.Enabled == true)
            {
                checkBoxClass5.Text = Properties.Resources.AbilitiesTitleWizardBrilliance;
                checkBoxClass5.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.heal, new Size(20, 20));
            }
            if (checkBoxClass6.Enabled == true)
            {
                checkBoxClass6.Text = Properties.Resources.AbilitiesTitleWizardArchon;
                checkBoxClass6.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.heal, new Size(20, 20));
            }
            if (checkBoxClass7.Enabled == true)
            {
                checkBoxClass7.Text = Properties.Resources.AbilitiesTitleWizardInferno;
                checkBoxClass7.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.fireball, new Size(20, 20));
            }
            if (checkBoxClass8.Enabled == true)
            {
                checkBoxClass8.Text = Properties.Resources.AbilitiesTitleWizardOracle;
                checkBoxClass8.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.heal, new Size(20, 20));
            }
        }

        private void SetAbilitiesPaladin()
        {
            if (checkBoxClass1.Enabled == true)
            {
                checkBoxClass1.Text = Properties.Resources.AbilitiesTitlePaladinWrath;
                checkBoxClass1.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.wrath, new Size(20, 20));
            }
            if (checkBoxClass2.Enabled == true)
            {
                checkBoxClass2.Text = Properties.Resources.AbilitiesTitlePaladinJustice;
                checkBoxClass2.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.wrath, new Size(20, 20));
            }
            if (checkBoxClass3.Enabled == true)
            {
                checkBoxClass3.Text = Properties.Resources.AbilitiesTitlePaladinSerenity;
                checkBoxClass3.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.wrath, new Size(20, 20));
            }
            if (checkBoxClass4.Enabled == true)
            {
                checkBoxClass4.Text = Properties.Resources.AbilitiesTitlePaladinRaiseSpirit;
                checkBoxClass4.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.wrath, new Size(20, 20));
            }
            if (checkBoxClass5.Enabled == true)
            {
                checkBoxClass5.Text = Properties.Resources.AbilitiesTitlePaladinPrayer;
                checkBoxClass5.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.wrath, new Size(20, 20));
            }
            if (checkBoxClass6.Enabled == true)
            {
                checkBoxClass6.Text = Properties.Resources.AbilitiesTitlePaladinBlessing;
                checkBoxClass6.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.wrath, new Size(20, 20));
            }
            if (checkBoxClass7.Enabled == true)
            {
                checkBoxClass7.Text = Properties.Resources.AbilitiesTitlePaladinDesperatePlea;
                checkBoxClass7.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.wrath, new Size(20, 20));
            }
            if (checkBoxClass8.Enabled == true)
            {
                checkBoxClass8.Text = Properties.Resources.AbilitiesTitlePaladinThePowerOfFaith;
                checkBoxClass8.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.wrath, new Size(20, 20));
            }
        }

        private void SetAbilitiesThief()
        {
            if (checkBoxClass1.Enabled == true)
            {
                checkBoxClass1.Text = Properties.Resources.AbilitiesTitleThiefQuickAttack;
                checkBoxClass1.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.quickattack, new Size(20, 20));
            }
            if (checkBoxClass2.Enabled == true)
            {
                checkBoxClass2.Text = Properties.Resources.AbilitiesTitleThiefBorrowWeapon;
                checkBoxClass2.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.quickattack, new Size(20, 20));
            }
            if (checkBoxClass3.Enabled == true)
            {
                checkBoxClass3.Text = Properties.Resources.AbilitiesTitleThiefBloodstealer;
                checkBoxClass3.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.quickattack, new Size(20, 20));
            }
            if (checkBoxClass4.Enabled == true)
            {
                checkBoxClass4.Text = Properties.Resources.AbilitiesTitleThiefPoisonedBlade;
                checkBoxClass4.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.quickattack, new Size(20, 20));
            }
            if (checkBoxClass5.Enabled == true)
            {
                checkBoxClass5.Text = Properties.Resources.AbilitiesTitleThiefSwiftness;
                checkBoxClass5.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.quickattack, new Size(20, 20));
            }
            if (checkBoxClass6.Enabled == true)
            {
                checkBoxClass6.Text = Properties.Resources.AbilitiesTitleThiefEnvenom;
                checkBoxClass6.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.quickattack, new Size(20, 20));
            }
            if (checkBoxClass7.Enabled == true)
            {
                checkBoxClass7.Text = Properties.Resources.AbilitiesTitleThiefDirtyTricks;
                checkBoxClass7.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.quickattack, new Size(20, 20));
            }
            if (checkBoxClass8.Enabled == true)
            {
                checkBoxClass8.Text = Properties.Resources.AbilitiesTitleThiefFlurry;
                checkBoxClass8.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.quickattack, new Size(20, 20));
            }
        }

        private void SetAbilitiesCaretaker()
        {
            if (checkBoxClass1.Enabled == true)
            {
                checkBoxClass1.Text = Properties.Resources.AbilitiesTitleCaretakerBodySlam;
                checkBoxClass1.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.bodyslam, new Size(20, 20));
            }
            if (checkBoxClass2.Enabled == true)
            {
                checkBoxClass2.Text = Properties.Resources.AbilitiesTitleCaretakerSacrifice;
                checkBoxClass2.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.bodyslam, new Size(20, 20));
            }
            if (checkBoxClass3.Enabled == true)
            {
                checkBoxClass3.Text = Properties.Resources.AbilitiesTitleCaretakerLifeforce;
                checkBoxClass3.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.bodyslam, new Size(20, 20));
            }
            if (checkBoxClass4.Enabled == true)
            {
                checkBoxClass4.Text = Properties.Resources.AbilitiesTitleCaretakerZealOfHumanity;
                checkBoxClass4.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.bodyslam, new Size(20, 20));
            }
            if (checkBoxClass5.Enabled == true)
            {
                checkBoxClass5.Text = Properties.Resources.AbilitiesTitleCaretakerAction;
                checkBoxClass5.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.bodyslam, new Size(20, 20));
            }
            if (checkBoxClass6.Enabled == true)
            {
                checkBoxClass6.Text = Properties.Resources.AbilitiesTitleCaretakerLifeblood;
                checkBoxClass6.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.bodyslam, new Size(20, 20));
            }
            if (checkBoxClass7.Enabled == true)
            {
                checkBoxClass7.Text = Properties.Resources.AbilitiesTitleCaretakerPowerAndDexterity;
                checkBoxClass7.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.bodyslam, new Size(20, 20));
            }
            if (checkBoxClass8.Enabled == true)
            {
                checkBoxClass8.Text = Properties.Resources.AbilitiesTitleCaretakerDeathdefiance;
                checkBoxClass8.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.bodyslam, new Size(20, 20));
            }
        }

        private void SetAbilitiesSynergist()
        {
            if (checkBoxClass1.Enabled == true)
            {
                checkBoxClass1.Text = Properties.Resources.AbilitiesTitleSynergistDuality;
                checkBoxClass1.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.duality, new Size(20, 20));
            }
            if (checkBoxClass2.Enabled == true)
            {
                checkBoxClass2.Text = Properties.Resources.AbilitiesTitleSynergistAgileMind;
                checkBoxClass2.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.duality, new Size(20, 20));
            }
            if (checkBoxClass3.Enabled == true)
            {
                checkBoxClass3.Text = Properties.Resources.AbilitiesTitleSynergistBalance;
                checkBoxClass3.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.duality, new Size(20, 20));
            }
            if (checkBoxClass4.Enabled == true)
            {
                checkBoxClass4.Text = Properties.Resources.AbilitiesTitleSynergistMentalAgility;
                checkBoxClass4.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.duality, new Size(20, 20));
            }
            if (checkBoxClass5.Enabled == true)
            {
                checkBoxClass5.Text = Properties.Resources.AbilitiesTitleSynergistAlign;
                checkBoxClass5.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.duality, new Size(20, 20));
            }
            if (checkBoxClass6.Enabled == true)
            {
                checkBoxClass6.Text = Properties.Resources.AbilitiesTitleSynergistCollapsedEquality;
                checkBoxClass6.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.duality, new Size(20, 20));
            }
            if (checkBoxClass7.Enabled == true)
            {
                checkBoxClass7.Text = Properties.Resources.AbilitiesTitleSynergistSynergy;
                checkBoxClass7.Image = Function.GeneralFunctions.ResizeImage(Properties.Resources.duality, new Size(20, 20));
            }
            if (checkBoxClass8.Enabled == true)
            {
                checkBoxClass8.Text = Properties.Resources.AbilitiesTitleSynergistCompleteBalance;
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
            tt.ToolTipTitle = Properties.Resources.AbilitiesTitleAnyMeleeAttack;
            tt.Show(Properties.Resources.AbilitiesDescriptionAnyMeleeAttack, checkBoxAll1, 5000);
        }

        private void checkBoxAll2_MouseHover(object sender, EventArgs e)
        {
                tt.ToolTipTitle = Properties.Resources.AbilitiesTitleAnyBattleRegeneration;
                tt.Show(Properties.Resources.AbilitiesDescriptionAnyBattleRegeneration, checkBoxAll2, 5000);
        }

        private void checkBoxAll3_MouseHover(object sender, EventArgs e)
        {
                tt.ToolTipTitle = Properties.Resources.AbilitiesTitleAnyEmpowerment;
                tt.Show(Properties.Resources.AbilitiesDescriptionAnyEmpowerment, checkBoxAll3, 5000);
        }

        private void checkBoxAll4_MouseHover(object sender, EventArgs e)
        {
                tt.ToolTipTitle = Properties.Resources.AbilitiesTitleAnyInvigorate;
                tt.Show(Properties.Resources.AbilitiesDescriptionAnyInvigorate, checkBoxAll4, 5000);
        }

        private void checkBoxAll5_MouseHover(object sender, EventArgs e)
        {
                tt.ToolTipTitle = Properties.Resources.AbilitiesTitleAnyDoubleSwing;
                tt.Show(Properties.Resources.AbilitiesDescriptionAnyDoubleSwing, checkBoxAll5, 5000);
        }

        private void checkBoxAll6_MouseHover(object sender, EventArgs e)
        {
                tt.ToolTipTitle = Properties.Resources.AbilitiesTitleAnyOpportunity;
                tt.Show(Properties.Resources.AbilitiesDescriptionAnyOpportunity, checkBoxAll6, 5000);
        }

        private void checkBoxAll7_MouseHover(object sender, EventArgs e)
        {
                tt.ToolTipTitle = Properties.Resources.AbilitiesTitleAnyTotalitarism;
                tt.Show(Properties.Resources.AbilitiesDescriptionAnyTotalitarism, checkBoxAll7, 5000);
        }

        private void checkBoxAll8_MouseHover(object sender, EventArgs e)
        {
                tt.ToolTipTitle = Properties.Resources.AbilitiesTitleAnyAscend;
                tt.Show(Properties.Resources.AbilitiesDescriptionAnyAscend, checkBoxAll8, 5000);
        }

        #endregion

        #region Classes checkbox events

        private void checkBoxClass1_MouseHover(object sender, EventArgs e)
        {
            switch (character.CharClass)
            {
                case EnumCharClass.Warrior:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleWarriorStrength;
                    tt.Show(Properties.Resources.AbilitiesDescriptionWarriorStrength, checkBoxClass1, 5000);
                    break;
                case EnumCharClass.Paladin:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitlePaladinWrath;
                    tt.Show(Properties.Resources.AbilitiesDescriptionPaladinWrath, checkBoxClass1, 5000);
                    break;
                case EnumCharClass.Wizard:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleWizardFireball;
                    tt.Show(Properties.Resources.AbilitiesDescriptionWizardFireball, checkBoxClass1, 5000);
                    break;
                case EnumCharClass.Thief:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleThiefQuickAttack;
                    tt.Show(Properties.Resources.AbilitiesDescriptionThiefQuickAttack, checkBoxClass1, 5000);
                    break;
                case EnumCharClass.Caretaker:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleCaretakerBodySlam;
                    tt.Show(Properties.Resources.AbilitiesDescriptionCaretakerBodySlam, checkBoxClass1, 5000);
                    break;
                case EnumCharClass.Synergist:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleSynergistDuality;
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
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleWarriorPowerStrike;
                    tt.Show(Properties.Resources.AbilitiesDescriptionWarriorPowerStrike, checkBoxClass2, 5000);
                    break;
                case EnumCharClass.Paladin:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitlePaladinJustice;
                    tt.Show(Properties.Resources.AbilitiesDescriptionPaladinJustice, checkBoxClass2, 5000);
                    break;
                case EnumCharClass.Wizard:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleWizardHeal;
                    tt.Show(Properties.Resources.AbilitiesDescriptionWizardHeal, checkBoxClass2, 5000);
                    break;
                case EnumCharClass.Thief:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleThiefBorrowWeapon;
                    tt.Show(Properties.Resources.AbilitiesDescriptionThiefBorrowWeapon, checkBoxClass2, 5000);
                    break;
                case EnumCharClass.Caretaker:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleCaretakerSacrifice;
                    tt.Show(Properties.Resources.AbilitiesDescriptionCaretakerSacrifice, checkBoxClass2, 5000);
                    break;
                case EnumCharClass.Synergist:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleSynergistAgileMind;
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
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleWarriorBlindRage;
                    tt.Show(Properties.Resources.AbilitiesDescriptionWarriorBlindRage, checkBoxClass3, 5000);
                    break;
                case EnumCharClass.Paladin:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitlePaladinSerenity;
                    tt.Show(Properties.Resources.AbilitiesDescriptionPaladinSerenity, checkBoxClass3, 5000);
                    break;
                case EnumCharClass.Wizard:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleWizardFlameComet;
                    tt.Show(Properties.Resources.AbilitiesDescriptionWizardFlameComet, checkBoxClass3, 5000);
                    break;
                case EnumCharClass.Thief:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleThiefBloodstealer;
                    tt.Show(Properties.Resources.AbilitiesDescriptionThiefBloodstealer, checkBoxClass3, 5000);
                    break;
                case EnumCharClass.Caretaker:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleCaretakerLifeforce;
                    tt.Show(Properties.Resources.AbilitiesDescriptionCaretakerLifeforce, checkBoxClass3, 5000);
                    break;
                case EnumCharClass.Synergist:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleSynergistBalance;
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
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleWarriorRampage;
                    tt.Show(Properties.Resources.AbilitiesDescriptionWarriorRampage, checkBoxClass4, 5000);
                    break;
                case EnumCharClass.Paladin:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitlePaladinRaiseSpirit;
                    tt.Show(Properties.Resources.AbilitiesDescriptionPaladinRaiseSpirit, checkBoxClass4, 5000);
                    break;
                case EnumCharClass.Wizard:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleWizardRevitalize;
                    tt.Show(Properties.Resources.AbilitiesDescriptionWizardRevitalize, checkBoxClass4, 5000);
                    break;
                case EnumCharClass.Thief:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleThiefPoisonedBlade;
                    tt.Show(Properties.Resources.AbilitiesDescriptionThiefPoisonedBlade, checkBoxClass4, 5000);
                    break;
                case EnumCharClass.Caretaker:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleCaretakerZealOfHumanity;
                    tt.Show(Properties.Resources.AbilitiesDescriptionCaretakerZealOfHumanity, checkBoxClass4, 5000);
                    break;
                case EnumCharClass.Synergist:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleSynergistMentalAgility;
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
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleWarriorRoar;
                    tt.Show(Properties.Resources.AbilitiesDescriptionWarriorRoar, checkBoxClass5, 5000);
                    break;
                case EnumCharClass.Paladin:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitlePaladinPrayer;
                    tt.Show(Properties.Resources.AbilitiesDescriptionPaladinPrayer, checkBoxClass5, 5000);
                    break;
                case EnumCharClass.Wizard:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleWizardBrilliance;
                    tt.Show(Properties.Resources.AbilitiesDescriptionWizardBrilliance, checkBoxClass5, 5000);
                    break;
                case EnumCharClass.Thief:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleThiefSwiftness;
                    tt.Show(Properties.Resources.AbilitiesDescriptionThiefSwiftness, checkBoxClass5, 5000);
                    break;
                case EnumCharClass.Caretaker:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleCaretakerAction;
                    tt.Show(Properties.Resources.AbilitiesDescriptionCaretakerAction, checkBoxClass5, 5000);
                    break;
                case EnumCharClass.Synergist:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleSynergistAlign;
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
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleWarriorInfuriate;
                    tt.Show(Properties.Resources.AbilitiesDescriptionWarriorInfuriate, checkBoxClass6, 5000);
                    break;
                case EnumCharClass.Paladin:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitlePaladinBlessing;
                    tt.Show(Properties.Resources.AbilitiesDescriptionPaladinBlessing, checkBoxClass6, 5000);
                    break;
                case EnumCharClass.Wizard:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleWizardArchon;
                    tt.Show(Properties.Resources.AbilitiesDescriptionWizardArchon, checkBoxClass6, 5000);
                    break;
                case EnumCharClass.Thief:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleThiefEnvenom;
                    tt.Show(Properties.Resources.AbilitiesDescriptionThiefEnvenom, checkBoxClass6, 5000);
                    break;
                case EnumCharClass.Caretaker:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleCaretakerLifeblood;
                    tt.Show(Properties.Resources.AbilitiesDescriptionCaretakerLifeblood, checkBoxClass6, 5000);
                    break;
                case EnumCharClass.Synergist:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleSynergistCollapsedEquality;
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
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleWarriorExecution;
                    tt.Show(Properties.Resources.AbilitiesDescriptionWarriorExecution, checkBoxClass7, 5000);
                    break;
                case EnumCharClass.Paladin:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitlePaladinDesperatePlea;
                    tt.Show(Properties.Resources.AbilitiesDescriptionPaladinDesperatePlea, checkBoxClass7, 5000);
                    break;
                case EnumCharClass.Wizard:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleWizardInferno;
                    tt.Show(Properties.Resources.AbilitiesDescriptionWizardInferno, checkBoxClass7, 5000);
                    break;
                case EnumCharClass.Thief:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleThiefDirtyTricks;
                    tt.Show(Properties.Resources.AbilitiesDescriptionThiefDirtyTricks, checkBoxClass7, 5000);
                    break;
                case EnumCharClass.Caretaker:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleCaretakerPowerAndDexterity;
                    tt.Show(Properties.Resources.AbilitiesDescriptionCaretakerPowerAndDexterity, checkBoxClass7, 5000);
                    break;
                case EnumCharClass.Synergist:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleSynergistSynergy;
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
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleWarriorInsanity;
                    tt.Show(Properties.Resources.AbilitiesDescriptionWarriorInsanity, checkBoxClass8, 5000);
                    break;
                case EnumCharClass.Paladin:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitlePaladinThePowerOfFaith;
                    tt.Show(Properties.Resources.AbilitiesDescriptionPaladinThePowerOfFaith, checkBoxClass8, 5000);
                    break;
                case EnumCharClass.Wizard:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleWizardOracle;
                    tt.Show(Properties.Resources.AbilitiesDescriptionWizardOracle, checkBoxClass8, 5000);
                    break;
                case EnumCharClass.Thief:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleThiefFlurry;
                    tt.Show(Properties.Resources.AbilitiesDescriptionThiefFlurry, checkBoxClass8, 5000);
                    break;
                case EnumCharClass.Caretaker:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleCaretakerDeathdefiance;
                    tt.Show(Properties.Resources.AbilitiesDescriptionCaretakerDeathdefiance, checkBoxClass8, 5000);
                    break;
                case EnumCharClass.Synergist:
                    tt.ToolTipTitle = Properties.Resources.AbilitiesTitleSynergistCompleteBalance;
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
