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
    public Button redKeyButton;
    public TextMeshProUGUI playerGold;
    public TextMeshProUGUI playerHealthPots;
    public TextMeshProUGUI playerManaPots;
    void Start()
    {
        redKey = new RedKey();
        costTxt.SetText(cost.ToString());
        CheckForPlayerRedKey();
    }

    public void BuyHealthPotion()
    {
        if (player.GetGold() >= cost)
        {
            player.addHealthPotion();
            player.playerLoseGold(cost);
            playerGold.SetText(player.GetGold().ToString());
            playerHealthPots.SetText(player.GetHealthPotions().ToString());
        }
    }

    public void BuyManaPotion()
    {
        if (player.GetGold() >= cost)
        {
            player.addManaPotion();
            player.playerLoseGold(cost);
            playerGold.SetText(player.GetGold().ToString());
            playerManaPots.SetText(player.GetManaPotions().ToString());
        }
    }

    public void BuyRedKey()
    {
        if (player.GetGold() >= cost)
        {
            player.playerLoseGold(cost);
            player.AddToken(redKey);
            playerGold.SetText(player.GetGold().ToString());
            CheckForPlayerRedKey();
        }
        
    }

    public void CheckForPlayerRedKey()
    {
        if (player.GetSpecificToken(redKey))
        {
            redKeyButton.interactable = false;
        }
    }


}
