using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : HeroClass
{
    // Start is called before the first frame update
    public Mage()
    {
        strength = 2;
        intelligence = 12;
        className = "Mage";
        description = "The wise mage wields the power of the elements to take down his foes.";
        strengthGrowth = 1;
        intelligenceGrowth = 3;
        healthGrowth = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
