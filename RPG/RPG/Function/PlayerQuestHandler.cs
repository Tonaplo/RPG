using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG.Core;
using RPG;
using RPG.UI;

namespace RPG.Function
{
    public static class PlayerQuestHandler
    {
        private static Random r = new Random();

        public static void BeginNewQuest(Player _player)
        {
            QuestDifficultyForm questDiff = new QuestDifficultyForm();
            questDiff.ShowDialog();

            LaunchQuest(_player, questDiff.ReturnDifficulty());
        }

        public static void LaunchQuest(Player _player, int _difficulty)
        {
            int quest;

            #region Very Easy Quests

            if (_difficulty == -4)
            {
                quest = r.Next(0, 6);

                switch (quest)
                {
                    case 0:
                        _player.CurrentQuest = new VeryEasyDefeat5();
                        break;
                    case 1:
                        _player.CurrentQuest = new VeryEasyHealing();
                        break;
                    case 2:
                        _player.CurrentQuest = new VeryEasyDamage();
                        break;
                    case 3:
                        _player.CurrentQuest = new VeryEasyClass();
                        break;
                    case 4:
                        _player.CurrentQuest = new VeryEasyPercentRemaining();
                        break;
                    case 5:
                        _player.CurrentQuest = new VeryEasyNPCType();
                        break;
                    default:
                        break;
                }
            }

            #endregion

            #region Easy Quests

            if (_difficulty == -2)
            {
                quest = r.Next(0, 6);

                switch (quest)
                {
                    case 0:
                        _player.CurrentQuest = new EasyDefeat5();
                        break;
                    case 1:
                        _player.CurrentQuest = new EasyHealing();
                        break;
                    case 2:
                        _player.CurrentQuest = new EasyDamage();
                        break;
                    case 3:
                        _player.CurrentQuest = new EasyClass();
                        break;
                    case 4:
                        _player.CurrentQuest = new EasyPercentRemaining();
                        break;
                    case 5:
                        _player.CurrentQuest = new EasyNPCType();
                        break;

                    default:
                        break;
                }
            }

            #endregion

            #region NormalQuests

            if (_difficulty == 0)
            {
                quest = r.Next(0, 6);

                switch (quest)
                {
                    case 0:
                        _player.CurrentQuest = new NormalDefeat5();
                        break;
                    case 1:
                        _player.CurrentQuest = new NormalHealing();
                        break;
                    case 2:
                        _player.CurrentQuest = new NormalDamage();
                        break;
                    case 3:
                        _player.CurrentQuest = new NormalClass();
                        break;
                    case 4:
                        _player.CurrentQuest = new NormalPercentRemaining();
                        break;
                    case 5:
                        _player.CurrentQuest = new NormalNPCType();
                        break;

                    default:
                        break;
                }
            }

            #endregion

            #region Hard Quests

            if (_difficulty == 2)
            {
                quest = r.Next(0, 6);

                switch (quest)
                {
                    case 0:
                        _player.CurrentQuest = new HardDefeat5();
                        break;
                    case 1:
                        _player.CurrentQuest = new HardHealing();
                        break;
                    case 2:
                        _player.CurrentQuest = new HardDamage();
                        break;
                    case 3:
                        _player.CurrentQuest = new HardClass();
                        break;
                    case 4:
                        _player.CurrentQuest = new HardPercentRemaining();
                        break;
                    case 5:
                        _player.CurrentQuest = new HardNPCType();
                        break;

                    default:
                        break;
                }
            }

            #endregion

            #region Very Hard Quests

            if (_difficulty == 4)
            {
                quest = r.Next(0, 6);

                switch (quest)
                {
                    case 0:
                        _player.CurrentQuest = new VeryHardDefeat5();
                        break;
                    case 1:
                        _player.CurrentQuest = new VeryHardHealing();
                        break;
                    case 2:
                        _player.CurrentQuest = new VeryHardDamage();
                        break;
                    case 3:
                        _player.CurrentQuest = new VeryHardClass();
                        break;
                    case 4:
                        _player.CurrentQuest = new VeryHardPercentRemaining();
                        break;
                    case 5:
                        _player.CurrentQuest = new VeryHardNPCType();
                        break;

                    default:
                        break;
                }
            }

            #endregion

            _player.CurrentQuest.InitiateQuest(_player);
            MessageForm mes = new MessageForm("You have been given a new quest! " + Environment.NewLine + _player.CurrentQuest.QuestText);
            mes.ShowDialog();
            
        }

        public static void GiveVeryEasyQuestReward(Player _player, EnumQuestRewardType _rewardType)
        {
            int xpReward = 0;
            Item itemReward = new Item();
            int dustReward = 0;
            MessageForm mes = new MessageForm("");
            Random r = new Random();

            switch (_rewardType)
            {
                case EnumQuestRewardType.Experience:
                    foreach (var item in _player.ControlledCharacters)
                    {
                        xpReward = (int)(item.CharXPToLevel * 0.05);
                        item.CharRecieveXP(xpReward);
                        mes = new MessageForm(item.UnitName + " received " + xpReward + " experience!");
                        mes.ShowDialog();
                    }
                    break;
                case EnumQuestRewardType.Item:

                    for (int i = 0; i < 2; i++)
                    {
                        int temp = r.Next(0, 101);
                        int ilevel = _player.ControlledCharacters[r.Next(0,_player.ControlledCharacters.Count)].UnitLevel-4;
                        if(ilevel < 1)
                            ilevel = 1;
                        
                        if(temp >=90 && ilevel > 10)
                        {
                            itemReward = ItemGeneration.ReturnEpocalItem(ilevel);
                        }
                        else
                        {
                            itemReward = ItemGeneration.GenerateFabledItem(ilevel);
                        }

                        _player.AddItemToInventory(itemReward);
                        mes = new MessageForm("You received an " + itemReward.ItemQuality + " item:" + Environment.NewLine + itemReward.ItemName);
                        mes.ShowDialog();
                    }

                    break;
                case EnumQuestRewardType.Dust:
                    foreach (var item in _player.ControlledCharacters)
                    {
                        dustReward += (int)(item.UnitLevel);
                    }
                    mes = new MessageForm("You received a total of " + dustReward + " Dust!");
                    _player.Dust += dustReward;
                    mes.ShowDialog();
                    break;
                default:
                    break;
            }
        }

        public static void GiveEasyQuestReward(Player _player, EnumQuestRewardType _rewardType)
        {
            int xpReward = 0;
            Item itemReward = new Item();
            int dustReward = 0;
            MessageForm mes = new MessageForm("");
            Random r = new Random();

            switch (_rewardType)
            {
                case EnumQuestRewardType.Experience:
                    foreach (var item in _player.ControlledCharacters)
                    {
                        xpReward = (int)(item.CharXPToLevel * 0.10);
                        item.CharRecieveXP(xpReward);
                        mes = new MessageForm(item.UnitName + " received " + xpReward + " experience!");
                        mes.ShowDialog();
                    }
                    break;
                case EnumQuestRewardType.Item:

                    for (int i = 0; i < 2; i++)
                    {
                        int temp = r.Next(0, 101);
                        int ilevel = _player.ControlledCharacters[r.Next(0,_player.ControlledCharacters.Count)].UnitLevel-2;
                        if (ilevel < 1)
                            ilevel = 1;

                        if(temp >=85 && ilevel > 10)
                        {
                            itemReward = ItemGeneration.ReturnEpocalItem(ilevel);
                        }
                        else
                        {
                            itemReward = ItemGeneration.GenerateFabledItem(ilevel);
                        }

                        _player.AddItemToInventory(itemReward);
                        mes = new MessageForm("You received an " + itemReward.ItemQuality + " item:" + Environment.NewLine + itemReward.ItemName);
                        mes.ShowDialog();
                    }

                    break;
                case EnumQuestRewardType.Dust:
                    foreach (var item in _player.ControlledCharacters)
                    {
                        dustReward += (int)(item.UnitLevel * 2);
                    }
                    mes = new MessageForm("You received a total of " + dustReward + " Dust!");
                    _player.Dust += dustReward;
                    mes.ShowDialog();
                    break;
                default:
                    break;
            }
        }

        public static void GiveNormalQuestReward(Player _player, EnumQuestRewardType _rewardType)
        {
            int xpReward = 0;
            Item itemReward = new Item();
            int dustReward = 0;
            MessageForm mes = new MessageForm("");
            Random r = new Random();

            switch (_rewardType)
            {
                case EnumQuestRewardType.Experience:
                    foreach (var item in _player.ControlledCharacters)
                    {
                        xpReward = (int)(item.CharXPToLevel * 0.15);
                        item.CharRecieveXP(xpReward);
                        mes = new MessageForm(item.UnitName + " received " + xpReward + " experience!");
                        mes.ShowDialog();
                    }
                    break;
                case EnumQuestRewardType.Item:

                    for (int i = 0; i < 2; i++)
                    {
                        int temp = r.Next(0, 101);
                        int ilevel = _player.ControlledCharacters[r.Next(0,_player.ControlledCharacters.Count)].UnitLevel;
                        if (ilevel < 1)
                            ilevel = 1;

                        if(temp >=80 && ilevel > 10)
                        {
                            itemReward = ItemGeneration.ReturnEpocalItem(ilevel);
                        }
                        else
                        {
                            itemReward = ItemGeneration.GenerateFabledItem(ilevel);
                        }

                        _player.AddItemToInventory(itemReward);
                        mes = new MessageForm("You received an " + itemReward.ItemQuality + " item:" + Environment.NewLine + itemReward.ItemName);
                        mes.ShowDialog();
                    }

                    break;
                case EnumQuestRewardType.Dust:
                    foreach (var item in _player.ControlledCharacters)
                    {
                        dustReward += (int)(item.UnitLevel * 3);
                    }
                    mes = new MessageForm("You received a total of " + dustReward + " Dust!");
                    _player.Dust += dustReward;
                    mes.ShowDialog();
                    break;
                default:
                    break;
            }
        }

        public static void GiveHardQuestReward(Player _player, EnumQuestRewardType _rewardType)
        {
            int xpReward = 0;
            Item itemReward = new Item();
            int dustReward = 0;
            MessageForm mes = new MessageForm("");
            Random r = new Random();

            switch (_rewardType)
            {
                case EnumQuestRewardType.Experience:
                    foreach (var item in _player.ControlledCharacters)
                    {
                        xpReward = (int)(item.CharXPToLevel * 0.20);
                        item.CharRecieveXP(xpReward);
                        mes = new MessageForm(item.UnitName + " received " + xpReward + " experience!");
                        mes.ShowDialog();
                    }
                    break;
                case EnumQuestRewardType.Item:

                    for (int i = 0; i < 2; i++)
                    {
                        int temp = r.Next(0, 101);
                        int ilevel = _player.ControlledCharacters[r.Next(0,_player.ControlledCharacters.Count)].UnitLevel+2;
                        if (ilevel < 1)
                            ilevel = 1;

                        if(temp >=75 && ilevel > 10)
                        {
                            itemReward = ItemGeneration.ReturnEpocalItem(ilevel);
                        }
                        else
                        {
                            itemReward = ItemGeneration.GenerateFabledItem(ilevel);
                        }

                        _player.AddItemToInventory(itemReward);
                        mes = new MessageForm("You received an " + itemReward.ItemQuality + " item:" + Environment.NewLine + itemReward.ItemName);
                        mes.ShowDialog();
                    }

                    break;
                case EnumQuestRewardType.Dust:
                    foreach (var item in _player.ControlledCharacters)
                    {
                        dustReward += (int)(item.UnitLevel * 4);
                    }
                    mes = new MessageForm("You received a total of " + dustReward + " Dust!");
                    _player.Dust += dustReward;
                    mes.ShowDialog();
                    break;
                default:
                    break;
            }
        }

        public static void GiveVeryHardQuestReward(Player _player, EnumQuestRewardType _rewardType)
        {
            int xpReward = 0;
            Item itemReward = new Item();
            int dustReward = 0;
            MessageForm mes = new MessageForm("");
            Random r = new Random();

            switch (_rewardType)
            {
                case EnumQuestRewardType.Experience:
                    foreach (var item in _player.ControlledCharacters)
                    {
                        xpReward = (int)(item.CharXPToLevel * 0.25);
                        item.CharRecieveXP(xpReward);
                        mes = new MessageForm(item.UnitName + " received " + xpReward + " experience!");
                        mes.ShowDialog();
                    }
                    break;
                case EnumQuestRewardType.Item:

                    for (int i = 0; i < 2; i++)
                    {
                        int temp = r.Next(0, 101);
                        int ilevel = _player.ControlledCharacters[r.Next(0,_player.ControlledCharacters.Count)].UnitLevel+4;
                        if (ilevel < 1)
                            ilevel = 1;

                        if(temp >=70 && ilevel > 10)
                        {
                            itemReward = ItemGeneration.ReturnEpocalItem(ilevel);
                        }
                        else
                        {
                            itemReward = ItemGeneration.GenerateFabledItem(ilevel);
                        }

                        _player.AddItemToInventory(itemReward);
                        mes = new MessageForm("You received an " + itemReward.ItemQuality + " item:" + Environment.NewLine + itemReward.ItemName);
                        mes.ShowDialog();
                    }

                    break;
                case EnumQuestRewardType.Dust:
                    foreach (var item in _player.ControlledCharacters)
                    {
                        dustReward += (int)(item.UnitLevel * 5);
                    }
                    mes = new MessageForm("You received a total of " + dustReward + " Dust!");
                    _player.Dust += dustReward;
                    mes.ShowDialog();
                    break;
                default:
                    break;
            }
        }

        public static EnumQuestRewardType ChooseQuestRewardType()
        {
            ChooseQuestRewardForm questReward = new ChooseQuestRewardForm();
            questReward.ShowDialog();

            return questReward.ReturnRewardType();
        }

        public static List<EnumCharClass> ReturnClassesForQuest(Player _player, int maxSize)
        {
            List<EnumCharClass> list = new List<EnumCharClass>();

            int usedSize = maxSize;
            if (maxSize > _player.ControlledCharacters.Count)
                usedSize = _player.ControlledCharacters.Count;


            while (list.Count < usedSize)
            {
                switch (r.Next(0,6))
                {
                    case 0:
                        if(!list.Any(x=> x == EnumCharClass.Caretaker) && _player.ControlledCharacters.Any(y => y.CharClass == EnumCharClass.Caretaker))
                            list.Add(EnumCharClass.Caretaker);
                        break;
                    case 1:
                        if (!list.Any(x => x == EnumCharClass.Paladin) && _player.ControlledCharacters.Any(y => y.CharClass == EnumCharClass.Paladin))
                            list.Add(EnumCharClass.Paladin);
                        break;
                    case 2:
                        if (!list.Any(x => x == EnumCharClass.Synergist) && _player.ControlledCharacters.Any(y => y.CharClass == EnumCharClass.Synergist))
                            list.Add(EnumCharClass.Synergist);
                        break;
                    case 3:
                        if (!list.Any(x => x == EnumCharClass.Thief) && _player.ControlledCharacters.Any(y => y.CharClass == EnumCharClass.Thief))
                            list.Add(EnumCharClass.Thief);
                        break;
                    case 4:
                        if (!list.Any(x => x == EnumCharClass.Warrior) && _player.ControlledCharacters.Any(y => y.CharClass == EnumCharClass.Warrior))
                            list.Add(EnumCharClass.Warrior);
                        break;
                    case 5:
                        if (!list.Any(x => x == EnumCharClass.Wizard) && _player.ControlledCharacters.Any(y => y.CharClass == EnumCharClass.Wizard))
                            list.Add(EnumCharClass.Wizard);
                        break;
                    default:
                        break;
                }
            }

            return list;
        }

        public static EnumMonsterType ReturnRandomMonsterType()
        {
            EnumMonsterType _newtype;
            int selectionValue = r.Next(0, 20);

            if (selectionValue < 8)
                _newtype = EnumMonsterType.Beast;
            else if (selectionValue <= 14)
                _newtype = EnumMonsterType.Humanoid;
            else if (selectionValue <= 18)
                _newtype = EnumMonsterType.Undead;
            else
                _newtype = EnumMonsterType.Dragon;

            return _newtype;
        }
    }
}
