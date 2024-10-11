using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


//TODO:
//Create scriptable object for each enemy.
//Then Create a list of enemies(scriptableobjects) as a public variable
//Then add all of the enemies into the list in the editor.
//This way we don't need to write as much code as we did now and it's a scalable solution.
public class CombatManager : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI playerHealth;
    public TextMeshProUGUI enemyName;
    public TextMeshProUGUI enemyHealth;
    public TextMeshProUGUI actionField;
    
    public PlayerData player;
    private Enemy currentEnemy;
    private List<Enemy> enemies;
    private Skeleton skeleton;
    private Zombie zombie;
    private Imp imp;
    private int randomValue;
    
    void Start()
    {
        currentEnemy = new Enemy();
        skeleton = new Skeleton();
        zombie = new Zombie();
        imp = new Imp();
        
        skeleton.Initialize();
        zombie.Initialize();
        imp.Initialize();
        
        enemies = new List<Enemy>();
        enemies.Add(skeleton);
        enemies.Add(zombie);
        enemies.Add(imp);
        
        randomValue = Random.Range(0, enemies.Count-1);
        currentEnemy = enemies[randomValue];
        
        playerName.SetText(player.GetName());
        playerHealth.SetText(player.GetHP().ToString());
        
        enemyName.SetText(currentEnemy.type);
        enemyHealth.SetText(currentEnemy.HP.ToString());
    }  

    private void Attack()
    {
        
    }

    private void ThrowSpell()
    {
        
    }

    private void Heal()
    {
        
    }
}
