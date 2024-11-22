using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Continue on special rooms
// Make it so that if the room is a special room then display the specific sprite of that special room
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
        
        // update inventory
        PopulateInventoryUI();
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
            }
        }
        else
        {
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

    public void PopulateInventoryUI()
    {
        if (player.inventory.Count != 0)
        {
            ItemQuantity.SetText(player.inventory.Count + "/" + player.inventory.Capacity);
        }
        
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
                int itemIndex = i; // Capture the current index in a local variable
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
    }

    public void ExitItemInfo()
    {
        ItemInfoPanel.SetActive(false);
    }

}
