# https://github.com/robcthegeek/Katas/blob/poker-hands/Poker-Hands.md

from random import shuffle

# Create a shuffled 52 card deck (no jokers)

class Card():

    def __init__(self, rank, suit):
        self.rank = rank
        self.suit = suit

class Deck():

    def __init__(self):

        self.deck = [] # deck variable (data type TBD)

    
    def build_deck(self):
        
        suits = ["clubs", "diamonds","hearts", "spades"]
        ranks = ["two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "jack", "queen", "king", "ace"]

        # Make cards & add to deck
        for suit in suits:
            for rank in ranks:
                # card = Card(rank, suit)
                card = (rank, suit)
                self.deck.append(card)

        return self.deck

    
    def shuffle_deck(self):
        
        shuffle(self.deck)

        return self.deck

    
    def get_shuffled(self):
        self.build_deck()
        self.shuffle_deck()
        return self.deck

