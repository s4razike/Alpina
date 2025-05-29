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

    [Header("Cartas")]
     //cartas
    public Image pajaroActive;
    public Image pajaroDeative;
    public Image elefanteActive;
    public Image elefanteDeactive;
    public Image tortugaActive;
    public Image tortugaDective;
    public Image unicornioActive;
    public Image unicornioDeactive;
    public GameObject tortuga;
    public GameObject pajaro;
    public GameObject unicornio;
    public GameObject elefante;

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

public void PajaroAct(){
    tortuga.SetActive(false); 
    elefante.SetActive(false);
    unicornio.SetActive(false);
    pajaroActive.gameObject.SetActive(true);
    pajaroDeative.gameObject.SetActive(false);
}

public void PajaroDeAct(){
    tortuga.SetActive(false); 
    elefante.SetActive(false);
    unicornio.SetActive(false);
    pajaroActive.gameObject.SetActive(false);
    pajaroDeative.gameObject.SetActive(true);
}

public void ElefanteAct(){
    pajaro.SetActive(false);
    tortuga.SetActive(false);
    unicornio.SetActive(false);
    elefanteActive.gameObject.SetActive(true);
    elefanteDeactive.gameObject.SetActive(false);
}

public void ElefanteDeAct(){
    pajaro.SetActive(false);
    tortuga.SetActive(false);
    unicornio.SetActive(false);
    elefanteActive.gameObject.SetActive(false);
    elefanteDeactive.gameObject.SetActive(true);
}

public void TortugaAct(){
    elefante.SetActive(false);
    unicornio.SetActive(false);
    pajaro.SetActive(false);
    tortugaActive.gameObject.SetActive(true);
    tortugaDective.gameObject.SetActive(false);
}

public void TortugaDeAct(){
     elefante.SetActive(false);
    unicornio.SetActive(false);
    pajaro.SetActive(false);
    tortugaActive.gameObject.SetActive(false);
    tortugaDective.gameObject.SetActive(true);
}

public void UnicornioAct(){
    elefante.SetActive(false);
    tortuga.SetActive(false);
    pajaro.SetActive(false);
    unicornioActive.gameObject.SetActive(true);
    unicornioDeactive.gameObject.SetActive(false);
}

public void UnicornioDeAct(){
    elefante.SetActive(false);
    tortuga.SetActive(false);
    pajaro.SetActive(false);
    unicornioActive.gameObject.SetActive(false);
    unicornioDeactive.gameObject.SetActive(true);
}

/*public void HealthText(float health)
    {
        extraHealth.text = health.ToString("0") + " /3";
    }*/
}
