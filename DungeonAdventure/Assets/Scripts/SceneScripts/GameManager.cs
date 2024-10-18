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

    void Start()
    {
        // Initialize the map and player
        map = new Map();
        map.Initialize();
        // player = new Player();
        row = 0;
        col = 0;
        
        displayRoomTxt.SetText(map.map[col, row].roomName);
        displayRoomDescTxt.SetText(map.map[col, row].description);
    }

    void UpdateRoomDisplay()
    {
        TriggerCombat();
        displayRoomTxt.SetText(map.map[col, row].roomName);
        displayRoomDescTxt.SetText(map.map[col, row].description);
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

}
