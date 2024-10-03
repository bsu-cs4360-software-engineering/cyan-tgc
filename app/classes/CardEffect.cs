public class CardEffect {
    public string Type { get; set; }
    public int Value { get; set; }
    public List<string> Targets { get; set; }

    public CardEffect(string type, int value, List<string> targets) {
        Type = type;
        Value = value;
        Targets = targets ?? new List<string>();
    }
}