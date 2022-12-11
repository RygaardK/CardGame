namespace Contacts.Interfaces;
public interface IRepositoryManager
{
    ICardRepository CardHistory { get; }
    Task SaveAsync();
}
