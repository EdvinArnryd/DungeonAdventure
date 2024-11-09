using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : Item
{
    void Start()
    {
        dropChance = 16;
        goldValue = 11;
        itemName = "Staff";
        description = "A powerful magic staff.";
        intelligence = 5;
        strength = 2;
    }
}
