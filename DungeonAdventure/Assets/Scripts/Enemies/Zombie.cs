using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
   
    public Zombie()
    {
        type = "Zombie";
        DMG = 3;
        maxHP = 12;
        HP = maxHP;
        XP = 10;
    }
}
