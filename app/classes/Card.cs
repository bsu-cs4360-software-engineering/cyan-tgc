using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Card {
    [BsonId]
    public ObjectId Id { get; set; }
    public string Name { get; set; }
    public int Cost { get; set; }
    public string Element { get; set; }
    public CardEffect Effect { get; set; }
    public string Description { get; set; }

    public Card(string name, int cost, string element, CardEffect effect, string description) {
        Name = name;
        Element = element;
        Cost = cost;
        Effect = effect;
        Description = description;
    }

    public bool CanPlay(Hero hero) {
        return hero.Mana >= Cost;
    }

    public override string ToString() {
        return $"{Name} ({Element}), Cost: {Cost}\n{Description}";
    }
}