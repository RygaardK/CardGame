using CardGame.Presentation.Controllers;
using Entities.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Service.Contracts.Interfaces;
using SharedHelpers.DataTransferObjects;

namespace CardGame.Test.ControllerTests;

public class CardControllerTest
{
    private readonly bool trackChanges = false;

    [Theory]
    [InlineData(200)] 
    public async Task GetAllCardHistoryAsync(int statusCode)
    {
        //Arrange
        var mockservice = new Mock<IServiceManager>();
        mockservice
            .Setup(x => x.CardService.GetAllCardHistoryAsync(trackChanges))
            .ReturnsAsync(new List<CardHistoryDto>());
        var sut = new CardController(mockservice.Object);

        //Act
        var result = (OkObjectResult)await sut.GetCardHistory();

        //Assert
        result.StatusCode.Should().Be(statusCode);
    }

    [Theory]
    [InlineData(204)]
    [InlineData(400)]
    [InlineData(500)]
    public async Task GetAllCardsAsync(int statusCode)
    {
        //Arrange
        var mockservice = new Mock<IServiceManager>();
        mockservice
            .Setup(x => x.CardService.GetAllCardHistoryAsync(trackChanges))
            .ReturnsAsync(new List<CardHistoryDto>());
        var sut = new CardController(mockservice.Object);

        //Act
        var result = (OkObjectResult)await sut.GetCardHistory();

        //Assert
        result.StatusCode.Should().NotBe(statusCode);
    }

    [Theory]
    [InlineData(200)] 
    private async Task StartNewDeckMocked(int statusCode)
    {
        //Arrange
        var mockservice = new Mock<IServiceManager>();
        mockservice
            .Setup(x => x.CardService.StartNewDeckAsync())
            .ReturnsAsync(new List<CardDto>());
        var sut = new CardController(mockservice.Object);

        //Act
        var result = (OkObjectResult)await sut.StartNewDeck();

        //Assert
        result.StatusCode.Should().Be(statusCode);
    }

    [Theory]
    [InlineData(200)]
    
    public async Task DeleteCardHistoryAsync(int statusCode)
    {
        //Arrange
        var cardTemp = new CardHistory { Id = 1 };
        var mockservice = new Mock<IServiceManager>();
        mockservice
          .Setup(x => x.CardService.DeleteCardHistoryAsync(cardTemp.Id, trackChanges));
        var sut = new CardController(mockservice.Object);

        //Act
        var result = (OkResult)await sut.DeleteCardHistory(cardTemp.Id);

        //Assert
        result.StatusCode.Should().Be(statusCode);
    }
}
