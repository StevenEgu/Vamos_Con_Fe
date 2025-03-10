using UnityEngine;
using UnityEngine.UI;  // Para interactuar con el UI
using System.Collections;  // Necesario para IEnumerator y corutinas

public class ButtonSoundAndClosePanel : MonoBehaviour
{
    public Button yourButton;  // El bot�n que usas
    public AudioSource audioSource;  // El AudioSource para reproducir el sonido
    public AudioClip clickSound;  // El sonido que se reproducir�
    public GameObject panelToClose;  // El panel que se cerrar�

    void Start()
    {
        // Asegurarse de que el bot�n est� asignado
        if (yourButton != null)
        {
            yourButton.onClick.AddListener(OnButtonClick);
        }
    }

    // Funci�n que se llama al hacer clic en el bot�n
    public void OnButtonClick()
    {
        // Comprobar si el AudioSource y el sonido est�n asignados correctamente
        if (audioSource != null && clickSound != null)
        {
            // Reproducir el sonido y asegurar que se hace al principio del clic
            audioSource.PlayOneShot(clickSound);
            // Iniciar la corrutina para esperar a que termine el sonido
            StartCoroutine(WaitForSoundAndClosePanel());
        }
        else
        {
            Debug.LogError("No se asign� el AudioSource o el clip de sonido.");
        }
    }

    // Corrutina que espera a que termine el sonido antes de cerrar el panel
    IEnumerator WaitForSoundAndClosePanel()
    {
        // Asegurarse de que el sonido realmente est� sonando
        float soundDuration = clickSound.length;

        // Verificar que el sonido no sea muy corto (por si acaso)
        if (soundDuration > 0.1f)
        {
            Debug.Log("Esperando a que termine el sonido...");
            yield return new WaitForSeconds(soundDuration);  // Espera hasta que termine la duraci�n del sonido
        }

        // Desactivar el panel
        if (panelToClose != null)
        {
            Debug.Log("Cerrando el panel");
            panelToClose.SetActive(false);
        }
        else
        {
            Debug.LogError("El panel no est� asignado.");
        }
    }
}
