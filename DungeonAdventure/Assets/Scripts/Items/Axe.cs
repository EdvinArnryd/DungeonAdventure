using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Item
{
    public Axe()
    {
        dropChance = 55;
        goldValue = 11;
        itemName = "Axe";
        description = "A strong axe.";
        intelligence = 0;
        strength = 6;
        sprite = Resources.Load<Sprite>("Art/Icons/AxeIcon");
    }
}
