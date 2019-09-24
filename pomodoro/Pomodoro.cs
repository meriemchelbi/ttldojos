using System;
using System.Threading;
using System.Timers;

namespace _SepPomodoro
{
    public class Pomodoro
    {

        public int TomatoCount;
        public int TomatoCycleLength;

        public Pomodoro(int cycleLength)
        {
            TomatoCount = 0;
            TomatoCycleLength = cycleLength;
        }

        public void RunTomato()
        {
            Thread.Sleep(TomatoCycleLength);
            TomatoCount++;

            
        }

    }
}
