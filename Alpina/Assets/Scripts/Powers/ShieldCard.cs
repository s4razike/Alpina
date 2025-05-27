using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShieldCard", menuName = "Cards/Shield")]
public class ShieldCard : PowerCard
{
    //shield trompedro
    public bool hasShield = false;
    private Coroutine shieldCoroutine;

    private bool yaFueUsada = false;

    [SerializeField] private float shieldDuration = 5f;
    [SerializeField] private int extraLifeReward = 1;

    public override bool CanActivate(GameObject player)
    {
        if (yaFueUsada) return false;

    var controller = player.GetComponent<Player>();
    var stats = controller.stats;

    return stats.Health == 1 && !controller.hasShield;
    }
    public override void Activate(GameObject player)
    {
        if (yaFueUsada) return;

    var controller = player.GetComponent<Player>();
    
    if (!controller.hasShield)
    {
        controller.ActivateShield(shieldDuration, extraLifeReward);
        yaFueUsada = true;
        Debug.Log("escudo activado");
    }
    }
}
