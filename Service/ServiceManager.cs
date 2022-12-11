using AutoMapper;
using Contacts.Interfaces;
using Service.Contracts.Interfaces;

namespace Service;
public class ServiceManager : IServiceManager
{
    private readonly Lazy<CardService> _cardHistoryService;
    private readonly Lazy<HandService> _handService;
    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager
    logger, IMapper mapper)
    {
        _cardHistoryService = new Lazy<CardService>(() => new
        CardService(repositoryManager, logger, mapper));

        _handService = new Lazy<HandService>(() => new
        HandService(repositoryManager, logger, mapper));
    }
    public ICardService CardService => _cardHistoryService.Value;
    public IHandService HandService => _handService.Value;
}
