using System.Collections;
using UnityEngine;
using TMPro;

public class ActivateLightAndShowMessage : MonoBehaviour
{
    [SerializeField] private GameObject panel; // El panel que se abrir�.
    [SerializeField] private GameObject objectToDestroy; // El objeto que se eliminar�.
    [SerializeField] private TMP_Text messageText; // El texto que mostrar� el mensaje.
    [SerializeField] private string message = "La luz del coche se encendi�."; // El mensaje a mostrar.
    [SerializeField] private float typingSpeed = 0.05f; // La velocidad con la que aparece el texto.
    [SerializeField] private float timeToDisappear = 3f; // Tiempo que el mensaje permanece en pantalla antes de desaparecer.

    private bool isMessageActive = false; // Control de si el mensaje est� siendo mostrado.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Comprueba si el objeto que colision� tiene la etiqueta "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            OpenPanel();
        }
    }

    private void OpenPanel()
    {
        panel.SetActive(true); // Activa el panel para que se muestre.
        Time.timeScale = 0f; // Pausa el tiempo (opcional, si quieres detener el juego).
    }

    public void OnButtonPress()
    {
        // Si el mensaje ya est� activo, no hacer nada
        if (isMessageActive)
            return;

        // Acci�n del bot�n: eliminar el objeto
        if (objectToDestroy != null)
        {
            Destroy(objectToDestroy); // Elimina el objeto.
        }

        // Muestra el mensaje de que la luz se encendi�
        StartCoroutine(ShowMessageWithTypingEffect());

        // Restaurar el tiempo cuando se presione el bot�n
        Time.timeScale = 1f; // Reanuda el tiempo.
    }

    private IEnumerator ShowMessageWithTypingEffect()
    {
        isMessageActive = true; // Marcar que el mensaje est� activo.
        messageText.gameObject.SetActive(true); // Aseguramos que el texto se activa
        messageText.text = ""; // Limpiamos el texto antes de mostrarlo.

        // Efecto de m�quina de escribir
        foreach (char letter in message)
        {
            messageText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        // Esperamos el tiempo antes de borrar el mensaje
        yield return new WaitForSeconds(timeToDisappear);

        messageText.text = ""; // Borramos el mensaje despu�s del tiempo configurado.
        isMessageActive = false; // Marcar que el mensaje ha terminado.
    }
}
