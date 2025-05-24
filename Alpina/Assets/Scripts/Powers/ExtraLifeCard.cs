using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExtraLifeCard", menuName = "Cards/Extra Life")]
public class ExtraLifeCard : PowerCard
{
    public override bool CanActivate(GameObject player)
    {
        var controller = player.GetComponent<Player>();
        var stats = controller.stats;
        
        return stats.Health == 1;
    }

    public override void Activate(GameObject player)
    {
        player.GetComponent<PlayerHealth>().AddLife(1); 
    }
}
