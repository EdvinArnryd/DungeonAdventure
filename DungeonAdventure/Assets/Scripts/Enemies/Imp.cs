using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp : Enemy
{
    public Imp()
    {
        type = "Imp";
        DMG = 2;
        maxHP = 8;
        HP = maxHP;
        XP = 5;
        sprite = Resources.Load<Sprite>("Art/Enemies/Imp");
        enemySpawnSound = Resources.Load<AudioClip>("Audio/Monsters/Dinosaur_Shriek4");
    }

}
