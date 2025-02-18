using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // Necesario para manejar el botón

public class TextDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text textDisplay;  // Componente TMP donde se mostrará el texto
    [SerializeField] private Button nextLevelButton; // Botón que se desbloqueará al final

    [SerializeField] private string textToDisplay;  // Texto a mostrar
    [SerializeField] private float textSpeed = 0.05f;  // Velocidad del efecto de máquina de escribir
    [SerializeField] private float delayBeforeUnlock = 1f;  // Tiempo después de mostrar el texto para desbloquear el botón

    void Start()
    {
        // Asegurarse de que el botón esté deshabilitado al principio
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

        // Esperar un poco antes de desbloquear el botón
        yield return new WaitForSeconds(delayBeforeUnlock);

        // Desbloquear el botón después de mostrar el texto
        if (nextLevelButton != null)
        {
            nextLevelButton.interactable = true;
        }
    }
}
