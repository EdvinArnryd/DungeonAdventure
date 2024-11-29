using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serpent : Enemy
{
    public Serpent()
    {
        type = "Serpent";
        DMG = 16;
        maxHP = 36;
        HP = maxHP;
        XP = 24;
    }
}
