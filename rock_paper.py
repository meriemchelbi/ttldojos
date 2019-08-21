import unittest
from random import choice

class RockPaperScissors():

    outcomes_list = ['rock', 'scissors', 'paper']    

    outcomes_dict = {
        'rock-scissors': 'Rock blunt scissors!',
        'scissors-paper': 'Scissors cut paper!',
        'paper-rock': 'Paper covers rock'
    }

    # generate generate outcome for hand

    def generate_hand(outcomes_list):
        hand = choice(outcomes_list)
        print(hand)
        return hand

    def play(hand1, hand2):

        if hand1 == 'scissors' and hand2 == 'rock' or hand1 == 'rock' and hand2 == 'scissors':
            action = outcomes_dict['rock-scissors']
        elif hand1 == 'scissors' and hand2 == 'paper' or hand1 == 'paper' and hand2 == 'scissors':
            outcome = outcomes_dict['scissors-paper']
        elif hand1 == 'rock' and hand2 == 'paper' or hand1 == 'paper' and hand2 == 'rock':
            outcome = outcomes_dict['paper-rock']
        elif hand1 == hand2:
            outcome = "DRAW!"
            
        print(outcome)
        return outcome

# tests https://docs.python.org/3/library/unittest.html
class RockPaperTests(unittest.TestCase):
    def scissors_cut_paper(self):
        self.assertEqual(1, 1, 'Paper covers rock')

if __name__ == '__main__':
    unittest.main()