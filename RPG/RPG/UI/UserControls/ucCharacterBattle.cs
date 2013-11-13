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
using RPG.Core;

namespace RPG.UI.UserControls
{
    public partial class ucCharacterBattle : UserControl
    {
        Core.Units.Character character;
        Core.Abilities.ActiveAbility selectedAbility;

        public ucCharacterBattle(Core.Units.Character _character, int _numberOfCharacters)
        {
            InitializeComponent();
            this.BackColor = Color.Transparent;
            character = _character;

            labelHealthRemaining.Width = flpHealthBar.Width;
            labelHealthRemaining.Text = character.CurrentHP.IntValue + "/" + character.BuffedHP.IntValue + " (100%)";

            lbTurnpoints.Text = character.CurrentTurnPoints.IntValue.ToString() + " Turnpoints left";

            lbCharStats.Text = Function.GeneralFunctions.ReturnCharBattleString(this.character);

            pictureBoxChar.Image = Function.GeneralFunctions.ReturnImageForClass(character);

            if (_numberOfCharacters < 4)
                checkBoxPlayer4.Visible = false;
            if (_numberOfCharacters < 3)
                checkBoxPlayer3.Visible = false;
            if (_numberOfCharacters < 2)
                checkBoxPlayer2.Visible = false;

            foreach (var item in character.UnitActiveAbilities)
	        {
                comboBoxAbilities.Items.Add(item.AbilityName);
	        }
            selectedAbility = character.UnitActiveAbilities.First();
            comboBoxAbilities.SelectedIndex = 0;
            labelAbilityDescription.Text = selectedAbility.Description;

            if (selectedAbility.DamageOrHealing == EnumActiveAbilityType.Damage)
                checkBoxEnemy.Checked = true;
            else
                checkBoxPlayer1.Checked = false;
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

        private void ucCharacterBattle_Load(object sender, EventArgs e)
        {
            LoadFont();
            foreach (var item in this.Controls)
            {
                AllocFont(font, (item as Control), (item as Control).Font.Size);
            }

            this.Font = new Font("Arial", 7.15f);
            
        }

        #endregion

        #region public functions
        public event EventHandler AttackClicked;

        public Core.Abilities.ActiveAbility ChoosenAbility()
        {
            return selectedAbility;
        }

        public Core.Units.Character Character()
        {
            return character;
        }

        public bool CheckBoxP1Status
        {
            get { return checkBoxPlayer1.Checked; }
        }

        public bool CheckBoxP2Status
        {
            get { return checkBoxPlayer2.Checked; }
        }

        public bool CheckBoxP3Status
        {
            get { return checkBoxPlayer3.Checked; }
        }

        public bool CheckBoxP4Status
        {
            get { return checkBoxPlayer4.Checked; }
        }

        public bool CheckBoxEnemyStatus
        {
            get { return checkBoxEnemy.Checked; }
        }

        public void Update()
        {
            int width = (int)(flpHealthBar.Width * ((double)character.CurrentHP.IntValue / (double)character.BuffedHP.IntValue));
            int percentHP = (int) (((double)character.CurrentHP.IntValue / (double)character.BuffedHP.IntValue) * 100);

            if (percentHP > 50)
            {
                flpHealthBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
                labelHealthRemaining.BackColor = Color.DarkGreen;
                flpHealthBar.BackColor = Color.DarkRed;

                labelHealthRemaining.Width = width;

                labelHealthRemaining.Text = character.CurrentHP.IntValue + "/" + character.BuffedHP.IntValue + " (" + percentHP + "%)";
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

                if (character.CurrentHP.IntValue > 0)
                    labelHealthRemaining.Text = character.CurrentHP.IntValue + "/" + character.BuffedHP.IntValue + " (" + percentHP + "%)";
                else
                {
                    labelHealthRemaining.Width = flpHealthBar.Width;
                    labelHealthRemaining.BackColor = Color.DarkRed;
                    labelHealthRemaining.ForeColor = Color.White;
                    labelHealthRemaining.Text = "DEAD";
                }
            }

            lbTurnpoints.Text = character.CurrentTurnPoints.IntValue.ToString() + " Turnpoints left";

            lbCharStats.Text = Function.GeneralFunctions.ReturnCharBattleString(this.character);

            if (flpBuffsAndDebuffs.Controls.Count != character.UnitBuffsAndDebuffs.Count)
            {
                flpBuffsAndDebuffs.Controls.Clear();
                foreach (var item in character.UnitBuffsAndDebuffs)
                {
                    flpBuffsAndDebuffs.Controls.Add(new ucAbilityIcon(item));
                }
            }
        }

        #endregion


        private void comboBoxAbilities_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedAbility = character.UnitActiveAbilities[comboBoxAbilities.SelectedIndex];
            labelAbilityDescription.Text = selectedAbility.Description;

            foreach (var item in groupBoxTargets.Controls)
            {
                (item as CheckBox).Checked = false;
            }

            if (selectedAbility.DamageOrHealing == EnumActiveAbilityType.Damage)
                checkBoxEnemy.Checked = true;
        }

        #region Checkbox functions
        private void checkBoxPlayer1_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked == true)
            {
                if (selectedAbility.DamageOrHealing == EnumActiveAbilityType.Damage)
                {
                    RPG.UI.MessageForm mes = new RPG.UI.MessageForm("This ability deals damage! Select the enemy!");
                    mes.ShowDialog();
                    (sender as CheckBox).Checked = false;
                }
                else
                {
                    checkBoxEnemy.Checked = false;
                }
            }
            
        }

        private void checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked == true)
            {
                if (selectedAbility.DamageOrHealing == EnumActiveAbilityType.Damage)
                {
                    RPG.UI.MessageForm mes = new RPG.UI.MessageForm("This ability deals damage! Select the enemy!");
                    mes.ShowDialog();
                    (sender as CheckBox).Checked = false;
                }
                else
                {
                    checkBoxEnemy.Checked = false;
                }
            }
            
        }

        private void checkBoxPlayer3_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked == true)
            {
                if (selectedAbility.DamageOrHealing == EnumActiveAbilityType.Damage)
                {
                    RPG.UI.MessageForm mes = new RPG.UI.MessageForm("This ability deals damage! Select the enemy!");
                    mes.ShowDialog();
                    (sender as CheckBox).Checked = false;
                }
                else
                {
                    checkBoxEnemy.Checked = false;
                }
            }
            
        }

        private void checkBoxPlayer4_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked == true)
            {
                if (selectedAbility.DamageOrHealing == EnumActiveAbilityType.Damage)
                {
                    RPG.UI.MessageForm mes = new RPG.UI.MessageForm("This ability deals damage! Select the enemy!");
                    mes.ShowDialog();
                    (sender as CheckBox).Checked = false;
                }
                else
                {
                    checkBoxEnemy.Checked = false;
                }
            }
            
        }

        private void checkBoxEnemy_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked == true)
            {
                if (selectedAbility.DamageOrHealing == EnumActiveAbilityType.Healing)
                {
                    RPG.UI.MessageForm mes = new RPG.UI.MessageForm("This ability is beneficial! Select an ally!");
                    mes.ShowDialog();
                    (sender as CheckBox).Checked = false;
                }
                else
                {
                    int some = groupBoxTargets.Controls.Count;
                    foreach (var item in groupBoxTargets.Controls)
                    {
                        if ((item as CheckBox).Checked == true && !(item.Equals(sender)))
                        {
                            (item as CheckBox).Checked = false;
                        }
                    }
                    (sender as CheckBox).Checked = true;
                }
            }
            
        }
        #endregion

        private void btAttack_Click(object sender, EventArgs e)
        {
            if (checkBoxPlayer1.Checked == false
                    && checkBoxPlayer2.Checked == false
                    && checkBoxPlayer3.Checked == false
                    && checkBoxPlayer4.Checked == false
                    && checkBoxEnemy.Checked == false)
            {
                MessageForm mes = new MessageForm("You havent choosen any targets!");
                mes.ShowDialog();
            }
            else
            {
                if (character.CurrentTurnPoints.IntValue >= selectedAbility.TurnPointCost)
                {
                    if (checkBoxEnemy.Checked == true & selectedAbility.DamageOrHealing == EnumActiveAbilityType.Damage)
                    {
                        character.CurrentTurnPoints.IntValue -= selectedAbility.TurnPointCost;
                        if (AttackClicked != null)
                            AttackClicked(this, EventArgs.Empty);

                        lbTurnpoints.Text = character.CurrentTurnPoints.IntValue.ToString() + " Turnpoints left";
                    }
                    else if ((checkBoxPlayer1.Checked == true
                        || checkBoxPlayer2.Checked == true
                        || checkBoxPlayer3.Checked == true
                        || checkBoxPlayer4.Checked == true)
                        & selectedAbility.DamageOrHealing == EnumActiveAbilityType.Healing
                        )
                    {
                        character.CurrentTurnPoints.IntValue -= selectedAbility.TurnPointCost;
                        if (AttackClicked != null)
                            AttackClicked(this, EventArgs.Empty);

                        lbTurnpoints.Text = character.CurrentTurnPoints.IntValue.ToString() + " Turnpoints left";
                    }
                }
                else
                {
                    RPG.UI.MessageForm mes = new RPG.UI.MessageForm("You dont have enough turnpoints!");
                    mes.ShowDialog();
                }
            }
        }
    }
}
