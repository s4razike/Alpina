using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerStats playerStats;
    void Start()
    {
        // Resetea las estad�sticas del jugador al iniciar el juego
        playerStats.ResetPlayer();
    }
    // Puedes agregar m�s l�gica aqu� para manejar el juego
}
