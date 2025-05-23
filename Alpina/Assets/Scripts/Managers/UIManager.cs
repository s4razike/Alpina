using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
     public static UIManager Instance;

     [Header("UI")]
    //referencias de texto(HUD)
    public TextMeshProUGUI playerHealth;

    //referencias para la barra de vida de enemigo
    public Image healthBar;
    public Image healthBar2;

    [Header("Panels")]

    //referencias panel ganar
    public GameObject winPanel;
    public Image winText;
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
    }

}
