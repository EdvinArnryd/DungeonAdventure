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

    [Header("LevelUI")] 
    public GameObject BG;

    [Header("ButtonRef")] 
    public Button north;
    public Button west;
    public Button east;
    public Button south;

    [Header("PlayerDataUI")] 
    public TextMeshProUGUI ClassTxt;
    public TextMeshProUGUI NameTxt;
    public TextMeshProUGUI HealthTxt;
    public TextMeshProUGUI XPTxt;
    public TextMeshProUGUI LevelTxt;
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
    public GameObject ShopPanel;
    public GameObject RedDoorPanel;
    public GameObject BlueDoorPanel;
    public GameObject ShopPanel2;

    [Header("TokenUI")]
    public GameObject tokenGrid;
    public GameObject tokenSlot;
    
    [Header("AudioManager")]
    public GameObject AudioManager;

    [Header("LevelLoader")] 
    public GameObject levelLoader;
    
    private Room currentRoom;
    private Room[,] playerDungeonLevel;
    
    void Start()
    {
        playerDungeonLevel = player.GetDungeonLevel();

        currentRoom = playerDungeonLevel[player.col, player.row];
        displayRoomTxt.SetText(currentRoom.roomName);
        displayRoomDescTxt.SetText(currentRoom.description);

        map = player.playerMap;

        if (player.IsSecondLevel())
        {
            BG.GetComponent<Image>().sprite = Resources.Load<Sprite>("Art/BackGrounds/WalkingBG2");
        }

        UpdatePlayerStats();
        
        
        // update inventory
        PopulateInventoryUI();
        PopulateTokenUI();
    }

    void UpdateRoomDisplay()
    {
        currentRoom = playerDungeonLevel[player.col, player.row];
        displayRoomTxt.SetText(currentRoom.roomName);
        displayRoomDescTxt.SetText(currentRoom.description);
        SpecialRoomObject.SetActive(false);

        // Special Room Logic
        if (currentRoom is SpecialRoom specialRoom)
        {
            SpecialRoomObject.SetActive(true);
            if (currentRoom.roomName == "Shop Keeper")
            {
                ShopPanel.SetActive(true);
                SpecialRoomObject.GetComponent<Image>().sprite = specialRoom.npcSprite;
                sellButton.gameObject.SetActive(true);
            }
            
            if (currentRoom.roomName == "Shop Keeper2")
            {
                ShopPanel2.SetActive(true);
                SpecialRoomObject.GetComponent<Image>().sprite = specialRoom.npcSprite;
                sellButton.gameObject.SetActive(true);
            }

            if (currentRoom.roomName == "Red Door")
            {
                SpecialRoomObject.GetComponent<Image>().sprite = specialRoom.npcSprite;
                if (player.GetSpecificToken("RedKey"))
                {
                    RedDoorPanel.SetActive(true);
                }
                else
                {
                    Debug.Log("Player doesnt have the token!");
                }
            }
            
            if (currentRoom.roomName == "Blue Door")
            {
                SpecialRoomObject.GetComponent<Image>().sprite = specialRoom.npcSprite;
                if (player.GetSpecificToken("BlueKey"))
                {
                    BlueDoorPanel.SetActive(true);
                }
                else
                {
                    Debug.Log("Player doesnt have the token!");
                }
            }
        }
        else
        {
            BlueDoorPanel.SetActive(false);
            ShopPanel2.SetActive(false);
            RedDoorPanel.SetActive(false);
            ShopPanel.SetActive(false);
            sellButton.gameObject.SetActive(false);
            TriggerCombat();
        }
    }
    
    public void walkNorth()
    {
        if (player.col <= 0)
        {
            player.col = 0;
            walkingDirectionTxt.SetText("Can't walk here");
        }
        else
        {
            player.col--;
            walkingDirectionTxt.SetText("You walked north");
            UpdateRoomDisplay();
        }
    }
    
    public void walkSouth()
    {
        if (player.col >= map.maxHeight -1)
        {
            player.col = map.maxHeight -1;
            walkingDirectionTxt.SetText("Can't walk here");
        }
        else
        {
            player.col++;
            walkingDirectionTxt.SetText("You walked south");
            UpdateRoomDisplay();
        }
    }
    
    public void walkEast()
    {
        if (player.row >= map.maxWidth -1)
        {
            player.row = map.maxWidth -1;
            walkingDirectionTxt.SetText("Can't walk here");
        }
        else
        {
            player.row++;
            walkingDirectionTxt.SetText("You walked east");
            UpdateRoomDisplay();
        }
    }
    
    public void walkWest()
    {
        if (player.row <= 0)
        {
            player.row = 0;
            walkingDirectionTxt.SetText("Can't walk here");
        }
        else
        {
            player.row--;
            walkingDirectionTxt.SetText("You walked west");
            UpdateRoomDisplay();
        }
    }

    private void TriggerCombat()
    {
        randomValue = Random.Range(1, 5);
        if (randomValue == 4)
        {
            north.interactable = false;
            south.interactable = false;
            east.interactable = false;
            west.interactable = false;
            levelLoader.GetComponent<LoadScene>().LoadNextScene("Combat");
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
                button.onClick.AddListener(() => AudioManager.GetComponent<AudioManager>().PlayInventorySlotSound());
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
        XPTxt.SetText("Experience: " + player.GetXP() + "/" + player.GetXpThreshold());
        LevelTxt.SetText("Level: " + player.GetLevel());
        GoldTxt.SetText("Gold: " + player.GetGold());
        STRTxt.SetText("Strength: " + player.GetStrength());
        INTTxt.SetText("Intelligence: " + player.GetIntelligence());
        ManaTxt.SetText("Mana: " + player.GetMana());
        healthPotsTxt.SetText(player.GetHealthPotions().ToString());
        manaPotsTxt.SetText(player.GetManaPotions().ToString());
    }

    public void EnterLevel2()
    {
        Level2 map2 = new Level2();
        player.SetMap(map2);
        player.SetDungeonLevel(map2.map);
        player.col = 0;
        player.row = 0;
        levelLoader.GetComponent<LoadScene>().LoadNextScene("Game");
    }

    public void EnterBossRoom()
    {
        levelLoader.GetComponent<LoadScene>().LoadNextScene("BossRoom");
    }

}
