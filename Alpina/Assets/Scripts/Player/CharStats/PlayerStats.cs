using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : ScriptableObject
{
    [Header("Config")]
  public float Stars;

  [Header("Health")]
  public float Health = 3; 
  public float MaxHealth = 3; 

  [Header("Character")]
  public string characterName;
  public GameObject prefab;

   public void ResetPlayer()
  {
    Health = MaxHealth;
    Stars=00;

  }
}
