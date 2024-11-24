using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterCreation : MonoBehaviour
{
    public PlayerData player;
    public Button continueButton;
    public TMP_InputField inputField;

    public void Start()
    {
        player.ResetData();
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
        player.SetHeroClass(new Warrior());
        Debug.Log(player.heroClass.className);
    }
    
    public void ChooseMageClass()
    {
        player.SetHeroClass(new Mage());
        Debug.Log(player.heroClass.className);
    }
    
    public void ChooseRogueClass()
    {
        player.SetHeroClass(new Rogue());
        Debug.Log(player.heroClass.className);
    }

    public void ContinueButton()
    {
        player.SetName(inputField.text);
        SceneManager.LoadScene("Game");
    }
    
}
