using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claws : Item
{
    public Claws()
    {
        dropChance = 20;
        goldValue = 18;
        itemName = "Claws";
        description = "Attack like a wolf.";
        intelligence = 1;
        strength = 12;
        sprite = Resources.Load<Sprite>("Art/Icons/ClawsIcon");
    }
}
