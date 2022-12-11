using Entities.Enums;

namespace SharedHelpers.DataTransferObjects;
public record CardDto
{
    public int Rank { get; set; }
    public CardSuit Suite { get; set; }
    public bool IsChecked { get; set; }
    public string? NamedValue { get; set; }
}


