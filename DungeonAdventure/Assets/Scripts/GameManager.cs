using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;  // Assign the Player object via Inspector
    private Map map;       // Local instance of the Map
    private int row, col;  // Player's current position on the map

    void Start()
    {
        // Initialize the map and player
        map = new Map();
        map.Initialize();
        player.Initialize();
    }

    void Update()
    {
        Debug.Log(map.map[player.row, player.col].description);
    }

}
