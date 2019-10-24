using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("What are the scores, George Dawes?");
            var userInput = Console.ReadLine();
            var bowlingGame = new BowlingGame(userInput);
            bowlingGame.LoadGameScores();


        }
    }
}
