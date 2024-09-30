using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int HP;
    private int maxHP;
    private int DMG;
    private List<Item> inventory;
    private HeroClass heroClass;
    private int row, col;
    private Map map;
    private Room playerRoom;
    void Start()
    {
        maxHP = 25;
        HP = maxHP;
        inventory = new List<Item>(5);
        row = 0;
        col = 0;
        playerRoom = new Room("My", "Room");
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(map.map[row, col].roomName);
        }
    }
    
    // Todo:
    // Create a GameManager to handle logic for the Map and the player.
    // This way we can create the map inside the same script that we are performing traversal logic
    // And easy access the Map.
}
