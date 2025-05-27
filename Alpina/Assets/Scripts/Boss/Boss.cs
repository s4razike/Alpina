using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    
    [Header("Referencias")]
    public Animator animator;
    public GameObject prefabPluma;
    
    [Header("Configuración General")]
    public float tiempoEntreAtaques = 5f;
    public float tiempoDeDescanso = 5f;
    public int vidaMaxima = 100;
    
    [Header("Configuración de Ataques")]
    public AtaqueConfig ataqueRadial;
    public AtaqueConfig ataqueAbajo;
    public AtaqueConfig ataqueRapido;
    public AtaqueConfig ataqueNubes;

    private int vidaActual;

    private bool enFase2 = false;
    private bool estaVivo = true;

    [System.Serializable]
    public class AtaqueConfig
    {
        public string nombre;
        public GameObject prefab;
        public float velocidad;
        public int cantidad;
        public float anguloInicial; // Para ataques no radiales
        public float separacion; // Para ataques lineales
        public float delayEjecucion;
    }

    private void Start()
    {
        vidaActual = vidaMaxima;
        StartCoroutine(Fase1());
    }

    public void RecibirDanio(int cantidad)
    {
        if (!estaVivo) return;

        vidaActual -= cantidad;
        Debug.Log("Enemigo recibió " + cantidad + " de daño. Vida restante: " + vidaActual);

        if (vidaActual <= 0)
        {
            estaVivo = false;
            animator.SetTrigger("Die");
            StopAllCoroutines();
        }
        else if (!enFase2 && vidaActual <= vidaMaxima / 2)
        {
            StartCoroutine(TransicionAFase2());
        }
    }

    IEnumerator Fase1()
    {
        while (!enFase2)
        {
            animator.SetTrigger("AtaquePlumas");
            EjecutarAtaqueRadial();
            Debug.Log("ataque plumas");
            yield return new WaitForSeconds(tiempoEntreAtaques);
            yield return Descanso();

            animator.SetTrigger("AtaquePlumas");
            EjecutarAtaqueRadial();
            Debug.Log("ataque plumas");
            yield return new WaitForSeconds(tiempoEntreAtaques);
            yield return Descanso();

            animator.SetTrigger("AtaquePlumas");
            EjecutarAtaqueRadial();
            Debug.Log("ataque plumas");
            yield return new WaitForSeconds(tiempoEntreAtaques);
            yield return Descanso();


            //animator.SetTrigger("AtaqueLengua");
            //yield return new WaitForSeconds(tiempoEntreAtaques);

            animator.SetTrigger("AtaquePlumasAbajo");
            EjecutarAtaqueAbajo();
            Debug.Log("ataque plumas abajo");
            yield return new WaitForSeconds(tiempoEntreAtaques);
            yield return Descanso();
        }
    }

    IEnumerator TransicionAFase2()
    {
        enFase2 = true;
        animator.SetTrigger("Transformar");
        Debug.Log("transformar");
        animator.SetBool("Fase2", true);
        Debug.Log("fase2");

        yield return new WaitForSeconds(2f); // espera animación transformación
        StartCoroutine(Fase2());
    }

    IEnumerator Fase2()
    {
        while (estaVivo)
        {
            animator.SetTrigger("AtaqueNubes");
            Debug.Log("ataque nubes");
            yield return new WaitForSeconds(tiempoEntreAtaques);
            yield return Descanso(true);

            animator.SetTrigger("AtaquePlumasRapido");
            Debug.Log("ataque plumas rapido");
            yield return new WaitForSeconds(tiempoEntreAtaques * 0.6f); // más rápido
            yield return Descanso(true);

            //animator.SetTrigger("AtaqueLenguaRapido");
            //yield return new WaitForSeconds(tiempoEntreAtaques * 0.6f);
        }
    }

    IEnumerator Descanso(bool enFase2 = false)
    {
        if (enFase2)
        {
            // Asegúrate que hay una transición a "Nojado" en el Animator si no está en ataque
            animator.Play("BossIdleF2");
            Debug.Log("descanso nojado");
        }
        else
        {
            animator.Play("BossIdleF1");
            Debug.Log("descanso");
        }

        yield return new WaitForSeconds(tiempoDeDescanso);

    }

    public void EjecutarAtaqueRadial()
    {
        StartCoroutine(EjecutarAtaqueCR(ataqueRadial, true));
    }

    public void EjecutarAtaqueAbajo()
    {
        StartCoroutine(EjecutarAtaqueCR(ataqueAbajo, false));
    }

    public void EjecutarAtaqueRapido()
    {
        StartCoroutine(EjecutarAtaqueCR(ataqueRapido, false));
    }

    public void EjecutarAtaqueNubes()
    {
        StartCoroutine(EjecutarAtaqueCR(ataqueNubes, true));
    }

    private IEnumerator EjecutarAtaqueCR(AtaqueConfig config, bool esRadial)
    {
        yield return new WaitForSeconds(config.delayEjecucion);

        if (esRadial)
        {
            for (int i = 0; i < config.cantidad; i++)
            {
                float angulo = i * (360f / config.cantidad) + config.anguloInicial;
                Vector2 direccion = new Vector2(Mathf.Cos(angulo * Mathf.Deg2Rad), Mathf.Sin(angulo * Mathf.Deg2Rad));
                DispararPluma(config.prefab, direccion * config.velocidad);
            }
        }
        else
        {
            for (int i = 0; i < config.cantidad; i++)
        {
            float randomX = Random.Range(-10, 10);
            Vector2 spawnPosition = new Vector2(randomX, 10);
            Instantiate(prefabPluma, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(config.delayEjecucion);
        }
        }
    }

    private void DispararPluma(GameObject prefab, Vector2 velocidad, Vector3? posicion = null)
    {
        Vector3 spawnPos = posicion ?? transform.position;
        GameObject pluma = Instantiate(prefab, spawnPos, Quaternion.identity);
        
        // Rotar la pluma en la dirección del movimiento
        float angle = Mathf.Atan2(velocidad.y, velocidad.x) * Mathf.Rad2Deg;
        pluma.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        pluma.GetComponent<Rigidbody2D>().velocity = velocidad;
    }
}
