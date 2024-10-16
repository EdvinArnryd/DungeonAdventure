using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Enemy
{
    // Start is called before the first frame update
    public string type;
    public int DMG;
    public int HP;
    public int maxHP;
    public int XP;
    
    public void healEnemy(int addedHealth)
    {
        HP += addedHealth;
        if (HP > maxHP)
        {
            HP = maxHP;
        }
    }
    
    public void enemyTakeDamage(int damage)
    {
        HP -= damage;
    }

}


