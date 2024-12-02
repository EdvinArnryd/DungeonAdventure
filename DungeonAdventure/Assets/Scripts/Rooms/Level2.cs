using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : Map
{
    public Level2()
    {
        // Level 2
        Room shadowedHall = new Room("Shadowed Hall", "A long, dark hallway with flickering lights and shadowy figures.");
        Room echoingChamber = new Room("Echoing Chamber", "Every sound here echoes, disorienting you.");
        Room bloodStainedRoom = new Room("Blood Stained Room", "Dried blood covers the walls and floor; an unsettling air hangs here.");
        Room tortureChamber = new Room("Torture Chamber", "Rusty devices line the room, whispers echo faintly.");
        Room ghostlyCorridor = new Room("Ghostly Corridor", "Spectral figures float, making navigation treacherous.");
        Room hallOfChains = new Room("Hall of Chains", "Chains hang from the ceiling, clinking ominously.");
        Room rottingCatacombs = new Room("Rotting Catacombs", "Rows of decayed skeletons seem to watch you.");
        Room cursedAltar = new Room("Cursed Altar", "A dark altar emanating malevolent energy; risk a reward?");
        Room etherealBridge = new Room("Ethereal Bridge", "A glowing bridge spans a void, spectral hands reaching upward.");
        Room pitOfDespair = new Room("Pit of Despair", "A deep pit of wailing souls; their screams fill the air.");
        Room mirrorMaze = new Room("Mirror Maze", "Reflective walls confuse you, and hidden traps await.");
        Room chamberOfSpikes = new Room("Chamber of Spikes", "The room is filled with spikes, ready to be triggered.");
        Room voidGateway = new Room("Void Gateway", "A swirling portal humming with dangerous power.");
        Room hauntedLibrary = new Room("Haunted Library", "Dusty tomes whisper and attack if disturbed.");
        Room demonsLair = new Room("Demon’s Lair", "A powerful demon resides here, surrounded by flames and shadows.");
        Room shopkeeper2 = new SpecialRoom("Shop Keeper2", "You entered the shop!", Resources.Load<Sprite>("Art/NPC/ShopKeeper"));
        Room blueDoor = new SpecialRoom("Blue Door", "Are you ready for what's inside?", Resources.Load<Sprite>("Art/NPC/BlueDoor"));

        map = new Room[,] {
            {shadowedHall, ghostlyCorridor, hallOfChains, cursedAltar},
            {echoingChamber, bloodStainedRoom, tortureChamber, blueDoor},
            {etherealBridge, pitOfDespair, mirrorMaze, chamberOfSpikes},
            {hauntedLibrary, voidGateway, demonsLair, shopkeeper2}
        };

        maxHeight = map.GetLength(0);
        maxWidth = map.GetLength(1);
        levelName = "Level2";
    }
}
