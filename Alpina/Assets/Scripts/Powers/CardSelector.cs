using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CardSelector : MonoBehaviour
{
   /* public PowerCard[] availableCards; // Array de cartas disponibles
    public CardUIManager cardUIManager; // UI Manager para las cartas
    public PlayerStats playerStats; // Stats del jugador
    public bool cardSelected = false; // Indica si hay una carta seleccionada
    public int selectedIndex = -1; // �ndice de la carta seleccionada
    public PowerCard selectedCard; // Carta seleccionada
    void Start()
    {
        cardUIManager.OcultarTodasLasCartas(); // Oculta todas las cartas al inicio
    }
    void Update() // Para probar 
    {
        if (!cardSelected)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                SelectCard(0); // Corregido aqu�
                UIManager.Instance.UnicornioAct();
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                SelectCard(1);
                UIManager.Instance.TortugaAct();
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                SelectCard(2);
                UIManager.Instance.PajaroAct();
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                SelectCard(3);
                UIManager.Instance.ElefanteDeAct();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && selectedCard != null)
        {
            Debug.Log("[CardSelector] Intentando activar la carta: " + selectedCard.cardName);
            if (selectedCard.CanActivate(gameObject))
            {
                selectedCard.Activate(gameObject);
            }
            else
            {
                Debug.Log("[CardSelector] No se puede activar la carta.");
            }
        }
    }
    public void SelectCard(int index)
    {
        if (index < 0 || index >= availableCards.Length) return;
        selectedIndex = index;
        selectedCard = availableCards[index];
        cardSelected = true;
        // Si la carta seleccionada es la DashCard, reinicia el cooldown
        if (selectedCard is DashCard dashCard)
        {
            dashCard.ResetCooldown(); // Reinicia el cooldown
            Debug.Log("[CardSelector] DashCard seleccionada - cooldown reseteado.");
        }
        Debug.Log("Carta seleccionada: " + selectedCard.cardName);
    }*/

    public PowerCard[] availableCards; // Array de cartas disponibles
    public CardUIManager cardUIManager; // UI Manager para las cartas
    public PlayerStats playerStats; // Stats del jugador
    public bool cardSelected = false; // Indica si hay una carta seleccionada
    public int selectedIndex = -1; // Índice de la carta seleccionada
    public PowerCard selectedCard; // Carta seleccionada

    void Start()
    {
        cardUIManager.OcultarTodasLasCartas(); // Oculta todas las cartas al inicio
    }

    // Este método se llamará desde los botones de la interfaz
    public void SelectCard(int index)
    {
        if (index < 0 || index >= availableCards.Length) return;
        selectedIndex = index;
        selectedCard = availableCards[index];
        PlayerPrefs.SetInt("SelectedCardIndex", index); // Almacenar el índice en PlayerPrefs
        PlayerPrefs.Save(); // Guardar los cambios
        cardSelected = true;

        // Si la carta seleccionada es la DashCard, reinicia el cooldown
        if (selectedCard is DashCard dashCard)
        {
            dashCard.ResetCooldown(); // Reinicia el cooldown
            Debug.Log("[CardSelector] DashCard seleccionada - cooldown reseteado.");
        }
        Debug.Log("Carta seleccionada: " + selectedCard.cardName);

        if (selectedCard is ExtraLifeCard lifeCard)
    {
        lifeCard.ResetCard();
        Debug.Log("[CardSelector] ExtraLifeCard seleccionada - yaFueUsada reiniciado.");
    }

    Debug.Log("Carta seleccionada: " + selectedCard.cardName);

    }

    void Update() // Para probar
    {
        if (Input.GetKeyDown(KeyCode.Space) && selectedCard != null)
        {
            Debug.Log("[CardSelector] Intentando activar la carta: " + selectedCard.cardName);
            if (selectedCard.CanActivate(gameObject))
            {
                selectedCard.Activate(gameObject);
            }
            else
            {
                Debug.Log("[CardSelector] No se puede activar la carta.");
            }
        }
    }
}
