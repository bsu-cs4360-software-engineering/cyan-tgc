import random

class Deck:
    def __init__(self):
        self.cards = []

    def add_card(self, card):
        self.cards.append(card)

    def draw_card(self):
        if not self.cards:
            raise ValueError("No cards left in the deck.")
        drawn_card = self.cards.pop(0)
        return drawn_card
    
    def shuffle(self):
        if len(self.cards) <= 1:
            return
        random.shuffle(self.cards)

    @property
    def count(self):
        return len(self.cards)
    
    def __str__(self):
        return "\n".join(str(card) for card in self.cards)