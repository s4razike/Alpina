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
    public Animator lifeUIAnimator;
    public int previousHealth = 4;


    //private PlayerAnimations playerAnimations;

     private void Awake()
    {
        //playerAnimations = GetComponent<PlayerAnimations>();
        player = GetComponent<Player>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Start()
{
    previousHealth = (int)stats.Health;
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

  /*public void TakeDamage(float amount)  
    {
        if (player.hasShield || playerMovement.isDashing){
            player.BreakShield();
        } else {
        if (stats.Health <= 0f) return; 
        stats.Health -= amount; // Reducir la salud
        Debug.Log(stats.Health);
         UpdateLifeUI(stats.Health);

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
         UpdateLifeUI(stats.Health);
    }*/

    /*private void UpdateLifeUI(float currentHealthFloat)
{
    int currentHealth = (int)currentHealthFloat;

    if (currentHealth < previousHealth)
    {
        if (previousHealth == 3 && currentHealth == 2)
            lifeUIAnimator.Play("3to2Life");
        else if (previousHealth == 2 && currentHealth == 1)
            lifeUIAnimator.Play("2to1Life");
        else if (previousHealth == 1 && currentHealth == 0)
            lifeUIAnimator.Play("1to0Life");
    }
    else if (currentHealth > previousHealth)
    {
        if (previousHealth == 1 && currentHealth == 2)
            lifeUIAnimator.Play("1to2Life");
    }

    previousHealth = currentHealth;
}*/

/*void UpdateLifeUI(float currentHealthFloat)
    {
         int currentHealth = (int)currentHealthFloat;

        int currentLife = Mathf.Clamp(Mathf.RoundToInt(stats.Health), 0, 4); // Asegura valores válidos
        lifeUIAnimator.SetInteger("LifeCount", currentLife);
    }*/ 

    public void TakeDamage(float amount)  
{
    if (player.hasShield || playerMovement.isDashing)
    {
        player.BreakShield();
        
        return;
    }
    
    if (stats.Health <= 0f) return; 
    
    stats.Health = Mathf.Max(0f, stats.Health - amount); // Asegura no menor a 0
    Debug.Log("Vida actual: " + stats.Health);
    
    UpdateLifeUI(stats.Health);

    if (stats.Health <= 0f)
    {
        PlayerDead();
    }
}

public void AddLife(float amount)
{
    if (stats.Health <= 0f) return;
    
    stats.Health += amount;
    Debug.Log("Vida actual: " + stats.Health);
    
    UpdateLifeUI(stats.Health);
}

private void UpdateLifeUI(float currentHealth)
{
    // Convertir salud a número de vidas (0-3)
    int lifeCount = Mathf.FloorToInt(currentHealth);
    
    // Asegurar que está en rango 0-3
    lifeCount = Mathf.Clamp(lifeCount, 0, 3);
    
    // Actualizar Animator
    lifeUIAnimator.SetInteger("LifeCount", lifeCount);
    
    // Debug adicional
    Debug.Log($"Actualizando UI: {currentHealth} → {lifeCount} vidas");
}

    private void PlayerDead()
    {
    //playerAnimations.ShowDeadAnimation();
    //UIManager.Instance.GameOver(health);
    }

}
