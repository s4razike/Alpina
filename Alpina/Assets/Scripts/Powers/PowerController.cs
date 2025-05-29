using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerController : MonoBehaviour
{
    public DashCard tortugaPowerSO; // Asigna el ScriptableObject desde el Inspector
    //public ExtraLifeCard unicornioPowerSO;

    void Update()
    {
        if (tortugaPowerSO.CanActivate(gameObject))
        {
            UIManager.Instance.TortugaAct(); // Mostrar ícono de activo
        }
        else
        {
            UIManager.Instance.TortugaDeAct(); // Mostrar ícono de desactivado
        }
        
       /* if (unicornioPowerSO.CanActivate(gameObject))
        {
           UIManager.Instance.UnicornioAct(); 
        }
        else 
        {
            UIManager.Instance.UnicornioDeAct();
        }*/
       
    }
}
