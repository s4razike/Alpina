using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DashCard", menuName = "Cards/Dash")]
public class DashCard : PowerCard
{

   public override bool CanActivate(GameObject player)
    {
        Debug.Log("funciona, aiuda");
        return true;
    }

    public override void Activate(GameObject player)
{
    PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
    if (playerMovement != null)
    {
        playerMovement.Dash();
        
        // Opcional: desactivar dash hasta que se complete
        // playerMovement.DisableDash();
        // Invoke(nameof(EnablePlayerDash), cooldownTime);
    }
}

private void EnablePlayerDash(GameObject player)
{
    player.GetComponent<PlayerMovement>().EnableDash();
}
}
