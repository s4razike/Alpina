using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelFinish : MonoBehaviour
{
    // Nombre de la escena a la que deseas cambiar
    public string sceneToLoad;
    // Este m�todo se llama cuando otro collider entra en el trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si el objeto que colision� tiene la etiqueta "Player"
        if (collision.CompareTag("Player"))
        {
            ChangeScene();
        }
    }
    void ChangeScene()
    {
        // Cargar la escena especificada
        SceneManager.LoadScene(sceneToLoad);
    }
}