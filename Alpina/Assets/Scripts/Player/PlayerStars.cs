using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStats stats;
    [SerializeField] private GameObject starPrefab; // Prefab de la moneda
    [SerializeField] private int starValue;

    /*private void Update()
    {if (Input.GetKeyDown(KeyCode.L))
        {AddCoins(3);}}*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {
            Debug.Log("Estrella recogida");
            stats.Stars += starValue; // Sumar estrellas al jugador
            Destroy(collision.gameObject); 
        }
    }
}
