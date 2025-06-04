using UnityEngine;
using UnityEngine.SceneManagement;

public class Escenas : MonoBehaviour
{
    public void ReiniciarNivelActual()
    {
        // Obtiene el �ndice de la escena actual
        int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;
        // Recarga la escena actual
        SceneManager.LoadScene(indiceEscenaActual);
    }

    [Tooltip("Panel de pausa que se mostrar�/ocultar�")]
    public GameObject panelPausa;
    // Variable para controlar si el juego est� pausado
    private bool juegoPausado = false;
    void Start()
    {
        // Asegurarse que el panel de pausa est� oculto al iniciar
        if (panelPausa != null)
        {
            panelPausa.SetActive(false);
        }
    }
    void Update()
    {
        // Detectar la pulsaci�n de la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                ReanudarJuego();
            }
            else
            {
                PausarJuego();
            }
        }
    }

    public void ReanudarJuego()
    {
        Time.timeScale = 1f; // Contin�a el tiempo del juego

        juegoPausado = false;

        if (panelPausa != null)
        {
            panelPausa.SetActive(false);
        }

        // Opcional: volver a bloquear el cursor al reanudar
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
         public void PausarJuego()
    {
        Time.timeScale = 0f; // Detiene el tiempo del juego
        juegoPausado = true;
        if (panelPausa != null)
        {
            panelPausa.SetActive(true);
        }
        // Opcional: bloquear el cursor al pausar
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void ChangeToNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;
        int nextIndex = (currentIndex + 1) % totalScenes;
        SceneManager.LoadScene(nextIndex);
    }

    [Tooltip("Nombre o �ndice de la escena del men� principal")]
    public string mainMenuSceneName = "Inicio";
    /// <summary>
    /// Carga la escena del men� principal.
    /// </summary>
    public void ReturnToMainMenuScene()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void SalirDelJuego()
{
    Debug.Log("[UI] Saliendo del juego...");
    Application.Quit();
}


    }
