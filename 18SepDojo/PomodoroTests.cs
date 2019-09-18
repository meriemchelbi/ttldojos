using System;
using Xunit;

namespace _SepPomodoro
{
    public class PomodoroTests
    {
        // Instantiate a Pomodoro object

        // Add method to start a stopwatch?
        // variable to log where in cycle? e.g. Cycle1, Pomodoro 3, short break 1, long break.

        
        [Theory]        
        public void UninterruptedPomodoroTimerAddsTomato()
        {
            // test completed pomodoro timer (25 mins) adds a tomato. 
            // Check new tomato count based on count at start of cycle

        }

        [Theory]
        public void ShortBreakTriggeredAfterUninterruptedPomodoro()
        {
            // Test 5 min break is triggered after first, second and third pomodoro cycle

        }

        [Fact]
        public void LongBreakTriggeredAfterFourthUninterruptedPomodoro()
        {
            // Test 30 min break is triggered after fourth cycle

        }

        [Theory]
        public void CheckTimeElapsedMatchesNumberOfTomatoes()
        {
            // Stop time at specific point and check correct number of tomatoes accumulated

        }
    }
}
