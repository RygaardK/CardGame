using Entities.Models;
using Microsoft.AspNetCore.Components;
using SharedHelpers.DataTransferObjects;

namespace CardGame.Ui.Pages;

public partial class Index : ComponentBase
{
    private List<CardDto> CardDeck = new List<CardDto>();
    private List<CardDto> CardsInHand = new List<CardDto>();
    private List<CardDto> RemovedCards = new();
    private readonly int cardLeft = 1;

    private bool GameStarted = false;

    protected override async Task OnInitializedAsync()
    {
        CardDeck = await _request.StartNewDeck();
    }
    private void StartGame()
    {
        CardsInHand = CardDeck.Take(5).ToList();
        GameStarted = true;
    }

    private void OnClick()
    {
        SaveHand();
        CardsInHand.RemoveAll(x => x.IsChecked == true);
        AddUsedCardToList(CardDeck);
        CardDeck.RemoveAll(x => x.IsChecked == true);
        GetMoreCardsIfNeeded();
        AddNewCards();
    }


    private void AddNewCards()
    {
        foreach (var card in CardDeck)
            if (CardsInHand.Count != 5 && !CardsInHand.Contains(card))
                CardsInHand.Add(card);
    }

    private void SaveHand()
    {
        string allCardsInOneString = "";
        for (int i = 0; i < CardsInHand.Count; i++)
            allCardsInOneString += ($"{CardsInHand[i].NamedValue} {CardsInHand[i].Suite},");
        _request.SaveHand(allCardsInOneString);
    }

    private void AddUsedCardToList(List<CardDto> fiveCards)
    {
        foreach (var card in fiveCards)
            if (card.IsChecked)
                RemovedCards.Add(card);
    }

    private void GetMoreCardsIfNeeded()
    {
        if (CardDeck.Count < cardLeft)
        {
            foreach(var card in RemovedCards) 
                card.IsChecked = true;
            CardDeck.AddRange(RemovedCards);
        }
    }
}
