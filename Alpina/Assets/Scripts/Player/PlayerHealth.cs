using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;

    [Header("Config")]
    [SerializeField] private PlayerStats stats; 

    //private PlayerAnimations playerAnimations;

     private void Awake()
    {
        //playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
       if (stats.Health <= 0f)
        {
            PlayerDead();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            TakeDamage(1); 
        }
    }

  public void TakeDamage(float amount)  
    {
        if (stats.Health <= 0f) return; 
        stats.Health -= amount; // Reducir la salud
        Debug.Log(stats.Health);
        if (stats.Health <= 0f) // Verificar si el jugador sigue vivo
        {
            stats.Health = 0f;
            PlayerDead();
        }
    }

    private void PlayerDead()
{
    //playerAnimations.ShowDeadAnimation();
    //UIManager.Instance.GameOver(health);
}
}
