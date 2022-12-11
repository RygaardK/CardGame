namespace Entities.Exceptions;
public class DeckNotFilled : NotFoundException
{
    public DeckNotFilled() : base("DeckOfCards saknar kort för att fortsätta!")
    {
    }
}
