using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;  // Assign the Player object via Inspector
    private Map map;       // Local instance of the Map
    private int row, col;  // Player's current position on the map
    public Button northBtn;
    public Button southBtn;
    public Button eastBtn;
    public Button westBtn;
    public TextMeshProUGUI walkingDirectionTxt;
    public TextMeshProUGUI displayRoomTxt;
    public TextMeshProUGUI displayRoomDescTxt;

    void Start()
    {
        // Initialize the map and player
        map = new Map();
        map.Initialize();
        player = new Player();
        player.Initialize();
        row = 0;
        col = 0;
        
        UpdateRoomDisplay();
    }

    void Update()
    {
        //Debug.Log(map.map[player.row, player.col].description);
    }

    void UpdateRoomDisplay()
    {
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

}
