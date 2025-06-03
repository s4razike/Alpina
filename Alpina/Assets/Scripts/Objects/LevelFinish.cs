using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelFinish : MonoBehaviour
{
    
    // Nombre de la escena a la que deseas cambiar
    public string sceneToLoad;
    void Update()
    {
        // Cambiar de escena al presionar la tecla "C"
        if (Input.GetKeyDown(KeyCode.C))
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