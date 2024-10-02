class Hand:
    MAX_HAND_SIZE = 10

    def __init__(self):
        self.cards = []

    def add_card(self, card):
        if len(self.cards) >= self.MAX_HAND_SIZE:
            raise ValueError("Cannot add more cards to hand. Maximum size reached.")
        self.cards.append(card)

    def play_card(self, index):
        card_to_play = self.remove_card(index)
        return card_to_play
    
    def remove_card(self, index):
        if index < 0 or index >= len(self.cards):
            raise IndexError("Invalid card index.")
        return self.cards.pop(index)
    
    def clear_hand(self):
        self.cards.clear()

    @property
    def count(self):
        return len(self.cards)
    
    def __str__(self):
        return "\n".join(str(card) for card in self.cards)