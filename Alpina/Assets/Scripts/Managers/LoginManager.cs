using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoginManager : MonoBehaviour
{

    [Header("Registro")]
    public TMP_InputField regUsernameInput;
    public TMP_InputField regPasswordInput;
    public TMP_InputField regCorreoInput;

    [Header("Login")]
    public TMP_InputField loginUsernameInput;
    public TMP_InputField loginPasswordInput;

    [Header("Paneles")]
    public GameObject panelLogin;
    public GameObject panelRegistro;
    public GameObject panelPreInicio;

    public TextMeshProUGUI messageText;

    void Start()
    {
        ShowPreLogin();
    }

    public void ShowLogin()
    {
        panelLogin.SetActive(true);
        panelRegistro.SetActive(false);
        panelPreInicio.SetActive(false);
         messageText.text = "";
    }

    public void ShowRegistro()
    {
        panelLogin.SetActive(false);
        panelRegistro.SetActive(true);
        panelPreInicio.SetActive(false);
         messageText.text = "";
    }

     public void ShowPreLogin()
    {
        panelLogin.SetActive(false);
        panelRegistro.SetActive(false);
        panelPreInicio.SetActive(true);
         messageText.text = "";
    }

    public void Registrar()
    {
        string username = regUsernameInput.text;
        string password = regPasswordInput.text;
        string correo = regCorreoInput.text;

        if (username != "" && password != "" && correo != "")
        {
            PlayerPrefs.SetString("user_" + username, password);
            messageText.text = "Registro exitoso. Ahora puedes iniciar sesión.";
            ShowLogin();
        }
        else
        {
            messageText.text = "Debes completar todos los campos.";
        }
    }

    public void IniciarSesion()
    {
        string username = loginUsernameInput.text;
        string password = loginPasswordInput.text;

        if (PlayerPrefs.HasKey("user_" + username))
        {
            string storedPassword = PlayerPrefs.GetString("user_" + username);

            if (storedPassword == password)
            {
                PlayerPrefs.SetString("username", username);
                //SceneManager.LoadScene("MainGameScene");
                Debug.Log("todo gucci");
            }
            else
            {
                messageText.text = "Contraseña incorrecta.";
            }
        }
        else
        {
            messageText.text = "Usuario no registrado.";
        }
    }

}
