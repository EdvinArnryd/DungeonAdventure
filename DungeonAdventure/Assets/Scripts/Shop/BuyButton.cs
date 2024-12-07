using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public int cost;
    public TextMeshProUGUI costTxt;
    public PlayerData player;
    private RedKey redKey;
    private BlueKey blueKey;
    public Button redKeyButton;
    public TextMeshProUGUI playerGold;
    public TextMeshProUGUI playerHealthPots;
    public TextMeshProUGUI playerManaPots;

    public GameObject shopItems;
    void Start()
    {
        redKey = new RedKey();
        blueKey = new BlueKey();
        costTxt.SetText(cost.ToString());
        CheckForPlayerRedKey();
        CheckForPlayerBlueKey();
        shopItems.GetComponent<ShopItems>().UpdateShopItems();
    }

    public void BuyHealthPotion()
    {
        if (player.GetGold() >= cost)
        {
            player.addHealthPotion();
            player.playerLoseGold(cost);
            playerGold.SetText("Gold: " + player.GetGold());
            playerHealthPots.SetText(player.GetHealthPotions().ToString());
            shopItems.GetComponent<ShopItems>().UpdateShopItems();
        }
    }

    public void BuyManaPotion()
    {
        if (player.GetGold() >= cost)
        {
            player.addManaPotion();
            player.playerLoseGold(cost);
            playerGold.SetText("Gold: " + player.GetGold());
            playerManaPots.SetText(player.GetManaPotions().ToString());
            shopItems.GetComponent<ShopItems>().UpdateShopItems();
        }
    }

    public void BuyRedKey()
    {
        if (player.GetGold() >= cost)
        {
            player.playerLoseGold(cost);
            player.AddToken(redKey);
            playerGold.SetText("Gold: " + player.GetGold());
            shopItems.GetComponent<ShopItems>().UpdateShopItems();
            CheckForPlayerRedKey();
        }
        
    }

    public void CheckForPlayerRedKey()
    {
        if (player.GetSpecificToken(redKey))
        {
            redKeyButton.interactable = false;
            redKeyButton.interactable = false;
            Debug.Log("Redkey checked");
        }
    }
    
    public void BuyBlueKey()
    {
        if (player.GetGold() >= cost)
        {
            player.playerLoseGold(cost);
            player.AddToken(blueKey);
            playerGold.SetText("Gold: " + player.GetGold());
            shopItems.GetComponent<ShopItems>().UpdateShopItems();
            CheckForPlayerBlueKey();
        }
    }
    
    public void CheckForPlayerBlueKey()
    {
        if (player.GetSpecificToken(blueKey))
        {
            redKeyButton.interactable = false;
        }
    }
}
