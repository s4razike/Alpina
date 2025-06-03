using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelFinish : MonoBehaviour
{
    // Lista de nombres de las escenas en el orden en que deben ser cargadas
    public string[] sceneNames;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador llegó a la meta. Avanzando al siguiente nivel...");
            LoadNextLevel();
        }
    }
    void LoadNextLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        int currentSceneIndex = System.Array.IndexOf(sceneNames, currentSceneName);
        if (currentSceneIndex >= 0 && currentSceneIndex < sceneNames.Length - 1)
        {
            string nextSceneName = sceneNames[currentSceneIndex + 1];
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.Log("Último nivel alcanzado. No hay más niveles.");
            // Aquí puedes agregar lógica para mostrar un menú o reiniciar el juego
        }
    }
}