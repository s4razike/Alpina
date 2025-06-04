using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ExtraLifeCard", menuName = "Cards/Extra Life")]
public class ExtraLifeCard : PowerCard
{
    private bool yaFueUsada = false; 
    public override bool CanActivate(GameObject player)
    {
        if (yaFueUsada) return false;
        var controller = player.GetComponent<Player>();
        var stats = controller.stats;
        Debug.Log($"[ExtraLifeCard] Salud del jugador: {stats.Health}"); // Verifica la salud
        return stats.Health == 1; // Solo se puede activar si la salud es 1
    }
    public override void Activate(GameObject player)
    {
        if (yaFueUsada) return;
        Debug.Log("[ExtraLifeCard] Activando carta...");
        var stats = player.GetComponent<Player>().stats;
        stats.AddHealth(1); 
        yaFueUsada = true; 
        Debug.Log("[ExtraLifeCard] Vida a�adida al jugador. Total de vidas ahora: " + stats.Health);
    }

    public void ResetCard()
{
    yaFueUsada = false;
}

}