using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursedKnight : Enemy
{
    public CursedKnight()
        {
            type = "CursedKnight";
            DMG = 11;
            maxHP = 28;
            HP = maxHP;
            XP = 18;
            sprite = Resources.Load<Sprite>("Art/Enemies/CursedKnight");
        }
}
