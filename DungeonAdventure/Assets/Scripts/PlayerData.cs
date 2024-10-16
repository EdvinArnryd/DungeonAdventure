using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewScriptableObject", menuName = "ScriptableObject/MyScriptableObject")]
public class PlayerData : ScriptableObject
{
    private int HP;
    private int maxHP;
    private int DMG;
    private int Mana;
    private List<Item> inventory;
    public HeroClass heroClass;
    private string playerName;
    // private int row, col;
    public void Initialize()
    {
        Mana = 15;
        maxHP = 25;
        HP = maxHP;
        DMG = 10;
        inventory = new List<Item>(5);
        heroClass = null;
        playerName = "Player";
        // row = 1;
        // col = 1;
    }

    public void UsedSpell()
    {
        Mana -= 3;
    }
    public int GetMana()
    {
        return Mana;
    }
    public int GetDMG()
    {
        return DMG;
    }
    
    public int GetHP()
    {
        return HP;
    }

    public void healPlayer(int addedHealth)
    {
        HP += addedHealth;
        if (HP > maxHP)
        {
            HP = maxHP;
        }
    }

    public void playerTakeDamage(int damage)
    {
        HP -= damage;
    }

    public string GetName()
    {
        return playerName;
    }

    public void SetName(string newName)
    {
        playerName = newName;
    }
    
    public void SetHeroClass(HeroClass newHeroClass)
    {
        heroClass = newHeroClass;
    }
    
    public void ResetData()
    {
        Initialize(); // Reset to defaults
    }
}