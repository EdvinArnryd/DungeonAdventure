using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public string roomName;
    public string description;

    public Room(string roomName, string description)
    {
        this.roomName = roomName;
        this.description = description;
    }
}
