using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    public void Attack()
    {
        actionField.SetText("Player attacked!");
    }

    public void ThrowSpell()
    {
        actionField.SetText("Player used their spell!");
    }

    public void Heal()
    {
        StartCoroutine(HealCoroutine());
    }

    private IEnumerator HealCoroutine()
    {
        actionField.SetText("Player healed!");
        yield return new WaitForSeconds(2f); // Method, delegate, or event is expected
        int addedHealth = 3;
        player.healPlayer(addedHealth);
        actionField.SetText("Player healed " + addedHealth + " HP!");
        yield return new WaitForSeconds(2f);
        actionField.SetText("Yay!");
    }
}
