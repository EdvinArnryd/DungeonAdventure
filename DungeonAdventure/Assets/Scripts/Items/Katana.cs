using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : Item
{
    public Katana()
    {
        dropChance = 10;
        goldValue = 39;
        itemName = "Katana";
        description = "Belonged to a Samurai.";
        intelligence = 5;
        strength = 20;
        sprite = Resources.Load<Sprite>("Art/Icons/KatanaIcon");
    }
}
