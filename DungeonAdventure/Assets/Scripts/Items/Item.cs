using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // This class will only give access to different variables that children will use
    // to change their values.
    public int dropChance;
    public int goldValue;
    public string itemType;
    public string itemName;
    public string description;
}