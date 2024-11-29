using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire : Enemy
{
    public Vampire()
    {
        type = "Vampire";
        DMG = 20;
        maxHP = 40;
        HP = maxHP;
        XP = 30;
    }
}
