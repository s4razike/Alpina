using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpikeDamage : MonoBehaviour
{
    public int damageAmount = 1;
    public string playerTag = "Player";
    public float pushForce = 5f; // Fuerza con la que se empuja al jugador
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            // Buscar PlayerHealth en el objeto colisionado o en sus padres
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth == null)
            {
                playerHealth = other.GetComponentInParent<PlayerHealth>();
            }
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                Debug.Log("SpikeDamage: Daño aplicado al jugador: " + damageAmount);
                // Aplicar fuerza al Rigidbody2D del jugador
                Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    // Calcular la dirección hacia afuera desde el centro de los picos
                    Vector2 pushDirection = (other.transform.position - transform.position).normalized;
                    rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
                }
            }
            else
            {
                Debug.LogWarning("SpikeDamage: No se encontró PlayerHealth en " + other.name);
            }
        }
    }
}
