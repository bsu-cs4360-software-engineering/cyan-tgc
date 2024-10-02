public class Hand {
    private List<Card> cards;
    private const int MaxHandSize = 10;

    public Hand() {
        cards = new List<Card>();
    }

    public void AddCard(Card card) {
        if (cards.Count >= MaxHandSize) {
            throw new InvalidOperationException("Cannot add more cards to hand. Maximum size reached.");
        }
        cards.Add(card);
    }

    public Card PlayCard(int index) {
        if (index < 0 || index >= cards.Count) {
            throw new ArgumentOutOfRangeException("Invalid card index.");
        }
        Card cardToPlay = cards[index];
        cards.RemoveAt(index);
        return cardToPlay;
    }

    public void ClearHand() {
        cards.Clear();
    }

    public int Count => cards.Count;

    public override string ToString() {
        return string.Join("\n", cards);
    }
}