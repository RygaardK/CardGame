using Entities.Enums;

namespace Entities.Models;
public class CardDeck
{
    public int Id { get; set; }
    private const int NumberOfCards = 52;
    public List<Card> Cards = new();
    public Card CardPrototype = new();

    public List<Card> FillDeck()
    {
        for (int i = 0; i < NumberOfCards; i++)
        {
            CardSuit suite = (CardSuit)(Math.Floor((decimal)i / 13));
            int val = i % 13 + 2;
            Card cardCopy = (Card)CardPrototype.Clone();
            cardCopy.Rank = val;
            cardCopy.Suite = suite;
            Cards.Add(cardCopy);
        }
        return Cards;
    }

    public List<Card> ShuffleCards(List<Card> DeckOfCards)
    {
        int i, j;
        Random rnd = new();
        for (int k = 0; k < DeckOfCards.Count; k++)
        {
            i = (rnd.Next(NumberOfCards));
            j = (rnd.Next(NumberOfCards));
            (DeckOfCards[j], DeckOfCards[i]) = (DeckOfCards[i], DeckOfCards[j]);
        }
        return DeckOfCards;
    }
}

