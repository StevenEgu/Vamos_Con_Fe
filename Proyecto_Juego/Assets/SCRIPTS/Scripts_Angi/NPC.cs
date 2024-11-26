using System.Collections;
using TMPro;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private TMP_Text dialoguePlayerText;  // Texto de "Presiona E para hablar"
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;  // Texto del di�logo del NPC
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;

    // Nuevo texto para el protagonista
    [SerializeField] private TMP_Text protagonistText;  // Texto que dir� el protagonista al final del di�logo
    [SerializeField] private string protagonistDialogue;  // Texto que aparecer� para el protagonista
    [SerializeField] private float protagonistDialogueDuration = 3f;  // Duraci�n en segundos del texto del protagonista

    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
        }
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);

            // Mostrar el texto del protagonista despu�s de que el NPC termine de hablar
            ShowProtagonistDialogue();

            // Desactivar el mensaje "Presiona E para hablar" despu�s de que termine la conversaci�n
            dialoguePlayerText.gameObject.SetActive(false);
        }
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialoguePlayerText.gameObject.SetActive(false);  // Ocultar el mensaje de interacci�n
        lineIndex = 0;
        Time.timeScale = 0f;  // Pausar el juego durante el di�logo
        Time.timeScale = 1f;  // Pausar el juego durante el di�logo
        StartCoroutine(ShowLine());
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(0.05f);  // Efecto de m�quina de escribir
        }
    }

    private void ShowProtagonistDialogue()
    {
        // Asegurarse de que el texto del protagonista est� visible
        protagonistText.gameObject.SetActive(true);

        // Limpiar el texto antes de comenzar a mostrarlo
        protagonistText.text = string.Empty;

        // Iniciar la coroutine para mostrar el texto del protagonista con efecto de m�quina de escribir
        StartCoroutine(ShowProtagonistLine());
    }

    private IEnumerator ShowProtagonistLine()
    {
        foreach (char ch in protagonistDialogue)
        {
            protagonistText.text += ch;  // Agregar una letra a la vez
            yield return new WaitForSeconds(0.05f);  // Efecto de m�quina de escribir
        }

        // Esperar unos segundos antes de ocultar el panel
        yield return new WaitForSeconds(protagonistDialogueDuration);

        // Ocultar el texto del protagonista despu�s del tiempo especificado
        protagonistText.gameObject.SetActive(false);  // Desactivar el texto del protagonista
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialoguePlayerText.text = "Ey...";  // Mensaje de interacci�n
            dialoguePlayerText.gameObject.SetActive(true);  // Activar el mensaje de interacci�n
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialoguePlayerText.gameObject.SetActive(false);  // Desactivar el texto cuando el jugador se aleja
        }
    }
}
