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

            Deck deck = new Deck();
            Hand hand = new Hand();

            if (dataLoader.Cards != null && dataLoader.Cards.Any()) {
                foreach (var card in dataLoader.Cards) {
                    deck.AddCard(card);
                }

                deck.Shuffle();
                Console.WriteLine("Deck initialized and shuffled.\n");

                while (true) {
                    Console.WriteLine("Choose an action:");
                    Console.WriteLine("1. Draw a card");
                    Console.WriteLine("2. Show hand");
                    Console.WriteLine("3. Play a card");
                    Console.WriteLine("4. Exit");
                    var choice = Console.ReadLine();

                    switch (choice) {
                        case "1":
                            try {
                                Card drawnCard = deck.DrawCard();
                                hand.AddCard(drawnCard);
                                Console.WriteLine($"Drew card: {drawnCard}");
                            } catch (Exception ex) {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        case "2":
                            Console.WriteLine("Your hand:");
                            Console.WriteLine(hand);
                            break;
                        case "3":
                            if (hand.Count == 0) {
                                Console.WriteLine("Your hand is empty.");
                            } else {
                                Console.WriteLine("Enter the index of the card to play (0 to {0}):", hand.Count - 1);
                                if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < hand.Count) {
                                    try {
                                        Card playedCard = hand.PlayCard(index);
                                        Console.WriteLine($"Played card: {playedCard}");
                                    } catch (Exception ex) {
                                        Console.WriteLine(ex.Message);
                                    }
                                } else {
                                    Console.WriteLine("Invalid index.");
                                }
                            }
                            break;
                        case "4":
                            return;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
            } else {
                Console.WriteLine("No cards found in the database.");
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