# https://github.com/robcthegeek/Katas/blob/poker-hands/Poker-Hands.md

# Create a poker hand from a deck

class Hand():
    
    def __init__(self):
        
        self.hand = []

    def order_hand(self):

    # sort hand by rank from low to high (Aces high by default)
        for card in self.hand:
            (rank, suit) = card
            sorted(self.hand, rank)
        return self.hand
    
    def build_hand(self, deck, cards):
        
        if len(deck) > 0:
            for i in range(cards):
                card = deck.pop(-1)
                self.hand.append(card)
        else:
            pass
        
        self.hand = self.order_hand()

        return self.hand


           