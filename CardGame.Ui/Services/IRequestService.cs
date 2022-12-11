using SharedHelpers.DataTransferObjects;

namespace CardGame.Ui.Services;
public interface IRequestService
{
    Task<IEnumerable<CardHistoryDto>> GetAllCardHistorysAsync();
    Task<List<CardDto>> StartNewDeck();
    Task SaveHand(string Hand);
    Task RemoveCard(int id);
}
