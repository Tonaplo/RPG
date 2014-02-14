using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RPG;
using RPG.Function;
using RPG.UI.UserControls;
using RPG.Core.Units;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using RPG.Core;


namespace RPG.UI
{
    public partial class BattleForm : Form
    {
        #region Fields
        bool end = false;
        List<Core.Units.Character> battleChars;
        Core.Units.NPC enemy;
        Function.NPCAI ai;
        Random r = new Random();
        int numberOfPlayers = 0;
        DialogResult result;
        int healingDone;
        int damageDone;
        #endregion

        /// <summary>
        /// Constructor for the Battle Form. Only supports Singleplayer combat atm
        /// </summary>
        /// <param name="_listOfChars"></param>
        /// <param name="_difficulty"></param>
        public BattleForm(List<Core.Units.Character> _listOfChars, int _difficulty)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackgroundImage = GeneralFunctions.ResizeImage(Properties.Resources.background, labelBackgroundIGNORE.Size);
            Function.SoundManager.PlayBattleMusic();

            numberOfPlayers = _listOfChars.Count;

            battleChars = _listOfChars;

            int sum = 0;

            foreach (var item in battleChars)
            {
                sum += item.UnitLevel;
            }

            int average = (int)(sum / battleChars.Count);

            enemy = WorldGeneration.GenerateNPC(null, average, _difficulty, EnumMonsterType.Null, battleChars.Count);
            ai = WorldGeneration.GenerateNPCAI(enemy,  battleChars);
            enemy = ai.ModifiedNPC;

            foreach (var item in battleChars)
            {
                ucCharacterBattle ucb = new ucCharacterBattle(item, battleChars.Count);
                ucb.AttackClicked += ucb_AttackClicked;
                flpCharacters.Controls.Add(ucb);
            }

            flpNPCs.Controls.Add(new ucNPC(enemy));

        }

        void ucb_AttackClicked(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            ucCharacterBattle control = sender as ucCharacterBattle;
            Core.Abilities.ActiveAbility ab = control.ChoosenAbility();
            if (ab.DamageOrHealing == EnumActiveAbilityType.Damage)
            {
                if (control.CheckBoxEnemyStatus)
                {

                    int previousHP = 0;
                    int postHP = 0;
                    int previousMonsterHP = 0;
                    int postMonsterHP = 0;

                    foreach (var item in battleChars)
                    {
                        previousHP += item.CurrentHP.IntValue;
                    }

                    previousMonsterHP = enemy.CurrentHP.IntValue;

                    ab.UseAbility(control.Character(), battleChars, null, enemy);

                    foreach (var item in battleChars)
                    {
                        postHP += item.CurrentHP.IntValue;
                    }

                    postMonsterHP = enemy.CurrentHP.IntValue;

                    if (postHP > previousHP)
                        healingDone += Math.Abs(postHP - previousHP);

                    if (postMonsterHP > previousMonsterHP)
                        damageDone += Math.Abs(postMonsterHP - previousMonsterHP);

                    Function.RichTextBoxExtensions.AppendText(richTextBoxActionbox, "[" + DateTime.Now.ToShortTimeString() + "] ", Color.DarkSeaGreen);
                    Function.RichTextBoxExtensions.AppendText(richTextBoxActionbox, ab.ChatString + Environment.NewLine, Color.DarkOrange);

                    if (!CheckPlayersHealth())
                    {
                        end = true;
                        this.bnTurnDone.Text = "Quit the battle";
                    }
                }
                else
                {
                    RPG.UI.MessageForm mes = new MessageForm("You have no target!");
                    mes.ShowDialog();
                }
            }
            else
            {
                if (control.CheckBoxP1Status || control.CheckBoxP2Status || control.CheckBoxP3Status  || control.CheckBoxP4Status)
                {
                    List<int> indexes = new List<int>();

                    if (control.CheckBoxP1Status)
                        indexes.Add(0);
                    if (control.CheckBoxP2Status)
                        indexes.Add(1);
                    if (control.CheckBoxP3Status)
                        indexes.Add(2);
                    if (control.CheckBoxP4Status)
                        indexes.Add(3);

                    int previousHP = 0;
                    int postHP = 0;

                    foreach (var item in battleChars)
                    {
                        previousHP += item.CurrentHP.IntValue;
                    }

                    ab.UseAbility(control.Character(), battleChars, indexes, enemy);

                    foreach (var item in battleChars)
                    {
                        postHP += item.CurrentHP.IntValue;
                    }

                    if (postHP > previousHP)
                        healingDone += Math.Abs(postHP - previousHP);

                    string temp = "";
                    int i = 0;

                    for (i = 0; i < indexes.Count-1; i++)
                    {
                        temp += battleChars[i].UnitName + " and ";
                    }

                    temp += battleChars[i].UnitName + "!";

                    Function.RichTextBoxExtensions.AppendText(richTextBoxActionbox, "[" + DateTime.Now.ToShortTimeString() + "] ", Color.DarkSeaGreen);
                    Function.RichTextBoxExtensions.AppendText(richTextBoxActionbox, ab.ChatString + Environment.NewLine, Color.DarkOrange);
                }
                else
                {
                    RPG.UI.MessageForm mes = new MessageForm("You have no target!");
                    mes.ShowDialog();
                }
            }
            control.Update();

            (flpNPCs.Controls[0] as ucNPC).Update();

            if (CheckNPCHealth())
            {
                end = true;
                this.bnTurnDone.Text = "Quit the battle";
            }
        }

        public List<Core.Units.Character> ReturnChars(Core.Player _player)
        {
            return battleChars;
        }

        public int ReturnNumberOfPlayers()
        {
            return numberOfPlayers;
        }

        public NPC ReturnedEnemy()
        {
            return enemy;
        }

        public int ReturnedHealingDone()
        {
            return healingDone;
        }

        public int ReturnedDamageDone()
        {
            return damageDone;
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

        private void BattleForm_Load(object sender, EventArgs e)
        {
            LoadFont();
            foreach (var item in this.Controls)
            {
                AllocFont(font, (item as Control), (item as Control).Font.Size);
            }

            this.Font = new Font("Microsoft Sans Serif", 8.0f);
        }

        #endregion

        /// <summary>
        /// This function runs the AI's turn and resets the characters turnpoints.
        /// </summary>
        private void DoAITurn()
        {
            if (enemy.CurrentHP.IntValue > 0)
            {
                int previousMonsterHP = enemy.CurrentHP.IntValue;

                ai.Run();
                Function.RichTextBoxExtensions.AppendText(richTextBoxActionbox, "[" + DateTime.Now.ToShortTimeString() + "] ", Color.DarkSeaGreen);
                Function.RichTextBoxExtensions.AppendText(richTextBoxActionbox, ai.Chat + Environment.NewLine, Color.DarkOrange);

                int postMonsterHP = enemy.CurrentHP.IntValue;

                if (postMonsterHP > previousMonsterHP)
                    damageDone += Math.Abs(postMonsterHP - previousMonsterHP);
            }

            battleChars = ai.Targets;
            int turnpoints = 0;

            foreach (var item in battleChars)
            {
                int newPoints = item.CurrentTurnPoints.IntValue + Function.CombatHandler.SpeedCalculator(item.UnitLevel, item.BuffedSpeed.IntValue);
                turnpoints = (item.UnitLevel / 10) + 1;
                if (newPoints > turnpoints)
                    item.CurrentTurnPoints.IntValue = (item.UnitLevel / 10) + 1;
                else
                {
                    item.CurrentTurnPoints.IntValue = newPoints;
                }

            }

            if (!CheckPlayersHealth())
            {
                end = true;
                this.bnTurnDone.Text = "Quit the battle";
            }

            foreach (var item in flpCharacters.Controls)
            {
                (item as ucCharacterBattle).Update();
            }

            foreach (var item in flpNPCs.Controls)
            {
                (item as ucNPC).Update();
            }
        }

        /// <summary>
        /// This function checks the health of the enemy and gives players experience if the monster has fallen.
        /// </summary>
        /// <returns>true if the monster is dead, false otherwise</returns>
        private bool CheckNPCHealth()
        {
            if (enemy.CurrentHP.IntValue <= 0)
            {
                Function.RichTextBoxExtensions.AppendText(richTextBoxActionbox, "[" + DateTime.Now.ToShortTimeString() + "] ", Color.LightGreen);
                Function.RichTextBoxExtensions.AppendText(richTextBoxActionbox, enemy.UnitName + " has been defeated! you recieve " + enemy.ExperienceYielded + " in experience!" + Environment.NewLine, Color.LightGreen);

                foreach (var item in battleChars)
                {
                    item.CharRecieveXP(enemy.ExperienceYielded);
                    item.CurrentTurnPoints.IntValue = 0;
                }
                
                result = System.Windows.Forms.DialogResult.OK;
                return true;
            }

            return false;
        }

        /// <summary>
        /// This function checks if the players are alive. If a player has died, it will be removed from the list of characters.
        /// </summary>
        /// <returns>return false if ALL players are dead, otherwise returns true</returns>
        private bool CheckPlayersHealth()
        {
                foreach (var item in battleChars)
                {
                    if (item.CurrentHP.IntValue <= 0)
                    {
                        Function.RichTextBoxExtensions.AppendText(richTextBoxActionbox, "[" + DateTime.Now.ToShortTimeString() + "] ", Color.DarkRed);
                        Function.RichTextBoxExtensions.AppendText(richTextBoxActionbox, item.UnitName + " has died from damage!" + Environment.NewLine, Color.DarkRed);
                        item.CurrentTurnPoints.IntValue = 0;
                    }
                }

                if (battleChars.Any(x => x.CurrentHP.IntValue > 0) == false)
                {
                     result = System.Windows.Forms.DialogResult.Cancel;
                    return false;
                }
                else
                    return true;
        }
        #endregion

        #region Events
        private void bnTurnDone_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            if (!end)
            {
                DoAITurn();
            }
            else
            {
                foreach (var item in battleChars)
                {
                    item.UnitBuffsAndDebuffs.Clear();
                }
                Function.SoundManager.StopBattleMusic();
                this.DialogResult = result;
                this.Close();
            }
        }

        private void textBoxChat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && textBoxChat.Text != "")
            {
                e.SuppressKeyPress = true;

                string playername = "";//player.UserName;

                Function.RichTextBoxExtensions.AppendText(richTextBoxActionbox, "[" + DateTime.Now.ToShortTimeString() + "] ", Color.DarkSeaGreen);
                Function.RichTextBoxExtensions.AppendText(richTextBoxActionbox, playername, Color.DarkRed);
                Function.RichTextBoxExtensions.AppendText(richTextBoxActionbox, ": " + textBoxChat.Text + Environment.NewLine, Color.White);

                richTextBoxActionbox.ScrollToCaret();

                textBoxChat.Text = "";
            }
        }

        private void richTextBoxActionbox_TextChanged(object sender, EventArgs e)
        {
            richTextBoxActionbox.ScrollToCaret();
        }

        #endregion
    }
}
