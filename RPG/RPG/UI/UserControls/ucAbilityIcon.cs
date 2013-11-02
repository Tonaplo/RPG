using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RPG
{
    public partial class ucAbilityIcon : UserControl
    {
        Core.Ability ucAbility;
        System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();

        public ucAbilityIcon(Core.Ability _ability)
        {
            InitializeComponent();

            ucAbility = _ability;
            pictureBoxIcon.Image = ucAbility.GetIcon();
        }

        private void pictureBoxIcon_MouseEnter(object sender, EventArgs e)
        {
            string classre = "";

            if (ucAbility.ClassReq == Core.EnumAbilityClassReq.ANY)
            {
                classre = "Can be used by any class";
            }

            else
            {
                classre = "Can be used by the " + ucAbility.ClassReq.ToString().ToLower() + " class.";
            }


            toolTip.ForeColor = Color.Yellow;
            toolTip.ToolTipTitle = ucAbility.AbilityName;
            toolTip.Show(ucAbility.Description + "\n\n" + classre, pictureBoxIcon, 5000);
        }

        private void pictureBoxIcon_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(this);
        }
    }
}
