using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItems : MonoBehaviour
{
    public GameObject healthPot;
    public GameObject manaPot;
    public GameObject key;

    public PlayerData player;

    public void UpdateShopItems()
    {
        // Iterate through all child objects of the ShopGrid (this GameObject)
        foreach (Transform item in transform)
        {
            // Get the cost from the BuyButton script
            BuyButton buyButton = item.GetComponent<BuyButton>();
            
            int itemCost = buyButton.cost;

            // Find the Button component in the child objects
            Button itemButton = item.GetComponentInChildren<Button>();
           
            // Enable or disable the button based on the player's money
            itemButton.interactable = player.GetGold() >= itemCost;
        }

    }
}
