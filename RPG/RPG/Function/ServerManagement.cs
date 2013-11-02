using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Deployment;
using System.Reflection;
using System.IO;
using System.Xml.Serialization;
using RPG;
using RPG.Core;
using RPG.UI;
using RPG.Core.Abilities;
using System.Drawing;
using RPG.Core.Items;


namespace RPG.Function
{
    public static class ServerManagement
    {
        /// <summary>
        /// Function to get the current version
        /// </summary>
        /// <returns></returns>
        public static Version GetRunningVersion()
        {
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                return System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
            }
            else
                return Assembly.GetExecutingAssembly().GetName().Version;
        }

        #region Temporary Save and Load Players

        private static Type[] Types()
        {
            #region Declaration of all inherited types
            Type[] types = new Type[] 
            { 
                
                typeof(Weapon), 
                typeof(Armor), 
                typeof(BattleCharm),
                //All Classes abilities
                typeof(MeleeAttack),
                typeof(BattleRegeneration),
                typeof(Empowerment),
                typeof(Invigorate),
                typeof(DoubleSwing),
                typeof(Opportunity),
                typeof(Totalitarism),
                typeof(Ascend),
                //Warrior abilities
                typeof(WarriorBlindRage),
                typeof(WarriorExecution),
                typeof(WarriorInfuriate),
                typeof(WarriorInsanity),
                typeof(WarriorPowerStrike),
                typeof(WarriorRampage),
                typeof(WarriorRoar),
                typeof(WarriorStrength),
                //Paladin Abilities
                typeof(PaladinBlessing),
                typeof(PaladinDesperatePlea),
                typeof(PaladinJustice),
                typeof(PaladinPrayer),
                typeof(PaladinRaiseSpirit),
                typeof(PaladinSerenity),
                typeof(PaladinThePowerOfFaith),
                typeof(PaladinWrath),
                //Wizard abilities
                typeof(WizardArchon),
                typeof(WizardBrilliance),
                typeof(WizardFireball),
                typeof(WizardFlameComet),
                typeof(WizardHeal),
                typeof(WizardInferno),
                typeof(WizardOracle),
                typeof(WizardRevitalize),
                //Thief Abilities
                typeof(ThiefBloodstealer),
                typeof(ThiefBorrowWeapon),
                typeof(ThiefCopycat),
                typeof(ThiefDirtyTricks),
                typeof(ThiefEnvenom),
                typeof(ThiefFlurry),
                typeof(ThiefQuickAttack),
                typeof(ThiefSwiftness),
                //Caretaker Abilities
                typeof(CaretakerAction),
                typeof(CaretakerBodySlam),
                typeof(CaretakerDeathdefiance),
                typeof(CaretakerLifeblood),
                typeof(CaretakerLifeforce),
                typeof(CaretakerPowerAndDexterity),
                typeof(CaretakerSacrifice),
                typeof(CaretakerZealOfHumanity),
                //Synergist Abilities
                typeof(SynergistAgileMind),
                typeof(SynergistAlign),
                typeof(SynergistBalanceAgility),
                typeof(SynergistBalance),
                typeof(SynergistMentalAgility),
                typeof(SynergistBalanceIntellect),
                typeof(SynergistCollapsedEquality),
                typeof(SynergistCompleteBalance),
                typeof(SynergistDuality),
                typeof(SynergistSynergy),
                // Quests
                typeof(VeryEasyDefeat5),
                typeof(EasyDefeat5),
                typeof(NormalDefeat5),
                typeof(HardDefeat5),
                typeof(VeryHardDefeat5),
                typeof(VeryEasyHealing),
                typeof(EasyHealing),
                typeof(NormalHealing),
                typeof(HardHealing),
                typeof(VeryHardHealing),
                typeof(VeryEasyDamage),
                typeof(EasyDamage),
                typeof(NormalDamage),
                typeof(HardDamage),
                typeof(VeryHardDamage),
                typeof(VeryEasyClass),
                typeof(EasyClass),
                typeof(NormalClass),
                typeof(HardClass),
                typeof(VeryHardClass),
                typeof(VeryEasyPercentRemaining),
                typeof(EasyPercentRemaining),
                typeof(NormalPercentRemaining),
                typeof(HardPercentRemaining),
                typeof(VeryHardPercentRemaining),
            };
            #endregion
            return types;
        }

        public static void Saveplayers(string path, List<Player> playerList, Player currentplayer)
        {
            //playerList.Find(x => x.UserName.ToLower() == currentplayer.UserName.ToLower()) = currentplayer;

            Type[] types = Types();

            System.IO.FileInfo fi = new System.IO.FileInfo(path);
            if (!fi.Directory.Exists) 
                fi.Directory.Create();

            if (fi.Exists)
                fi.Delete();
            try
            {
                StreamWriter w = new StreamWriter(path);

                XmlSerializer xmlserializer = new XmlSerializer(typeof(List<Player>), types);
                xmlserializer.Serialize(w, playerList);

                w.Close();
            }
            catch (Exception exp)
            {
                //System.Windows.Forms.MessageBox.Show(exp.Message);
            }
            finally { }
        }

        public static List<Player> LoadPlayers(string filename)
        {
            string path = filename;

            Type[] types = Types();

            List<Player> t = null;

            if (System.IO.File.Exists(path))
            {
                TextReader textReader;
                XmlSerializer deserializer = new XmlSerializer(typeof(List<Player>), types);
                textReader = new StreamReader(path);

                try
                {
                    t = (List<Player>)deserializer.Deserialize(textReader);
                }
                catch (Exception exp)
                {
                    MessageForm missingInfo = new MessageForm(exp.Message);
                    missingInfo.ShowDialog();
                    textReader.Close();
                }
                finally
                {
                    textReader.Close();
                }
                return t;
            }
            else
                return new List<Player>();

        }

        public static void ExportToFolder(string fullFileNameA, List<Player> playerList)
        {
            Type[] types = Types();

            System.IO.FileInfo fiA = new System.IO.FileInfo(fullFileNameA);
            if (!fiA.Directory.Exists) fiA.Directory.Create();

            if (fiA.Exists)
                fiA.Delete();
            try
            {
                StreamWriter w = new StreamWriter(fullFileNameA);

                XmlSerializer xmlserializer = new XmlSerializer(typeof(List<Player>), types);
                xmlserializer.Serialize(w, playerList);

                w.Close();
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(exp.Message + exp.InnerException.Message);
            }
            finally { }
        }

        public static List<Player> LoadFromFolder(string moviepath)
        {
            Type[] types = Types();
            List<Player> t = null;
            TextReader textReader = null;
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Player>), types);

            try
            {
                textReader = new StreamReader(moviepath);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }


            try
            {
                t = (List<Player>)deserializer.Deserialize(textReader);
                textReader.Close();
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(exp.Message);
            }

            finally
            {
            }

            if (t == null)
                return new List<Player>();
            return t;


        }

        #endregion

        public static void ConnectToDatabase()
        {

        }
    }
}
