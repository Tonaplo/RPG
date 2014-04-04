using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace RPG.Core
{
    public class Player
    {
        #region Fields
        private string userName;
        private string password;
        private List<Units.Character> controlledCharacters = new List<Units.Character>();
        private List<Item> inventoryOfPlayer = new List<Item>();
        private int dust = 0;
        private PlayerQuest currentQuest = null;
        private PlayerSettings settings = new PlayerSettings(RPG.Function.ServerManagement.GetRunningVersion());
        #endregion

        #region Constructors
        
        /// <summary>
        /// Constructor for the Player
        /// </summary>
        public Player(string _name, string _pw)
        {
            this.userName = _name;
            this.password = _pw;
            this.inventoryOfPlayer = new List<Item>();
            this.ControlledCharacters = new List<Units.Character>();
            this.dust = 0;
        }

        /// <summary>
        /// COnstructor only used for XML Serialization.
        /// </summary>
        public Player()
        {
            this.inventoryOfPlayer = new List<Item>();
            this.ControlledCharacters = new List<Units.Character>();
        }

        #endregion

        #region Properties

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public List<Units.Character>  ControlledCharacters
        {
            get { return controlledCharacters; }
            set { controlledCharacters = value; }
        }

        public List<Item> InventoryOfPlayer
        {
            get { return inventoryOfPlayer; }
            set { inventoryOfPlayer = value; }
        }

        public int Dust
        {
            get { return dust; }
            set { dust = value; }
        }

        public PlayerQuest CurrentQuest
        {
            get { return currentQuest; }
            set { currentQuest = value; }
        }

        public PlayerSettings Settings
        {
            get { return settings; }
            set { settings = value; }
        }

        #endregion

        #region Functions

        /// <summary>
        /// This Function is used to add a character to a player. A player may have a maximum of 6 characters.
        /// </summary>
        /// <param name="_character">The character to be added</param>
        public void AddCharacter(Units.Character _character)
        {
            if (this.ControlledCharacters.Count < 4)
                this.ControlledCharacters.Add(_character);
            else
            {
                RPG.UI.MessageForm mes = new RPG.UI.MessageForm("You cannot have more than 4 characters");
                mes.ShowDialog();
            }
        }

        /// <summary>
        /// This Function is used to remove a character from a player.
        /// </summary>
        /// <param name="_character">The character to be removed</param>
        public void RemoveCharacter(Units.Character _character)
        {
            if (this.ControlledCharacters.Contains(_character))
                this.ControlledCharacters.Remove(_character);
            else
            {
                RPG.UI.MessageForm mes = new RPG.UI.MessageForm("An error occured while trying to remove a character");
                mes.ShowDialog();
            }
        }

        /// <summary>
        /// This Function is used to add an item to a players inventory. The inventory can hold a maximum of 30 items.
        /// </summary>
        /// <param name="_item">The item to be added</param>
        public void AddItemToInventory(Item _item)
        {
            if (this.inventoryOfPlayer.Count < 30)
                this.inventoryOfPlayer.Add(_item);
            else
            {
                RPG.UI.MessageForm mes = new RPG.UI.MessageForm("You cannot have more than 30 items in your inventory");
                mes.ShowDialog();
            }
        }

        /// <summary>
        /// This Function is used to add an item to a players inventory. The inventory can hold a maximum of 30 items.
        /// </summary>
        /// <param name="_item">The item to be added</param>
        public void RemoveItemToInventory(Item _item)
        {
            if (this.inventoryOfPlayer.Contains(_item))
                this.inventoryOfPlayer.Remove(_item);
            else
            {
                RPG.UI.MessageForm mes = new RPG.UI.MessageForm("An error occured while trying to remove an item from the inventory");
                mes.ShowDialog();
            }
        }
        #endregion
    }
}
