using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public enum CardType {
    Damage,
    Armor,
    Heal
}

public class Card {
    [BsonId]
    public ObjectId Id { get; set; }

    public string Name { get; set; }
    public int Cost { get; set; }

    public CardType Type { get; set; }
    public int Value { get; set; }

    public string Description { get; set; }

    public Card(string name, int cost, CardType type, int value, string description) {
        Name = name;
        Cost = cost;
        Type = type;
        Value = value;
        Description = description;
    }

    public bool CanPlay(Hero hero) {
        return hero.Mana >= Cost;
    }

    public override string ToString() {
        return $"{Name} ({Type}), Cost: {Cost}, Value: {Value}\n{Description}";
    }
}