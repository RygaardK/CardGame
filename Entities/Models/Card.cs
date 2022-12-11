using Entities.Commons;
using Entities.Enums;

namespace Entities.Models;
public class Card : ICard
{
    public int Rank { get; set; }
    public CardSuit Suite { get; set; }
    public bool IsChecked { get; set; }

    public ICard Clone()
    {
        return (ICard)MemberwiseClone();
    }

    public string NamedValue
    {
        get
        {
            string name = string.Empty;
            name = Rank switch
            {
                (14) => $"Ace",
                (13) => $"King",
                (12) => $"Queen",
                (11) => $"Jack",
                _ => $"{Rank.ToString()}",
            };
            return name;
        }
    }
}
