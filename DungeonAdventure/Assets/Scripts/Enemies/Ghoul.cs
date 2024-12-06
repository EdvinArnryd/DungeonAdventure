using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghoul : Enemy
{
    public Ghoul()
    {
        type = "Ghoul";
        DMG = 10;
        maxHP = 28;
        HP = maxHP;
        XP = 17;
        sprite = Resources.Load<Sprite>("Art/Enemies/Abomination");
    }
}
