using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewScriptableObject", menuName = "ScriptableObject/Player")]
public class PlayerData : ScriptableObject
{
    private int HP;
    private int maxHP;
    private int Mana;
    private int XP;
    private int level;
    private int gold;
    public List<Item> inventory;
    public HeroClass heroClass;
    private string playerName;
    
    // Combat Stats
    private int strength;
    private int intelligence;
    // private int row, col;
    public void Initialize()
    {
        gold = 0;
        level = 1;
        XP = 0;
        Mana = 15;
        maxHP = 25;
        HP = maxHP;
        inventory = new List<Item>(5);
        heroClass = null;
        playerName = "Player";
        strength = 0;
        intelligence = 0;

        // row = 1;
        // col = 1;
    }

    public int GetStrength()
    {
        return strength;
    }

    public int GetIntelligence()
    {
        return intelligence;
    }
    public void CalculateStrength()
    {
        int strengthSum = 0;
        if (inventory.Count >= 1)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                strengthSum += inventory[i].strength;
            }
        }

        strengthSum += heroClass.GetStrength();

        strength = strengthSum;
    }

    public void CalculateIntelligence()
    {
        int intelligenceSum = 0;
        if (inventory.Count >= 1)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                intelligenceSum += inventory[i].intelligence;
            } 
        }
        
        intelligenceSum += heroClass.GetIntelligence();

        intelligence = intelligenceSum;
    }
    
    public void addItem(Item item)
    {
        if (inventory.Count < 5)
        {
            inventory.Add(item);
        }
    }
    public int GetGold()
    {
        return gold;
    }
    public void AddGold(int goldAdded)
    {
        gold += goldAdded;
    }
    public void AddXP(int xpAdded)
    {
        XP += xpAdded;
    }

    public int GetXP()
    {
        return XP;
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
        return heroClass.AttackEffectiveness(strength);
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