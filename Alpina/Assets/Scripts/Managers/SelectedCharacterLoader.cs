using UnityEngine;
public class SelectedCharacterLoader : MonoBehaviour
{
    [Tooltip("Spawn position where the character will be instantiated")]
    public Transform spawnPoint;
    [Header("Character Prefabs")]
    public GameObject TrompedroChar;
    public GameObject CanarioChar;
    public GameObject TortugaChar;
    public GameObject UnicornChar;
    private const string PlayerPrefKey = "SelectedCharacter";
    void Start()
    {
        string selectedCharacter = PlayerPrefs.GetString(PlayerPrefKey, "");
        Debug.Log($"Selected character from PlayerPrefs: {selectedCharacter}");
        if (string.IsNullOrEmpty(selectedCharacter))
        {
            Debug.LogWarning("No character selected. Defaulting to ElefanteChar.");
            selectedCharacter = "ElefanteChar";  // fallback default
        }
        GameObject prefabToSpawn = GetPrefabByName(selectedCharacter);
        if (prefabToSpawn == null)
        {
            Debug.LogError($"No prefab assigned for character '{selectedCharacter}'.");
            return;
        }
        if (spawnPoint == null)
        {
            Debug.LogError("Spawn point is not assigned.");
            return;
        }
        Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
    }
    private GameObject GetPrefabByName(string characterName)
    {
        switch (characterName)
        {
            case "TrompedroChar":
                return TrompedroChar;
            case "CanarioChar":
                return CanarioChar;
            case "TortugaChar":
                return TortugaChar;
            case "UnicornChar":
                return UnicornChar;
            default:
                Debug.LogError($"No prefab found for character '{characterName}'.");
                return null;
        }
    }
}