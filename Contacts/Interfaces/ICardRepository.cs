using Entities.Models;

namespace Contacts.Interfaces;
public interface ICardRepository
{
    Task<IEnumerable<CardHistory>> GetAllCardHistoryAsync(bool trackChanges);
    Task<CardHistory> GetCardHistoryAsync(int id, bool trackChanges);
    void CreateCardHistory(CardHistory card);
    void DeleteCardHistory(CardHistory card);
}
