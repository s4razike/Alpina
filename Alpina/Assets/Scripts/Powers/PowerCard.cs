using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerCard : ScriptableObject
{
    public string cardName;
    public string description;
    public Sprite icon;

    public abstract void Activate(GameObject player);

    public virtual bool CanActivate(GameObject player)
    {
        return true; 
    }
}
