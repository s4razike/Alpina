using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FloatCard", menuName = "Cards/Float")]
public class FloatCard : PowerCard
{
    public float floatDuration = 3f;

    public override bool CanActivate(GameObject player)
    {

        return true;
    }

    public override void Activate(GameObject player)
    {
       player.GetComponent<PlayerMovement>().StartFloat(); 
    }
}
