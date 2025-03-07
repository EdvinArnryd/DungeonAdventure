using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

// TODO
// Create a player function that resets player's position on the map and lose some gold.
public class CombatManager : MonoBehaviour
{
    [Header("Initialize UI")]
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI playerHealth;
    public TextMeshProUGUI playerMana;
    public TextMeshProUGUI enemyName;
    public TextMeshProUGUI enemyHealth;
    public TextMeshProUGUI actionField;
    public Image playerImage;
    public Image enemyImage;
    public TextMeshProUGUI enemyDMG;

    [Header("LevelUp")] 
    public Image BG;
    
    public GameObject combatOverPanel;
    public TextMeshProUGUI combatOverTxt;
    public Button combatOverContinue;
    public Button combatOverRespawn;
    public TextMeshProUGUI lootTxt;
    
    [Header("Action Buttons")]
    public Button AttackButton;
    public Button SpellButton;
    public Button HealButton;
    public Button ManaButton;
    
    [Header("Player")]
    public PlayerData player;
    
    [Header("Potions")]
    public TextMeshProUGUI healthPotions;
    public TextMeshProUGUI manaPotions;

    [Header("LevelUp")] 
    public GameObject levelUpPopUp;
    public TextMeshProUGUI levelUpText;
    public TextMeshProUGUI healthIncreaseTxt;
    public TextMeshProUGUI manaIncreaseTxt;
    public TextMeshProUGUI strengthIncreaseTxt;
    public TextMeshProUGUI intelligenceIncreaseTxt;
    public Button continueButton;
    
    [Header("AudioManager")]
    public GameObject AudioManager;

    [Header("LevelLoader")]
    public GameObject levelLoader;
    
    private Enemy currentEnemy;
    private LootSystem lootSystem;
    private EnemySpawner enemySpawner;
    
    
    void Start()
    {
        lootSystem = new LootSystem();
        lootSystem.Initialize();
        enemySpawner = new EnemySpawner();
        enemySpawner.Initialize();
        currentEnemy = new Enemy();
        
        // Player DungeonLevel logic
        if (player.IsSecondLevel())
        {
            BG.sprite = Resources.Load<Sprite>("Art/BackGrounds/CombatBG2");
            currentEnemy = enemySpawner.GetRandomEnemy2();
        }
        else if(player.IsFirstLevel())
        {
            currentEnemy = enemySpawner.GetRandomEnemy1();
        }
        else
        {
            currentEnemy = enemySpawner.SpawnBoss();
        }
        
        // Set enemy stats
        enemyName.SetText(currentEnemy.type);
        enemyImage.sprite = currentEnemy.sprite;
        enemyDMG.SetText(currentEnemy.DMG.ToString());
        
        playerName.SetText(player.GetName());
        UpdateUI();

        playerImage.sprite = player.heroClass.spriteBack;
        
        healthPotions.SetText(player.GetHealthPotions().ToString());
        manaPotions.SetText(player.GetManaPotions().ToString());

        player.OnLevelUp += HandleLevelUp;
        
        AudioManager.GetComponent<AudioManager>().PlayEnemySpawnSound(currentEnemy.enemySpawnSound);
    }

    private void OnDestroy()
    {
        player.OnLevelUp -= HandleLevelUp;
    }

    public void UpdateUI()
    {
        // Set Player and Enemy's Name's and health to UI
        playerHealth.SetText(player.GetHP().ToString());
        playerMana.SetText(player.GetMana().ToString());
        enemyHealth.SetText(currentEnemy.HP.ToString());
    }

    public void Attack()
    {
        DisableButtons();
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        actionField.SetText(player.GetName() + " attacked!");
        yield return new WaitForSeconds(2f);
        AudioManager.GetComponent<AudioManager>().PlayAttackHitSound();
        int randomValue = Random.Range(1, 7);
        if (randomValue == 6)
        {
            // Crit
            actionField.SetText(player.GetName() + " got a lucky crit!");
            yield return new WaitForSeconds(2f);
            currentEnemy.enemyTakeDamage(player.GetDMG());
            UpdateUI();
            actionField.SetText(currentEnemy.type + " took " + player.GetDMG() + " damage.");
            yield return new WaitForSeconds(2f);
            
            if (currentEnemy.HP <= 0)
            {
                yield return new WaitForSeconds(2f);
                actionField.SetText("You killed the enemy!");
                yield return new WaitForSeconds(2f);
                EnemyDied();
                yield break;
            }
        }
        else
        {
            // Attack
            currentEnemy.enemyTakeDamage(player.GetDMG());
            UpdateUI();
            actionField.SetText(currentEnemy.type + " took " + player.GetDMG() + " damage.");
            yield return new WaitForSeconds(2f);
            
            if (currentEnemy.HP <= 0)
            {
                yield return new WaitForSeconds(2f);
                actionField.SetText("You killed the enemy!");
                yield return new WaitForSeconds(2f);
                EnemyDied();
                yield break;
            }
        }
        
        EnemyAction();
    }

    public void ThrowSpell()
    {
        DisableButtons();
        StartCoroutine(ThrowSpellCoroutine());
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
            AudioManager.GetComponent<AudioManager>().PlayUseSpellSound();
            player.UsedSpell();
            currentEnemy.enemyTakeDamage(spellDamage);
            UpdateUI();
            actionField.SetText(currentEnemy.type + " took " + spellDamage + " damage.");
            yield return new WaitForSeconds(2f);
            
            if (currentEnemy.HP <= 0)
            {
                yield return new WaitForSeconds(2f);
                actionField.SetText("You killed the enemy!");
                yield return new WaitForSeconds(2f);
                EnemyDied();
                yield break;
            }
        }

        EnemyAction();
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
        if (player.useHealthPotion(5))
        {
            AudioManager.GetComponent<AudioManager>().PlayUsePotionSound();
            UpdateUI();
            healthPotions.SetText(player.GetHealthPotions().ToString());
            actionField.SetText("Player used health potion!");
            yield return new WaitForSeconds(2f);
        }
        else
        {
            actionField.SetText("Player is out of health potions!");
            yield return new WaitForSeconds(2f);
        }
        
        EnemyAction();
    }

    public void Mana()
    {
        DisableButtons();
        StartCoroutine(ManaCoroutine());
    }

    private IEnumerator ManaCoroutine()
    {
        actionField.SetText("Player used Mana potion!");
        yield return new WaitForSeconds(2f);

        if (player.useManaPotion(6))
        {
            AudioManager.GetComponent<AudioManager>().PlayUsePotionSound();
            UpdateUI();
            actionField.SetText("Player used mana potion!");
            manaPotions.SetText(player.GetManaPotions().ToString());
            yield return new WaitForSeconds(2f);
        }
        else
        {
            actionField.SetText("Player is out of mana potions!");
            yield return new WaitForSeconds(2f);
        }
        
        EnemyAction();
    }

    private void WaitingForPlayer()
    {
        actionField.SetText("Waiting for player input...");
        AttackButton.interactable = true;
        SpellButton.interactable = true;
        HealButton.interactable = true;
        ManaButton.interactable = true;
    }

    private void DisableButtons()
    {
        AttackButton.interactable = false;
        SpellButton.interactable = false;
        HealButton.interactable = false;
        ManaButton.interactable = false;
    }

    private void EnemyAction()
    {
        actionField.SetText("Enemy's turn!");
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
            AudioManager.GetComponent<AudioManager>().PlayEnemyAttackSound();
            // CRIT
            actionField.SetText("Enemy got a lucky hit!");
            yield return new WaitForSeconds(2f);
            player.playerTakeDamage(currentEnemy.DMG * 2);
            UpdateUI();
            actionField.SetText("You lost " + currentEnemy.DMG * 2 + " health points.");
            if (player.GetHP() <= 0)
            {
                yield return new WaitForSeconds(2f);
                actionField.SetText("You Died!");
                yield return new WaitForSeconds(2f);
                PlayerDied();
                yield break;
            }
        }
        else if (randomValue == 5)
        {
            AudioManager.GetComponent<AudioManager>().PlayEnemyMissSound();
            // MISS
            actionField.SetText("Enemy missed!");
        }
        else
        {
            AudioManager.GetComponent<AudioManager>().PlayEnemyAttackSound();
            // NORMAL ATTACK
            player.playerTakeDamage(currentEnemy.DMG);
            UpdateUI();
            actionField.SetText("You lost " + currentEnemy.DMG + " health points.");
            if (player.GetHP() <= 0)
            {
                yield return new WaitForSeconds(2f);
                actionField.SetText("You Died!");
                yield return new WaitForSeconds(2f);
                PlayerDied();
                yield break;
            }
        }
        
        yield return new WaitForSeconds(2f);
        WaitingForPlayer();
    }
    
    private IEnumerator EnemyHealCoroutine()
    {
        yield return new WaitForSeconds(2f);
        currentEnemy.healEnemy(3);
        UpdateUI();
        AudioManager.GetComponent<AudioManager>().PlayEnemyHealSound();
        actionField.SetText("Enemy healed themselves!");
        yield return new WaitForSeconds(2f);
        WaitingForPlayer();
    }

    private void PlayerDied()
    {
        AudioManager.GetComponent<AudioManager>().PlayLoseSound();
        combatOverPanel.SetActive(true);
        Image panelImage = combatOverPanel.GetComponent<Image>();
        combatOverTxt.SetText("GAME OVER!");
        lootTxt.SetText("");
    
        if (panelImage != null)
        {
            panelImage.color = new Color(1, 0,0, 0.5f);
        }
        
        combatOverRespawn.gameObject.SetActive(true);
    }

    private void EnemyDied()
    {
        AudioManager.GetComponent<AudioManager>().PlayWinSound();
        int randomXPGold = Random.Range(1, 10);
        int gold = randomXPGold + 4;
        int xp = (randomXPGold + 2) * 2;
        combatOverPanel.SetActive(true);
        Image panelImage = combatOverPanel.GetComponent<Image>();
        combatOverTxt.SetText("You won!");
        
        Item loot = new Item();
        if (player.IsSecondLevel())
        {
            loot = lootSystem.LootDropLevel2();
        }
        else
        {
            loot = lootSystem.LootDrop();
        }
        string lootName;
        if (loot == null)
        {
            lootName = "Enemy dropped no loot.";
        }
        else
        {
            lootName = loot.itemName;
            player.addItem(loot);
        }
            
        if (panelImage != null)
        {
            panelImage.color = new Color(0,0,0,0.5f);
        }
        lootTxt.SetText("XP: " + xp + "\nGold: " + gold + "\nLoot: " + lootName);
        player.AddGold(gold);
        player.AddXP(xp);
        combatOverContinue.gameObject.SetActive(true);
    }
    
    private void HandleLevelUp()
    {
        AudioManager.GetComponent<AudioManager>().PlayLevelUpSound();
        levelUpPopUp.SetActive(true);
        levelUpText.SetText(player.GetLevel().ToString());
        healthIncreaseTxt.SetText(player.heroClass.healthGrowth.ToString());
        manaIncreaseTxt.SetText(player.heroClass.manaGrowth.ToString());
        strengthIncreaseTxt.SetText(player.heroClass.strengthGrowth.ToString());
        intelligenceIncreaseTxt.SetText(player.heroClass.intelligenceGrowth.ToString());
    }

    public void ContinueGameOver()
    {
        levelLoader.GetComponent<LoadScene>().LoadNextScene("MainMenu");
    }

    public void ContinueWin()
    {
        levelLoader.GetComponent<LoadScene>().LoadNextScene("Game");
    }
    
    public void ContinueDefeatBoss()
    {
        levelLoader.GetComponent<LoadScene>().LoadNextScene("WinScene");
    }

    public void ContinueLevelUp()
    {
        levelUpPopUp.SetActive(false);
    }

}
