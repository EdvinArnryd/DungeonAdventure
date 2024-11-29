using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkBall : Item
{
    public PinkBall()
    {
        dropChance = 1;
        goldValue = 99;
        itemName = "PinkBall";
        description = "??????????????????";
        intelligence = 99;
        strength = 99;
        sprite = Resources.Load<Sprite>("Art/Icons/PinkBalliIcon");
    }
}
