using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RPG.Function;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace RPG.UI
{
    public partial class SupportForm : Form
    {
        #region Fields
        TextBox changelog = new TextBox();
        TextBox upcomming = new TextBox();
        RichTextBox howtoplay = new RichTextBox();
        RichTextBox faq = new RichTextBox();
        #endregion

        public SupportForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackgroundImage = GeneralFunctions.ResizeImage(Properties.Resources.background, labelBackgroundIGNORE.Size);

            #region Creation of the ChangeLog
            changelog.Size = flpMain.Size;
            changelog.BackColor = Color.Black;
            changelog.ForeColor = Color.White;
            changelog.Font = new Font(changelog.Font.FontFamily, 12);
            changelog.ReadOnly = true;
            changelog.ScrollBars = ScrollBars.Vertical;
            changelog.Multiline = true;
            changelog.Text = Properties.Resources.ChangeLog;
            #endregion

            #region Creation of the Upcomming Log
            upcomming.Size = flpMain.Size;
            upcomming.BackColor = Color.Black;
            upcomming.ForeColor = Color.White;
            upcomming.Font = new Font(changelog.Font.FontFamily, 12);
            upcomming.ReadOnly = true;
            upcomming.ScrollBars = ScrollBars.Vertical;
            upcomming.Multiline = true;
            upcomming.Text = Properties.Resources.Upcomming;
            #endregion

            #region Creation of the How to Play text
            
            howtoplay.Size = flpMain.Size;
            howtoplay.BackColor = Color.Black;
            howtoplay.ForeColor = Color.White;
            howtoplay.Font = new Font(changelog.Font.FontFamily, 12);
            howtoplay.ReadOnly = true;
            howtoplay.ScrollBars = RichTextBoxScrollBars.Vertical;
            howtoplay.Multiline = true;
            RichTextBoxExtensions.AppendText(howtoplay, "Welcome to The Legend of Eiwar!" + Environment.NewLine + Environment.NewLine + Environment.NewLine, Color.DarkOrange);
            RichTextBoxExtensions.AppendText(howtoplay, "The Legend of Eiwar is a Turn based Role Playing Game, where you fight against monsters either singleplayer or together with others!", Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, " You start out by creating a character using the \"Add Character\" button. You also choose between six classes:" + Environment.NewLine + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Warrior:" + Environment.NewLine, Color.Red);
            RichTextBoxExtensions.AppendText(howtoplay, "   " + Properties.Resources.DescriptionWarrior + Environment.NewLine + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Paladin:" + Environment.NewLine, Color.Red);
            RichTextBoxExtensions.AppendText(howtoplay, "   " + Properties.Resources.DescriptionPaladin + Environment.NewLine + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Wizard:" + Environment.NewLine, Color.Red);
            RichTextBoxExtensions.AppendText(howtoplay, "   " + Properties.Resources.DescriptionWizard + Environment.NewLine + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Thief:" + Environment.NewLine, Color.Red);
            RichTextBoxExtensions.AppendText(howtoplay, "   " + Properties.Resources.DescriptionThief + Environment.NewLine + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Caretaker:" + Environment.NewLine, Color.Red);
            RichTextBoxExtensions.AppendText(howtoplay, "   " + Properties.Resources.DescriptionCaretaker + Environment.NewLine + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Synergist:" + Environment.NewLine, Color.Red);
            RichTextBoxExtensions.AppendText(howtoplay, "   " + Properties.Resources.DescriptionSynergist + Environment.NewLine + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Combat: The Basics:" + Environment.NewLine + Environment.NewLine, Color.OrangeRed);
            RichTextBoxExtensions.AppendText(howtoplay, "You enter a battle with you character by clicking the \"Find Battle\" button. Entering a battle makes you face off with a dangerous foe!", Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, " First, however, you must select which character you want to battle with and how difficult the battle should be! Once you have made your choice, enter a single- or multiplayer battle!" + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "You will now face off against your foe. Your character is in the panel to the left and the enemy is to the right. Choose which ability to use and press the ''Attack'' button to strike!", Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, " Using an ability cost turnpoints, so be sure which ability to use before you attack! You start the game with 1 turnpoint available each turn and gain more as you progress.", Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, " When you have used up all of your turnpoints, you must let the monter have its turn to retaliate. Once the monster has retaliated, you will regain turnpoints to spend in your next turn!", Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, " If you manage to bring the monster to 0 health before the monster brings you to 0 health, you have won the battle!" + Environment.NewLine + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Experience and levels:" + Environment.NewLine + Environment.NewLine, Color.OrangeRed);
            RichTextBoxExtensions.AppendText(howtoplay, "Winning a battle grants your character experience. When your character gains enough experience they will level up, growing in power as they do!", Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, " Each level will require more experience than the previous one and will grant your character attributes and at certain levels new abilities as well!", Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, " Your charcter will automatically have some of their attributes increased, but it will also gain 4 attributes that you can allocate into either Strength, Agility or Intellect! See the ''Character Overview'' section below for more details." + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Besides experience, when you win a battle, you also gain loot. Loot is items that you can give to your character to make him or her stronger. Items you have looted will automatically appear in your inventory where you can doubleclick them to equip them!" + Environment.NewLine + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Items:" + Environment.NewLine + Environment.NewLine, Color.OrangeRed);
            RichTextBoxExtensions.AppendText(howtoplay, "Items have attributes on them and when a character equips an item it will gain all of these attributes. How many attributes the item has depends on its quality:" + Environment.NewLine + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Normal Items " , Color.White);
            RichTextBoxExtensions.AppendText(howtoplay, " are the lowest quality and only have 1 attribute on them." + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Grand Items ", Color.Aqua);
            RichTextBoxExtensions.AppendText(howtoplay, " are of the next quality and have 1 - 3 attribute on them." + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Fabled Items ", Color.Orange);
            RichTextBoxExtensions.AppendText(howtoplay, " are of the second best quality and have 1 - 4 attribute on them." + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Epochal Items ", Color.DarkRed);
            RichTextBoxExtensions.AppendText(howtoplay, " are very rare are of the best quality. They allways have the same attributes, in varying amounts" + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Many of the abilities of characters are improved by attributes. Ideally, you should try to give a character items with attributes that correspond to their class, as specified above!" + Environment.NewLine + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Attributes:" + Environment.NewLine + Environment.NewLine, Color.OrangeRed);
            RichTextBoxExtensions.AppendText(howtoplay, " But what do these attributes actually do? Different attributes also have different effects on your character. Here's an overview:" + Environment.NewLine + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Health:" + Environment.NewLine, Color.Red);
            RichTextBoxExtensions.AppendText(howtoplay, "  Health determines how much life your character has. The more life it has, the more hits it will be able to survive!" + Environment.NewLine + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Armor:" + Environment.NewLine, Color.Red);
            RichTextBoxExtensions.AppendText(howtoplay, "  Armor makes your character harder to kill. Each point of armor gives your character one point of additional health!" + Environment.NewLine + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Attack:" + Environment.NewLine, Color.Red);
            RichTextBoxExtensions.AppendText(howtoplay, "  Attack is the melee damage your character can inflict. This is used by certain abilities in your characters arsenal." + Environment.NewLine + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Crit:" + Environment.NewLine, Color.Red);
            RichTextBoxExtensions.AppendText(howtoplay, "  Crit gives your characters abilities a chance to have a critical effect! An abilty that 'crits' inflicts 50% extra damage or healing upon the target!" + Environment.NewLine + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Speed:" + Environment.NewLine, Color.Red);
            RichTextBoxExtensions.AppendText(howtoplay, "  Speed give your character a chance to gain 2 turnpoints instead of 1 when ending their turn!" + Environment.NewLine + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Strength:" + Environment.NewLine, Color.Red);
            RichTextBoxExtensions.AppendText(howtoplay, "  Strength is one of the three main attributes and is paramount for certain classes' abilities. 30% of your characters Strength will also be added to its Health!" + Environment.NewLine + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Agility:" + Environment.NewLine, Color.Red);
            RichTextBoxExtensions.AppendText(howtoplay, "  Agility is the second of the three main attributes and is paramount for certain classes' abilities. 30% of your characters Agility will also be added to its Attack Damage!" + Environment.NewLine + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Intellect:" + Environment.NewLine, Color.Red);
            RichTextBoxExtensions.AppendText(howtoplay, "  Intellect is the last of the three main attributes and is also paramount for certain classes' abilities. 30% of your characters Intellect will also be added to its Crit!" + Environment.NewLine + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Character Overview:" + Environment.NewLine + Environment.NewLine, Color.OrangeRed);
            RichTextBoxExtensions.AppendText(howtoplay, "You can gain an overview of your character by pressing the ''Character Overview'' button! Here you can select your current abilities, see your gear, which is your currently equipped items, and view and edit your allocated attributes.", Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, " As previously mentioned, when your character levels up, it gains attribute points - 4 for each level. These can be spent in one of the three main attributes by using the panel to the topright!", Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, " You can also reset your allocated Attribute points to place them again and perfect your character!" + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Finally, you can select and read about the abilities of your character! The panel to the bottom right will display all known abilities - and those the character has not learned yet! Simply check the abilities you want your character to use and uncheck the ones you dont want to use now." + Environment.NewLine + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Disenchanting Items and Dust:" + Environment.NewLine + Environment.NewLine, Color.OrangeRed);
            RichTextBoxExtensions.AppendText(howtoplay, "Defeating your foes, you might also get items you dont wish to use. These items can be disenchanted for Dust by pressing one of the two Disenchant buttons at the bottom right of the screen.", Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, " Dust can be used to randomize attributes on an item, by pressing the ''Randomize Stat'' Button. You then select what item and what stat on the item you want to randomize and roll the dice!", Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, " The amount of the stat on the item will changed - it can maximum be the amount of Dust spent on the randomization, but could also become the minimal and terrifying 0!" + Environment.NewLine + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Options:" + Environment.NewLine + Environment.NewLine, Color.OrangeRed);
            RichTextBoxExtensions.AppendText(howtoplay, "Pressing the ''Options'' button on the main menu will bring you to the Options Menu. Here you can set a prefered character to battle with and a preferred difficulty level! If you choose ''None'' as your preferred character, you will always be asked if you want to battle with the at least recently active character!" + Environment.NewLine + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Quests:" + Environment.NewLine + Environment.NewLine, Color.OrangeRed);
            RichTextBoxExtensions.AppendText(howtoplay, "You will now receive quests while battling monsters! These quests will require you to complete objectives of varying difficulty - how difficulty is up to you!", Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Quests can be Very Easy, Easy, Normal, Hard or Very Hard. As the quests become more challenging, the rewards become greater! You may choose between 3 different rewards:" + Environment.NewLine + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Experience:" + Environment.NewLine, Color.Red);
            RichTextBoxExtensions.AppendText(howtoplay, "  This reward will give ALL of your characters experience! How much will depend on the difficulty of the quest and the level of each character!" + Environment.NewLine + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "High Quality Items:" + Environment.NewLine, Color.Red);
            RichTextBoxExtensions.AppendText(howtoplay, "  This reward will give you 2 items of Fabled or Epochal quality! The harder the quest, the higher the chance for an Epochal item!" + Environment.NewLine + Environment.NewLine, Color.Honeydew);
            RichTextBoxExtensions.AppendText(howtoplay, "Dust:" + Environment.NewLine, Color.Red);
            RichTextBoxExtensions.AppendText(howtoplay, "  This reward will give you more dust to randomize stats on your items! How much you get depends on the average level of your characters and the difficulty of the quest!" + Environment.NewLine + Environment.NewLine, Color.Honeydew);
            
            RichTextBoxExtensions.AppendText(howtoplay, "Thank you for reading this ''How to Play'' section. Good luck and have fun!", Color.Honeydew);
            #endregion

            #region Creation of the FAQ
            faq.Size = flpMain.Size;
            faq.BackColor = Color.Black;
            faq.ForeColor = Color.White;
            faq.Font = new Font(changelog.Font.FontFamily, 12);
            faq.ReadOnly = true;
            faq.ScrollBars = RichTextBoxScrollBars.Vertical;
            faq.Multiline = true;
            RichTextBoxExtensions.AppendText(faq, "Welcome to the Frequently Asked Questions section, or FAQ", Color.White);
            #endregion

            //Start out the form by looking at the how to play
            flpMain.Controls.Add(howtoplay);
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

        private void SupportForm_Load(object sender, EventArgs e)
        {
            LoadFont();
            foreach (var item in this.Controls)
            {
                AllocFont(font, (item as Control), (item as Control).Font.Size);
            }

            this.Font = new Font("Microsoft Sans Serif", 8.0f);
        }

        #endregion

        #endregion

        #region Events

        private void btChangeLog_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            flpMain.Controls.Clear();
            flpMain.Controls.Add(changelog);
        }

        private void btDone_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            this.Close();
        }

        private void btUpcomming_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            flpMain.Controls.Clear();
            flpMain.Controls.Add(upcomming);
        }

        private void btHowToPlay_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            flpMain.Controls.Clear();
            flpMain.Controls.Add(howtoplay);
        }

        private void btFAQ_Click(object sender, EventArgs e)
        {
            Function.SoundManager.PlayButtonSound();
            flpMain.Controls.Clear();
            flpMain.Controls.Add(faq);
        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
           Function.ServerManagement.OpenFeedbackWindow();
        }
    }
}
