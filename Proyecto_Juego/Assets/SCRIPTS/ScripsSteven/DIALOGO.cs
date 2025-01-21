using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; // Para volver al menú principal.

public class DIALOGO : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePlayer;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;

    // Nuevos paneles y botones
    [SerializeField] private GameObject questionPanel;
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private GameObject returnMenuButton;

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
            EndDialogue();
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
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }

    private void EndDialogue()
    {
        didDialogueStart = false;
        dialoguePanel.SetActive(false);
        questionPanel.SetActive(true); // Abre el panel de la pregunta.
        Time.timeScale = 0f;
        Time.timeScale = 1f;
    }

    // Métodos para manejar las opciones de los botones
    public void OnOption1Selected()
    {
        questionPanel.SetActive(false);
        finalPanel.SetActive(true); // Abre el panel final.
    }

    public void OnOption2Selected()
    {
        questionPanel.SetActive(false);
        finalPanel.SetActive(true); // Abre el mismo panel final.
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // Reactiva el tiempo.
        SceneManager.LoadScene("MainMenu"); // Cambia "MainMenu" al nombre de tu escena principal.
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
