import unittest
from poker_deck import Deck
from poker_hand import Hand
from hand_evaluation import ScoreHand

class TestDeck(unittest.TestCase):

    # test length of deck is 52 cards and all cards unique
    def test_build_deck(self):
        
        my_deck = deck.build_deck()
        self.assertEqual(len(my_deck), 52)
        self.assertEqual(my_deck[0], ("two", "clubs"))
        self.assertEqual(my_deck[-1], ("ace", "spades"))
        
        deck_dict = { i: "card" for i in my_deck}
        self.assertEqual(len(deck_dict), 52)
    
    def test_shuffle_deck(self):
        
        shuffled_deck = deck.shuffle_deck()
        self.assertEqual(len(shuffled_deck), 52)
        
        deck_dict = { i: "card" for i in shuffled_deck}
        self.assertEqual(len(deck_dict), 52)        

class TestHand(unittest.TestCase):

    def test_build_hand(self):
        
        deck = Deck()
        deck = deck.get_shuffled()
        my_hand = hand.build_hand(deck, 5)
        
        self.assertEqual(len(my_hand), 5)
        self.assertEqual(len(deck), 47)

    # def test_order_hand(self):

    #     # not sure how to test this
    #     hand2 = [('four', 'hearts'), ('king', 'diamonds'), ('three', 'spades'), ('ten', 'hearts'), ('seven', 'clubs')]
    #     self.assertEqual(order_hand(hand2), [('three', 'spades'), ('four', 'hearts'), ('seven', 'clubs'), ('ten', 'hearts'), ('king', 'diamonds')])

deck = Deck()
hand = Hand()

if __name__ == '__main__':
    unittest.main()

    
