using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Windows;
using System.Reflection;
using System.Windows.Media;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.IO;

namespace RPG.Function
{
    public static class SoundManagerClass
    {
        private static SoundEffect buttonSound;
        private static SoundEffectInstance backMusic1;
        private static SoundEffectInstance backMusic2;
        private static SoundPlayer test;

        public static void InitializeSounds()
        {
            /*
            //buttonSound.URL = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("YourNamespace.IconFilename.ico");
            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream s = a.GetManifestResourceStream("RPG.Resources.chimes.wav");
            test = new SoundPlayer(Properties.Resources.buttonpress);
            //buttonSound = SoundEffect.FromStream();
            //buttonSound = new SoundEffect(
            
            //backMusic1 = SoundEffect.FromStream(Properties.Resources.ResourceManager.GetStream("backmusic1.wav")).CreateInstance();
            string lol = Directory.GetCurrentDirectory() + "\\Resources\\buttonpress.wav";
            Uri stupid = new Uri(lol, UriKind.Absolute);

            using (Stream what = new FileStream(lol, FileMode.Open))
            {
                buttonSound = SoundEffect.FromStream(what);//Application.GetResourceStream(stupid).Stream);
                what.Close();
            }
            
            */
        }

        public static void PlayButtonSound()
        {
            //test.Play();
            //buttonSound.Play(1.0f, 0.0f, 0.0f);
        }

        public static void PlayMainMenuMusic()
        {
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
