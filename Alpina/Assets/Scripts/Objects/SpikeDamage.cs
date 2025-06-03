using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpikeDamage : MonoBehaviour
{
    public int damageAmount = 1;
    public string playerTag = "Player";
    private void OnTriggerEnter(Collider other)
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
            }
            else
            {
                Debug.LogWarning("SpikeDamage: No se encontró PlayerHealth en " + other.name);
            }
        }
    }
}
