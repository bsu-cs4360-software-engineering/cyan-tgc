using DotNetEnv;

class Program {
    public static async Task Main(string[] args) {
        if (args.Length > 0 && args[0] == "insert") {
            await RunInsertion(false, false);
        } else {
            string connectionString = "mongodb+srv://guest:KfWLTPmOiQFblrch@m0.l2w43.mongodb.net/?retryWrites=true&w=majority&appName=M0";
            Database db = new Database(connectionString);
            var dataLoader = new Loader(db);

            await dataLoader.LoadDataAsync();

            if (dataLoader.Heroes != null && dataLoader.Heroes.Any()) {
                foreach (var hero in dataLoader.Heroes) {
                    Console.WriteLine($"Hero: {hero.Name}");
                }
            } else {
                Console.WriteLine("No heroes found.");
            }

            if (dataLoader.Cards != null && dataLoader.Cards.Any()) {
                foreach (var card in dataLoader.Cards) {
                    Console.WriteLine($"Card: {card.Name}");
                }
            } else {
                Console.WriteLine("No cards found.");
            }
        }
        
    }

    private static async Task RunInsertion(bool insertHeroes, bool insertCards) {
        Env.Load("../");

        var connectionString = Env.GetString("CON_STR");
        Database db = new Database(connectionString);

        var heroes = new List<Hero> {
            new Hero(
                "Apostle of Light", // Hero Name
                35, // Hero Health (Int)
                20, // Hero Mana (Int)
                new Dictionary<string, double>{ { "Light", 0.25 } }, // Mastery
                "An Apostle of the Light." // Hero Description
            )
        };

        if (insertHeroes) {
            foreach (var heroI in heroes) {
                await db.CreateHeroAsync(heroI);
                Console.WriteLine($"Hero '{heroI.Name}' inserted successfully!");
            }
        } else {
            Console.WriteLine("Hero insertion skipped.");
        }

        var cards = new List<Card> {
            new Card(
                "Healing Light", // Card Name
                3, // Card Cost
                CardType.Heal, // Card Type
                5, // Effect Value
                "Heals the caster for 5" // Card Description
            )
        };

        if (insertCards) {
            foreach (var card in cards) {
                await db.CreateCardAsync(card);
                Console.WriteLine($"Card '{card.Name}' inserted successfully!");
            }
        } else {
            Console.WriteLine("Card insertion skipped.");
        }
    }
}