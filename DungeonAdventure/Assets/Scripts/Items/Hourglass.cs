using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hourglass : Item
{
    // Start is called before the first frame update
    void Start()
    {
        dropChance = 1;
        goldValue = 99;
        itemName = "Hourglass";
        description = "I wonder what this could be used for...";
        intelligence = 10;
        strength = 10;
    }
}
