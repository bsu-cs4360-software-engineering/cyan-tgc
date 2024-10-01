class Loader:
    def __init__(self, database):
        self._database = database
        self.heroes = None
        self.cards = None

    async def load_data(self):
        self.heroes = await self._database.get_heroes()
        self.cards = await self._database.get_cards()