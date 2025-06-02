using UnityEngine;
using UnityEngine.SceneManagement;

public class Escenas : MonoBehaviour
{
    public void ReiniciarNivelActual()
    {
        // Obtiene el índice de la escena actual
        int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;
        // Recarga la escena actual
        SceneManager.LoadScene(indiceEscenaActual);
    }

    [Tooltip("Panel de pausa que se mostrará/ocultará")]
    public GameObject panelPausa;
    // Variable para controlar si el juego está pausado
    private bool juegoPausado = false;
    void Start()
    {
        // Asegurarse que el panel de pausa está oculto al iniciar
        if (panelPausa != null)
        {
            panelPausa.SetActive(false);
        }
    }
    void Update()
    {
        // Detectar la pulsación de la tecla Escape
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
        Time.timeScale = 1f; // Continúa el tiempo del juego

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

    [Tooltip("Nombre o índice de la escena del menú principal")]
    public string mainMenuSceneName = "MainMenu";
    /// <summary>
    /// Carga la escena del menú principal.
    /// </summary>
    public void ReturnToMainMenuScene()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }



    }
