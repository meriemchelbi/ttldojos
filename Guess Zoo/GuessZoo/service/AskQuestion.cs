using System;
using System.Collections.Generic;
using System.Text;

namespace GuessZoo.service
{
    class AskQuestion
    {
        public string CaptureCriteria()
        {
            Console.WriteLine("\nEnter your guess. Is it a...?\n");
            var criterion = Console.ReadLine();

            return criterion;
        }
    }
}
