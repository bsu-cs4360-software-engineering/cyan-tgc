from pymongo import MongoClient

class Database:
    def __init__(self, connection_string):
        try:
            self.client = MongoClient(connection_string)
            self.database = self.client["4360TCG"]

            # self.heroes_collection = self.database["Heroes"]
            self.cards_collection = self.database["Cards"]
        except Exception as ex:
            print(f"Failed to connect to the database: {ex}")
            raise

    # async def get_heroes(self):
    #     heroes = await self.heroes_collection.find().to_list(length=None)
    #     return heroes
    
    async def get_cards(self):
        cards = await self.cards_collection.find().to_list(length=None)
        return cards
    
    # async def create_hero(self, hero):
    #     await self.heroes_collection.insert_one(hero)

    async def create_card(self, card):
        await self.cards_collection.insert_one(card)