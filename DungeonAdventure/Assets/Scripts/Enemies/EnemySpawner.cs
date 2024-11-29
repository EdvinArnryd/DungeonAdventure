using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner
{
    public List<Enemy> enemiesLevel1;
    public List<Enemy> enemiesLevel2;
    public void Initialize()
    {
        enemiesLevel1 = new List<Enemy>();
        enemiesLevel2 = new List<Enemy>();
        
        enemiesLevel1.Add(new Imp());
        enemiesLevel1.Add(new Skeleton());
        enemiesLevel1.Add(new Zombie());
        
        enemiesLevel2.Add(new Basilisk());
        enemiesLevel2.Add(new Demon());
        enemiesLevel2.Add(new Ghoul());
        enemiesLevel2.Add(new Minotaur());
        enemiesLevel2.Add(new Serpent());
        enemiesLevel2.Add(new Vampire());
    }

    public Enemy GetRandomEnemy1()
    {
        int random = Random.Range(0, enemiesLevel1.Count);

        Enemy returningEnemy = enemiesLevel1[random];

        return returningEnemy;
    }
    
    public Enemy GetRandomEnemy2()
    {
        int random = Random.Range(0, enemiesLevel2.Count);

        Enemy returningEnemy = enemiesLevel2[random];

        return returningEnemy;
    }

}
