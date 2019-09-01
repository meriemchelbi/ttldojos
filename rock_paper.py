import unittest
from random import choice

class RockPaperScissors():

    def __init__(self):
        self.outcomes_list = ['rock', 'scissors', 'paper']    

        self.outcomes_dict = {
            'rock-scissors': 'Rock blunt scissors!',
            'scissors-paper': 'Scissors cut paper!',
            'paper-rock': 'Paper covers rock'
        }

    # generate generate outcome for hand

    def generate_hand(self, outcomes_list):
        hand = choice(outcomes_list)
        print(hand)
        return hand

    def play(self, hand1, hand2):

        if hand1 == 'scissors' and hand2 == 'rock' or hand1 == 'rock' and hand2 == 'scissors':
            outcome = self.outcomes_dict['rock-scissors']
        elif hand1 == 'scissors' and hand2 == 'paper' or hand1 == 'paper' and hand2 == 'scissors':
            outcome = self.outcomes_dict['scissors-paper']
        elif hand1 == 'rock' and hand2 == 'paper' or hand1 == 'paper' and hand2 == 'rock':
            outcome = self.outcomes_dict['paper-rock']
        elif hand1 == hand2:
            outcome = "DRAW!"
            
        print(outcome)
        return outcome

# tests https://docs.python.org/3/library/unittest.html
class RockPaperTests(unittest.TestCase):
    def test_scissors_cut_paper(self):
        self.assertEqual(game.play('scissors','paper'), 'Scissors cut paper!')

game = RockPaperScissors()
if __name__ == '__main__':
    unittest.main()

