using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    // Start is called before the first frame update
    // private Room corridor;
    // private Room barracks;
    // private Room hall;
    // private Room cave;
    public Room[,] map;
    public int maxHeight;
    public int maxWidth;

    public void Initialize()
    {
        // Initialize each Room object
        Room corridor = new Room("Corridor", "What a lovely Corridor!");
        Room barracks = new Room("Barracks", "These barracks are massive!");
        Room hall = new Room("Hall", "Woah, that's a creepy and empty hall...");
        Room cave = new Room("Cave", "This cave echoes in the darkness...");
        Room library = new Room("Library", "Books line every wall, the smell of parchment fills the air.");
        Room armory = new Room("Armory", "Rows of weapons and armor lie here, forgotten by time.");
        Room kitchen = new Room("Kitchen", "The kitchen is cold, with pots still hanging above the counter.");
        Room throneRoom = new Room("Throne Room", "The throne sits empty, an air of abandonment in the grand hall.");
        Room dungeon = new Room("Dungeon", "Chains and shackles dangle from the stone walls.");
        Room treasury = new Room("Treasury", "Piles of gold and jewels gleam under the dim light.");
        Room garden = new Room("Garden", "An overgrown garden with tangled vines and strange flowers.");
        Room observatory = new Room("Observatory", "The night sky can be seen through a broken telescope.");
        Room cellar = new Room("Cellar", "Dusty barrels and crates are stacked in this cold, damp room.");
        Room chapel = new Room("Chapel", "An old chapel with shattered stained-glass windows.");
        Room shopkeeper = new SpecialRoom("Shop Keeper", "You entered the shop!", Resources.Load<Sprite>("Art/NPC/ShopKeeper"));
        Room witch = new Room("Witch", "You lose 5 health for walking upon the with!");
        Room enchantress = new Room("Enchantress", "You walked upon the enchantress!");
        
        map = new Room[,] {
            {corridor, shopkeeper, armory, dungeon},
            {hall, cave, kitchen, treasury},
            {throneRoom, cellar, library, garden},
            {observatory, chapel, barracks, witch}
        };

        maxHeight = map.GetLength(0);
        maxWidth = map.GetLength(1);
    }

}