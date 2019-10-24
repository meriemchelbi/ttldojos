using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BowlingSolution
{
    
    public class BowlingTests
    {
        [Theory]
        [InlineData("X X X X X X X X X X X X", "555555555555", "555555555555")]
        public void TestLoadGameScores(string scoresString, string round1Scores, string round2Scores)
        {
            Assert.Equal(scoresString, round1Scores);
        }

        [Fact]
        public void TestTotalScoreComputed()
        {
            // Given collection of frames
            // When total score computed
            // Then score matches expected value
        }

    }
}
