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
        XP = 7;
        sprite = Resources.Load<Sprite>("Art/Enemies/SkeletonDA");
        enemySpawnSound = Resources.Load<AudioClip>("Audio/Monsters/Dinosaur_Shriek5");
    }
}
