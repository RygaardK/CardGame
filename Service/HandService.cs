using AutoMapper;
using Contacts.Interfaces;
using Entities.Models;
using Service.Contracts.Interfaces;
using SharedHelpers.DataTransferObjects;

namespace Service;
public class HandService : IHandService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    public HandService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<CardHistoryDto> SaveHandAsync(HandForCreationDto hand)
    {
        _logger.LogInfo("SaveHandAsync körs, hand som sparas:" + hand.CardOne + hand.CardTwo + hand.CardThree + hand.CardFour + hand.CardFive);
        var cardHistoryEntity = _mapper.Map<CardHistory>(hand);
        _repository.CardHistory.CreateCardHistory(cardHistoryEntity);
        await _repository.SaveAsync();
        var cardHistoryToReturn = _mapper.Map<CardHistoryDto>(cardHistoryEntity);
        return cardHistoryToReturn;
    }
}
