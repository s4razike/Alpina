using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioManager : MonoBehaviour
{
    public GameObject inicioPanel;
    public GameObject settingsPanel;
    public GameObject tiendaMochis;
    public GameObject tiendaPoderes;
    public GameObject tiendaCodigo;

    public void Start()
    {
        inicioPanel.SetActive(true);
        settingsPanel.SetActive(false);
        tiendaMochis.SetActive(false);
        tiendaPoderes.SetActive(false);
        tiendaCodigo.SetActive(false);
    }

    public void Inicio()
    {
        inicioPanel.SetActive(true);
        settingsPanel.SetActive(false);
        tiendaMochis.SetActive(false);
        tiendaPoderes.SetActive(false);
        tiendaCodigo.SetActive(false);
    }

      public void Settings()
    {
        inicioPanel.SetActive(false);
        settingsPanel.SetActive(true);
        tiendaMochis.SetActive(false);
        tiendaPoderes.SetActive(false);
        tiendaCodigo.SetActive(false);
    }

      public void TiendaMochis()
    {
        inicioPanel.SetActive(false);
        settingsPanel.SetActive(false);
        tiendaMochis.SetActive(true);
        tiendaPoderes.SetActive(false);
        tiendaCodigo.SetActive(false);
    }

    public void TiendaPoderes()
    {
        inicioPanel.SetActive(false);
        settingsPanel.SetActive(false);
        tiendaMochis.SetActive(false);
        tiendaPoderes.SetActive(true);
        tiendaCodigo.SetActive(false);
    }

    public void TiendaCodigo()
    {
        inicioPanel.SetActive(false);
        settingsPanel.SetActive(false);
        tiendaMochis.SetActive(false);
        tiendaPoderes.SetActive(false);
        tiendaCodigo.SetActive(true);
    }
     
}

