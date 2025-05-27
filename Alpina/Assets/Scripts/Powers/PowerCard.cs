using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public abstract class PowerCard : ScriptableObject
{
    public string cardName;
    public string description;

    public abstract void Activate(GameObject player);

    public virtual bool CanActivate(GameObject player)
    {
        return true; 
    }
}
