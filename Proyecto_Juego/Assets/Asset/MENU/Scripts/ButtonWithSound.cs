using System.Collections;  // Necesario para IEnumerator
using UnityEngine;
using UnityEngine.SceneManagement;  // Para cambiar de escena

public class ButtonWithSound : MonoBehaviour
{
    public AudioSource audioSource; // El componente AudioSource del bot�n
    public AudioClip buttonSound; // El sonido a reproducir
    public string sceneName; // Nombre de la escena a cargar (puedes dejarlo vac�o si no cambia de escena)

    // Este m�todo es llamado cuando el bot�n es presionado
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

        // Una vez el sonido haya terminado, realiza la acci�n que necesitas
        DoAction();

    }

    // M�todo que realiza la acci�n deseada (ej. cargar una escena)
    private void DoAction()
    {
        // Si tienes una escena para cargar, utiliza este c�digo:
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName); // Cambiar de escena
        }

        // Aqu� puedes agregar otras acciones si lo necesitas
        // Por ejemplo, si el bot�n realiza otra acci�n, como abrir un men�, puedes agregarla aqu�.
    }
}
