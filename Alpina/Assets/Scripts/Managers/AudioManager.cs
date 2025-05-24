using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public static AudioManager instance;
   private AudioSource audioSource;

   [Header("Audio Clips")]
   public AudioClip enemyDamageLv1;
   public AudioClip playerDamage;
   public AudioClip playerAttack;
   public AudioClip enemyAttackLv1;
   public AudioClip gameOver;
   public AudioClip win;
   public AudioClip starFalling;
   public AudioClip pickStar;
   public AudioClip jump;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlayEnemyDamageLv1() { PlaySound(enemyDamageLv1);}
    public void PlayPlayerDamage() { PlaySound(playerDamage);}
    public void PlayPlayerAttack() { PlaySound(playerAttack);}
    public void PlayEnemyAttackLv1() { PlaySound(enemyAttackLv1);}
    public void PlayGameOver() { PlaySound(gameOver);}
    public void PlayWin() { PlaySound(win);}
    public void PlayStarFalling() { PlaySound(starFalling);}
    public void PlayPickStar() { PlaySound(pickStar);}
    public void PlayJump() { PlaySound(jump);}

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
