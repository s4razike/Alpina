using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelector : MonoBehaviour
{
    public PowerCard[] availableCards;
    public CardUIManager cardUIManager;
    public PlayerStats playerStats;

    public bool cardSelected = false;
    public int selectedIndex = -1;
    public PowerCard selectedCard;

    void Start()
    {
        cardUIManager.OcultarTodasLasCartas();
    }

    void Update() //para probar 
{
    if (!cardSelected)
    {
        if (Input.GetKeyDown(KeyCode.H))
            {SelectCard(0);
             }
        else if (Input.GetKeyDown(KeyCode.J))
            {SelectCard(1);
            UIManager.Instance.TortugaAct(); }
        else if (Input.GetKeyDown(KeyCode.K))
           { SelectCard(2);
            UIManager.Instance.PajaroAct(); } 
        else if (Input.GetKeyDown(KeyCode.L))
            { SelectCard(3);
            UIManager.Instance.ElefanteDeAct();}
    }
    else
    {
        if (Input.GetKeyDown(KeyCode.Space) && selectedCard != null)
        {
            if (selectedCard.CanActivate(gameObject))
            {
                selectedCard.Activate(gameObject);
            }
        }
    }
}

    /*void SelectCard(int index)
    {
        if (index < 0 || index >= availableCards.Length) return;
        
        selectedCard = availableCards[index]; // GUARDAMOS
        selectedIndex = index;
        cardSelected = true;
        Debug.Log("Carta seleccionada: " + selectedCard.cardName);
    }*/

    public void SelectCard(int index)
    {
        if (index < 0 || index >= availableCards.Length) return;

        selectedIndex = index;
        selectedCard = availableCards[index];
        cardSelected = true;

        Debug.Log("Carta seleccionada: " + selectedCard.cardName);
    }

}

