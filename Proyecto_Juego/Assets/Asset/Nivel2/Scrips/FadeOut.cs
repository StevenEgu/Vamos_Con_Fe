using UnityEngine;
using UnityEngine.UI;
using TMPro; // Importante para usar TextMeshPro
using System.Collections;

public class FadeOut : MonoBehaviour
{
    public float fadeDuration = 2f; // Duración del desvanecimiento
    public TMP_Text fadeText; // Referencia al texto (TextMeshPro)
    private Image panelImage;
    private float targetAlpha = 0f; // El valor final de la opacidad
    public PlayerController player; // Referencia al personaje

    void Start()
    {
        panelImage = GetComponent<Image>(); // Obtiene el componente Image del panel
        if (panelImage != null && fadeText != null)
        {
            StartCoroutine(FadeOutCoroutine());
        }
    }

    IEnumerator FadeOutCoroutine()
    {
        Color panelStartColor = panelImage.color;
        Color textStartColor = fadeText.color; // Color inicial del texto
        float startAlpha = panelStartColor.a; // Alpha inicial del panel y texto
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);

            // Aplicamos el nuevo alpha al panel y al texto (TextMeshPro usa color directamente)
            panelImage.color = new Color(panelStartColor.r, panelStartColor.g, panelStartColor.b, alpha);
            fadeText.color = new Color(textStartColor.r, textStartColor.g, textStartColor.b, alpha);

            // Efecto de escalado en el texto para hacerlo más llamativo
            float scale = Mathf.Lerp(1f, 1.2f, elapsedTime / fadeDuration);
            fadeText.transform.localScale = new Vector3(scale, scale, 1f);

            yield return null;
        }

        // Asegura que el color final tenga el alpha en 0
        panelImage.color = new Color(panelStartColor.r, panelStartColor.g, panelStartColor.b, targetAlpha);
        fadeText.color = new Color(textStartColor.r, textStartColor.g, textStartColor.b, targetAlpha);

        // Desactiva el panel y el texto
        gameObject.SetActive(false);
        fadeText.gameObject.SetActive(false);

        // Habilita el movimiento del personaje
        if (player != null)
        {
            player.EnableMovement();
        }
    }
}
