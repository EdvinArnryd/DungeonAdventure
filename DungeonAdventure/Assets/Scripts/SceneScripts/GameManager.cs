using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerData player;  // Assign the Player object via Inspector
    private Map map;       // Local instance of the Map
    private int row, col;  // Player's current position on the map
    public TextMeshProUGUI walkingDirectionTxt;
    public TextMeshProUGUI displayRoomTxt;
    public TextMeshProUGUI displayRoomDescTxt;
    private int randomValue;

    [Header("PlayerDataUI")] 
    public TextMeshProUGUI ClassTxt;
    public TextMeshProUGUI NameTxt;
    public TextMeshProUGUI HealthTxt;
    public TextMeshProUGUI XPTxt;
    public TextMeshProUGUI GoldTxt;
    public TextMeshProUGUI STRTxt;
    public TextMeshProUGUI INTTxt;
    public TextMeshProUGUI ManaTxt;
    public TextMeshProUGUI healthPotsTxt;
    public TextMeshProUGUI manaPotsTxt;

    [Header("InventoryUI")] 
    public TextMeshProUGUI ItemQuantity;
    public GameObject itemGrid;
    public GameObject itemSlot;
    public Button sellButton;


    [Header("ItemDataUI")] 
    public GameObject ItemInfoPanel;
    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI ItemStrength; 
    public TextMeshProUGUI ItemIntelligence;
    public TextMeshProUGUI ItemGold;
    public TextMeshProUGUI ItemDescription;

    [Header("ItemDataUI")] 
    public GameObject SpecialRoomObject;

    [Header("TokenUI")]
    public GameObject tokenGrid;
    public GameObject tokenSlot;
    
    private Room currentRoom;
    
    void Start()
    {
        // Initialize the map and player
        map = new Map();
        map.Initialize();
        
        // player = new Player();
        row = 0;
        col = 0;
        
        currentRoom = map.map[col, row];
        displayRoomTxt.SetText(currentRoom.roomName);
        displayRoomDescTxt.SetText(currentRoom.description);

        UpdatePlayerStats();
        
        
        // update inventory
        PopulateInventoryUI();
        PopulateTokenUI();
    }

    void UpdateRoomDisplay()
    {
        currentRoom = map.map[col, row];
        displayRoomTxt.SetText(currentRoom.roomName);
        displayRoomDescTxt.SetText(currentRoom.description);
        SpecialRoomObject.SetActive(false);

        // Special Room Logic
        if (currentRoom is SpecialRoom specialRoom)
        {
            SpecialRoomObject.SetActive(true);
            if (currentRoom.roomName == "Shop Keeper")
            {
                SpecialRoomObject.GetComponent<Image>().sprite = specialRoom.npcSprite;
                sellButton.gameObject.SetActive(true);
            }
        }
        else
        {
            sellButton.gameObject.SetActive(false);
            TriggerCombat();
        }
    }
    
    public void walkNorth()
    {
        if (col <= 0)
        {
            col = 0;
            walkingDirectionTxt.SetText("Can't walk here");
        }
        else
        {
            col--;
            walkingDirectionTxt.SetText("You walked north");
            UpdateRoomDisplay();
        }
    }
    
    public void walkSouth()
    {
        if (col >= map.maxHeight -1)
        {
            col = map.maxHeight -1;
            walkingDirectionTxt.SetText("Can't walk here");
        }
        else
        {
            col++;
            walkingDirectionTxt.SetText("You walked south");
            UpdateRoomDisplay();
        }
    }
    
    public void walkEast()
    {
        if (row >= map.maxWidth -1)
        {
            row = map.maxWidth -1;
            walkingDirectionTxt.SetText("Can't walk here");
        }
        else
        {
            row++;
            walkingDirectionTxt.SetText("You walked east");
            UpdateRoomDisplay();
        }
    }
    
    public void walkWest()
    {
        if (row <= 0)
        {
            row = 0;
            walkingDirectionTxt.SetText("Can't walk here");
        }
        else
        {
            row--;
            walkingDirectionTxt.SetText("You walked west");
            UpdateRoomDisplay();
        }
    }

    private void TriggerCombat()
    {
        randomValue = Random.Range(1, 5);
        if (randomValue == 4)
        {
            SceneManager.LoadScene("Combat");
        }
    }

    public void PopulateTokenUI()
    {
        foreach (Transform child in tokenGrid.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (var token in player.GetTokens())
        {
            GameObject newSlot = Instantiate(tokenSlot, tokenGrid.transform);
            newSlot.GetComponent<Image>().sprite = token.tokenSprite;
        }
    }

    public void PopulateInventoryUI()
    {
        ItemQuantity.SetText(player.inventory.Count + "/" + player.inventory.Capacity);
        
        foreach (Transform child in itemGrid.transform)
        {
            Destroy(child.gameObject);
        }
        
        int i = 0;
        foreach (var item in player.inventory)
        {
            GameObject newSlot = Instantiate(itemSlot, itemGrid.transform);

            newSlot.GetComponent<Image>().sprite = item.sprite;
            newSlot.GetComponent<ItemSlot>().ID = i;
            
            Button button = newSlot.GetComponent<Button>();
            if (button != null)
            {
                int itemIndex = i;
                button.onClick.AddListener(() => ItemPressed(itemIndex));
            }
            
            i++;
        }
    }

    public void ItemPressed(int ID)
    {
        ItemInfoPanel.SetActive(true);
        ItemName.SetText(player.inventory[ID].itemName);
        ItemStrength.SetText("Strength: " + player.inventory[ID].strength);
        ItemIntelligence.SetText("Intelligence: " + player.inventory[ID].intelligence);
        ItemGold.SetText("Gold: " + player.inventory[ID].goldValue);
        ItemDescription.SetText("Description: " + player.inventory[ID].description);
        sellButton.GetComponent<SellButton>().ID = ID;
    }

    public void ExitItemInfo()
    {
        ItemInfoPanel.SetActive(false);
    }

    public void SellItem()
    {
        int BTNID = sellButton.GetComponent<SellButton>().ID;
        int itemGoldValue = player.inventory[BTNID].goldValue;
        player.AddGold(itemGoldValue);
        player.inventory.RemoveAt(BTNID);
        ItemInfoPanel.SetActive(false);
        PopulateInventoryUI();
        UpdatePlayerStats();
    }

    public void UpdatePlayerStats()
    {
        player.CalculateIntelligence();
        player.CalculateStrength();
        // Set player stats
        ClassTxt.SetText("Class: " + player.heroClass.className);
        NameTxt.SetText("Name: " + player.GetName());
        HealthTxt.SetText("Health: " + player.GetHP());
        XPTxt.SetText("Experience: " + player.GetXP());
        GoldTxt.SetText("Gold: " + player.GetGold());
        STRTxt.SetText("Strength: " + player.GetStrength());
        INTTxt.SetText("Intelligence: " + player.GetIntelligence());
        ManaTxt.SetText("Mana: " + player.GetMana());
        healthPotsTxt.SetText(player.GetHealthPotions().ToString());
        manaPotsTxt.SetText(player.GetManaPotions().ToString());
    }

}
