using UnityEngine;
[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player/Stats")]
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
    /// <summary>
    /// Resetea la salud y las estrellas del jugador.
    /// </summary>
    public void ResetPlayer()
    {
        Health = MaxHealth;
        Stars = 0;
    }
    /// <summary>
    /// Aumenta la salud del jugador.
    /// </summary>
    /// <param name="amount">Cantidad de vida a agregar.</param>
    public void AddHealth(float amount)
    {
        Health += amount; // Aumenta la salud
        if (Health > MaxHealth) // Asegura que no exceda el máximo
        {
            Health = MaxHealth;
        }
        Debug.Log($"[PlayerStats] Salud actual: {Health}/{MaxHealth}"); // Verifica la salud
    }
}