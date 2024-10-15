using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    // Start is called before the first frame update
    public void Initialize()
    {
        type = "Zombie";
        DMG = 3;
        maxHP = 12;
        HP = maxHP;
        XP = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
