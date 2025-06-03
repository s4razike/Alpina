using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryImageController : MonoBehaviour
{
    public Image[] storyImages;
    public Image backgroundCoverImage; // Imagen que cubre el fondo
    public float fadeDuration = 1.5f;
    public float displayDuration = 4f;

    public GameObject loginPanelGO; // Asignar aquí el GO del login

    private int currentIndex = 0;
    private Coroutine transitionCoroutine = null;
    private bool isTransitioning = false;

    private void Start()
    {
        // Inicializar al principio:
        for (int i = 0; i < storyImages.Length; i++)
        {
            SetAlpha(storyImages[i], i == 0 ? 1f : 0f);
            storyImages[i].gameObject.SetActive(true);
        }

        if (backgroundCoverImage != null)
        {
            SetAlpha(backgroundCoverImage, 1f);
            backgroundCoverImage.gameObject.SetActive(true);
        }

        currentIndex = 0;

        // Ocultar login al inicio
        if (loginPanelGO != null)
            loginPanelGO.SetActive(false);

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
            yield return new WaitForSeconds(waitTime);

            yield return FadeToNextImage();

            currentIndex++;
            if (currentIndex >= storyImages.Length - 1)
            {
                // Historia terminada
                EndStorySequence();
                yield break;
            }
        }
    }

    private IEnumerator FadeToNextImage()
    {
        isTransitioning = true;

        Image currentImage = storyImages[currentIndex];
        Image nextImage = storyImages[Mathf.Min(currentIndex + 1, storyImages.Length - 1)];

        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / fadeDuration);

            SetAlpha(currentImage, Mathf.Lerp(1f, 0f, t));
            SetAlpha(nextImage, Mathf.Lerp(0f, 1f, t));

            yield return null;
        }

        SetAlpha(currentImage, 0f);
        SetAlpha(nextImage, 1f);

        isTransitioning = false;
    }

    private void NextImage()
    {
        if (currentIndex >= storyImages.Length - 1) return;

        StartCoroutine(FadeToNextImage());
        currentIndex++;
    }

    private void EndStorySequence()
    {
        // Desactivar todas las imágenes de la historia
        foreach(var img in storyImages)
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

    private void SetAlpha(Image img, float alpha)
    {
        Color color = img.color;
        color.a = alpha;
        img.color = color;
    }
}



