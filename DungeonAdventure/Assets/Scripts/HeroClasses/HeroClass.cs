using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HeroClass
{
    // This class will only give access to different variables that children will use
    // to change their values.
    public int strength;
    public int intelligence;
    public string className;
    public string description;
    public int strengthGrowth;
    public int intelligenceGrowth;
    public int healthGrowth;
    public int attackPower;
    public Sprite spriteBack;

    public int AttackEffectiveness(int playerStrength)
    {
        return playerStrength * attackPower / 10;
    }

    public int UseSpell(int heroIntelligence, int mana)
    {
        int spellDamage = 0;
        if (heroIntelligence >= 12 & mana >= 3)
        {
            spellDamage = 6 + heroIntelligence / 2;
            return spellDamage;
        }

        return spellDamage;
    }

    public int GetIntelligence()
    {
        return intelligence;
    }
    
    public int GetStrength()
    {
        return strength;
    }
}
