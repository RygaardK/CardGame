namespace Service.Contracts.Interfaces;
public interface IServiceManager
{
    ICardService CardService { get; }
    IHandService HandService { get; }
}
