using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedKey : Token
{
    public RedKey()
    {
        tokenName = "RedKey";
        tokenSprite = Resources.Load<Sprite>("Art/Icons/RedKeyIcon");
    }
}
