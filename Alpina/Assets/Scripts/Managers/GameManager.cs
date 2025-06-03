using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerStats playerStats;
    void Start()
    {
        // Resetea las estadísticas del jugador al iniciar el juego
        playerStats.ResetPlayer();
    }
    // Puedes agregar más lógica aquí para manejar el juego
}
