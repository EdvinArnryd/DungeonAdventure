using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;


    public void LoadNextScene(string sceneName)
    {
        StartCoroutine(LoadSpecificScene(sceneName));
    }

    IEnumerator LoadSpecificScene(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
    }
}
