using Contacts.Interfaces;

namespace Repository;
public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<CardRepository> _cardRepository;
    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;

        _cardRepository = new Lazy<CardRepository>(() => new
        CardRepository(repositoryContext));
    }

    public ICardRepository CardHistory => _cardRepository.Value;
    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}
