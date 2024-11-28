using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : Map
{
    public Level1()
    {
        // Level 1
        Room entranceTunnel = new Room("Entrance Tunnel", "A narrow passage marking the beginning of the cave.");
        Room echoingCavern = new Room("Echoing Cavern", "A vast, open space with distant, eerie sounds.");
        Room crystalChamber = new Room("Crystal Chamber", "The room glows with crystals. Their light is both beautiful and ominous.");
        Room undergroundStream = new Room("Underground Stream", "A stream flows through here, with slippery rocks.");
        Room batColony = new Room("Bat Colony", "Bats flutter above, their screeches echoing.");
        Room mushroomGrove = new Room("Mushroom Grove", "Bioluminescent mushrooms light up this dense grove. Some seem poisonous.");
        Room collapsedTunnel = new Room("Collapsed Tunnel", "A partially blocked tunnel. Proceed with caution.");
        Room hiddenAlcove = new Room("Hidden Alcove", "A small, secret room. What treasures might it hold?");
        Room rockfallTrap = new Room("Rockfall Trap", "The rocks here look unstable. Move carefully!");
        Room chasm = new Room("Chasm", "A massive gap blocks the way forward.");
        Room ancientShrine = new Room("Ancient Shrine", "An old altar, emanating a mysterious energy.");
        Room subterraneanLake = new Room("Subterranean Lake", "A still, dark lake stretches before you.");
        Room spiderNest = new Room("Spider Nest", "Webs cover the walls, and spiders scuttle in the shadows.");
        Room lavaPool = new Room("Lava Pool", "The heat here is intense, and lava bubbles dangerously.");
        Room caveBeastLair = new Room("Cave Beast's Lair", "The final challenge lies ahead: a ferocious beast guards this room.");
        Room shopkeeper = new SpecialRoom("Shop Keeper", "You entered the shop!", Resources.Load<Sprite>("Art/NPC/ShopKeeper"));
        Room lockedRedDoor = new Room("Red Door", "There is a big red door here. Seems locked.");

        map = new Room[,] {
            {entranceTunnel, echoingCavern, crystalChamber, ancientShrine},
            {undergroundStream, mushroomGrove, rockfallTrap, chasm},
            {batColony, collapsedTunnel, spiderNest, lavaPool},
            {hiddenAlcove, subterraneanLake, lockedRedDoor, shopkeeper}
        };
        
        maxHeight = map.GetLength(0);
        maxWidth = map.GetLength(1);
    }
}
