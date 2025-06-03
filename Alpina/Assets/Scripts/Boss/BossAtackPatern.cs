using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAtackPatern : MonoBehaviour
{
[Header("Referencias")]
    public Animator animator;
    public GameObject prefabPluma;

    [Header("Configuración General")]
    public float tiempoDeDescanso = 10f;   // Descanso entre ataques
    public int vidaMaxima = 100;

    [Header("Configuración de Ataques")]
    public AtaqueConfig ataqueRadial;
    public AtaqueConfig ataqueAbajo;
    public AtaqueConfig ataqueRapido;
    public AtaqueConfig ataqueAbajoF2;
    public AtaqueConfig ataqueNubes;

    private int vidaActual;
    private bool enFase2 = false;
    private bool estaVivo = true;

    public GameObject fondoFase1GO;
    public GameObject fondoFase2GO;

    private SpriteRenderer[] rendersF1;
    private SpriteRenderer[] rendersF2;

    [Header("Ataque Nubes")]
   public Transform[] posicionesTornado; // Asigna en el inspector 3 posiciones: arriba, medio, abajo
   public GameObject tornadoPrefab;

    // Secuencia de ataques para fase 1 y fase 2
    private string[] secuenciaFase1 = { "AtaquePlumas", "AtaquePlumasAbajo" };
    private string[] secuenciaFase2 = { "AtaqueNubesF2", "AtaquePlumasF2", "AtaquePlumasAbajoF2" };

    private int indiceAtaqueActual = 0;

    [System.Serializable]
    public class AtaqueConfig
    {
        public string nombre;
        public GameObject prefab;
        public float velocidad;
        public int cantidad;
        public float anguloInicial;
        public float separacion;
        public float delayEjecucion;
    }

    private void Start()
    {
        vidaActual = vidaMaxima;
        indiceAtaqueActual = 0;
        enFase2 = false;
        estaVivo = true;
        // Inicia la primera animación (ataque)
        AvanzarAtaque();
        
        rendersF1 = fondoFase1GO.GetComponentsInChildren<SpriteRenderer>();
        rendersF2 = fondoFase2GO.GetComponentsInChildren<SpriteRenderer>();
        // Al inicio, fondo fase 1 visible y fondo fase 2 transparente
        SetAlpha(rendersF1, 1f);
        SetAlpha(rendersF2, 0f);
        
    }

    private void SetAlpha(SpriteRenderer[] renders, float alpha)
    {
        foreach (var sr in renders)
        {
            Color color = sr.color;
            color.a = alpha;
            sr.color = color;
        }
    }


    public void RecibirDanio(int cantidad)
    {
        if (!estaVivo) return;

        vidaActual -= cantidad;
        Debug.Log("Enemigo recibió " + cantidad + " de daño. Vida restante: " + vidaActual);

        if (vidaActual <= 0)
        {
            estaVivo = false;
            //animator.SetTrigger("Die");
            UIManager.Instance.Win();
            StopAllCoroutines();
        }
        else if (!enFase2 && vidaActual <= vidaMaxima - 70)
        {
            StartCoroutine(TransicionAFase2());
        }
    }

    IEnumerator TransicionAFase2()
    {
        enFase2 = true;
        animator.SetTrigger("Transformar");
        animator.SetBool("Fase2", true);

        yield return new WaitForSeconds(2f); // Espera la animación de transformación

        indiceAtaqueActual = 0; // Reiniciar índice ataque para fase 2
        // Comienza secuencia de fase 2
        StartCoroutine(TransicionarFondo());
        AvanzarAtaque();
    }

    // Método público que deben llamar los eventos finales de animación para avanzar secuencia
    public void AvanzarAtaque()
{
    if (!estaVivo) return;

    string[] secuenciaActual = enFase2 ? secuenciaFase2 : secuenciaFase1;

    if (indiceAtaqueActual >= secuenciaActual.Length)
    {
        Debug.Log("Secuencia terminada. Entrando en descanso...");
        StartCoroutine(DescansoYReiniciar());
        return;
    }

    string triggerAtaque = secuenciaActual[indiceAtaqueActual];
    indiceAtaqueActual++;

    Debug.Log("Avanzando a ataque: " + triggerAtaque);
    animator.SetTrigger(triggerAtaque);
}

    // Método público que los eventos de animación DEL ATAQUE llaman para disparar el ataque puntual
    public void DispararAtaqueEvento()
    {
        string animacionActual = GetAnimacionActual();

        switch(animacionActual)
        {
            case "AtaquePlumas":
                StartCoroutine(EjecutarAtaqueCR(ataqueRadial, true));
                break;
            case "AtaquePlumasAbajo":
                StartCoroutine(EjecutarAtaqueCR(ataqueAbajo, false));
                break;
            case "AtaquePlumasAbajoF2":
                StartCoroutine(EjecutarAtaqueCR(ataqueRapido, true));
                break;
            case "AtaquePlumasF2":
                StartCoroutine(EjecutarAtaqueCR(ataqueRapido, true));
                break;
            case "AtaqueNubesF2":
                StartCoroutine(EjecutarAtaqueCR(ataqueNubes, true));
                break;
            default:
                Debug.LogWarning("Animación de ataque desconocida para disparar ataque: " + animacionActual);
                break;
        }
    }

    // Coroutine de descanso y reinicio de la secuencia
    IEnumerator DescansoYReiniciar()
    {
        animator.Play(enFase2 ? "BossIdleF2" : "BossIdleF1");
        yield return new WaitForSeconds(tiempoDeDescanso);
        indiceAtaqueActual = 0; 
        AvanzarAtaque();
    }

    // Método para obtener estado actual del animador (nombre de animación)
    private string GetAnimacionActual()
    {
        // Obtenemos el primer layer (normalmente 0)
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        return clipInfo.Length > 0 ? clipInfo[0].clip.name : "SinAnimación";
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
                float randomX = Random.Range(-8f, 2f);
                Vector2 spawnPosition = new Vector2(randomX, 10f);
                GameObject pluma = Instantiate(prefabPluma, spawnPosition, Quaternion.identity);
                Rigidbody2D rb = pluma.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = Vector2.down * config.velocidad;
                }

                yield return new WaitForSeconds(config.delayEjecucion);
            }
        }
    }

    private void DispararPluma(GameObject prefab, Vector2 velocidad, Vector3? posicion = null)
    {
        Vector3 spawnPos = posicion ?? transform.position;
        GameObject pluma = Instantiate(prefab, spawnPos, Quaternion.identity);

        float angle = Mathf.Atan2(velocidad.y, velocidad.x) * Mathf.Rad2Deg;
        pluma.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Rigidbody2D rb = pluma.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = velocidad;
        }
    }

    public void LanzarTornado()
{
    int index = Random.Range(0, posicionesTornado.Length); // elige 0, 1 o 2
    Instantiate(tornadoPrefab, posicionesTornado[index].position, Quaternion.identity);
}

public IEnumerator TransicionarFondo()
    {
        float duracion = 1.5f;
        float tiempo = 0f;
        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, tiempo / duracion);
            // Fondo fase 1 desvanece de 1 a 0
            SetAlpha(rendersF1, 1f - alpha);
            // Fondo fase 2 aumenta de 0 a 1
            SetAlpha(rendersF2, alpha);
            yield return null;
        }
        // Al finalizar, asegurar opacidades finales precisas
        SetAlpha(rendersF1, 0f);
        SetAlpha(rendersF2, 1f);
    }
}

