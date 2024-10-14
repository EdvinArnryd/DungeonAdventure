using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    [Header("Initialize UI")]
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI playerHealth;
    public TextMeshProUGUI enemyName;
    public TextMeshProUGUI enemyHealth;
    public TextMeshProUGUI actionField;

    [Header("Initialize UI")]
    public Button AttackButton;
    public Button SpellButton;
    public Button HealButton;
    
    public PlayerData player;
    private Enemy currentEnemy;
    private List<Enemy> enemies;
    private Skeleton skeleton;
    private Zombie zombie;
    private Imp imp;
    private int randomValue;
    
    void Start()
    {
        //Creating all enemies
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
        
        //Randomizing which enemy will be in combat
        randomValue = Random.Range(0, enemies.Count-1);
        currentEnemy = enemies[randomValue];
        
        // Set Player and Enemy's Name's and health to UI
        playerName.SetText(player.GetName());
        playerHealth.SetText(player.GetHP().ToString());
        
        enemyName.SetText(currentEnemy.type);
        enemyHealth.SetText(currentEnemy.HP.ToString());
    }  

    public void Attack()
    {
        DisableButtons();
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        actionField.SetText("Player attacked!");
        yield return new WaitForSeconds(2f);
        
        WaitingForPlayer();
    }

    public void ThrowSpell()
    {
        DisableButtons();
        StartCoroutine(ThrowSpellCoroutine());
    }

    private IEnumerator ThrowSpellCoroutine()
    {
        actionField.SetText("Player used their spell!");
        yield return new WaitForSeconds(2f);
        
        WaitingForPlayer();
    }

    public void Heal()
    {
        DisableButtons();
        StartCoroutine(HealCoroutine());
    }

    private IEnumerator HealCoroutine()
    {
        actionField.SetText("Player healed!");
        yield return new WaitForSeconds(2f);
        int addedHealth = 3;
        player.healPlayer(addedHealth);
        actionField.SetText("Player healed " + addedHealth + " HP!");
        yield return new WaitForSeconds(2f);
        WaitingForPlayer();
    }

    private void WaitingForPlayer()
    {
        actionField.SetText("Waiting for player input...");
        AttackButton.interactable = true;
        SpellButton.interactable = true;
        HealButton.interactable = true;
    }

    private void DisableButtons()
    {
        AttackButton.interactable = false;
        SpellButton.interactable = false;
        HealButton.interactable = false;
    }
}
