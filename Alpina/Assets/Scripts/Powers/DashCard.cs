using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DashCard", menuName = "Cards/Dash")]
public class DashCard : PowerCard
{
    public float cooldownTime = 2f; // Tiempo de cooldown en segundos
    private float lastUseTime = -Mathf.Infinity; // Inicializa para permitir el uso inmediato
    /// <summary>
    /// Resetea el cooldown para que la habilidad pueda usarse inmediatamente al inicio.
    /// Puedes llamar este método desde algún controlador al empezar el juego o cuando se crea la instancia.
    /// </summary>
    /// 

    public void Start()
    {
        ResetCooldown();
    }
    public void ResetCooldown()
    {
        lastUseTime = -Mathf.Infinity; // Permite el uso inmediato
        Debug.Log("[DashCard] Cooldown reseteado, lastUseTime = " + lastUseTime);
    }
    public override bool CanActivate(GameObject player)
    {
        Debug.Log($"[DashCard] Checking CanActivate - Time.time={Time.time:F2}, lastUseTime={lastUseTime:F2}, cooldownTime={cooldownTime}");
        if (Time.time >= lastUseTime + cooldownTime)
        {
            Debug.Log("[DashCard] CanActivate = true");
            return true;
        }
        else
        {
            float timeLeft = (lastUseTime + cooldownTime) - Time.time;
            timeLeft = Mathf.Max(0f, timeLeft);
            Debug.Log("[DashCard] Cooldown activo. Tiempo restante: " + timeLeft.ToString("F2") + " segundos");
            return false;
        }
    }
    public override void Activate(GameObject player)
    {
        if (!CanActivate(player)) return; // Verifica si se puede activar
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.Dash(); // Ejecuta el dash
            lastUseTime = Time.time; // Actualiza el tiempo de uso
            Debug.Log("[DashCard] Dash activado. lastUseTime actualizado a " + lastUseTime);
        }
    }
    private void EnablePlayerDash(GameObject player)
    {
        player.GetComponent<PlayerMovement>().EnableDash();
    }
}