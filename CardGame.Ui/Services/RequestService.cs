using SharedHelpers.DataTransferObjects;
using System.Net.Http.Json;

namespace CardGame.Ui.Services;
public class RequestService : IRequestService
{
    private readonly HttpClient _httpClient;
    public RequestService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<IEnumerable<CardHistoryDto>> GetAllCardHistorysAsync()
    {
        var respons = await _httpClient.GetFromJsonAsync<IEnumerable<CardHistoryDto>>("card");
        return respons!;
    }

    public async Task<List<CardDto>> StartNewDeck()
    {
        var respons = await _httpClient.GetFromJsonAsync<List<CardDto>>("card/deck");
        return respons!;
    }

    public async Task SaveHand(string hand)
    {
        HandForCreationDto handToSave = new HandForCreationDto();

        List<string> allCardsStored;
        allCardsStored = hand.Split(",").ToList();

        string[] cardsSplited = allCardsStored.ToArray();
        handToSave = SetHand(cardsSplited, handToSave);

        await _httpClient.PostAsJsonAsync("hand", handToSave);
    }

    public HandForCreationDto SetHand(string[] SplitedCard, HandForCreationDto hand)
    {
        hand.CardOne = SplitedCard[0];
        hand.CardTwo = SplitedCard[1];
        hand.CardThree = SplitedCard[2];
        hand.CardFour = SplitedCard[3];
        hand.CardFive = SplitedCard[4];
        return hand;
    }

    public async Task RemoveCard(int id)
    {
         await _httpClient.DeleteAsync($"card/delete/{id}");
    }
}

