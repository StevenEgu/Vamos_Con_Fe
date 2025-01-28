using System.Collections;  // Necesario para IEnumerator
using UnityEngine;
using UnityEngine.SceneManagement;  // Para cambiar de escena

public class ButtonWithSound : MonoBehaviour
{
    public AudioSource audioSource; // El componente AudioSource del botón
    public AudioClip buttonSound; // El sonido a reproducir
    public string sceneName; // Nombre de la escena a cargar (puedes dejarlo vacío si no cambia de escena)

    // Este método es llamado cuando el botón es presionado
    public void OnButtonClick()
    {
        StartCoroutine(PlaySoundThenDoAction());
    }

    // La corrutina que espera que el sonido termine
    private IEnumerator PlaySoundThenDoAction()
    {
        // Reproducir el sonido
        if (audioSource != null && buttonSound != null)
        {
            audioSource.PlayOneShot(buttonSound); // Reproducir el sonido

            // Esperar el tiempo que dure el sonido
            yield return new WaitForSeconds(buttonSound.length);
        }

        // Una vez el sonido haya terminado, realiza la acción que necesitas
        DoAction();

    }

    // Método que realiza la acción deseada (ej. cargar una escena)
    private void DoAction()
    {
        // Si tienes una escena para cargar, utiliza este código:
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName); // Cambiar de escena
        }

        // Aquí puedes agregar otras acciones si lo necesitas
        // Por ejemplo, si el botón realiza otra acción, como abrir un menú, puedes agregarla aquí.
    }
}
