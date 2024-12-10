using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevel : Map
{
    public BossLevel()
    {


        map = new Room[,]{};

        maxHeight = map.GetLength(0);
        maxWidth = map.GetLength(1);
        levelName = "BossLevel";
    }
}
