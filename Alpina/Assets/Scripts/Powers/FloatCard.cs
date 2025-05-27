using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FloatCard", menuName = "Cards/Float")]
public class FloatCard : PowerCard
{
    public float floatDuration = 3f;

    public float cooldownTime = 15f; // tiempo de espera en segundos
    private float lastUseTime = -Mathf.Infinity;

    public override bool CanActivate(GameObject player)
    {
        return Time.time >= lastUseTime + cooldownTime;
    }

    public override void Activate(GameObject player)
    {
       player.GetComponent<PlayerMovement>().StartFloat(); 
       
        lastUseTime = Time.time;
    }
}
