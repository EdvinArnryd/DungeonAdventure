using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private int HP;
    private int maxHP;
    private int DMG;
    private List<Item> inventory;
    private HeroClass heroClass;
    void Start()
    {
        maxHP = 25;
        HP = maxHP;
        inventory.Capacity = 5;
    }
    
    void Update()
    {
       // health = 1;

        // if (health < 0)
        // {
        //     health = 5;
        // }
    }
}
