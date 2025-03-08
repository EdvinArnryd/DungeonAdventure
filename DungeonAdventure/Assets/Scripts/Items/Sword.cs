using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Item
{
    public Sword()
    {
        dropChance = 70;
        goldValue = 5;
        itemName = "Sword";
        description = "A casual shiny sword.";
        intelligence = 1;
        strength = 2;
        sprite = Resources.Load<Sprite>("Art/Icons/SwordIcon");
    }
}
