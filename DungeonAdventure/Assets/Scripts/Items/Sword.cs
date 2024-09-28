using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Item
{
    void Start()
    {
        dropChance = 2;
        goldValue = 5;
        itemName = "Sword";
        description = "A casual shiny sword.";
    }
}
