using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG;
using RPG.Core;
using RPG.UI;
using RPG.Core.Units;
using RPG.Function;

namespace RPG.Core
{
    public class PlayerQuest
    {
        #region Fields
        public int finalValue = 1;
        public int currentValue = 0;
        public string questText = "";
        public bool questcompleted = false;
        #endregion
        public PlayerQuest()
        {}

        #region Properties

        public string QuestText
        {
            get { return questText; }
            set { questText = value; }
        }
        #endregion

        #region Functions

        public virtual void InitiateQuest(Player _player)
        {
        }

        public virtual void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class) 
        {
        }

        public virtual void EndQuest(Player _player)
        {
        }

        #endregion
    }

    #region Actual Quests

    #region Defeat 5 of difficulty quests
    public class VeryEasyDefeat5 : PlayerQuest
    {
        public VeryEasyDefeat5()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            this.currentValue = 0;
            this.finalValue = 5;
            this.questText = "Defeat 5 opponents of Very Easy difficulty.";
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if (_difficulty == -4)
            {
                this.currentValue++;
                if (currentValue == 5)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveVeryEasyQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }

    public class EasyDefeat5 : PlayerQuest
    {
        public EasyDefeat5()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            this.currentValue = 0;
            this.finalValue = 5;
            this.questText = "Defeat 5 opponents of Easy difficulty.";
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if (_difficulty == -2)
            {
                this.currentValue++;
                if (currentValue == 5)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveEasyQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }

    public class NormalDefeat5 : PlayerQuest
    {
        public NormalDefeat5()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            this.currentValue = 0;
            this.finalValue = 5;
            this.questText = "Defeat 5 opponents of Normal difficulty.";
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if (_difficulty == 0)
            {
                this.currentValue++;
                if (currentValue == 5)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveNormalQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }

    public class HardDefeat5 : PlayerQuest
    {
        public HardDefeat5()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            this.currentValue = 0;
            this.finalValue = 5;
            this.questText = "Defeat 5 opponents of Hard difficulty.";
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if (_difficulty == 2)
            {
                this.currentValue++;
                if (currentValue == 5)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveHardQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }

    public class VeryHardDefeat5 : PlayerQuest
    {
        public VeryHardDefeat5()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            this.currentValue = 0;
            this.finalValue = 5;
            this.questText = "Defeat 5 opponents of Very Hard difficulty.";
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if (_difficulty == 4)
            {
                this.currentValue++;
                if (currentValue == 5)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveVeryHardQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }

    #endregion

    #region Healing Quests

    public class VeryEasyHealing : PlayerQuest
    {
        public VeryEasyHealing()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            this.currentValue = 0;

            foreach (var item in _player.ControlledCharacters)
            {
                this.finalValue += item.BuffedHP.IntValue;
            }
            
            this.questText = "Heal " + finalValue + " damage during Very Easy battles.";
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if(_difficulty == -4)
            {
                this.currentValue += _healingDone;
                if (currentValue >= finalValue)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveVeryEasyQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }

    public class EasyHealing : PlayerQuest
    {
        public EasyHealing()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            this.currentValue = 0;

            foreach (var item in _player.ControlledCharacters)
            {
                this.finalValue += (int)(item.BuffedHP.IntValue*1.5);
            }

            this.questText = "Heal " + finalValue + " damage during Easy battles.";
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if(_difficulty == -2)
            {
                this.currentValue += _healingDone;
                if (currentValue >= finalValue)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveEasyQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }

    public class NormalHealing : PlayerQuest
    {
        public NormalHealing()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            this.currentValue = 0;

            foreach (var item in _player.ControlledCharacters)
            {
                this.finalValue += (int)(item.BuffedHP.IntValue * 2.0);
            }

            this.questText = "Heal " + finalValue + " damage during Normal battles.";
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if(_difficulty == 0)
            {
                this.currentValue += _healingDone;
                if (currentValue >= finalValue)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveNormalQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }

    public class HardHealing : PlayerQuest
    {
        public HardHealing()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            this.currentValue = 0;

            foreach (var item in _player.ControlledCharacters)
            {
                this.finalValue += (int)(item.BuffedHP.IntValue * 2.5);
            }

            this.questText = "Heal " + finalValue + " damage during Hard battles.";
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if(_difficulty == 2)
            {
                this.currentValue += _healingDone;
                if (currentValue >= finalValue)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveHardQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }

    public class VeryHardHealing : PlayerQuest
    {
        public VeryHardHealing()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            this.currentValue = 0;

            foreach (var item in _player.ControlledCharacters)
            {
                this.finalValue += (int)(item.BuffedHP.IntValue * 3.0);
            }

            this.questText = "Heal " + finalValue + " damage during Very Hard battles.";
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if(_difficulty == 4)
            {
                this.currentValue += _healingDone;
                if (currentValue >= finalValue)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveVeryHardQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }

    #endregion

    #region Damage quests

    public class VeryEasyDamage : PlayerQuest
    {
        public VeryEasyDamage()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            this.currentValue = 0;

            foreach (var item in _player.ControlledCharacters)
            {
                this.finalValue += (int)(item.BuffedHP.IntValue * 3.0);
            }

            this.questText = "Deal " + finalValue + " damage during Very Easy battles.";
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if (_difficulty == -4)
            {
                this.currentValue += _damageDone;
                if (currentValue >= finalValue)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveVeryEasyQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }

    public class EasyDamage : PlayerQuest
    {
        public EasyDamage()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            this.currentValue = 0;

            foreach (var item in _player.ControlledCharacters)
            {
                this.finalValue += (int)(item.BuffedHP.IntValue * 4.0);
            }

            this.questText = "Deal " + finalValue + " damage during Easy battles.";
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if (_difficulty == -2)
            {
                this.currentValue += _damageDone;
                if (currentValue >= finalValue)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveEasyQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }

    public class NormalDamage : PlayerQuest
    {
        public NormalDamage()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            this.currentValue = 0;

            foreach (var item in _player.ControlledCharacters)
            {
                this.finalValue += (int)(item.BuffedHP.IntValue * 5.0);
            }

            this.questText = "Deal " + finalValue + " damage during Normal battles.";
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if (_difficulty == 0)
            {
                this.currentValue += _damageDone;
                if (currentValue >= finalValue)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveNormalQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }

    public class HardDamage : PlayerQuest
    {
        public HardDamage()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            this.currentValue = 0;

            foreach (var item in _player.ControlledCharacters)
            {
                this.finalValue += (int)(item.BuffedHP.IntValue * 6.0);
            }

            this.questText = "Deal " + finalValue + " damage during Hard battles.";
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if (_difficulty == 2)
            {
                this.currentValue += _damageDone;
                if (currentValue >= finalValue)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveHardQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }

    public class VeryHardDamage : PlayerQuest
    {
        public VeryHardDamage()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            this.currentValue = 0;

            foreach (var item in _player.ControlledCharacters)
            {
                this.finalValue += (int)(item.BuffedHP.IntValue * 7.0);
            }

            this.questText = "Deal " + finalValue + " damage during Very Hard battles.";
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if (_difficulty == 4)
            {
                this.currentValue += _damageDone;
                if (currentValue >= finalValue)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveVeryHardQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }

    #endregion
    
    #region Class Quests
    public class VeryEasyClass : PlayerQuest
    {
        List<EnumCharClass> classList = new List<EnumCharClass>();

        public VeryEasyClass()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            classList = Function.PlayerQuestHandler.ReturnClassesForQuest(_player, 3);
            this.currentValue = 0;
            this.finalValue = 3;
            this.questText = "Defeat 3 opponents of Very Easy difficulty with a " + classList[0] + ", " + classList[1] + " or " + classList[2];
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if (classList.Count == 0)
            {
                classList = Function.PlayerQuestHandler.ReturnClassesForQuest(_player, 3);
                this.questText = "Defeat 3 opponents of Very Easy difficulty with a " + classList[0] + ", " + classList[1] + " or " + classList[2];
            }

            if (_difficulty == -4 && classList.Any(x => x == _class))
            {
                this.currentValue++;
                if (currentValue == finalValue)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveVeryEasyQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }

    public class EasyClass : PlayerQuest
    {
        List<EnumCharClass> classList = new List<EnumCharClass>();

        public EasyClass()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            classList = Function.PlayerQuestHandler.ReturnClassesForQuest(_player, 3);
            this.currentValue = 0;
            this.finalValue = 3;
            this.questText = "Defeat 3 opponents of Easy difficulty with a " + classList[0] + ", " + classList[1] + " or " + classList[2];
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if (classList.Count == 0)
            {
                classList = Function.PlayerQuestHandler.ReturnClassesForQuest(_player, 3);
                this.questText = "Defeat 3 opponents of Easy difficulty with a " + classList[0] + ", " + classList[1] + " or " + classList[2];
            }

            if (_difficulty == -2 && classList.Any(x => x == _class))
            {
                this.currentValue++;
                if (currentValue == finalValue)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveEasyQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }

    public class NormalClass : PlayerQuest
    {
        List<EnumCharClass> classList = new List<EnumCharClass>();

        public NormalClass()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            classList = Function.PlayerQuestHandler.ReturnClassesForQuest(_player, 2);
            this.currentValue = 0;
            this.finalValue = 3;
            this.questText = "Defeat 3 opponents of Normal difficulty with a " + classList[0] + " or a " + classList[1];
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if (classList.Count == 0)
            {
                classList = Function.PlayerQuestHandler.ReturnClassesForQuest(_player, 2);
                this.questText = "Defeat 3 opponents of Normal difficulty with a " + classList[0] + " or a " + classList[1];
            }

            if (_difficulty == 0 && classList.Any(x => x == _class))
            {
                this.currentValue++;
                if (currentValue == finalValue)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveNormalQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }

    public class HardClass : PlayerQuest
    {
        List<EnumCharClass> classList = new List<EnumCharClass>();

        public HardClass()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            classList = Function.PlayerQuestHandler.ReturnClassesForQuest(_player, 1);
            this.currentValue = 0;
            this.finalValue = 3;
            this.questText = "Defeat 3 opponents of Hard difficulty with a " + classList[0];
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if (classList.Count == 0)
            {
                classList = Function.PlayerQuestHandler.ReturnClassesForQuest(_player, 1);
                this.questText = "Defeat 3 opponents of Hard difficulty with a " + classList[0];
            }

            if (_difficulty == 2 && classList.Any(x => x == _class))
            {
                this.currentValue++;
                if (currentValue == finalValue)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveHardQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }

    public class VeryHardClass : PlayerQuest
    {
        List<EnumCharClass> classList = new List<EnumCharClass>();

        public VeryHardClass()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            classList = Function.PlayerQuestHandler.ReturnClassesForQuest(_player, 1);
            this.currentValue = 0;
            this.finalValue = 3;
            this.questText = "Defeat 3 opponents of Very Hard difficulty with a " + classList[0];
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if (classList.Count == 0)
            {
                classList = Function.PlayerQuestHandler.ReturnClassesForQuest(_player, 1);
                this.questText = "Defeat 3 opponents of Very Hard difficulty with a " + classList[0];
            }

            if (_difficulty == 4 && classList.Any(x => x == _class))
            {
                this.currentValue++;
                if (currentValue == finalValue)
                    this.EndQuest(_player);
            }
            
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveVeryHardQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }
    #endregion

    #region Health Percent Quests

    public class VeryEasyPercentRemaining : PlayerQuest
    {
        public VeryEasyPercentRemaining()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            this.currentValue = 0;
            this.finalValue = 3;
            this.questText = "Defeat 3 opponents of Very Easy difficulty with less than 35% health remaining";
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if (_difficulty == -4 && (_charPercent < 0.35))
            {
                this.currentValue++;
                if (currentValue == finalValue)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveVeryEasyQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }

    public class EasyPercentRemaining : PlayerQuest
    {
        public EasyPercentRemaining()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            this.currentValue = 0;
            this.finalValue = 3;
            this.questText = "Defeat 3 opponents of Easy difficulty with less than 30% health remaining";
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if (_difficulty == -2 && (_charPercent < 0.30))
            {
                this.currentValue++;
                if (currentValue == finalValue)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveEasyQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }

    public class NormalPercentRemaining : PlayerQuest
    {
        public NormalPercentRemaining()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            this.currentValue = 0;
            this.finalValue = 3;
            this.questText = "Defeat 3 opponents of Normal difficulty with less than 25% health remaining";
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if (_difficulty == 0 && (_charPercent < 0.25))
            {
                this.currentValue++;
                if (currentValue == finalValue)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveNormalQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }

    public class HardPercentRemaining : PlayerQuest
    {
        public HardPercentRemaining()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            this.currentValue = 0;
            this.finalValue = 3;
            this.questText = "Defeat 3 opponents of Hard difficulty with less than 20% health remaining";
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if (_difficulty == 2 && (_charPercent < 0.20))
            {
                this.currentValue++;
                if (currentValue == finalValue)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveHardQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }

    public class VeryHardPercentRemaining : PlayerQuest
    {
        public VeryHardPercentRemaining()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            this.currentValue = 0;
            this.finalValue = 3;
            this.questText = "Defeat 3 opponents of Very Hard difficulty with less than 15% health remaining";
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if (_difficulty == 4 && (_charPercent < 0.15))
            {
                this.currentValue++;
                if (currentValue == finalValue)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveVeryHardQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }

    #endregion

    #region NPC Type Quests
    public class VeryEasyNPCType : PlayerQuest
    {
        EnumMonsterType monsterType;

        public VeryEasyNPCType()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            monsterType = Function.PlayerQuestHandler.ReturnRandomMonsterType();
            this.currentValue = 0;
            this.finalValue = 3;
            this.questText = "Defeat 3 " + monsterType + " of Very Easy difficulty";
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if (monsterType == null)
            {
                monsterType = Function.PlayerQuestHandler.ReturnRandomMonsterType();
                this.questText = "Defeat 3 " + monsterType + " of Very Easy difficulty";
            }

            if (_difficulty == -4 && monsterType == _enemy.TypeOfNPC)
            {
                this.currentValue++;
                if (currentValue == finalValue)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveVeryEasyQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }

    public class EasyNPCType : PlayerQuest
    {
        EnumMonsterType monsterType;

        public EasyNPCType()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            monsterType = Function.PlayerQuestHandler.ReturnRandomMonsterType();
            this.currentValue = 0;
            this.finalValue = 3;
            this.questText = "Defeat 3 " + monsterType + " of Easy difficulty";
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if (monsterType == null)
            {
                monsterType = Function.PlayerQuestHandler.ReturnRandomMonsterType();
                this.questText = "Defeat 3 " + monsterType + " of Easy difficulty";
            }

            if (_difficulty == -2 && monsterType == _enemy.TypeOfNPC)
            {
                this.currentValue++;
                if (currentValue == finalValue)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveVeryEasyQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }

    public class NormalNPCType : PlayerQuest
    {
        EnumMonsterType monsterType;

        public NormalNPCType()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            monsterType = Function.PlayerQuestHandler.ReturnRandomMonsterType();
            this.currentValue = 0;
            this.finalValue = 3;
            this.questText = "Defeat 3 " + monsterType + " of Normal difficulty";
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if (monsterType == null)
            {
                monsterType = Function.PlayerQuestHandler.ReturnRandomMonsterType();
                this.questText = "Defeat 3 " + monsterType + " of Normal difficulty";
            }

            if (_difficulty == 0 && monsterType == _enemy.TypeOfNPC)
            {
                this.currentValue++;
                if (currentValue == finalValue)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveVeryEasyQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }

    public class HardNPCType : PlayerQuest
    {
        EnumMonsterType monsterType;

        public HardNPCType()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            monsterType = Function.PlayerQuestHandler.ReturnRandomMonsterType();
            this.currentValue = 0;
            this.finalValue = 3;
            this.questText = "Defeat 3 " + monsterType + " of Hard difficulty";
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if (monsterType == null)
            {
                monsterType = Function.PlayerQuestHandler.ReturnRandomMonsterType();
                this.questText = "Defeat 3 " + monsterType + " of Hard difficulty";
            }

            if (_difficulty == 2 && monsterType == _enemy.TypeOfNPC)
            {
                this.currentValue++;
                if (currentValue == finalValue)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveVeryEasyQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }

    public class VeryHardNPCType : PlayerQuest
    {
        EnumMonsterType monsterType;

        public VeryHardNPCType()
        {
        }

        public override void InitiateQuest(Player _player)
        {
            monsterType = Function.PlayerQuestHandler.ReturnRandomMonsterType();
            this.currentValue = 0;
            this.finalValue = 3;
            this.questText = "Defeat 3 " + monsterType + " of Very Hard difficulty";
        }

        public override void UpdateQuest(Player _player, int _difficulty, NPC _enemy, int _healingDone, int _damageDone, double _charPercent, EnumCharClass _class)
        {
            if (monsterType == null)
            {
                monsterType = Function.PlayerQuestHandler.ReturnRandomMonsterType();
                this.questText = "Defeat 3 " + monsterType + " of Very Hard difficulty";
            }

            if (_difficulty == 4 && monsterType == _enemy.TypeOfNPC)
            {
                this.currentValue++;
                if (currentValue == finalValue)
                    this.EndQuest(_player);
            }
        }

        public override void EndQuest(Player _player)
        {
            this.currentValue = 0;
            PlayerQuestHandler.GiveVeryEasyQuestReward(_player, PlayerQuestHandler.ChooseQuestRewardType());
            this.questcompleted = true;
        }
    }
    #endregion

    #endregion
}
