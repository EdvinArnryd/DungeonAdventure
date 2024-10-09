using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : HeroClass
{
    // Start is called before the first frame update
    public Rogue()
    {
        strength = 6;
        agility = 10;
        intelligence = 6;
        className = "Rogue";
        description = "The sneaky rogue has a few tricks up his sleave to decieve anyone who crosses him.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
