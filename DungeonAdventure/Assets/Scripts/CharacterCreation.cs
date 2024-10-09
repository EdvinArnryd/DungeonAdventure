using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreation : MonoBehaviour
{
    private Player player;
    public Button continueButton;
    public TMP_InputField inputField;

    public void Start()
    {
        player = new Player();
    }

    public void Update()
    {
        if (player.heroClass == null)
        {
            continueButton.interactable = false;
        }
        else
        {
            continueButton.interactable = true;
        }
    }

    public void ChooseWarriorClass()
    {
        player.heroClass = new Warrior();
        Debug.Log(player.heroClass.className);
    }
    
    public void ChooseMageClass()
    {
        player.heroClass = new Mage();
        Debug.Log(player.heroClass.className);
    }
    
    public void ChooseRogueClass()
    {
        player.heroClass = new Rogue();
        Debug.Log(player.heroClass.className);
    }

    public void ContinueButton()
    {
        player.name = inputField.text;
        Debug.Log(player.name);
    }
    
}
