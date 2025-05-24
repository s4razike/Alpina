using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelector : MonoBehaviour
{
    public PowerCard[] availableCards;
    public PlayerStats playerStats;

    private bool cardSelected = false;
    private PowerCard selectedCard;

    void Update() //para probar 
{
    if (!cardSelected)
    {
        if (Input.GetKeyDown(KeyCode.H))
            SelectCard(0);
        else if (Input.GetKeyDown(KeyCode.J))
            SelectCard(1);
        else if (Input.GetKeyDown(KeyCode.K))
            SelectCard(2);
        else if (Input.GetKeyDown(KeyCode.L))
            SelectCard(3);
    }
    else
    {
        if (Input.GetKeyDown(KeyCode.Space) && selectedCard != null)
        {
            // Cambiado: pasamos el GameObject en vez de PlayerStats
            if (selectedCard.CanActivate(gameObject))
            {
                selectedCard.Activate(gameObject);
            }
        }
    }

    void SelectCard(int index)
    {
        if (index < 0 || index >= availableCards.Length) return;
        
        selectedCard = availableCards[index]; // GUARDAMOS
        cardSelected = true;
        Debug.Log("Carta seleccionada: " + selectedCard.cardName);
    }
}
}
