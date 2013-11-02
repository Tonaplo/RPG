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
                quest = r.Next(0, 5);

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
                    default:
                        break;
                }
            }

            #endregion

            #region Easy Quests

            if (_difficulty == -2)
            {
                quest = r.Next(0, 5);

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

                    default:
                        break;
                }
            }

            #endregion

            #region NormalQuests

            if (_difficulty == 0)
            {
                quest = r.Next(0, 5);

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

                    default:
                        break;
                }
            }

            #endregion

            #region Hard Quests

            if (_difficulty == 2)
            {
                quest = r.Next(0, 5);

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

                    default:
                        break;
                }
            }

            #endregion

            #region Very Hard Quests

            if (_difficulty == 4)
            {
                quest = r.Next(0, 5);

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

                    default:
                        break;
                }
            }

            #endregion

            MessageForm mes = new MessageForm("You have been given a new quest! " + Environment.NewLine + _player.CurrentQuest.QuestText);
            mes.ShowDialog();
            _player.CurrentQuest.InitiateQuest(_player);
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
                        xpReward = (int)(item.CharXPToLevel * (0.5 / (item.UnitLevel + 3)));
                        item.CharRecieveXP(xpReward);
                        mes = new MessageForm(item.UnitName + " received " + xpReward + " experience!");
                        mes.ShowDialog();
                    }
                    break;
                case EnumQuestRewardType.Item:

                    for (int i = 0; i < 2; i++)
                    {
                        int temp = r.Next(0, 11);
                        int ilevel = _player.ControlledCharacters[r.Next(0,_player.ControlledCharacters.Count)].UnitLevel-4;
                        if(ilevel < 1)
                            ilevel = 1;
                        
                        if(temp >=5 && ilevel > 10)
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
                        dustReward += (int)(item.UnitLevel * 0.5);
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
                        xpReward = (int)(item.CharXPToLevel * (1.0 / (item.UnitLevel + 3)));
                        item.CharRecieveXP(xpReward);
                        mes = new MessageForm(item.UnitName + " received " + xpReward + " experience!");
                        mes.ShowDialog();
                    }
                    break;
                case EnumQuestRewardType.Item:

                    for (int i = 0; i < 2; i++)
                    {
                        int temp = r.Next(0, 11);
                        int ilevel = _player.ControlledCharacters[r.Next(0,_player.ControlledCharacters.Count)].UnitLevel-2;
                        if (ilevel < 1)
                            ilevel = 1;

                        if(temp >=4 && ilevel > 10)
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
                        dustReward += (int)(item.UnitLevel * 0.75);
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
                        xpReward = (int)(item.CharXPToLevel * (1.5 / (item.UnitLevel + 3)));
                        item.CharRecieveXP(xpReward);
                        mes = new MessageForm(item.UnitName + " received " + xpReward + " experience!");
                        mes.ShowDialog();
                    }
                    break;
                case EnumQuestRewardType.Item:

                    for (int i = 0; i < 2; i++)
                    {
                        int temp = r.Next(0, 11);
                        int ilevel = _player.ControlledCharacters[r.Next(0,_player.ControlledCharacters.Count)].UnitLevel;
                        if (ilevel < 1)
                            ilevel = 1;

                        if(temp >=3 && ilevel > 10)
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
                        dustReward += (int)(item.UnitLevel * 1.0);
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
                        xpReward = (int)(item.CharXPToLevel * (2.0 / (item.UnitLevel + 3)));
                        item.CharRecieveXP(xpReward);
                        mes = new MessageForm(item.UnitName + " received " + xpReward + " experience!");
                        mes.ShowDialog();
                    }
                    break;
                case EnumQuestRewardType.Item:

                    for (int i = 0; i < 2; i++)
                    {
                        int temp = r.Next(0, 11);
                        int ilevel = _player.ControlledCharacters[r.Next(0,_player.ControlledCharacters.Count)].UnitLevel+2;
                        if (ilevel < 1)
                            ilevel = 1;

                        if(temp >=2 && ilevel > 10)
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
                        dustReward += (int)(item.UnitLevel * 1.25);
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
                        xpReward = (int)(item.CharXPToLevel * (2.5/(item.UnitLevel+3)));
                        item.CharRecieveXP(xpReward);
                        mes = new MessageForm(item.UnitName + " received " + xpReward + " experience!");
                        mes.ShowDialog();
                    }
                    break;
                case EnumQuestRewardType.Item:

                    for (int i = 0; i < 2; i++)
                    {
                        int temp = r.Next(0, 11);
                        int ilevel = _player.ControlledCharacters[r.Next(0,_player.ControlledCharacters.Count)].UnitLevel+4;
                        if (ilevel < 1)
                            ilevel = 1;

                        if(temp >=11 && ilevel > 10)
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
                        dustReward += (int)(item.UnitLevel * 1.5);
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

        public static List<EnumCharClass> ReturnClassesForQuest(int _sizeOfList)
        {
            List<EnumCharClass> list = new List<EnumCharClass>();

            if (_sizeOfList > 6)
                return list;

            while (list.Count < _sizeOfList)
            {
                switch (r.Next(0,6))
                {
                    case 0:
                        if(!list.Any(x=> x == EnumCharClass.Caretaker))
                            list.Add(EnumCharClass.Caretaker);
                        break;
                    case 1:
                        if(!list.Any(x=> x == EnumCharClass.Paladin))
                            list.Add(EnumCharClass.Paladin);
                        break;
                    case 2:
                        if (!list.Any(x => x == EnumCharClass.Synergist))
                            list.Add(EnumCharClass.Synergist);
                        break;
                    case 3:
                        if (!list.Any(x => x == EnumCharClass.Thief))
                            list.Add(EnumCharClass.Thief);
                        break;
                    case 4:
                        if (!list.Any(x => x == EnumCharClass.Warrior))
                            list.Add(EnumCharClass.Warrior);
                        break;
                    case 5:
                        if (!list.Any(x => x == EnumCharClass.Wizard))
                            list.Add(EnumCharClass.Wizard);
                        break;
                    default:
                        break;
                }
            }

            return list;
        }
    }
}
