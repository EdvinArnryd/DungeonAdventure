using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : Enemy
{
    public Demon()
    {
        type = "Demon";
        DMG = 12;
        maxHP = 30;
        HP = maxHP;
        XP = 20;
        sprite = Resources.Load<Sprite>("Art/Enemies/DemonDA");
    }
}
