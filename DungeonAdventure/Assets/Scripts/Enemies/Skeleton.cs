using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    public Skeleton()
    {
        type = "Skeleton";
        DMG = 2;
        maxHP = 10;
        HP = maxHP;
        XP = 8;
    }
}
