using System;
using System.Diagnostics;
using System.Windows.Threading;

namespace TPA.Simulator.Physics
{
    class GameTime
    {
        public DispatcherTimer GameTimer;
        public Stopwatch GameClock;
        public int GameSpeedInMilliseconds { get; set; }
        public TimeSpan GameDuration { get; set; }

        public GameTime()
        {
            LoadTimers();
            //GameSpeedInMilliseconds = 1000;
            GameTimer.Tick += TimerTick;
        }

        public string ElapsedTime()
        {
            return String.Format("{0:D2}:{1:D2}:{2:D2}",
                GameDuration.Hours,
                GameDuration.Minutes,
                GameDuration.Seconds);
        }

        public void LoadTimers()
        {
            GameTimer = new DispatcherTimer();
            GameTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            GameTimer.Start();
            GameClock = Stopwatch.StartNew();
        }

        public void TimerTick(object sender, EventArgs e)
        {
            GameDuration = GameClock.Elapsed;
        }

    }
}
