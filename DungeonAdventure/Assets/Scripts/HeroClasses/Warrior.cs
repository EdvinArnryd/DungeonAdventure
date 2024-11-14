using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Warrior : HeroClass
{
    public Warrior()
    {
        strength = 10;
        intelligence = 5;
        className = "Warrior";
        description = "Fierce and powerful! The warrior wields heavy weaponry to take down his foes.";
        strengthGrowth = 3;
        intelligenceGrowth = 1;
        healthGrowth = 4;
        attackPower = 13;
        spriteBack = Resources.Load<Sprite>("Art/Characters/WarriorBack");
    }
    
}
