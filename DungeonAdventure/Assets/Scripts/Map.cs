using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    // Start is called before the first frame update
    private Room corridor;
    private Room barracks;
    private Room hall;
    private Room cave;
    public Room[,] map;

    public void Initialize()
    {
        // Initialize each Room object
        corridor = new Room("Corridor", "What a lovely Corridor!");
        barracks = new Room("Barracks", "These barracks are massive!");
        hall = new Room("Hall", "Woah, that's a creepy and empty hall...");
        cave = new Room("Cave", "This cave echoes in the darkness...");
        
        map = new Room[,] {
            {corridor, barracks},
            {hall, cave}
        };
    }

}