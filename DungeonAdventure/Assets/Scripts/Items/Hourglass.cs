using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hourglass : Item
{
    // Start is called before the first frame update
    public Hourglass()
    {
        dropChance = 13;
        goldValue = 99;
        itemName = "Hourglass";
        description = "I wonder what this could be used for...";
        intelligence = 10;
        strength = 10;
        sprite = Resources.Load<Sprite>("Art/Icons/HourglassIcon");
    }
}
