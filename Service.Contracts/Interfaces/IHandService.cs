using SharedHelpers.DataTransferObjects;

namespace Service.Contracts.Interfaces
{
    public interface IHandService
    {
        Task<CardHistoryDto> SaveHandAsync(HandForCreationDto hand);
    }
}
