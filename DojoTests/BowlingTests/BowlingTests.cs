using System;
using System.Collections.Generic;
using System.Text;
using BowlingSolution;
using Xunit;


namespace DojoTests.BowlingTests
{
    public class BowlingTests
    {
        [Theory]
        [InlineData("X X X X X X X X X X X X", "555555555555", "555555555555")]
        [InlineData("9- 9- 9- 9- 9- 9- 9- 9- 9- 9-", "9999999999", "0000000000")]
        [InlineData("5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/5", "55555555555", "00000000000")]

        public void TestLoadGameScores(string scoresString, string round1Scores, string round2Scores)
        {
            var bowling = new BowlingGame(scoresString);
            bowling.LoadGameScores();

            List<Frame> scores = bowling.Scores;

            for (int i = 0; i < scores.Count; i++)
            {
                var frame = scores[i];

                var round1Actual = frame.Round1;
                var round1Expected = int.Parse(round1Scores[i] + "");

                var round2Actual = frame.Round2;
                var round2Expected = int.Parse(round2Scores[i] + "");

                Assert.Equal(round1Expected, round1Actual);
                Assert.Equal(round2Expected, round2Actual);
            }
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
