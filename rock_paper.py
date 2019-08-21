import unittest
from random import choice



outcomes_list = ['rock', 'scissors', 'paper']    

outcomes_dict = {
    'rock-scissors': 'Rock blunt scissors!',
    'scissors-paper': 'Scissors cut paper!',
    'paper-rock': 'Paper covers rock!'
}

def generate_hand(outcomes_list):
    hand = choice(outcomes_list)
    return hand

def play(hand1, hand2, outcomes_dict):
    
    print('hand1:', hand1)
    print('hand12:', hand2)

    if hand1 == 'scissors' and hand2 == 'rock' or hand1 == 'rock' and hand2 == 'scissors':
        outcome = outcomes_dict['rock-scissors']
    elif hand1 == 'scissors' and hand2 == 'paper' or hand1 == 'paper' and hand2 == 'scissors':
        outcome = outcomes_dict['scissors-paper']
    elif hand1 == 'rock' and hand2 == 'paper' or hand1 == 'paper' and hand2 == 'rock':
        outcome = outcomes_dict['paper-rock']
    elif hand1 == hand2:
        outcome = "DRAW!"
    else:
        outcome = "WTF??"
        
    print(outcome)
    return outcome

hand1 = generate_hand(outcomes_list)
hand2 = generate_hand(outcomes_list)

play(hand1, hand2, outcomes_dict)
