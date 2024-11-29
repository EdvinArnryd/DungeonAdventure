using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSystem
{
    // Start is called before the first frame update
    // private Axe axe;
    // private Hourglass hourglass;
    // private Staff staff;
    // private Sword sword;
    // private Wand wand;
    private List<Item> lootTable = new List<Item>();
    private List<Item> lootTableLevel2 = new List<Item>();

    public void Initialize()
    {
        // axe = new Axe();
        // hourglass = new Hourglass();
        // staff = new Staff();
        // sword = new Sword();
        // wand = new Wand();
        
        lootTable.Add(new Axe());
        lootTable.Add(new Hourglass());
        lootTable.Add(new Staff());
        lootTable.Add(new Sword());
        lootTable.Add(new Wand());
        
        lootTableLevel2.Add(new Claws());
        lootTableLevel2.Add(new Crown());
        lootTableLevel2.Add(new Dagger());
        lootTableLevel2.Add(new Gauntlet());
        lootTableLevel2.Add(new Katana());
        lootTableLevel2.Add(new MagicRing());
        lootTableLevel2.Add(new PinkBall());
    }

    public Item LootDrop()
    {
        int rollHundred = Random.Range(0, 101);
        List<Item> viableLoot = new List<Item>();
        foreach (var item in lootTable)
        {
            if (item.dropChance >= rollHundred)
            {
                viableLoot.Add(item);
            }
        }

        if (viableLoot.Count > 0)
        {
            int finalRandom = Random.Range(0, viableLoot.Count);
            return viableLoot[finalRandom];
        }

        return null;
    }
    
    public Item LootDropLevel2()
    {
        int rollHundred = Random.Range(0, 101);
        List<Item> viableLoot = new List<Item>();
        foreach (var item in lootTableLevel2)
        {
            if (item.dropChance >= rollHundred)
            {
                viableLoot.Add(item);
            }
        }

        if (viableLoot.Count > 0)
        {
            int finalRandom = Random.Range(0, viableLoot.Count);
            return viableLoot[finalRandom];
        }

        return null;
    }
    
}
