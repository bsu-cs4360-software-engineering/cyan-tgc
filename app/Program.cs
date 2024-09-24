using DotNetEnv;

class Program {
    public static async Task Main(string[] args) {
        if (args.Length > 0 && args[0] == "insert") {
            await RunInsertion(false, false);
        } else {
            string connectionString = "mongodb+srv://guest:KfWLTPmOiQFblrch@m0.l2w43.mongodb.net/?retryWrites=true&w=majority&appName=M0";
            Database db = new Database(connectionString);
            Console.WriteLine("Default Logic");
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
                "Fireball", // Card Name
                5, // Card Cost
                "Fire", // Element Type
                new CardEffect(
                    "Damage", // Effect Type ex. Damage, Heal
                    10, // Effect Value (Int)
                    new List<string> { "Enemy" } // Targets ex. Enemy, Self, Ally
                ),
                "Deals 10 damage to the target" // Card Description
            )
        };

        if (insertCards) {
            foreach (var cardI in cards) {
                await db.CreateCardAsync(cardI);
                Console.WriteLine($"Hero '{cardI.Name}' inserted successfully!");
            }
        } else {
            Console.WriteLine("Card insertion skipped.");
        }
    }
}