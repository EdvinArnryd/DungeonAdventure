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

    void Start()
    {
        // Initialize the map and player
        map = new Map();
        map.Initialize();
        player = new Player();
        player.Initialize();
        row = 1;
        col = 1;
    }

    void Update()
    {
        //Debug.Log(map.map[player.row, player.col].description);
    }
    

    public void walkNorth()
    {
        if (col <= 1)
        {
            col = 1;
            Debug.Log(col);
            Debug.Log("Can't walk here");
        }
        else
        {
            col--;
            Debug.Log(col);
            Debug.Log("You walked north");
        }
    }
    
    public void walkSouth()
    {
        if (col >= map.maxHeight)
        {
            col = map.maxHeight;
            Debug.Log(col);
            Debug.Log("Can't walk here");
        }
        else
        {
            col++;
            Debug.Log(col);
            Debug.Log("You walked south");
        }
    }
    
    public void walkEast()
    {
        if (row >= map.maxWidth)
        {
            row = map.maxWidth;
            Debug.Log("row" + row);
            Debug.Log("Can't walk here");
        }
        else
        {
            row++;
            Debug.Log("row" + row);
            Debug.Log("You walked east");
        }
    }
    
    public void walkWest()
    {
        if (row <= 1)
        {
            row = 1;
            Debug.Log("row" + row);
            Debug.Log("Can't walk here");
        }
        else
        {
            row--;
            Debug.Log("row" + row);
            Debug.Log("You walked west");
        }
    }

}
