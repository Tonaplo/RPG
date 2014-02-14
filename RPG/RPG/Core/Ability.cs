using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using System.IO;
using RPG.Core.Units;

namespace RPG.Core
{
    public class Ability
    {
        string abilityName;
        string description;
        string icon;
        EnumAbilityClassReq classReq;

        public Ability(Character _char, string _abilityName, string _description, Image _icon, EnumAbilityClassReq _classRep)
        {
            this.abilityName = _abilityName;
            this.description = _description;
            this.SetIcon(_icon);
            this.classReq = _classRep;
        }

        /// <summary>
        /// Used only for XML Serialization
        /// </summary>
        public Ability()
        { }

        #region Properties

        public string AbilityName
        {
            get { return abilityName; }
            set { abilityName = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public EnumAbilityClassReq ClassReq
        {
            get { return classReq; }
            set { classReq = value; }
        }

        public Image GetIcon()
        {
            return Function.GeneralFunctions.Base64ToImage(icon);
        }

        public string SetIcon(Image _icon)
        {
            icon = Function.GeneralFunctions.ImageToBase64(_icon, System.Drawing.Imaging.ImageFormat.Png);
            return icon;
        }

        public string Icon
        {
            get { return icon; }
            set{ icon = value; }
        }

        #endregion
    }
}
