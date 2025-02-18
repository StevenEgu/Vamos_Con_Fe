using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // Necesario para manejar el bot�n

public class TextDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text textDisplay;  // Componente TMP donde se mostrar� el texto
    [SerializeField] private Button nextLevelButton; // Bot�n que se desbloquear� al final

    [SerializeField] private string textToDisplay;  // Texto a mostrar
    [SerializeField] private float textSpeed = 0.05f;  // Velocidad del efecto de m�quina de escribir
    [SerializeField] private float delayBeforeUnlock = 1f;  // Tiempo despu�s de mostrar el texto para desbloquear el bot�n

    void Start()
    {
        // Asegurarse de que el bot�n est� deshabilitado al principio
        if (nextLevelButton != null)
        {
            nextLevelButton.interactable = false;
        }

        // Iniciamos la coroutine para mostrar el texto
        StartCoroutine(ShowText());
    }

    private IEnumerator ShowText()
    {
        textDisplay.text = "";  // Limpiar el texto previo

        // Escribir el texto letra por letra
        foreach (char letter in textToDisplay)
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(textSpeed);  // Controla la velocidad de escritura
        }

        // Esperar un poco antes de desbloquear el bot�n
        yield return new WaitForSeconds(delayBeforeUnlock);

        // Desbloquear el bot�n despu�s de mostrar el texto
        if (nextLevelButton != null)
        {
            nextLevelButton.interactable = true;
        }
    }
}
