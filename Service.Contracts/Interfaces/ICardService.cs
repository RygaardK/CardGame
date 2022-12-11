using Entities.Models;
using SharedHelpers.DataTransferObjects;

namespace Service.Contracts.Interfaces;
public interface ICardService
{
    Task<IEnumerable<CardHistoryDto>> GetAllCardHistoryAsync(bool trackChanges);
    Task<List<CardDto>> StartNewDeckAsync();
    List<Card> ShuffleDeckOfCards(List<Card> DeckOfCrads);
    bool CheckIfDeckIsFilled(List<Card> cards);
    Task DeleteCardHistoryAsync(int id, bool trackChanges);
}
