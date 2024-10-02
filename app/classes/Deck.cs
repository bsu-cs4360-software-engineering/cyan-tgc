public class Deck {
    private List<Card> cards;

    public Deck() {
        cards = new List<Card>();
    }

    public void AddCard(Card card) {
        cards.Add(card);
    }

    public Card DrawCard() {
        if (cards.Count == 0) {
            throw new InvalidOperationException("No cards left in the deck.");
        }
        Card drawnCard = cards[0];
        cards.RemoveAt(0);
        return drawnCard;
    }

    public void Shuffle() {
        if (cards.Count <= 1) return;
        Random rand = new Random();
        for (int i = 0; i < cards.Count; i++) {
            int j = rand.Next(i, cards.Count);
            (cards[i], cards[j]) = (cards[j], cards[i]);
        }
    }

    public int Count => cards.Count;

    public override string ToString() {
        return string.Join("\n", cards);
    }
}