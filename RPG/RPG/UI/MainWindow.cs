using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using RPG.UI;
using RPG.Core;
using RPG.UI.UserControls;
using RPG.Function;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace RPG
{
    public partial class MainWindow : Form
    {
        #region declaration of fields
        List<Player> playerlist = new List<Player>();
        Player player = null;
        ToolTip tt = new ToolTip();
        #endregion

        public MainWindow(Player _player, List<Player> _playerlist)
        {
            InitializeComponent();
            player = _player;
            Function.SoundManager.PlayMainMenuMusic();

            if (player.PrefChar == null)
                player.PrefChar.Add("None");
            if (player.CurrentQuest != null)
            {
                player.CurrentQuest.UpdateQuest(player, 1, null, 0, 0, 1.0, new List<EnumCharClass>());
            }

            playerlist = _playerlist;
            this.BackgroundImage = GeneralFunctions.ResizeImage(Properties.Resources.background, labelBackgroundIGNORE.Size);

            this.richTextBoxActionbox.Text =   "Welcome to The Legend of Eiwar" + Environment.NewLine +
                                                "Version : " + ServerManagement.GetRunningVersion() + Environment.NewLine + Environment.NewLine +
                                                "Click the support tab to instructions on how to play and to see changes!" + Environment.NewLine +
                                                "If you find a bug or believe there is a balance issue in the game, please report this with the " +
                                                "following link: https://docs.google.com/forms/d/15iHbzt2H74AGrO3oVzdlIc08Q1vP3_cegFcdOmP02Hk/viewform" + Environment.NewLine; 

            listBoxInventory.DataSource = player.InventoryOfPlayer;
            listBoxInventory.DisplayMember = "ItemName";

            foreach (var item in player.ControlledCharacters)
            {
                item.ResetCharSkills();
            }

            if (this.player.ControlledCharacters.Count == 0)
            {
                NewPlayer();
            }
            else
            {
                foreach (var item in this.player.ControlledCharacters)
                {
                    this.flpCharacters.Controls.Add(new ucCharacterInterface(item, true));
                }

                foreach (var item in flpCharacters.Controls)
                {
                    (item as ucCharacterInterface).Update();
                }
            }

            UpdateQuestVisual();
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

        private void MainWindow_Load(object sender, EventArgs e)
        {
            LoadFont();
            foreach (var item in this.Controls)
            {
                AllocFont(font, (item as Control), (item as Control).Font.Size);
            }
            this.Font = new Font("Microsoft Sans Serif", 8.0f);
        }

        #endregion

        private void UpdateInventoryVisual()
        {
            listBoxInventory.DataSource = null;
            listBoxInventory.DataSource = this.player.InventoryOfPlayer;
            listBoxInventory.DisplayMember = "InventoryDisplay";
            listBoxInventory.Refresh();
        }

        private void NewPlayer()
        {
            SupportForm sup = new SupportForm();
            sup.ShowDialog();

            CreateACharacter();
        }

        private void CreateACharacter()
        {

            CharacterCreationForm form = new CharacterCreationForm(player);

            var result = form.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Core.Units.Character c = form.ReturnCharacter();
                c.Owner = player.UserName;
                player.AddCharacter(c);
                this.flpCharacters.Controls.Add(new ucCharacterInterface(form.ReturnCharacter(), true));
            }
        }

        private void UpdateChars()
        {

            foreach (var item in player.ControlledCharacters)
            {
                item.CurrentTurnPoints.IntValue = (item.UnitLevel / 10) + 1;
                int temp = item.BuffedHP.IntValue;
                item.CurrentHP.IntValue = temp;
            }

            foreach (var item in flpCharacters.Controls)
            {
                (item as ucCharacterInterface).Update();
            }
        }

        private void UseGearChangeForm()
        {
            if (listBoxInventory.Items.Count != 0 && listBoxInventory.SelectedIndex != -1)
            {
                try
                {
                    int index = listBoxInventory.SelectedIndex;
                    var currentItem = this.player.InventoryOfPlayer[index];
                    ChangeGearForm gear = new ChangeGearForm(currentItem, player);
                    if (gear.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        UpdateChars();
                        UpdateInventoryVisual();
                    }

                }
                catch (Exception exp)
                {
                    RPG.UI.MessageForm mes = new RPG.UI.MessageForm(exp.Message);
                    mes.ShowDialog();
                }
                finally { }
            }
        }

        private void UpdateQuestVisual()
        {
            labelQuestBar.Text = "";
            //labelQuestText.Location = flpQuestBar.Location;
            //labelQuestText.Size = flpQuestBar.Size;
            flpQuestBar.ForeColor = Color.White;
            

            if (player.CurrentQuest != null)
            {
                int width = (int)(flpQuestBar.Width * ((double)player.CurrentQuest.currentValue / (double)player.CurrentQuest.finalValue));
                int percentDone = (int)(((double)player.CurrentQuest.currentValue / (double)player.CurrentQuest.finalValue) * 100);

                labelQuestBar.Text = player.CurrentQuest.currentValue + "/" + player.CurrentQuest.finalValue + " (" + percentDone + "%) of current quest: " + player.CurrentQuest.questText;
                labelQuestBar.ForeColor = Color.White;

                if (percentDone > 50)
                {
                    flpQuestBar.FlowDirection = FlowDirection.LeftToRight;
                    labelQuestBar.BackColor = Color.MidnightBlue;
                    flpQuestBar.BackColor = Color.Black;

                    labelQuestBar.Width = width;

                    

                }
                else
                {
                    flpQuestBar.FlowDirection = FlowDirection.RightToLeft;
                    width = (flpQuestBar.Width - width);
                    labelQuestBar.BackColor = Color.Black;
                    flpQuestBar.BackColor = Color.MidnightBlue;

                    labelQuestBar.Width = width;

                    if (percentDone <= 0)
                    {
                        labelQuestBar.Width = flpQuestBar.Width;
                        labelQuestBar.BackColor = Color.Black;
                    }
                }
            }
            else
            {
                labelQuestBar.Text = "";
                labelQuestBar.BackColor = Color.Transparent;
                flpQuestBar.BackColor = Color.Transparent;
                labelQuestBar.Width = flpQuestBar.Width;
                labelQuestBar.Text = "No Quest!";
                
            }
        }

        #region Battle related functions

        private List<Item> GenerateLoot(int difficulty, int averagePlayerLevel, int numberOfPlayers, int enemyLevel)
        {
            List<Item> loot = new List<Item>();
            loot.Add(Function.ItemGeneration.GenerateLoot(averagePlayerLevel, numberOfPlayers, enemyLevel));
            loot.Add(Function.ItemGeneration.GenerateLoot(averagePlayerLevel, numberOfPlayers, enemyLevel));
            if (difficulty < 0)
                loot.Add(Function.ItemGeneration.GenerateLoot(averagePlayerLevel, numberOfPlayers, enemyLevel));

            if (loot.Count == 2)
            {
                if (loot[0].ItemName == loot[1].ItemName)
                    loot[0].ItemName = Function.ItemGeneration.RandomizeNewName(loot[0]);
            }

            if (loot.Count == 3)
            {
                if (loot[0].ItemName == loot[1].ItemName && loot[1].ItemName == loot[2].ItemName)
                {
                    loot[0].ItemName = Function.ItemGeneration.RandomizeNewName(loot[0]);
                    loot[1].ItemName = Function.ItemGeneration.RandomizeNewName(loot[1]);
                }
                if (loot[0].ItemName == loot[1].ItemName)
                {
                    loot[0].ItemName = Function.ItemGeneration.RandomizeNewName(loot[0]);
                }
                if (loot[0].ItemName == loot[2].ItemName)
                {
                    loot[0].ItemName = Function.ItemGeneration.RandomizeNewName(loot[0]);
                }
                if (loot[1].ItemName == loot[2].ItemName)
                {
                    loot[1].ItemName = Function.ItemGeneration.RandomizeNewName(loot[1]);
                }
            }

            if (loot.Count > 0)
            {
                foreach (var item in loot)
                {
                    this.player.AddItemToInventory(item);
                }
            }

            return loot;
        }

        private void CheckForQuest(int difficulty, Core.Units.NPC enemy, int healingdone, double percent, List<Core.EnumCharClass> usedclass)
        {
            if (player.CurrentQuest != null)
            {
                player.CurrentQuest.UpdateQuest(player, difficulty, enemy, healingdone, enemy.BuffedHP.IntValue, percent, usedclass);

                if (player.CurrentQuest.questcompleted == true)
                    PlayerQuestHandler.BeginNewQuest(player);
            }
            else
            {
                Function.PlayerQuestHandler.BeginNewQuest(player);
            }
        }

        private double ReturnLowestPercent(List<Core.Units.Character> list)
        {
            double percent = 100.0;

            foreach (var item in list)
            {
                if (((((double)item.CurrentHP.IntValue) / (double)item.BuffedHP.IntValue)*100) < percent)
                    percent = (double)item.BuffedHP.IntValue / (double)item.CurrentHP.IntValue;
            }

            return percent;
        }

        private int ReturnAverageLevel(List<Core.Units.Character> list)
        {
            int average = 0;

            foreach (var item in list)
            {
                average += item.UnitLevel;
            }

            average /= list.Count;

            return average;
        }
        #endregion

        #endregion

        #region Events

        private void btExitGame_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Choose a location to save your list of players. This will work as a backup case case anything changes!";

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ServerManagement.Saveplayers("players.xml", playerlist, player);
                ServerManagement.ExportToFolder(Path.Combine(fbd.SelectedPath,"players.xml"), playerlist);
            }

            Function.SoundManager.StopMainMenuMusic();
            this.Close();
        }

        private void bnBattle_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            if (player.ControlledCharacters.Count > 0)
            {
                FindLocalBattleForm battlechoose = new FindLocalBattleForm(player);
                var result = battlechoose.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    List<Core.Units.Character> list = new List<Core.Units.Character>();

                    foreach (var item in battlechoose.ReturnChars())
                    {
                        list.Add(item);
                    }
                        
                    Function.SoundManager.PauseMainMenuMusic();

                    BattleForm battle = new BattleForm(list, battlechoose.ReturnDifficulty());
                    if (battle.ShowDialog() == DialogResult.OK)
                    {
                        Function.SoundManager.ResumeMainMenuMusic();
                        list = battle.ReturnChars(player);

                        List<EnumCharClass> classesUsed = new List<EnumCharClass>();
                        foreach (var item in list)
                        {
                            classesUsed.Add(item.CharClass);
                        }

                        List<Item> loot = GenerateLoot(battlechoose.ReturnDifficulty(), ReturnAverageLevel(list), battle.ReturnNumberOfPlayers(), battle.ReturnedEnemy().UnitLevel);
                        CheckForQuest(battlechoose.ReturnDifficulty(), battle.ReturnedEnemy(), battle.ReturnedHealingDone(), ReturnLowestPercent(list), classesUsed);
                            

                        UpdateQuestVisual();

                        foreach (var item in list)
                        {
                            this.player.ControlledCharacters.RemoveAll(x => x.UnitName == item.UnitName);
                        }
                        
                        this.player.ControlledCharacters.AddRange(battle.ReturnChars(player));

                        UpdateChars();

                        UpdateInventoryVisual();
                    }
                    else
                    {
                        UpdateChars();
                    }
                }
            }
            else
            {
                RPG.UI.MessageForm mes = new RPG.UI.MessageForm("You dont have any characters to battle with!");
                mes.ShowDialog();
            }

            this.ResumeLayout();

        }

        private void textBoxChat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && textBoxChat.Text != "")
            {
                e.SuppressKeyPress = true;

                string playername = player.UserName;

                Function.RichTextBoxExtensions.AppendText(richTextBoxActionbox, "[" + DateTime.Now.ToShortTimeString() + "] ", Color.DarkSeaGreen);
                Function.RichTextBoxExtensions.AppendText(richTextBoxActionbox, playername, Color.DarkRed);
                Function.RichTextBoxExtensions.AppendText(richTextBoxActionbox, ": " + textBoxChat.Text + Environment.NewLine, Color.White);
                richTextBoxActionbox.ScrollToCaret();

                textBoxChat.Text = "";
            }
        }

        private void btNewGame_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            SupportForm sup = new SupportForm();
            sup.ShowDialog();
        }

        private void btDisenchant_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            if (listBoxInventory.SelectedItem != null)
            {
                int temp = listBoxInventory.SelectedIndex;
                this.player.Dust += (this.player.InventoryOfPlayer[temp].ItemLevel / 10) + 1 + GeneralFunctions.ReturnExtraDust(this.player.InventoryOfPlayer[temp]);
                this.player.InventoryOfPlayer.Remove(this.player.InventoryOfPlayer[temp]);
                UpdateInventoryVisual();
                listBoxInventory.SelectedIndex = listBoxInventory.Items.Count - 1;
            }
            else
            {
                RPG.UI.MessageForm mes = new RPG.UI.MessageForm("Please select an item to disenchant!");
                mes.ShowDialog();
            }

            
        }

        private void btDisenchantAll_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            int count = 0;

            while (this.player.InventoryOfPlayer.Any(c => (c.ItemQuality == EnumItemQuality.Normal || c.ItemQuality == EnumItemQuality.Grand))) 
            {
                if (this.player.InventoryOfPlayer[count].ItemQuality == EnumItemQuality.Normal || this.player.InventoryOfPlayer[count].ItemQuality == EnumItemQuality.Grand)
                {
                    this.player.Dust += (this.player.InventoryOfPlayer[count].ItemLevel / 10) + 1 + GeneralFunctions.ReturnExtraDust(this.player.InventoryOfPlayer[count]);
                    this.player.InventoryOfPlayer.Remove(this.player.InventoryOfPlayer[count]);
                }
                else
                {
                    count++;
                }
	        }

            UpdateInventoryVisual();
            listBoxInventory.SelectedIndex = listBoxInventory.Items.Count - 1;
        }

        private void listBoxInventory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            UseGearChangeForm();
        }

        private void btRandomizeStat_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            if ((this.player.InventoryOfPlayer.Count > 0 && listBoxInventory.SelectedIndex >= 0) || this.player.ControlledCharacters.Count > 0)
            {
                RandomizeStatForm rsform = new RandomizeStatForm(this.player);
                rsform.ShowDialog();
                UpdateChars();
            }
            else 
            {
                RPG.UI.MessageForm mes = new RPG.UI.MessageForm("You have not choosen an item or you have no items in your inventory!");
                mes.ShowDialog();
            }
        }

        private void btAddCharacter_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            if (this.player.ControlledCharacters.Count < 4)
            {
                CreateACharacter();
            }
            else
            {
                RPG.UI.MessageForm mes = new RPG.UI.MessageForm("You already have 4 characters!");
                mes.ShowDialog();
            }
        }

        private void listBoxInventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxInventory.Items.Count != 0 && listBoxInventory.SelectedIndex != -1)
            {
                int index = listBoxInventory.SelectedIndex;
                var currentItem = this.player.InventoryOfPlayer[index];

                this.labelCurrentItem.Text = Function.GeneralFunctions.ReturnItemLabelString(currentItem);
                this.labelCurrentItem.ForeColor = Function.GeneralFunctions.ReturnProperColorForItem(currentItem);
            }
            else if (listBoxInventory.SelectedIndex == -1)
            {
                this.labelCurrentItem.Text = "Nothing Selected!";
                this.labelCurrentItem.ForeColor = Color.Yellow;
            }
        }

        private void listBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index > -1)
            {
                var currentItem = this.player.InventoryOfPlayer[e.Index];
                e.DrawBackground();
                Graphics yourObj = e.Graphics;
                Color forecolor = GeneralFunctions.ReturnProperColorForItem(currentItem);

                using (SolidBrush fbr = new SolidBrush(forecolor))
                    e.Graphics.DrawString(currentItem.ItemName, e.Font, fbr, e.Bounds, StringFormat.GenericDefault);

                //yourObj.DrawString("",new Font(Fon(new SolidBrush(Color.Red), e.Bounds);

                e.DrawFocusRectangle();
            }
        }

        private void btDeleteCharacter_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            if (this.player.ControlledCharacters.Count > 0)
            {
                DeleteCharForm del = new DeleteCharForm(player);
                if (del.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    int index = 0;
                    int i = 0;
                    foreach (var item in flpCharacters.Controls)
                    {
                        if ((item as ucCharacterInterface).Character().UnitName == del.ChooseChar().UnitName)
                            index = i;

                        i++;
                    }

                    flpCharacters.Controls.RemoveAt(index);
                    player.ControlledCharacters.Remove(del.ChooseChar());

                    UpdateChars();
                }
            }
            else
            {
                MessageForm mes = new MessageForm("You dont have any characters to delete!");
            }
        }

        private void bnOptions_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            OptionsForm options = new OptionsForm(player);
            options.ShowDialog();

            UpdateQuestVisual();
        }

        private void listBoxInventory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Function.SoundManager.PlayButtonSound();
                e.SuppressKeyPress = true;

                UseGearChangeForm();
            }
        }

        #region Showing Button Tooltips

        private void btSupport_MouseEnter(object sender, EventArgs e)
        {
            tt.ToolTipTitle = "Support";
            tt.Show("Click here to see how to play if you are new to the game, or whats changed if you are returning!", btSupport, 5000);
        }

        private void btAddCharacter_MouseEnter(object sender, EventArgs e)
        {
            tt.ToolTipTitle = "Add Character";
            tt.Show("Click here to add a new character to your list!", btAddCharacter, 5000);
        }

        private void btDeleteCharacter_MouseEnter(object sender, EventArgs e)
        {
            tt.ToolTipTitle = "Delete Character";
            tt.Show("Click here to delete a current character.", btDeleteCharacter, 5000);
        }

        private void btRandomizeStat_MouseEnter(object sender, EventArgs e)
        {
            tt.ToolTipTitle = "Randomize Stat";
            tt.Show("Click here to randomize a certain stat on an item!", btRandomizeStat, 5000);
        }

        private void btExitGame_MouseEnter(object sender, EventArgs e)
        {
            tt.ToolTipTitle = "Exit";
            tt.Show("Click here to exit the game.", btExitGame, 5000);
        }

        private void btBattle_MouseEnter(object sender, EventArgs e)
        {
            tt.ToolTipTitle = "Find Battle!";
            tt.Show("Click here to find a foe to battle against, alone or teaing up with others!", btBattle, 5000);
        }

        private void btDisenchant_MouseEnter(object sender, EventArgs e)
        {
            tt.ToolTipTitle = "Disenchant Ttem";
            tt.Show("Click here to destroy the selected item in your inventory, gaining Dust in the progress! Character equipment will not be affected.", btDisenchant, 5000);
        }

        private void btDisenchantAll_MouseEnter(object sender, EventArgs e)
        {
            tt.ToolTipTitle = "Disenchant All";
            tt.Show("Click here to destroy the all items of Normal or Grand quality in your inventory, gaining Dust for each one! Character equipment will not be affected.", btDisenchantAll, 5000);
        }
        #endregion

        #region Hiding Button tooltips
        private void btSupport_MouseLeave(object sender, EventArgs e)
        {
            tt.Hide(btSupport);
        }

        private void btAddCharacter_MouseLeave(object sender, EventArgs e)
        {
            tt.Hide(btAddCharacter);
        }

        private void btDeleteCharacter_MouseLeave(object sender, EventArgs e)
        {
            tt.Hide(btDeleteCharacter);
        }

        private void btRandomizeStat_MouseLeave(object sender, EventArgs e)
        {
            tt.Hide(btRandomizeStat);
        }

        private void btExitGame_MouseLeave(object sender, EventArgs e)
        {
            tt.Hide(btExitGame);
        }

        private void bnBattle_MouseLeave(object sender, EventArgs e)
        {
            tt.Hide(btBattle);
        }

        private void btDisenchant_MouseLeave(object sender, EventArgs e)
        {
            tt.Hide(btDisenchant);
        }

        private void btDisenchantAll_MouseLeave(object sender, EventArgs e)
        {
            tt.Hide(btDisenchantAll);
        }
        #endregion

        #endregion

    }
}
