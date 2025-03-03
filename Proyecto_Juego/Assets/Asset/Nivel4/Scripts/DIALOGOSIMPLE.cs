using System.Collections;
using TMPro;
using UnityEngine;

public class DIALOGOSIMPLE : MonoBehaviour
{
    [SerializeField] private TMP_Text dialoguePlayerText;  // Cambiado a TMP_Text
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;

    [SerializeField] private GameObject colliderToDestroy;

    [SerializeField] private GameObject playerDialoguePanel;
    [SerializeField] private TMP_Text playerDialogueText;
    [SerializeField] private string playerDialogue;
    [SerializeField] private float playerDialogueDuration = 3f;

    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;

    private MOVIMIENTOJUGADOR movimientoJugador; // Referencia al script de movimiento

    void Start()
    {
        // Buscar el script de movimiento en el jugador
        movimientoJugador = FindObjectOfType<MOVIMIENTOJUGADOR>();
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
            dialoguePlayerText.gameObject.SetActive(true);  // Activa el TMP_Text para el jugador
            Time.timeScale = 1f;

            if (colliderToDestroy != null)
            {
                Destroy(colliderToDestroy);
            }

            ShowPlayerDialogue();
        }
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialoguePlayerText.gameObject.SetActive(false);  // Desactiva el TMP_Text para el jugador
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
            yield return new WaitForSecondsRealtime(0.05f);
        }
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 1f;
    }

    private void ShowPlayerDialogue()
    {
        playerDialoguePanel.SetActive(true);
        playerDialogueText.text = string.Empty;

        // 🔥 **Bloquear movimiento**
        if (movimientoJugador != null)
        {
            movimientoJugador.enabled = false;
        }

        StartCoroutine(ShowPlayerLine());
    }

    private IEnumerator ShowPlayerLine()
    {
        foreach (char ch in playerDialogue)
        {
            playerDialogueText.text += ch;
            yield return new WaitForSecondsRealtime(0.05f);
        }

        yield return new WaitForSeconds(playerDialogueDuration);

        playerDialoguePanel.SetActive(false);

        // 🔥 **Desbloquear movimiento**
        if (movimientoJugador != null)
        {
            movimientoJugador.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialoguePlayerText.gameObject.SetActive(true);  // Activa el TMP_Text cuando el jugador entra
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialoguePlayerText.gameObject.SetActive(false);  // Desactiva el TMP_Text cuando el jugador sale
        }
    }
}
