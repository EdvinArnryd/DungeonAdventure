using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Enemy
{
    public Dragon()
    {
        type = "Dragon";
        DMG = 30;
        maxHP = 80;
        HP = maxHP;
        XP = 99;
        sprite = Resources.Load<Sprite>("Art/Enemies/DragonDA");
        enemySpawnSound = Resources.Load<AudioClip>("Audio/Monsters/Monster_Roar20");
    }
}
