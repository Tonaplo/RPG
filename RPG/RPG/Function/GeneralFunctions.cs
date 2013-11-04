using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using RPG.Core;
using RPG.Core.Units;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace RPG.Function
{
    public class GeneralFunctions
    {
        #region Font Fields
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbfont, uint cbfont, IntPtr pdv, [In] ref uint pcFonts);
        FontFamily ff;
        Font font;
        #endregion

        /// <summary>
        /// This function checks a text for non-numbers and non-alfabethical characters, returning true if none are found and false if any other char is found
        /// </summary>
        /// <param name="text">The text to be tested.</param>
        /// <returns></returns>
        public static bool CheckTextForNonLettersAndNonDigits(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsLetterOrDigit(c))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// This function checks a string for non-letter characters, returning true if only letters and false otherwise
        /// </summary>
        /// <param name="text">The text to be checked</param>
        /// <returns></returns>
        public static bool CheckTextForNonLetters(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsLetter(c))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// This function return the color the text should be, based on the Quality of the given item
        /// </summary>
        /// <param name="_item"></param>
        /// <returns></returns>
        public static Color ReturnProperColorForItem(Item _item)
        {
            if (_item != null)
            {
                if (_item.ItemQuality == EnumItemQuality.Normal)
                    return Color.White;
                else if (_item.ItemQuality == EnumItemQuality.Grand)
                    return Color.Aqua;
                else if (_item.ItemQuality == EnumItemQuality.Fabled)
                    return Color.Orange;
                else if (_item.ItemQuality == EnumItemQuality.Epochal)
                    return Color.DarkRed;
                else
                    return Color.White;
            }
            else
                return Color.Yellow;
        }

        /// <summary>
        /// Returns a text string representing an item as a label. Also handles the case where the item is null.
        /// </summary>
        /// <param name="_item"></param>
        /// <returns></returns>
        public static string ReturnItemLabelString(Item _item)
        {
            string temp = "";
            string returned = "";

            if (_item != null)
            {
                temp += "Item level: " + _item.ItemLevel + Environment.NewLine;

                foreach (var item in _item.stats)
                {
                    temp += " + " + item.IntValue + " " + item.Type + Environment.NewLine;
                }

                returned = _item.ItemName + Environment.NewLine + Environment.NewLine + temp;
            }
            else
            {
                returned = "Nothing equipped";
            }

            return returned;
        }

        /// <summary>
        /// Return the appropiate image given the characters class. Also handles the case where the character is null.
        /// </summary>
        /// <param name="thisChar"></param>
        /// <returns></returns>
        public static Image ReturnImageForClass(Character thisChar)
        {
            if (thisChar != null)
            {
                switch (thisChar.CharClass)
                {
                    case RPG.Core.EnumCharClass.Warrior:
                        return Properties.Resources.warrior;

                    case RPG.Core.EnumCharClass.Paladin:
                        return Properties.Resources.paladin;

                    case RPG.Core.EnumCharClass.Wizard:
                        return Properties.Resources.wizard;

                    case RPG.Core.EnumCharClass.Thief:
                        return Properties.Resources.thief;

                    case RPG.Core.EnumCharClass.Caretaker:
                        return Properties.Resources.caretaker;

                    case RPG.Core.EnumCharClass.Synergist:
                        return Properties.Resources.synergist;

                    default:
                        return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Return the string for a label with a character that is NOT in battle.
        /// </summary>
        /// <param name="thisChar"></param>
        /// <returns></returns>
        public static string ReturnCharInterfaceString(Character thisChar)
        {
            string temp = "";

            if (thisChar != null)
            {
                temp = "Level: " + thisChar.UnitLevel;

                if (thisChar.UnitLevel != 60)
                {
                    temp += "\nXP: " + thisChar.CharCurrentXP + "/" + thisChar.CharXPToLevel;
                }
                else
                {
                    temp += "\n";
                }

                temp += "\nHealth: " + thisChar.CurrentHP.IntValue + "/" + thisChar.BuffedHP.IntValue +
                                    "\nStrength: " + thisChar.BuffedStrength.IntValue +
                                    "\nAgility: " + thisChar.BuffedAgility.IntValue +
                                    "\nIntellect: " + thisChar.BuffedIntellingence.IntValue +
                                    "\nCrit: " + thisChar.BuffedCrit.IntValue + " (" + CombatHandler.ReturnCritAndSpeedPercent(thisChar.UnitLevel, thisChar.BuffedCrit.IntValue) + "%)" +
                                    "\nSpeed: " + thisChar.BuffedSpeed.IntValue + " (" + CombatHandler.ReturnCritAndSpeedPercent(thisChar.UnitLevel, thisChar.BuffedSpeed.IntValue) + "%)" +
                                    "\nAttack: " + thisChar.BuffedAttackDamage.IntValue +
                                    "\nArmor: " + thisChar.BuffedArmor.IntValue;
            }

            return temp;
        }

        /// <summary>
        /// Return the string for a label with a character that is NOT in battle.
        /// </summary>
        /// <param name="thisChar"></param>
        /// <returns></returns>
        public static string ReturnCharBaseString(Character thisChar)
        {
            string temp = "";

            if (thisChar != null)
            {
                temp = "Level: " + thisChar.UnitLevel;

                if (thisChar.UnitLevel != 60)
                {
                    temp += "\nXP: " + thisChar.CharCurrentXP + "/" + thisChar.CharXPToLevel;
                }
                else
                {
                    temp += "\n";
                }

                temp += "\nHealth: " + thisChar.BaseHP.IntValue + "/" + thisChar.BaseHP.IntValue +
                                    "\nStrength: " + thisChar.BaseStrength.IntValue +
                                    "\nAgility: " + thisChar.BaseAgility.IntValue +
                                    "\nIntellect: " + thisChar.BaseIntellingence.IntValue +
                                    "\nCrit: " + thisChar.BaseCrit.IntValue + " (" + CombatHandler.ReturnCritAndSpeedPercent(thisChar.UnitLevel, thisChar.BaseCrit.IntValue) + "%)" +
                                    "\nSpeed: " + thisChar.BuffedSpeed.IntValue + " (" + CombatHandler.ReturnCritAndSpeedPercent(thisChar.UnitLevel, thisChar.BuffedSpeed.IntValue) + "%)" +
                                    "\nAttack: " + thisChar.BaseAttackDamage.IntValue +
                                    "\nArmor: " + thisChar.BaseArmor.IntValue;
            }

            return temp;
        }

        /// <summary>
        /// Return the string for a label with a character that IS in battle.
        /// </summary>
        /// <param name="thisChar"></param>
        /// <returns></returns>
        public static string ReturnCharBattleString(Character thisChar)
        {
            string temp = "";

            if (thisChar != null)
            {
                temp = thisChar.UnitName +
                                "\nthe " + thisChar.CharClass +
                                "\nLevel: " + thisChar.UnitLevel +
                                "\nStrength: " + thisChar.BuffedStrength.IntValue +
                                "\nAgility: " + thisChar.BuffedAgility.IntValue +
                                "\nIntellect: " + thisChar.BuffedIntellingence.IntValue +
                                "\nCrit: " + thisChar.BuffedCrit.IntValue + " (" + CombatHandler.ReturnCritAndSpeedPercent(thisChar.UnitLevel, thisChar.BuffedCrit.IntValue) + "%)" +
                                "\nSpeed: " + thisChar.BuffedSpeed.IntValue + " (" + CombatHandler.ReturnCritAndSpeedPercent(thisChar.UnitLevel, thisChar.BuffedSpeed.IntValue) + "%)" +
                                "\nAttack: " + thisChar.BuffedAttackDamage.IntValue +
                                "\nArmor: " + thisChar.BuffedArmor.IntValue;
            }

            return temp;
        }

        /// <summary>
        /// This function resizes and image according to a size
        /// </summary>
        /// <param name="image"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Bitmap ResizeImage(Image image, Size size)
        {
            Bitmap result = new Bitmap(size.Width, size.Height);

            using (Graphics graphics = Graphics.FromImage(result))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, result.Width, result.Height);
            }

            return result;
        }

        public static string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            if (image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    // Convert Image to byte[]
                    image.Save(ms, format);
                    byte[] imageBytes = ms.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
            return "";
        }

        public static Image Base64ToImage(string base64String)
        {
            if (base64String != null)
            {
                // Convert Base64 String to byte[]
                byte[] imageBytes = Convert.FromBase64String(base64String);
                MemoryStream ms = new MemoryStream(imageBytes, 0,
                  imageBytes.Length);

                // Convert byte[] to Image
                ms.Write(imageBytes, 0, imageBytes.Length);
                Image image = Image.FromStream(ms, true);
                return image;
            }
            else
            {
                return Properties.Resources.questionmark;
            }
        }

        public static int ReturnExtraDust(Item _item)
        {
            if (_item.ItemQuality == EnumItemQuality.Normal)
                return 0;
            if (_item.ItemQuality == EnumItemQuality.Grand)
                return 1;
            if (_item.ItemQuality == EnumItemQuality.Fabled)
                return 1;
            if (_item.ItemQuality == EnumItemQuality.Epochal)
                return 5;
            else
                return 0;
        }
    }

    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
