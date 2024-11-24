using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueKey : Token
{
    public BlueKey()
    {
        tokenName = "BlueKey";
        tokenSprite = Resources.Load<Sprite>("Art/Icons/BlueKeyIcon");
    }
}
