using MongoDB.Bson;
using MongoDB.Driver;

public class Database {
    private readonly IMongoCollection<Hero> _heroesCollection;
    private readonly IMongoCollection<Card> _cardsCollection;

    public Database(string connectionString) {
        try {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("4360TCG");

            _heroesCollection = database.GetCollection<Hero>("Heroes");
            _cardsCollection = database.GetCollection<Card>("Cards");
        } catch (Exception ex) {
            Console.WriteLine($"Failed to connect to the database: {ex.Message}");
            throw;
        }
    }

    public async Task<List<Hero>> GetHeroesAsync() {
        return await _heroesCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<List<Card>> GetCardsAsync() {
        return await _cardsCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task CreateHeroAsync(Hero hero) {
        await _heroesCollection.InsertOneAsync(hero);
    }

    public async Task CreateCardAsync(Card card) {
        await _cardsCollection.InsertOneAsync(card);
    }
}