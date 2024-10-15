using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    // Start is called before the first frame update
    public void Initialize()
    {
        type = "Skeleton";
        DMG = 2;
        maxHP = 10;
        HP = maxHP;
        XP = 8;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
