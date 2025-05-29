using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DashCard", menuName = "Cards/Dash")]
public class DashCard : PowerCard
{
    public float cooldownTime = 5f;
    private float lastUseTime = -Mathf.Infinity;

   public override bool CanActivate(GameObject player)
    {
     if (Time.time >= lastUseTime + cooldownTime)
    {
        return true;
    }
    else
    {
        float timeLeft = (lastUseTime + cooldownTime) - Time.time;
        timeLeft = Mathf.Max(0f, timeLeft);
        Debug.Log("Cooldown activo. Tiempo restante: " + timeLeft.ToString("F2") + " segundos");
        return false;
    }

    //return  true;
    }

    public override void Activate(GameObject player)
{
    if (!CanActivate(player)) return;

    PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
    if (playerMovement != null)
    {
        playerMovement.Dash();
        lastUseTime = Time.time;
        Debug.Log("Tortuga activada");
    }
}

private void EnablePlayerDash(GameObject player)
{
    player.GetComponent<PlayerMovement>().EnableDash();
}
}
