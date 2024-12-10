using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abomination : Enemy
{
    public Abomination()
    {
        type = "Abomination";
        DMG = 14;
        maxHP = 34;
        HP = maxHP;
        XP = 25;
        sprite = Resources.Load<Sprite>("Art/Enemies/Abomination");
        enemySpawnSound = Resources.Load<AudioClip>("Audio/Monsters/Monster_Roar10");
    }
}
