using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicRing : Item
{
    public MagicRing()
    {
        dropChance = 12;
        goldValue = 29;
        itemName = "MagicRing";
        description = "This ring has some magic.";
        intelligence = 21;
        strength = 0;
        sprite = Resources.Load<Sprite>("Art/Icons/MagicRing");
    }
}
