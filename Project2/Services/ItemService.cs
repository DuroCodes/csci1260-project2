using Project2.Models;

namespace Project2.Services;

public class ItemService
{
    private static readonly Dictionary<string, Item> Items = new()
    {
        {
            "Health Potion",
            new Item(
                "Health Potion",
                "Consumable",
                "Restores 10 health points when consumed.",
                "images/health-potion.png"
            )
        },
        {
            "Mana Potion",
            new Item(
                "Mana Potion",
                "Consumable",
                "Restores 10 mana points when consumed.",
                "images/mana-potion.png"
            )
        },
        {
            "Sword",
            new Item(
                "Sword",
                "Weapon",
                "A sharp blade that deals 10 damage.",
                "images/sword.jpg"
            )
        },
        {
            "Shield",
            new Item(
                "Shield",
                "Armor",
                "Provides protection and reduces damage taken by 5.",
                "images/shield.png"
            )
        }
    };

    public static IEnumerable<IGrouping<string, Item>> GetItemGroups() =>
        Items.Values.GroupBy(c => c.Type);

    public static bool TryGetItem(string name, out Item? character) =>
        Items.TryGetValue(name, out character);
}