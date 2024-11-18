using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : Item
{
    public Staff()
    {
        dropChance = 40;
        goldValue = 11;
        itemName = "Staff";
        description = "A powerful magic staff.";
        intelligence = 5;
        strength = 2;
        sprite = Resources.Load<Sprite>("Art/Icons/StaffIcon");
    }
}
