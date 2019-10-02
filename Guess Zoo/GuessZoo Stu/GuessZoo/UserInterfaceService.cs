using System;
using System.Threading;
using GuessZoo.domain;
using GuessZoo.service;

namespace GuessZoo
{
    public interface IUserInterfaceService
    {
        void PlayGame(IManagementSvc managementSvc);
    }

    public class UserInterfaceService : IUserInterfaceService
    {
        private IManagementSvc _managementSvc;

        public void PlayGame(IManagementSvc managementSvc)
        {
            _managementSvc = managementSvc;
            WriteOutRemainingCards();
            OfferSelection();
        }

        public void OfferSelection()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Would you like to ask a question [1] or guess the chosen one [2]?");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.KeyChar=='1')
                Ask();
            else if (key.KeyChar == '2')
            {
                Guess();
                return;
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Oops, it seems you entered something other than a 1 or a 2. It's pretty simple, either a 1 or a 2...");
            }

            WriteOutRemainingCards();
            OfferSelection();
        }

        private void Ask()
        {
            Console.WriteLine("");
            Console.WriteLine("What would you like to guess about: Colour (1), Animal (2) or Adjective (3)");
            ConsoleKeyInfo key = Console.ReadKey();
            Descriptor? descriptorFromSelection = GetDescriptorFromSelection(key.KeyChar);
            if (!descriptorFromSelection.HasValue)
            {
                Console.WriteLine("");
                Console.WriteLine("Oops, it seems you entered something other than a 1, 2 or a 3. It's pretty simple, either a 1, 2 or a 3...");
                OfferSelection();
                return;
            }
            Console.WriteLine("");
            Console.WriteLine($"Which {descriptorFromSelection.Value} would you like to suggest?");
            string ask = Console.ReadLine();
            _managementSvc.AddQuestion(descriptorFromSelection.Value, ask);
        }

        private Descriptor? GetDescriptorFromSelection(char selectedKey)
        {
            if (selectedKey == '1') return Descriptor.Colour;
            if (selectedKey == '2') return Descriptor.Animal;
            if (selectedKey == '3') return Descriptor.Adjective;
            return null;
        } 

        private void Guess()
        {
            Console.WriteLine("");
            Console.WriteLine("OK, we're guessing!");
            Console.WriteLine("First: which colour?");
            string colour = Console.ReadLine();
            Console.WriteLine("Hmmmm maybe, secondly: which animal?");
            string animal = Console.ReadLine();
            Console.WriteLine("haha, oh seriously? Right, finally: which adjective?");
            string adjective = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("OK, I'll have a look to see if you're right");
            Thread.Sleep(2000);

            bool correctGuess = _managementSvc.Guess(colour, animal, adjective);
            if (correctGuess)
                Console.WriteLine("Hurrah, you are a winner!");
            else
                Console.WriteLine("Boooo! You are a Looooooooser!");
        }

        public void WriteOutRemainingCards()
        {
            Console.WriteLine("");Console.WriteLine("");
            Console.WriteLine("Here are your current options...");
            foreach (Card card in _managementSvc.RemainingCards)
            {
                Console.WriteLine(card.ToString());
            }
        }
    }
}