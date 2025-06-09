using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionManager : MonoBehaviour
{
 
/// &lt;summary&gt;
/// Manages character selection from 4 options and scene change.
/// Save selected character in PlayerPrefs and load next scene.
/// &lt;/summary&gt
    [Header("Scene to load after selection")]
    [Tooltip("Set the name of the scene to load after selecting a character")]
    public string nextSceneName = "GameScene";
    // Keys for PlayerPrefs
    private const string PlayerPrefKey = "SelectedCharacter";
    /// &lt;summary&gt;
    /// Call this method from UI buttons with the character identifier.
    /// Example: "Warrior", "Archer", "Mage", "Thief"
    /// &lt;/summary&gt;
    /// &lt;param name="characterName"&gt;Selected character identifier&lt;/param&gt;
    public void SelectCharacter(string characterName)
    {
        Debug.Log($"Character selected: {characterName}");
        PlayerPrefs.SetString(PlayerPrefKey, characterName);
        PlayerPrefs.Save();
        // Load the next scene
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("Next scene name not set in CharacterSelectionManager");
        }
    }
    /// &lt;summary&gt;
    /// Optional: Get currently selected character from PlayerPrefs.
    /// &lt;/summary&gt;
    /// &lt;returns&gt;Selected character name or empty&lt;/returns&gt;
    public string GetSelectedCharacter()
    {
        return PlayerPrefs.GetString(PlayerPrefKey, "");
    }
}

