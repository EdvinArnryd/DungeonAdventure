using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : Item
{
    public Staff()
    {
        dropChance = 31;
        goldValue = 11;
        itemName = "Staff";
        description = "A powerful magic staff.";
        intelligence = 7;
        strength = 2;
        sprite = Resources.Load<Sprite>("Art/Icons/StaffIcon");
    }
}
