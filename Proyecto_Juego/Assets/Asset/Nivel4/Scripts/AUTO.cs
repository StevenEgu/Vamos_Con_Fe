using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal; // Para usar Light2D
using TMPro;

public class ActivateLightAndShowMessage : MonoBehaviour
{
    [SerializeField] private GameObject panel; // El panel que se abrirá.
    [SerializeField] private GameObject objectToDestroy; // El objeto que se eliminará (opcional).
    [SerializeField] private TMP_Text messageText; // Texto del mensaje.
    [SerializeField] private string message = "La luz del coche se encendió."; // Mensaje a mostrar.
    [SerializeField] private float typingSpeed = 0.05f; // Velocidad del texto.
    [SerializeField] private float timeToDisappear = 3f; // Tiempo que el mensaje permanece en pantalla.
    [SerializeField] private Light2D lightToActivate; // Luz 2D que se enciende.

    private bool isMessageActive = false; // Control del mensaje.

    private void Start()
    {
        if (lightToActivate != null)
        {
            lightToActivate.enabled = false; // La luz comienza apagada.
            lightToActivate.intensity = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OpenPanel();
        }
    }

    private void OpenPanel()
    {
        panel.SetActive(true);
        Time.timeScale = 0f; // Pausar el tiempo.
    }

    public void OnButtonPress()
    {
        if (isMessageActive) return;

        if (objectToDestroy != null)
        {
            Destroy(objectToDestroy); // Elimina el objeto (si está asignado).
        }

        StartCoroutine(ShowMessageWithTypingEffect());

        Time.timeScale = 1f; // Reanuda el tiempo.
    }

    private IEnumerator ShowMessageWithTypingEffect()
    {
        isMessageActive = true;
        messageText.gameObject.SetActive(true);
        messageText.text = "";

        // 🔥 Encender la luz cuando aparece el mensaje
        if (lightToActivate != null)
        {
            lightToActivate.enabled = true;
            lightToActivate.intensity = 1f;
        }

        // Animación de texto
        foreach (char letter in message)
        {
            messageText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        // Espera antes de cerrar el panel
        yield return new WaitForSeconds(timeToDisappear);

        messageText.text = "";
        isMessageActive = false;

        // 🔥 Cierra y destruye solo el panel
        if (panel != null)
        {
            Destroy(panel);
        }
    }
}
