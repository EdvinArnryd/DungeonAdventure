using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialRoom : Room
{
    public Sprite npcSprite;
    public SpecialRoom(string roomName, string description, Sprite npcSprite) : base(roomName, description)
    {
        this.npcSprite = npcSprite;
    }
}
