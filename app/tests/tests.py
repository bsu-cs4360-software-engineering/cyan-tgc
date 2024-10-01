import unittest
from card import Card, CardType
from hand import Hand
from deck import Deck

class TestCard(unittest.TestCase):
    def test_card_init(self):
        card = Card("Fireball", 5, CardType.DAMAGE, 10, "A powerful fire spell.")
        self.assertEqual(card.name, "Fireball")
        self.assertEqual(card.cost, 5)
        self.assertEqual(card.type, CardType.DAMAGE)
        self.assertEqual(card.power, 10)
        self.assertEqual(card.description, "A powerful fire spell.")

    def test_card_invalid_cost(self):
        with self.assertRaises(ValueError):
            Card("InvalidCard", -1, CardType.DAMAGE, 10, "Invalid cost.")

    def test_card_invalid_power(self):
        with self.assertRaises(ValueError):
            Card("InvalidCard", 5, CardType.DAMAGE, -1, "Invalid power.")

class TestHand(unittest.TestCase):
    def setUp(self):
        self.hand = Hand()

    def test_hand_init(self):
        self.assertEqual(self.hand.count, 0)

    def test_add_card(self):
        card = Card("Fireball", 5, CardType.DAMAGE, 10, "A powerful fire spell.")
        self.hand.add_card(card)
        self.assertEqual(self.hand.count, 1)
        self.assertEqual(self.hand.cards[0].name, "Fireball")

    def test_add_card_exceeds_max_size(self):
        for _ in range(Hand.MAX_HAND_SIZE):
            self.hand.add_card(Card("Card", 1, CardType.HEAL, 1, "Test card."))
        with self.assertRaises(ValueError):
            self.hand.add_card(Card("Overflow Card", 1, CardType.HEAL, 1, "Shouldn't be added."))

    def test_play_card(self):
        card = Card("Fireball", 5, CardType.DAMAGE, 10, "A powerful fire spell.")
        self.hand.add_card(card)
        played_card = self.hand.play_card(0)
        self.assertEqual(played_card.name, "Fireball")
        self.assertEqual(self.hand.count, 0)

    def test_remove_card(self):
        card = Card("Fireball", 5, CardType.DAMAGE, 10, "A powerful fire spell.")
        self.hand.add_card(card)
        removed_card = self.hand.remove_card(0)
        self.assertEqual(removed_card.name, "Fireball")
        self.assertEqual(self.hand.count, 0)

    def test_play_card_invalid_index(self):
        with self.assertRaises(IndexError):
            self.hand.play_card(0) # No cards to play

    def test_remove_card_invalid_index(self):
        with self.assertRaises(IndexError):
            self.hand.remove_card(0)

    def test_clear_hand(self):
        card1 = Card("Fireball", 5, CardType.DAMAGE, 10, "A powerful fire spell.")
        card2 = Card("Healing Light", 3, CardType.HEAL, 5, "A healing spell.")
        self.hand.add_card(card1)
        self.hand.add_card(card2)
        self.hand.clear_hand()
        self.assertEqual(self.hand.count, 0)

class TestDeck(unittest.TestCase):
    def setUp(self):
        self.deck = Deck()

    def test_deck_init(self):
        self.assertEqual(self.deck.count, 0)

    def test_add_card_to_deck(self):
        card = Card("Fireball", 5, CardType.DAMAGE, 10, "A powerful fire spell.")
        self.deck.add_card(card)
        self.assertEqual(self.deck.count, 1)

    def test_draw_card_empty_deck(self):
        with self.assertRaises(ValueError):
            self.deck.draw_card()
    
    def test_draw_card(self):
        card = Card("Fireball", 5, CardType.DAMAGE, 10, "A powerful fire spell.")
        self.deck.add_card(card)
        drawn_card = self.deck.draw_card()
        self.assertEqual(drawn_card.name, "Fireball")
        self.assertEqual(self.deck.count, 0)

    def test_shuffle_deck(self):
        card1 = Card("Fireball", 5, CardType.DAMAGE, 10, "A powerful fire spell.")
        card2 = Card("Healing Light", 3, CardType.HEAL, 5, "A healing spell.")
        self.deck.add_card(card1)
        self.deck.add_card(card2)
        self.deck.shuffle()
        self.assertEqual(self.deck.count, 2)

if __name__ == "__main__":
    unittest.main()