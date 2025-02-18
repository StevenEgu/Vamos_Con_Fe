using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // Necesario para manejar el botón

public class NPC : MonoBehaviour
{
    [SerializeField] private TMP_Text dialoguePlayerText;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;

    [SerializeField] private TMP_Text protagonistText;
    [SerializeField] private string protagonistDialogue;
    [SerializeField] private float protagonistDialogueDuration = 3f;

    [SerializeField] private Button nextLevelButton; // Botón para continuar

    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;

    void Start()
    {
        // Desactivar el botón desde el inicio
        if (nextLevelButton != null)
        {
            nextLevelButton.interactable = false;
        }
    }

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
            dialoguePlayerText.gameObject.SetActive(false);

            // Desbloquear el botón antes de mostrar el diálogo del protagonista
            if (nextLevelButton != null)
            {
                nextLevelButton.interactable = true;
            }

            // Mostrar el diálogo del protagonista
            ShowProtagonistDialogue();
        }
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialoguePlayerText.gameObject.SetActive(false); // Ocultamos el mensaje de interacción
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = "";  // Limpiar el texto previo

        // Escribir el texto letra por letra
        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(0.05f); // Efecto de máquina de escribir
        }
    }

    private void ShowProtagonistDialogue()
    {
        protagonistText.gameObject.SetActive(true);
        protagonistText.text = string.Empty;
        StartCoroutine(ShowProtagonistLine());
    }

    private IEnumerator ShowProtagonistLine()
    {
        foreach (char ch in protagonistDialogue)
        {
            protagonistText.text += ch;
            yield return new WaitForSeconds(0.05f); // Efecto de máquina de escribir
        }

        // Esperar algunos segundos antes de ocultar el texto del protagonista
        yield return new WaitForSeconds(protagonistDialogueDuration);

        // Desactivar el texto del protagonista
        protagonistText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialoguePlayerText.text = "Ey...";  // Mensaje para interactuar
            dialoguePlayerText.gameObject.SetActive(true);  // Activar el mensaje de interacción
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialoguePlayerText.gameObject.SetActive(false); // Desactivar mensaje de interacción cuando el jugador se aleje
        }
    }
}
