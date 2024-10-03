from enum import Enum
from bson import ObjectId

class CardType(Enum):
    DAMAGE = "Damage"
    ARMOR = "Armor"
    HEAL = "Heal"

class Card:
    def __init__(self, name: str, cost: int, card_type: CardType, power: int, description: str):
        if cost < 0:
            raise ValueError("Cost cannot be negative.")
        if power < 0:
            raise ValueError("Power cannot be negative.")

        self.id = ObjectId()
        self.name = name
        self.cost = cost
        self.type = card_type
        self.power = power
        self.description = description

    def can_play(self, hero):
        return hero.mana >= self.cost
    
    def __str__(self):
        return f"{self.name} ({self.type.value}), Cost: {self.cost}, Value: {self.value}\n{self.description}"