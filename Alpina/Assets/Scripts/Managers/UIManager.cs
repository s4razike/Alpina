using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
     public static UIManager Instance;
     // UI 
     public Image escudo;

    //referencias para la barra de vida de enemigo
    //public Image healthBar;
    //public Image healthBar2;

    [Header("Panels")]

    //referencias panel ganar
    public GameObject winPanel;
    public Image winText;
    public Animator winAnimator;
    public Image loseText;
    public Animator loseAnimator;
    public TextMeshProUGUI extraHealth;
    public TextMeshProUGUI time;
    private float totalDuration;
    private float timer;
    public Image star1;
    public Image star2;
    public Image star3;
    public TextMeshProUGUI score;
    //referencias panel perder
    public GameObject gameOverPanel;

    public GameObject settingsPanel;

    private Coroutine activeCoroutine;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);  
        settingsPanel.SetActive(false);
        escudo.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
        loseText.gameObject.SetActive(false);
 
    }

    public void ShieldPower()
    {
    escudo.gameObject.SetActive(true);
 
    }

    public void DisableShieldPower()
    {
    escudo.gameObject.SetActive(false);
    }

    public void GameOver(float health)
{
    StartCoroutine(PlayLoseAnimationThenShowPanel());
}

private IEnumerator PlayLoseAnimationThenShowPanel()
{
    loseText.gameObject.SetActive(true);
    loseAnimator.SetTrigger("Derrota"); // Asegúrate de tener un trigger llamado "Derrota" en el Animator
    yield return new WaitForSeconds(1.6f); // Tiempo estimado de la animación de perder

    gameOverPanel.SetActive(true);
    loseText.gameObject.SetActive(false);
    Time.timeScale = 0;
}

public void Win()
{
    StartCoroutine(PlayWinAnimationThenShowPanel());
}

private IEnumerator PlayWinAnimationThenShowPanel()
{
    winText.gameObject.SetActive(true);
    winAnimator.SetTrigger("VictoriaText");
    yield return new WaitForSeconds(1.7f); // Tiempo de animación de victoria

    //HealthText(health);
    winPanel.SetActive(true);
    winText.gameObject.SetActive(false);
    Time.timeScale = 0;
}

/*public void HealthText(float health)
    {
        extraHealth.text = health.ToString("0") + " /3";
    }*/
}
