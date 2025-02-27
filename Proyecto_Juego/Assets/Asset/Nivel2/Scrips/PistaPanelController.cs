using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PistaPanelController : MonoBehaviour
{
    public GameObject pistaPanel; // Panel de la pista
    public float closeTime = 3f; // Tiempo antes de cerrar el panel
    private CanvasGroup canvasGroup;

    public AudioSource audioSource; // Componente de AudioSource
    public AudioClip buttonSound; // Sonido del bot�n

    void Start()
    {
        // Asegurar que el panel est� activo para configurar CanvasGroup correctamente
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

        // Ahora s�, desactivar el panel despu�s de la configuraci�n inicial
        pistaPanel.SetActive(false);

        // Asegurar que el AudioSource est� listo
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.playOnAwake = false;
        audioSource.clip = buttonSound;
    }

    public void ShowHint()
    {
        // Reproducir sonido correctamente
        PlaySound();

        StopAllCoroutines(); // Detener cualquier animaci�n en curso
        pistaPanel.SetActive(true);
        StartCoroutine(FadeInPanel());
    }

    private void PlaySound()
    {
        if (audioSource == null || buttonSound == null) return; // Evitar errores

        // Forzar la reproducci�n inmediata
        audioSource.Stop();
        audioSource.Play();
    }

    IEnumerator FadeInPanel()
    {
        float duration = 0.5f; // Duraci�n de la animaci�n
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
