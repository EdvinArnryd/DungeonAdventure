using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewScriptableObject", menuName = "ScriptableObject/Player")]
public class PlayerData : ScriptableObject
{
    private int HP;
    private int maxHP;
    private int Mana;
    private int maxMana;
    private int XP;
    private int xpThreshold;
    private int level;
    private int gold;
    private int healthPotions;
    private int manaPotions;
    public List<Item> inventory;
    private List<Token> tokens;
    public HeroClass heroClass;
    private string playerName;
    private int points;

    public int col;
    public int row;
    private Room[,] dungeonLevel;
    public Map playerMap;

    public event Action OnLevelUp;
    
    
    // Combat Stats
    private int strength;
    private int intelligence;
    // private int row, col;
    
    
    
    public void Initialize()
    {
        gold = 400;
        level = 1;
        XP = 0;
        maxMana = 15;
        Mana = maxMana;
        maxHP = 15;
        HP = maxHP;
        healthPotions = 2;
        manaPotions = 2;
        inventory = new List<Item>(8);
        tokens = new List<Token>(3);
        heroClass = null;
        playerName = "Player";
        strength = 0;
        intelligence = 0;
        xpThreshold = 10;
        row = 0;
        col = 0;
        
        // Test data
        Sword sword = new Sword();
        Axe axe = new Axe();
        inventory.Add(sword);
        inventory.Add(axe);
        inventory.Add(sword);

    }

    // public void SetCol(int newCol)
    // {
    //     col = newCol;
    // }
    //
    // public int GetCol()
    // {
    //     return col;
    // }
    //
    // public void SetRow(int newRow)
    // {
    //     row = newRow;
    // }
    //
    // public int GetRow()
    // {
    //     return row;
    // }

    public bool IsSecondLevel()
    {
        if (GetMap().levelName == "Level2")
        {
            return true;
        }

        return false;
    }
    
    public bool IsFirstLevel()
    {
        if (GetMap().levelName == "Level1")
        {
            return true;
        }

        return false;
    }

    public Room[,] GetDungeonLevel()
    {
        return dungeonLevel;
    }

    public void SetMap(Map map)
    {
        playerMap = map;
    }

    public Map GetMap()
    {
        return playerMap;
    }

    public void SetDungeonLevel(Room[,] newDungeonLevel)
    {
        dungeonLevel = newDungeonLevel;
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

    public bool GetSpecificToken(String wantedToken)
    {
        foreach (var token in tokens)
        {
            if (token.tokenName == wantedToken)
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

    public int GetLevel()
    {
        return level;
    }
    public void AddXP(int xpAdded)
    {
        XP += xpAdded;
        if (XP >= xpThreshold)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        level++;
        xpThreshold = level * 4 + 20 + xpThreshold;

        strength += heroClass.strengthGrowth;
        intelligence += heroClass.intelligenceGrowth;
        maxHP += heroClass.healthGrowth;
        maxMana += heroClass.manaGrowth;

        HP = maxHP;
        Mana = maxMana;
        
        OnLevelUp?.Invoke();
    }

    public int GetXP()
    {
        return XP;
    }

    public int GetXpThreshold()
    {
        return xpThreshold;
    }

    public void UsedSpell()
    {
        Mana -= 3;
    }
    public int GetMana()
    {
        return Mana;
    }

    public bool useManaPotion(int manaAdded)
    {
        if (manaPotions > 0)
        {
            Mana += manaAdded;
            if (Mana > maxMana)
            {
                Mana = maxMana;
            }
            manaPotions--;
            return true;
        }

        return false;
    }

    public void addManaPotion()
    {
        manaPotions++;
    }

    public bool useHealthPotion(int addedHealth)
    {
        if (healthPotions > 0)
        {
            HP += addedHealth;
            if (HP > maxHP)
            {
                HP = maxHP;
            }
            healthPotions--;
            return true;
        }

        return false;
    }

    public void addHealthPotion()
    {
        healthPotions++;
    }
    
    public int GetHP()
    {
        return HP;
    }
    
    public int GetDMG()
    {
        return heroClass.AttackEffectiveness(strength);
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

    public int GetFinalPoints()
    {
        int score = gold + XP;
        return score;
    }
}