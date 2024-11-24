using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldKey : Token
{
    public GoldKey()
    {
        tokenName = "GoldKey";
        tokenSprite = Resources.Load<Sprite>("Art/Icons/GoldKeyIcon");
    }
}
