using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Item
{
    void Start()
    {
        dropChance = 15;
        goldValue = 11;
        itemName = "Axe";
        description = "A strong axe.";
        intelligence = 0;
        strength = 6;
    }
}
