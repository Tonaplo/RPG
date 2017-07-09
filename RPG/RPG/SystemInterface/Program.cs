using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RPG.Core;
using RPG.Core.Units;
using RPG.Core.Items;
using RPG.Core.Abilities;
using RPG.Function;
using System.IO;

namespace RPG
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region Initialization
            ItemGeneration.ItemGenerationInitialization();
            WorldGeneration.InitializeWorldGeneration();
            #endregion

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            List<Player> playerList = ServerManagement.LoadPlayers("players.xml");
            SoundManager.InitializeSounds();

            playerList = ServerManagement.LoadFromFolder(Path.Combine(Environment.SpecialFolder.MyDocuments.ToString(), "/The Legend of Eiwar/players.xml"));
                
            if (playerList == null)
            {
                playerList = new List<Player>();
            }

            LoginForm lf = new LoginForm(playerList);
            Application.Run(lf);

            if (lf.DialogResult == DialogResult.OK)
            {
                Player player = lf.ReturnedPlayer();
                Application.Run(new MainWindow(player, playerList));
            }
            
        }
    }
}
