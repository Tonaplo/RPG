using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Core
{
    public class PlayerSettings
    {
        #region Constructors
        /// <summary>
        /// Empty constructor for XML serialization
        /// </summary>
        public PlayerSettings()
        { }

        /// <summary>
        /// This is the default player settings, when creating a new profile.
        /// </summary>
        public PlayerSettings(Version currentVersion)
        {
            this.thisVersion = currentVersion.ToString();
            this.soundOn = true;
            this.soundVolume = 10;
            this.prefDifficulty = 0;
            this.prefChars = new List<string>();
        }
        #endregion

        #region private variables
        private string thisVersion;
        private bool soundOn;
        private int soundVolume;
        private int prefDifficulty;
        private List<string> prefChars;
        #endregion

        #region Properties
        public string ThisVersion
        {
            get { return thisVersion; }
            set { thisVersion = value; }
        }
        public bool SoundOn
        {
            get { return soundOn; }
            set { soundOn = value; }
        }
        public int SoundVolume
        {
            get { return soundVolume; }
            set { soundVolume = value; }
        }
        public int PrefDifficulty
        {
            get { return prefDifficulty; }
            set { prefDifficulty = value; }
        }
        public List<string> PrefChars
        {
            get { return prefChars; }
            set { prefChars = value; }
        }
        #endregion

    }
}
