using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basilisk : Enemy
{
    public Basilisk()
    {
        type = "Basilisk";
        DMG = 8;
        maxHP = 20;
        HP = maxHP;
        XP = 18;
    }
}
