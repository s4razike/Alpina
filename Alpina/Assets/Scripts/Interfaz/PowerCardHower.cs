using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class PowerCardHower : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [TextArea]
    public string descriptionText; // Descripción de este poder

    public GameObject descriptionPanel; // Panel que muestra la descripción
    public TextMeshProUGUI descriptionLabel; // El texto de TMP que se actualizará

    private CanvasGroup descriptionCanvasGroup;

    private bool isPointerOverCard = false;
    private bool isPointerOverPanel = false;

    private void Awake()
    {
        if (descriptionPanel != null)
            descriptionCanvasGroup = descriptionPanel.GetComponent<CanvasGroup>();
        if (descriptionPanel != null)
            descriptionPanel.SetActive(false); // Asegurar que empieza oculto
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOverCard = true;
        ShowDescription();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOverCard = false;
        CheckHideDescription();
    }

    // Para el panel debemos añadir otro script que implemente estos eventos y llame a este control para informar el estado

    public void PanelPointerEnter()
    {
        isPointerOverPanel = true;
        ShowDescription();
    }

    public void PanelPointerExit()
    {
        isPointerOverPanel = false;
        CheckHideDescription();
    }

    private void ShowDescription()
    {
        if (descriptionPanel != null && descriptionLabel != null)
        {
            descriptionLabel.text = descriptionText;
            descriptionPanel.SetActive(true);

            if (descriptionCanvasGroup != null)
                descriptionCanvasGroup.blocksRaycasts = false; // No bloquea raycasts para que no interfiera en pointer events
        }
    }

    private void CheckHideDescription()
    {
        if (!isPointerOverCard && !isPointerOverPanel)
        {
            if (descriptionPanel != null)
            {
                descriptionPanel.SetActive(false);
                if (descriptionCanvasGroup != null)
                    descriptionCanvasGroup.blocksRaycasts = true;
            }
        }
    }
}
