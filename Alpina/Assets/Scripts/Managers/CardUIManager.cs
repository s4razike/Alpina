using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUIManager : MonoBehaviour
{
    public static CardUIManager Instance;

    public DashCard tortuga;

     [Header("Cartas activas")]
    public GameObject[] cartasActivas;

    [Header("Cartas desactivadas")]
    public GameObject[] cartasDesactivadas;

     private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void MostrarCartaSeleccionada(int index)
    {
        for (int i = 0; i < cartasActivas.Length; i++)
        {
            bool seleccionada = (i == index);

            // Mostrar solo la carta activa seleccionada
            cartasActivas[i].SetActive(seleccionada);
            cartasDesactivadas[i].SetActive(!seleccionada);
        }
    }

    public void OcultarTodasLasCartas()
    {
        for (int i = 0; i < cartasActivas.Length; i++)
        {
            cartasActivas[i].SetActive(false);
            cartasDesactivadas[i].SetActive(false);
        }
    }
}
