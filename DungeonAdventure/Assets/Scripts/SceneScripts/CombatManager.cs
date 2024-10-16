using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// TODO
// Big issue with null ref from heroClass
// Because we never initialize it
// Maybe we can do that inside of PlayerData?
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
        
        enemyName.SetText(currentEnemy.type);
        playerName.SetText(player.GetName());
        UpdateUI();
    }

    public void UpdateUI()
    {
        // Set Player and Enemy's Name's and health to UI
        playerHealth.SetText(player.GetHP().ToString());
        enemyHealth.SetText(currentEnemy.HP.ToString());
    }

    public void Attack()
    {
        DisableButtons();
        StartCoroutine(AttackCoroutine());
        EnemyAction();
    }

    private IEnumerator AttackCoroutine()
    {
        actionField.SetText(player.GetName() + " attacked!");
        yield return new WaitForSeconds(2f);
        randomValue = Random.Range(1, 7);
        if (randomValue == 6)
        {
            // Crit
            actionField.SetText(player.GetName() + " got a lucky crit!");
            yield return new WaitForSeconds(2f);
            currentEnemy.enemyTakeDamage(player.GetDMG());
            UpdateUI();
            actionField.SetText(currentEnemy.type + " took " + player.GetDMG() + " damage.");
            yield return new WaitForSeconds(2f);
        }
        else
        {
            // Attack
            currentEnemy.enemyTakeDamage(player.GetDMG());
            UpdateUI();
            actionField.SetText(currentEnemy.type + " took " + player.GetDMG() + " damage.");
            yield return new WaitForSeconds(2f);
        }
    }

    public void ThrowSpell()
    {
        DisableButtons();
        StartCoroutine(ThrowSpellCoroutine());
        EnemyAction();
    }

    private IEnumerator ThrowSpellCoroutine()
    {
        actionField.SetText(player.GetName() + " used their spell!");
        yield return new WaitForSeconds(2f);
        int spellDamage = player.heroClass.UseSpell(player.heroClass.intelligence, player.GetMana());
        if (spellDamage == 0)
        {
            actionField.SetText(player.GetName() + " Could not use their spell!");
            yield return new WaitForSeconds(2f);
        }
        else
        {
            player.UsedSpell();
            currentEnemy.enemyTakeDamage(spellDamage);
            UpdateUI();
            actionField.SetText(currentEnemy.type + " took " + spellDamage + " damage.");
            yield return new WaitForSeconds(2f);
        }
    }

    public void Heal()
    {
        DisableButtons();
        StartCoroutine(HealCoroutine());
        EnemyAction();
    }

    private IEnumerator HealCoroutine()
    {
        actionField.SetText("Player healed!");
        yield return new WaitForSeconds(2f);
        int addedHealth = 3;
        player.healPlayer(addedHealth);
        actionField.SetText("Player healed " + addedHealth + " HP!");
        yield return new WaitForSeconds(2f);
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

    private void EnemyAction()
    {
        int random = Random.Range(1, 7);
        if (random == 6)
        {
            StartCoroutine(EnemyHealCoroutine());
        }
        else
        {
            StartCoroutine(EnemyAttackCoroutine());
        }
    }

    private IEnumerator EnemyAttackCoroutine()
    {
        yield return new WaitForSeconds(2f);
        actionField.SetText("Enemy is going for an attack!");
        yield return new WaitForSeconds(2f);
        int randomValue = Random.Range(1, 7);
        if (randomValue == 6)
        {
            // CRIT
            actionField.SetText("Enemy got a lucky hit!");
            yield return new WaitForSeconds(2f);
            player.playerTakeDamage(currentEnemy.DMG * 2);
            UpdateUI();
            actionField.SetText("You lost " + currentEnemy.DMG * 2 + " health points.");
        }
        else if (randomValue == 5)
        {
            // MISS
            actionField.SetText("Enemy missed!");
        }
        else
        {
            // NORMAL ATTACK
            player.playerTakeDamage(currentEnemy.DMG);
            UpdateUI();
            actionField.SetText("You lost " + currentEnemy.DMG + " health points.");
        }
        
        yield return new WaitForSeconds(2f);
        WaitingForPlayer();
    }
    
    private IEnumerator EnemyHealCoroutine()
    {
        yield return new WaitForSeconds(2f);
        actionField.SetText("Enemy's turn!");
        yield return new WaitForSeconds(2f);
        currentEnemy.healEnemy(3);
        UpdateUI();
        actionField.SetText("Enemy healed themselves!");
        
        WaitingForPlayer();
        yield return new WaitForSeconds(2f);
    }
}
