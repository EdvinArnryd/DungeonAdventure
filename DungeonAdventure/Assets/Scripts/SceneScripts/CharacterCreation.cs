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
    private Level1 level1;

    public GameObject levelLoader;

    public void Start()
    {
        level1 = new Level1();
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
        player.SetMap(level1);
        player.SetDungeonLevel(level1.map);
        //SceneManager.LoadScene("Game");
        levelLoader.GetComponent<LoadScene>().LoadNextScene("Game");
    }
    
}
