using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject levelLoader;
    public void LoadScene()
    {
        //SceneManager.LoadScene(sceneName);
        levelLoader.GetComponent<LoadScene>().LoadNextScene("CharacterCreation");
    }
}
