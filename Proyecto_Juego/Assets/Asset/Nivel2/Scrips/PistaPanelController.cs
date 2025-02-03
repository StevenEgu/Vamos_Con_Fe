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
        canvasGroup = pistaPanel.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = pistaPanel.AddComponent<CanvasGroup>();
        }

        pistaPanel.SetActive(false);
        canvasGroup.alpha = 0; // Inicia invisible
    }

    public void ShowHint()
    {
        StopAllCoroutines(); // Detener cualquier animaci�n en curso
        pistaPanel.SetActive(true);
        StartCoroutine(FadeInPanel());
    }

    IEnumerator FadeInPanel()
    {
        float duration = 0.5f; // Duraci�n de la animaci�n
        float elapsed = 0;

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
        pistaPanel.SetActive(false);
    }
}
