using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur : Enemy
{
    public Minotaur()
    {
        type = "Minotaur";
        DMG = 14;
        maxHP = 35;
        HP = maxHP;
        XP = 22;
    }
}
