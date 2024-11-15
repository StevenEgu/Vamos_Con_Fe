using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject contButton;
    public float wordSpeed = 0.05f;
    public bool playerIsClose;

    public GameObject interactionText; // El texto flotante que indica "Presiona E para hablar"

    void Update()
    {
        if (dialoguePanel == null || dialogueText == null || contButton == null || interactionText == null)
        {
            Debug.LogError("Asegúrate de que todos los elementos están asignados en el Inspector.");
            return;
        }

        // Si el jugador está cerca y presiona E
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        // Muestra el botón de continuar cuando se haya escrito todo el diálogo
        if (dialogueText.text == dialogue[index])
        {
            contButton.SetActive(true);
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        dialogueText.text = ""; // Reinicia el texto
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        contButton.SetActive(false);

        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Debug.Log("Jugador ha entrado en contacto con el NPC");
            playerIsClose = true;
            interactionText.SetActive(true); // Muestra el mensaje cuando el jugador está cerca
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Debug.Log("Jugador ha salido del contacto con el NPC");
            playerIsClose = false;
            zeroText();
            interactionText.SetActive(false); // Oculta el mensaje cuando el jugador se aleja
        }
    }
}