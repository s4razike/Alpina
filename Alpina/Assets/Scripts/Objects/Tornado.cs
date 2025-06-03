using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    public float velocidad = 10f;
    public int amount = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Buscar si tiene un script con la función RecibirDanio
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(amount);
            }

            Destroy(gameObject); // Destruir la bala al impactar
        }
    }
    void Update()
    {
    transform.Translate(Vector2.left * velocidad * Time.deltaTime);
    }
}
