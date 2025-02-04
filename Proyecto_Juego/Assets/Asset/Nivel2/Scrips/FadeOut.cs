using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeOut : MonoBehaviour
{
    public float fadeDuration = 2f; // Duración del desvanecimiento
    private Image panelImage;
    private float targetAlpha = 0f; // El valor final de la opacidad

    void Start()
    {
        panelImage = GetComponent<Image>(); // Obtiene el componente Image del panel
        if (panelImage != null)
        {
            StartCoroutine(FadeOutCoroutine());
        }
    }

    IEnumerator FadeOutCoroutine()
    {
        Color startColor = panelImage.color; // Obtiene el color inicial
        float startAlpha = startColor.a; // Alpha inicial
        float elapsedTime = 0f;

        // Realiza el desvanecimiento de forma gradual
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            panelImage.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        // Asegura que el color final tenga el alpha en 0
        panelImage.color = new Color(startColor.r, startColor.g, startColor.b, targetAlpha);
    }
}
