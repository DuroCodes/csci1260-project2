using Project2.Models;

namespace Project2.Services;

public class CharacterService
{
    private static readonly Dictionary<string, Character> Characters = new()
    {
        {
            "Joe",
            new Character(
                "Joe",
                "Player",
                "Joe is the main character of the game. He is a brave adventurer that is trying to escape the maze. Joe has a lot of health and can deal a lot of damage",
                100,
                10,
                "images/joe.png"
            )
        },
        {
            "Elon",
            new Character(
                "Elon",
                "Monster",
                "Elon is a powerful monster that can deal a lot of damage (from stealing your wages 😭). Make sure you have some health potions ready whenever you encounter him.",
                100,
                10,
                "images/elon.png"
            )
        },
        {
            "Goblin",
            new Character(
                "Goblin",
                "Monster",
                "Goblins are weak monsters that can be easily defeated. They have low health and deal low damage.",
                50,
                5,
                "images/goblin.png"
            )
        },
        {
            "Ogre",
            new Character(
                "Ogre",
                "Monster",
                "Ogres are relatively strong monsters that can sneak up on you if you're not careful. They have a lot of health and deal a lot of damage.",
                75,
                7,
                "images/ogre.png"
            )
        }
    };

    public static IEnumerable<IGrouping<string, Character>> GetCharacterGroups() =>
        Characters.Values.GroupBy(c => c.Type);

    public static bool TryGetCharacter(string name, out Character? character) =>
        Characters.TryGetValue(name, out character);
}