using UnityEngine;
using UnityEngine.UI;  // Para interactuar con el UI
using UnityEngine.SceneManagement;  // Para cambiar de escena
using System.Collections;  // Necesario para IEnumerator y corutinas

public class ButtonSoundAndChangeScene : MonoBehaviour
{
    public Button yourButton;  // El botón que usas
    public AudioSource audioSource;  // El AudioSource para reproducir el sonido
    public AudioClip clickSound;  // El sonido que se reproducirá
    public string sceneToLoad;  // El nombre de la escena a cargar

    void Start()
    {
        // Asegurarse de que el botón está asignado
        if (yourButton != null)
        {
            yourButton.onClick.AddListener(OnButtonClick);
        }
    }

    // Función que se llama al hacer clic en el botón
    public void OnButtonClick()
    {
        // Comprobar si el AudioSource y el sonido están asignados correctamente
        if (audioSource != null && clickSound != null)
        {
            // Reproducir el sonido y asegurar que se hace al principio del clic
            audioSource.PlayOneShot(clickSound);
            // Iniciar la corrutina para esperar a que termine el sonido
            StartCoroutine(WaitForSoundAndChangeScene());
        }
        else
        {
            Debug.LogError("No se asignó el AudioSource o el clip de sonido.");
        }
    }

    // Corrutina que espera a que termine el sonido antes de cambiar la escena
    IEnumerator WaitForSoundAndChangeScene()
    {
        // Asegurarse de que el sonido realmente esté sonando
        float soundDuration = clickSound.length;

        // Verificar que el sonido no sea muy corto (por si acaso)
        if (soundDuration > 0.1f)
        {
            Debug.Log("Esperando a que termine el sonido...");
            yield return new WaitForSeconds(soundDuration);  // Espera hasta que termine la duración del sonido
        }

        // Cambiar a la siguiente escena
        Debug.Log("Cambiando a la escena: " + sceneToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }
}
