using System;
using System.Collections.Generic;
using System.Media;
using System.Text;
using System.Windows.Media;

namespace TPA.Simulator.Audio
{
    class AudioPlayer
    {
        public List<SoundPlayer> Themes;
        public MediaPlayer CollidedBlock;
        public MediaPlayer DeleteLine;

        public AudioPlayer()
        {
            LoadAudioFiles();
            PlayMainThemeInLoop();
        }

        public void LoadAudioFiles()
        {
            Themes = new List<SoundPlayer>();
            CollidedBlock = new MediaPlayer();
            DeleteLine = new MediaPlayer();
            Themes.Add(new SoundPlayer(Properties.Resources.mainTheme));
        }

        public void PlayMainThemeInLoop()
        {
            // Themes[0].PlayLooping();
        }

        public void StopMainThemeLoop()
        {
            Themes[0].Stop();
        }

        public void PlayCollisionSound()
        {
            CollidedBlock.Open(new Uri("C:/Repositories/GitHub/The Polyominoes App/The Polyominoes App/TPA.Simulator/Audio/AudioFiles/collisionTetromino.wav"));
            CollidedBlock.Play();
        }

        public void PlayDeleteLine()
        {
            DeleteLine.Open(new Uri("C:/Repositories/GitHub/The Polyominoes App/The Polyominoes App/TPA.Simulator/Audio/AudioFiles/deleteLine.wav"));
            DeleteLine.Play();
        }

    }
}
