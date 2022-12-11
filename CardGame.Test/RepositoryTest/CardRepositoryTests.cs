using Contacts.Interfaces;
using Entities.Models;
using Moq;

namespace CardGame.Test.RepositoryTest;
public class CardRepositoryTests
{
    private readonly Mock<IRepositoryManager> _repositoryManagerMock = new();

    public IEnumerable<CardHistory> GetAll() =>
        new CardHistory[]
        {
            new CardHistory (){Id = 1,CardOne = "1 a",CardTwo = "1 a",CardThree = "1 a",CardFour = "1 a",CardFive = "1 a"},
            new CardHistory (){Id = 1,CardOne = "1 a",CardTwo = "1 a",CardThree = "1 a",CardFour = "1 a",CardFive = "1 a"},
            new CardHistory (){Id = 1,CardOne = "1 a",CardTwo = "1 a",CardThree = "1 a",CardFour = "1 a",CardFive = "1 a"}
        };

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(12)]
    public void GetCardHistoryAsync(int id)
    {
        //Arrange
        var cardHistoryId = id;
        bool trackChanges = false;
        CardHistory card = new CardHistory
        {
            Id = cardHistoryId
        };

        //Act
        _repositoryManagerMock.Setup(x => x.CardHistory.GetCardHistoryAsync(cardHistoryId, trackChanges));

        //Assert
        Assert.Equal(id, card.Id);
    }

    [Theory]
    [InlineData(3)]
    public void GetCardHistoryListAsync(int count)
    {
        //Arrange
        IEnumerable<CardHistory> cards = GetAll();
        bool trackChanges = false;

        //Act
        _repositoryManagerMock.Setup(x => x.CardHistory.GetAllCardHistoryAsync(trackChanges)).ReturnsAsync(cards);

        //Assert
        Assert.Equal(count, cards.Count());
    }

}