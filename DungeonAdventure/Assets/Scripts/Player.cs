using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private int HP;
    private int maxHP;
    private int DMG;
    private List<Item> inventory;
    private HeroClass heroClass;
    public int row, col;
    public void Initialize()
    {
        maxHP = 25;
        HP = maxHP;
        inventory = new List<Item>(5);
        row = 1;
        col = 1;
    }
    
    void Update()
    {
        
    }
    
    // Todo:
    // Create a GameManager to handle logic for the Map and the player.
    // This way we can create the map inside the same script that we are performing traversal logic
    // And easy access the Map.
}
