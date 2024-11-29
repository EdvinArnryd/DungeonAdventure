using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp : Enemy
{
    public Imp()
    {
        type = "Imp";
        DMG = 1;
        maxHP = 6;
        HP = maxHP;
        XP = 5;
    }

}
