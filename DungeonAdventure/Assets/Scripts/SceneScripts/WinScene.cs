using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinScene : MonoBehaviour
{
    public GameObject levelLoader;
    public PlayerData player;
    public TextMeshProUGUI playerScoreTxt;

    private void Start()
    {
        playerScoreTxt.SetText(player.GetFinalPoints().ToString());
    }

    public void Restart()
    {
        levelLoader.GetComponent<LoadScene>().LoadNextScene("MainMenu");
    }
}
