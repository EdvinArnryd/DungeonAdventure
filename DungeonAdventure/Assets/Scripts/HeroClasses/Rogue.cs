using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : HeroClass
{
    // Start is called before the first frame update
    public Rogue()
    {
        strength = 6;
        intelligence = 6;
        className = "Rogue";
        description = "The sneaky rogue has a few tricks up his sleave to decieve anyone who crosses him.";
        strengthGrowth = 2;
        intelligenceGrowth = 2;
        healthGrowth = 3;
        manaGrowth = 2;
        attackPower = 12;
        spriteBack = Resources.Load<Sprite>("Art/Characters/RogueBack");
    }
}
