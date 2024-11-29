using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gauntlet : Item
{
    public Gauntlet()
    {
        dropChance = 30;
        goldValue = 14;
        itemName = "Gauntlet";
        description = "Good for close up battle.";
        intelligence = 0;
        strength = 11;
        sprite = Resources.Load<Sprite>("Art/Icons/GauntletIcon");
    }
}
