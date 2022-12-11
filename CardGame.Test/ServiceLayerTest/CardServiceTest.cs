using AutoMapper;
using Contacts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Moq;
using Service;
using Service.Contracts.Interfaces;

namespace CardGame.Test.ServiceLayerTest;
public class CardServiceTest
{
    private readonly IServiceManager _serviceManager;
    private readonly Mock<IRepositoryManager> _repositoryManagerMock = new();
    private readonly Mock<ILoggerManager> _loggerManagerMock = new();
    private readonly Mock<IMapper> _mapperMock = new();

    public CardServiceTest()
    {
        _serviceManager = new ServiceManager(_repositoryManagerMock.Object, _loggerManagerMock.Object, _mapperMock.Object);
    }

    public IEnumerable<CardHistory> GetAll() =>
        new CardHistory[]
        {
            new CardHistory (){Id = 1,CardOne = "1 a",CardTwo = "1 a",CardThree = "1 a",CardFour = "1 a",CardFive = "1 a"},
            new CardHistory (){Id = 1,CardOne = "1 a",CardTwo = "1 a",CardThree = "1 a",CardFour = "1 a",CardFive = "1 a"},
            new CardHistory (){Id = 1,CardOne = "1 a",CardTwo = "1 a",CardThree = "1 a",CardFour = "1 a",CardFive = "1 a"}
        };

    public List<Card> StartNewDeck()
    {
        List<Card> DeckOfCards = new();
        CardDeck cardDeck = new();
        DeckOfCards = cardDeck.FillDeck();
        return DeckOfCards;
    }

    [Fact]
    public void GetAllCardHistoryAsync()
    {
        //Arrange
        bool trackChanges = false;
        IEnumerable<CardHistory> cards = GetAll();

        //Act
        _repositoryManagerMock.Setup(x => x.CardHistory.GetAllCardHistoryAsync(trackChanges)).ReturnsAsync(cards);

        //Assert
        Assert.Equal(3, cards.Count());
    }

    [Fact]
    public void StartNewDeck_CheckDeckOf52()
    {
        //Arrange
        var deck = new List<Card>();
        int deckLengt = 52;

        //Act
        deck = StartNewDeck();

        //Assert
        Assert.Equal(deckLengt, deck.Count());
    }

    [Fact]
    public void CheckIfDeckIsFilled()
    {
        //Arrange
        var deck = new List<Card>{
            new Card(),
            new Card(),
            new Card(),
                  };

        //Assert
        Assert.Throws<DeckNotFilled>(() => _serviceManager.CardService.CheckIfDeckIsFilled(deck));
    }
}
