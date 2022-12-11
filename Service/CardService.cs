using AutoMapper;
using Contacts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts.Interfaces;
using SharedHelpers.DataTransferObjects;

namespace Service;
public class CardService : ICardService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly int deckSize = 52;
    public CardDeck DeckCard { get; set; } = new CardDeck();
    public CardService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CardHistoryDto>> GetAllCardHistoryAsync(bool trackChanges)
    {
        _logger.LogInfo("GetAllCardHistoryAsync körs");
        var cardHistory = await _repository.CardHistory.GetAllCardHistoryAsync(trackChanges);
        var cardHistoryDto = _mapper.Map<IEnumerable<CardHistoryDto>>(cardHistory);
        return cardHistoryDto;
    }

    public async Task<List<CardDto>> StartNewDeckAsync()
    {
        _logger.LogInfo("StartNewDeckAsync körs");
        var newDeck = DeckCard.FillDeck();
        newDeck = ShuffleDeckOfCards(newDeck);
        var newDeckDto = _mapper.Map<List<CardDto>>(newDeck);
        return await Task.FromResult(newDeckDto.ToList());
    }

    public List<Card> ShuffleDeckOfCards(List<Card> DeckOfCards)
    {
        _logger.LogInfo("ShuffleDeckOfCards körs, antal i listan: " + DeckOfCards.Count.ToString());
        CheckIfDeckIsFilled(DeckOfCards);
        DeckOfCards = DeckCard.ShuffleCards(DeckOfCards);
        return DeckOfCards;
    }

    public bool CheckIfDeckIsFilled(List<Card> cards)
    {
        if (cards.Count < deckSize)
        {
            _logger.LogError($"ShuffleDeckOfCards körs, DECK NOT FILLED! Antal kort: " + cards.Count.ToString() + new DeckNotFilled());
            throw new DeckNotFilled();
        }
        _logger.LogInfo("ShuffleDeckOfCards körs, antal kort som kommer ut: " + cards.Count.ToString());
        return true;
    }

    public async Task DeleteCardHistoryAsync(int id, bool trackChanges)
    {
        await _repository.CardHistory.GetCardHistoryAsync(id, trackChanges);
        var cardHistory = await _repository.CardHistory.GetCardHistoryAsync(id, trackChanges);
        if(cardHistory != null) 
            _logger.LogInfo("DeleteCardHistoryAsync körs, Hand som kastas: " + cardHistory.CardOne + cardHistory.CardTwo + cardHistory.CardThree + cardHistory.CardFour + cardHistory.CardFive + ", från id: " + id.ToString());
        else
            _logger.LogWarn("DeleteCardHistoryAsync körs utan att hitta id: " + id.ToString());
        _repository.CardHistory.DeleteCardHistory(cardHistory);
        await _repository.SaveAsync();
    }
}
