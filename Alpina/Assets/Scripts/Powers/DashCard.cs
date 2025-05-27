using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DashCard", menuName = "Cards/Dash")]
public class DashCard : PowerCard
{
    public float cooldownTime = 5f; // tiempo de espera en segundos
    private float lastUseTime = -Mathf.Infinity;

   public override bool CanActivate(GameObject player)
    {
        //Debug.Log("funciona, aiuda");
        //return true;
        return Time.time >= lastUseTime + cooldownTime;
    }

    public override void Activate(GameObject player)
{
    PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
    if (playerMovement != null)
    {
        playerMovement.Dash();
        
         lastUseTime = Time.time;
    }
}

private void EnablePlayerDash(GameObject player)
{
    player.GetComponent<PlayerMovement>().EnableDash();
}
}
