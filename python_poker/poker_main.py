# https://github.com/robcthegeek/Katas/blob/poker-hands/Poker-Hands.md

'''
Pit both hands against each other
'''

from poker_hand import Hand
from poker_deck import Deck
from hand_evaluation import ScoreHand


deck_obj = Deck()
deck = deck_obj.get_shuffled()

hand1_obj = Hand()
hand1 = hand1_obj.build_hand(deck, 5).order_hand()

hand2_obj = Hand()
hand2 = hand2_obj.build_hand(deck, 5)
