using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("UI")]
    public AudioSource audioSource;
    public AudioClip buttonClickSound;
    public AudioClip sellButtonSound;
    public AudioClip buyButtonSound;
    public AudioClip openDoorSound;

    [Header("Combat UI")]
    public AudioClip attackHitSound;
    public AudioClip usePotionSound;
    public AudioClip useSpellSound;

    [Header("Enemy Combat")]
    public AudioClip enemyMissSound;
    public AudioClip enemyAttackSound;
    public AudioClip enemyHealSound;
    public AudioClip enemyGruntSound;

    [Header("Combat Over")] 
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip levelUpSound;

    
    public void PlayWinSound()
    {
        audioSource.PlayOneShot(winSound);
    }
    
    public void PlayLoseSound()
    {
        audioSource.PlayOneShot(loseSound);
    }
    
    public void PlayLevelUpSound()
    {
        audioSource.PlayOneShot(levelUpSound);
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
    
    public void PlayAttackHitSound()
    {
        audioSource.PlayOneShot(attackHitSound);
    }
    
    public void PlayUseSpellSound()
    {
        audioSource.PlayOneShot(useSpellSound);
    }

    public void PlayUsePotionSound()
    {
        audioSource.PlayOneShot(usePotionSound);
    }

    public void PlayOpenDoorSound()
    {
        audioSource.PlayOneShot(openDoorSound);
    }
    
    
    
    // Enemy SFX
    
    public void PlayEnemyMissSound()
    {
        audioSource.PlayOneShot(enemyMissSound);
    }
    
    public void PlayEnemyAttackSound()
    {
        audioSource.PlayOneShot(enemyAttackSound);
    }
    
    public void PlayEnemyHealSound()
    {
        audioSource.PlayOneShot(enemyHealSound);
    }
    
    public void PlayEnemyGrunt()
    {
        audioSource.PlayOneShot(enemyGruntSound);
    }
}
