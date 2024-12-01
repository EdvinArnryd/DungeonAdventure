using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource audioSource;
    public AudioClip buttonClickSound;
    public AudioClip sellButtonSound;
    public AudioClip buyButtonSound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(buttonClickSound);
    }
    
    public void PlaySellSound()
    {
        audioSource.PlayOneShot(sellButtonSound);
    }
    
    public void PlayBuySound()
    {
        audioSource.PlayOneShot(buyButtonSound);
    }
}
