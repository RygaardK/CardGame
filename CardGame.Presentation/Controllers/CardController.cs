using Microsoft.AspNetCore.Mvc;
using Service.Contracts.Interfaces;

namespace CardGame.Presentation.Controllers;
[Route("card")]
[ApiController]
public class CardController : ControllerBase
{
    private readonly IServiceManager _service;
    public CardController(IServiceManager service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetCardHistory()
    {
        var cardHistory = await _service.CardService.GetAllCardHistoryAsync(trackChanges: false);
        return Ok(cardHistory);
    }

    [HttpGet("deck")]
    public async Task<IActionResult> StartNewDeck()
    {
        var newDeck = await _service.CardService.StartNewDeckAsync();
        return Ok(newDeck);
    }

    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> DeleteCardHistory(int id)
    {
        await _service.CardService.DeleteCardHistoryAsync(id, trackChanges:false);
        return Ok();
    }
}
