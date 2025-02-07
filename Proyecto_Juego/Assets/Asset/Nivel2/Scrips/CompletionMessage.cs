using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CompletionMessage : MonoBehaviour
{
    public Animator completionAnimator; // Arrastra aquí el Animator del mensaje
    public float messageDuration = 2f;  // Tiempo que el mensaje estará visible
    public string nextSceneName;        // Nombre de la escena a cargar

    public void ShowCompletionMessage()
    {
        StartCoroutine(ShowMessageAndChangeScene());
    }

    private IEnumerator ShowMessageAndChangeScene()
    {
        if (completionAnimator != null)
        {
            completionAnimator.SetTrigger("Show"); // Activa la animación
        }

        yield return new WaitForSeconds(messageDuration); // Espera el tiempo del mensaje

        SceneManager.LoadScene(nextSceneName); // Cambia de escena
    }
}
