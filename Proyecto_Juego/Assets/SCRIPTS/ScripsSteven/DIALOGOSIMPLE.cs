using System.Collections;
using TMPro;
using UnityEngine;

public class DIALOGOSIMPLE : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePlayer;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;

    // Referencia al objeto con el collider que quieres destruir
    [SerializeField] private GameObject colliderToDestroy;

    // Nueva referencia para el panel de texto del personaje principal
    [SerializeField] private GameObject playerDialoguePanel;
    [SerializeField] private TMP_Text playerDialogueText;
    [SerializeField] private string playerDialogue;  // Texto que se mostrará para el personaje principal
    [SerializeField] private float playerDialogueDuration = 3f;  // Duración en segundos antes de ocultar el panel

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
            dialoguePlayer.SetActive(true);
            Time.timeScale = 1f;

            // Destruir el collider al terminar el diálogo
            if (colliderToDestroy != null)
            {
                Destroy(colliderToDestroy);
            }

            // Activar el panel de texto del personaje principal
            ShowPlayerDialogue();
        }
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialoguePlayer.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(0.05f);  // Efecto de máquina de escribir
        }
    }

    private void ShowPlayerDialogue()
    {
        // Mostrar el panel del personaje principal
        playerDialoguePanel.SetActive(true);

        // Limpiar el texto antes de comenzar a mostrarlo
        playerDialogueText.text = string.Empty;

        // Iniciar la coroutine para mostrar el texto del personaje principal con efecto de máquina de escribir
        StartCoroutine(ShowPlayerLine());
    }

    private IEnumerator ShowPlayerLine()
    {
        foreach (char ch in playerDialogue)
        {
            playerDialogueText.text += ch;  // Agregar una letra a la vez
            yield return new WaitForSeconds(0.05f);  // Efecto de máquina de escribir
        }

        // Esperar unos segundos antes de ocultar el panel
        yield return new WaitForSeconds(playerDialogueDuration);

        // Ocultar el panel después del tiempo especificado
        playerDialoguePanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialoguePlayer.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialoguePlayer.SetActive(false);
        }
    }
}
