using System;
using System.Timers;

namespace _SepPomodoro
{
    public class Pomodoro
    {

        public int _tomatoCount;
        public int _tomatoCycleLength;
        // private static System.Timers.Timer myTimer;

        public Pomodoro(int cycleLength)
        {
            _tomatoCount = 0;
            _tomatoCycleLength = cycleLength;
        }

        public void RunTomato()
        {
            Timer timer = new Timer(_tomatoCycleLength);
            timer.Start();
            _tomatoCount++;
            timer.Stop();
        }
    }
}
