using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryImageController : MonoBehaviour
{
    public GameObject[] storyContainers;
    public Image backgroundCoverImage; // Imagen que cubre el fondo
    public float fadeDuration = 1.5f;
    public float displayDuration = 4f;

    public GameObject loginPanelGO; // Asignar aquí el GO del login

    private int currentIndex = 0;
    private Coroutine transitionCoroutine = null;
    private bool isTransitioning = false;

    private void Start()
    {
        for (int i = 0; i < storyContainers.Length; i++)
        {
            SetAlpha(storyContainers[i], i == 0 ? 1f : 0f);
            storyContainers[i].SetActive(true);
        }

        if (backgroundCoverImage != null)
        {
            SetAlpha(backgroundCoverImage.gameObject, 1f);
            backgroundCoverImage.gameObject.SetActive(true);
        }

        if (loginPanelGO != null)
            loginPanelGO.SetActive(false);

        currentIndex = 0;
        transitionCoroutine = StartCoroutine(AutoPlayStory());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTransitioning) return;

            if (transitionCoroutine != null)
                StopCoroutine(transitionCoroutine);

            NextImage();
            transitionCoroutine = StartCoroutine(AutoPlayStory());
        }
    }

    IEnumerator AutoPlayStory()
    {
        while (true)
        {
            float waitTime = displayDuration - fadeDuration;
            // Esperar la duración normal antes del fade
            yield return new WaitForSeconds(waitTime);

            if (currentIndex >= storyContainers.Length - 1)
            {
                // Última imagen: esperar displayDuration completa antes de terminar
                yield return new WaitForSeconds(fadeDuration);
                EndStorySequence();
                yield break;
            }

            yield return FadeToNextImage();

            // Incrementar currentIndex después de transición
            currentIndex++;
        }
    }

    private IEnumerator FadeToNextImage()
    {
        isTransitioning = true;

        GameObject currentGO = storyContainers[currentIndex];
        GameObject nextGO = storyContainers[currentIndex + 1];

        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / fadeDuration);

            SetAlpha(currentGO, 1f - t);
            SetAlpha(nextGO, t);

            yield return null;
        }

        SetAlpha(currentGO, 0f);
        SetAlpha(nextGO, 1f);

        isTransitioning = false;
    }

    private void NextImage()
    {
        if (isTransitioning) return;

        if (currentIndex < storyContainers.Length - 1)
        {
            // Si hay una transición en curso, no hacer nada
            if (transitionCoroutine != null)
                StopCoroutine(transitionCoroutine);

            transitionCoroutine = StartCoroutine(UserSkipToNextImage());
        }
        else
        {
            // Si estamos en la última imagen, finalizar secuencia
            EndStorySequence();
        }
    }

    private IEnumerator UserSkipToNextImage()
    {
        isTransitioning = true;

        GameObject currentGO = storyContainers[currentIndex];
        GameObject nextGO = storyContainers[currentIndex + 1];

        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / fadeDuration);

            SetAlpha(currentGO, 1f - t);
            SetAlpha(nextGO, t);

            yield return null;
        }

        SetAlpha(currentGO, 0f);
        SetAlpha(nextGO, 1f);

        currentIndex++;

        isTransitioning = false;

        // Reiniciar autoproceso después del salto manual
        if (transitionCoroutine != null)
            StopCoroutine(transitionCoroutine);
        transitionCoroutine = StartCoroutine(AutoPlayStory());
    }

    private void EndStorySequence()
    {
        // Desactivar todas las imágenes de la historia
        foreach (var img in storyContainers)
        {
            img.gameObject.SetActive(false);
        }
        // Desactivar la imagen que cubre el fondo
        if (backgroundCoverImage != null)
            backgroundCoverImage.gameObject.SetActive(false);

        // Activar el panel de login
        if (loginPanelGO != null)
            loginPanelGO.SetActive(true);
    }

    private void SetAlpha(GameObject container, float alpha)
    {
        Graphic[] graphics = container.GetComponentsInChildren<Graphic>(true);
        foreach (Graphic g in graphics)
        {
            Color c = g.color;
            c.a = alpha;
            g.color = c;
        }
    }
}






