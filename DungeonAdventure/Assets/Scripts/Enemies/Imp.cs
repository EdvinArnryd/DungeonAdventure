using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp : Enemy
{
    // Start is called before the first frame update
    public void Initialize()
    {
        type = "Imp";
        DMG = 1;
        maxHP = 6;
        HP = maxHP;
        XP = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
