using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : Item
{
    void Start()
    {
        dropChance = 18;
        goldValue = 9;
        itemName = "Wand";
        description = "A tiny magical wand.";
        intelligence = 4;
        strength = 1;
    }
}
