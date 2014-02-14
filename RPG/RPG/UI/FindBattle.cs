using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RPG;
using RPG.Core;

namespace RPG.UI
{
    public partial class FindBattle : Form
    {
        private Core.EnumBattleMode mode = EnumBattleMode.Single;

        public FindBattle()
        {
            InitializeComponent();
        }

        public Core.EnumBattleMode BattleModeChoosen()
        {
            return mode;
        }

        private void bnSingle_Click(object sender, EventArgs e)
        {
            mode = EnumBattleMode.Single;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void bnLocalMulti_Click(object sender, EventArgs e)
        {
            mode = EnumBattleMode.Local;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btSinglePlayer_Click(object sender, EventArgs e)
        {
            MessageForm form = new MessageForm("This mode is currently unavailable.");
            form.ShowDialog();
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
