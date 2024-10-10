using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Todo
//Before continuing on creating the combat system:
//Organize and structure.
//Create a character creation where player picks a class and creates their name
//Then we will have a concrete player object that we can reference in the future.
//Otherwise it will be messy and unorganized because I dont know where the player
//Is starting right now.
public class CombatManager : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI playerHealth;
    public TextMeshProUGUI enemyName;
    public TextMeshProUGUI enemyHealth;
    public TextMeshProUGUI actionField;
    
    private GameManager player;
    private Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        //playerName.SetText(player.name);
        //playerHealth.SetText(player.player.);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Attack()
    {
        
    }

    private void ThrowSpell()
    {
        
    }

    private void Heal()
    {
        
    }
}
