using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Hero {
    [BsonId]
    public ObjectId Id { get; set; }
    public string Name { get; set; }
    public int Health { get; set; }
    public int Mana { get; set; }
    public Dictionary<string, double> Mastery { get; set; }
    public string Description { get; set; }

    public Hero(string name, int health, int mana, Dictionary<string, double> mastery, string description) {
        Name = name;
        Health = health;
        Mana = mana;
        Mastery = mastery;
        Description = description;
    }

    public bool SpendMana(int amount) {
        if (amount > Mana) {
            return false;
        }
        Mana -= amount;
        return true;
    }

    public void TakeDamage(int amount) {
        Health = Math.Max(0, Health - amount);
    }

    public override string ToString() {
        return $"{Name} - Health: {Health}, Mana: {Mana}";
    }
}