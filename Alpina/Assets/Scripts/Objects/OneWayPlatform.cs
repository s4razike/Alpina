using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
   [Header("Settings")]
    [SerializeField] private float dropDownTime = 0.5f;
    [SerializeField] private float dropDownForce = 5f;
    
    private PlatformEffector2D effector;
    private Collider2D platformCollider;
    private bool playerIsOnPlatform;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
        platformCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        // Verificar input solo si el jugador está en la plataforma
        if (playerIsOnPlatform && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            StartCoroutine(DisablePlatformTemporarily());
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerIsOnPlatform = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerIsOnPlatform = false;
        }
    }

    IEnumerator DisablePlatformTemporarily()
    {
        // Obtener el collider del jugador (asumiendo que solo un jugador puede estar en la plataforma)
        Collider2D playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        Rigidbody2D playerRb = playerCollider.GetComponent<Rigidbody2D>();
        
        if (playerCollider != null && playerRb != null)
        {
            // Desactivar colisión
            Physics2D.IgnoreCollision(platformCollider, playerCollider, true);
            
            // Aplicar fuerza hacia abajo
            playerRb.velocity = new Vector2(playerRb.velocity.x, -dropDownForce);
            
            // Esperar
            yield return new WaitForSeconds(dropDownTime);
            
            // Reactivar colisión solo si el jugador no ha vuelto a entrar
            if (!playerIsOnPlatform)
            {
                Physics2D.IgnoreCollision(platformCollider, playerCollider, false);
            }
        }
    }
}
