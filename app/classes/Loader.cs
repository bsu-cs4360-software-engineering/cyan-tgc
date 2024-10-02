public class Loader {
    private readonly Database _database;
    public List<Hero>? Heroes { get; private set; }
    public List<Card>? Cards { get; private set; }

    public Loader(Database database) {
        _database = database;
    }

    public async Task LoadDataAsync() {
        Heroes = await _database.GetHeroesAsync();
        Cards = await _database.GetCardsAsync();
    }
}