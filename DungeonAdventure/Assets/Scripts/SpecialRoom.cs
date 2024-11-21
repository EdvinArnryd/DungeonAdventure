using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialRoom : Room
{
    public Sprite eventSprite;
    public SpecialRoom(string roomName, string description, Sprite eventSprite) : base(roomName, description)
    {
        this.eventSprite = eventSprite;

    }
}
