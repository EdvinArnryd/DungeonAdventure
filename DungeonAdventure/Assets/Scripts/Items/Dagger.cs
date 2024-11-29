using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : Item
{
    public Dagger()
    {
        dropChance = 60;
        goldValue = 9;
        itemName = "Dagger";
        description = "Short range, but deadly.";
        intelligence = 0;
        strength = 8;
        sprite = Resources.Load<Sprite>("Art/Icons/DaggerIcon");
    }
}
