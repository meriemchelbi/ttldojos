using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingSolution
{
    public class BowlingGame
    {
        private string scoresString;

        public BowlingGame(string scoresString)
        {
            this.scoresString = scoresString;
        }

        public List<Frame> Scores { get; private set; }

        public void LoadGameScores()
        {
            throw new NotImplementedException();
        }
    }
}
