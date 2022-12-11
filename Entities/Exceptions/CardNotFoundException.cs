namespace Entities.Exceptions;
public class CardNotFoundException : NotFoundException
{
    public CardNotFoundException(int id) : base($"Card med id {id} finns inte i databasen")
    {

    }
}
