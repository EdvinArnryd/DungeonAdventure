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
    private int healthPotions;
    private int manaPotions;
    public List<Item> inventory;
    private List<Token> tokens;
    public HeroClass heroClass;
    private string playerName;
    
    // Combat Stats
    private int strength;
    private int intelligence;
    // private int row, col;
    
    
    
    public void Initialize()
    {
        gold = 50;
        level = 1;
        XP = 0;
        Mana = 15;
        maxHP = 25;
        HP = maxHP;
        healthPotions = 2;
        manaPotions = 2;
        inventory = new List<Item>(8);
        tokens = new List<Token>(3);
        heroClass = null;
        playerName = "Player";
        strength = 0;
        intelligence = 0;
        Sword sword = new Sword();
        Axe axe = new Axe();
        
        inventory.Add(sword);
        inventory.Add(axe);
        inventory.Add(sword);

        // row = 1;
        // col = 1;
    }

    public int GetHealthPotions()
    {
        return healthPotions;
    }
    
    public int GetManaPotions()
    {
        return manaPotions;
    }

    public List<Token> GetTokens()
    {
        return tokens;
    }

    public void AddToken(Token tokenToAdd)
    {
        if (!tokens.Contains(tokenToAdd))
        {
            tokens.Add(tokenToAdd);
        }
    }

    public bool GetSpecificToken(Token wantedToken)
    {
        foreach (var token in tokens)
        {
            if (token == wantedToken)
            {
                return true;
            }
        }
        return false;
    }

    public void playerLoseGold(int goldLost)
    {
        gold -= goldLost;
    }

    public bool useHealthPotion()
    {
        if (healthPotions > 0)
        {
            healthPotions--;
            return true;
        }

        return false;
    }

    public void addHealthPotion()
    {
        healthPotions++;
    }
    
    
    
    public void addManaPotion()
    {
        manaPotions++;
    }
    
    public bool useManaPotion()
    {
        if (manaPotions > 0)
        {
            manaPotions--;
            return true;
        }

        return false;
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