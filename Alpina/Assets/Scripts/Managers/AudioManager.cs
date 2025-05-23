using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public static AudioManager instance;
   private AudioSource audioSource;

   [Header("Audio Clips")]
   public AudioClip enemyDamageLv1;
   public AudioClip enemyDamageLv2;
   public AudioClip playerDamage;
   public AudioClip playerAttack;
   public AudioClip enemyAttackLv1;
   public AudioClip enemyAttackLv2;
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
}
