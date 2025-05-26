using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player Stats")] 
public class PlayerStats : ScriptableObject
{
    [Header("Config")]
  public float Stars;

  [Header("Health")]
  public float Health; 
  public float MaxHealth = 3; 

   public void ResetPlayer()
  {
    Health = MaxHealth;
    Stars=00;

  }
}
