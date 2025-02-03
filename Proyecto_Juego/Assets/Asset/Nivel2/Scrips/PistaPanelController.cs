using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PistaPanelController : MonoBehaviour
{
    public GameObject pistaPanel; // Panel de la pista
    public float closeTime = 3f; // Tiempo antes de cerrar el panel
    private CanvasGroup canvasGroup;

    void Start()
    {
        // Asegurar que el panel esté activo para configurar CanvasGroup correctamente
        pistaPanel.SetActive(true);

        // Obtener o agregar el componente CanvasGroup
        canvasGroup = pistaPanel.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = pistaPanel.AddComponent<CanvasGroup>();
        }

        // Inicializar el panel como invisible
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        // Ahora sí, desactivar el panel después de la configuración inicial
        pistaPanel.SetActive(false);
    }

    public void ShowHint()
    {
        StopAllCoroutines(); // Detener cualquier animación en curso
        pistaPanel.SetActive(true);
        StartCoroutine(FadeInPanel());
    }

    IEnumerator FadeInPanel()
    {
        float duration = 0.5f; // Duración de la animación
        float elapsed = 0;

        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        while (elapsed < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(0, 1, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 1;
        StartCoroutine(ClosePanelAfterTime());
    }

    IEnumerator ClosePanelAfterTime()
    {
        yield return new WaitForSeconds(closeTime);

        float duration = 0.5f;
        float elapsed = 0;

        while (elapsed < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(1, 0, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        pistaPanel.SetActive(false);
    }
}
