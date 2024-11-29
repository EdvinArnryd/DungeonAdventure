using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crown : Item
{
    public Crown()
    {
        dropChance = 6;
        goldValue = 49;
        itemName = "Crown";
        description = "A powerful headgear.";
        intelligence = 28;
        strength = 1;
        sprite = Resources.Load<Sprite>("Art/Icons/CrownIcon");
    }
}
