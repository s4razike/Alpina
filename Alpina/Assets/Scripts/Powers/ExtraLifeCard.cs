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
        
        return stats.Health == 1;
    }

    public override void Activate(GameObject player)
    {
        if (yaFueUsada) return;

        player.GetComponent<PlayerHealth>().AddLife(1); 
        yaFueUsada = true;
    }
}
