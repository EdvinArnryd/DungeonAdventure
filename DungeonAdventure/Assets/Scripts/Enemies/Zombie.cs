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
        XP = 9;
        sprite = Resources.Load<Sprite>("Art/Enemies/ZombieDA");
        enemySpawnSound = Resources.Load<AudioClip>("Audio/Zombie 1 - Short 1-01");
    }
}
