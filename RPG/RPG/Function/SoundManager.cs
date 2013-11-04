using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Windows;
using System.Reflection;
using System.Windows.Media;
using System.IO;

namespace RPG.Function
{
    public static class SoundManager
    {
        private static SoundPlayer backMusic1;
        private static SoundPlayer backMusic2;

        public static void InitializeSounds()
        {
           
            backMusic1 = new SoundPlayer(Properties.Resources.backmusic1);
            backMusic2 = new SoundPlayer(Properties.Resources.backmusic2);

        }

        public static void PlayButtonSound()
        {
            //test.Play();
            //buttonSound.Play(1.0f, 0.0f, 0.0f);
        }

        public static void PlayMainMenuMusic()
        {
            backMusic1.PlayLooping();
            //backMusic1.IsLooped = true;
            //backMusic1.Play();
        }

        public static void PauseMainMenuMusic()
        {
            //backMusic1.Pause();
        }

        public static void StopMainMenuMusic()
        {
            //backMusic1.Stop();
        }

        public static void ResumeMainMenuMusic()
        {
            //backMusic1.Resume();
        }

        public static void PlayBattleMusic()
        {
            //backMusic2.IsLooped = true;
            //backMusic2.Play();
        }

        public static void PauseBattleMusic()
        {
            //backMusic2.Pause();
        }

        public static void ResumeBattleMusic()
        {
            //backMusic2.Resume();
        }

        public static void StopBattleMusic()
        {
            //backMusic2.Stop();
        }
    }
}
