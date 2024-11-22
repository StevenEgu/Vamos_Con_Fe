using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText; // Texto del di�logo
    public string[] dialogue;
    private int index;

    public GameObject contButton;
    public float wordSpeed = 0.05f;
    public bool playerIsClose;

    public GameObject interactionText; // Texto flotante de "Presiona E para hablar"
    public GameObject popup; // Referencia al popup que aparecer� tras el di�logo

    void Start()
    {
        // Asegurarse de que el popup est� desactivado al inicio
        if (popup != null)
        {
            popup.SetActive(false);
        }
    }

    void Update()
    {
        if (dialoguePanel == null || dialogueText == null || contButton == null || interactionText == null || popup == null)
        {
            Debug.LogError("Aseg�rate de que todos los elementos est�n asignados en el Inspector.");
            return;
        }

        // Si el jugador est� cerca y presiona E
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

        // Muestra el bot�n de continuar cuando se haya escrito todo el di�logo
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
        if (popup != null)
        {
            popup.SetActive(false); // Asegurarse de que el popup se oculta si se interrumpe
        }
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
            if (popup != null)
            {
                popup.SetActive(true); // Mostrar el popup despu�s del �ltimo di�logo
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Debug.Log("Jugador ha entrado en contacto con el NPC");
            playerIsClose = true;
            interactionText.SetActive(true); // Muestra el mensaje cuando el jugador est� cerca
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
            if (popup != null)
            {
                popup.SetActive(false); // Oculta el popup si el jugador se aleja
            }
        }
    }
}
