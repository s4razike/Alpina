using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;

    [Header("Config")]
    [SerializeField] private PlayerStats stats;
    private Player player; 
    private PlayerMovement playerMovement; 


    //private PlayerAnimations playerAnimations;

     private void Awake()
    {
        //playerAnimations = GetComponent<PlayerAnimations>();
        player = GetComponent<Player>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
       if (stats.Health <= 0f)
        {
            PlayerDead();
        }

        /*if (Input.GetKeyDown(KeyCode.X))
        {
            TakeDamage(1); 
        }*/
    }

  public void TakeDamage(float amount)  
    {
        if (player.hasShield || playerMovement.isDashing){
            player.BreakShield();
        } else {
        if (stats.Health <= 0f) return; 
        stats.Health -= amount; // Reducir la salud
        Debug.Log(stats.Health);
        if (stats.Health <= 0f) // Verificar si el jugador sigue vivo
        {
            stats.Health = 0f;
            PlayerDead();
        }
        }
    }

    public void AddLife(float amount)
    {
        if (stats.Health <= 0f) return;
        stats.Health += amount;
        Debug.Log(stats.Health);
    }

    private void PlayerDead()
    {
    //playerAnimations.ShowDeadAnimation();
    //UIManager.Instance.GameOver(health);
    }

}
