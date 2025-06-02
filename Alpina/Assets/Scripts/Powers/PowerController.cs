using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerController : MonoBehaviour
{
    public DashCard tortugaPowerSO; // Asigna el ScriptableObject desde el Inspector
    //public ExtraLifeCard unicornioPowerSO;

    public ExtraLifeCard unicornioPowerSO;
    public FloatCard pajaroPowerSO;
    public ShieldCard elefantePowerSO;

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
        
        if (unicornioPowerSO.CanActivate(gameObject))
        {
           UIManager.Instance.UnicornioAct(); 
        }
        else 
        {
            UIManager.Instance.UnicornioDeAct();
        }

        if (pajaroPowerSO.CanActivate(gameObject))
        {
            UIManager.Instance.PajaroAct();
        }
        else
        {
            UIManager.Instance.PajaroDeAct();
        }

       if(elefantePowerSO.CanActivate(gameObject))
        {
            UIManager.Instance.ElefanteAct();
        }
        else
        {
            UIManager.Instance.ElefanteDeAct();
        }


    }
}
