using UnityEngine;
using TMPro;  // Importante para usar TextMesh Pro

public class TeleportTrigger : MonoBehaviour
{
    public Transform targetLocation;  // El lugar al que el jugador ser� teletransportado
    public string message = "Presiona E para teletransportarte";  // El mensaje que aparecer�
    private bool playerInRange = false;  // Para saber si el jugador est� en el trigger

    public TextMeshProUGUI messageText;  // Referencia al componente TextMeshProUGUI donde se mostrar� el mensaje

    // Se llama cuando el jugador entra en el trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Aseg�rate de que el jugador tiene la etiqueta "Player"
        {
            playerInRange = true;
            ShowMessage();  // Mostrar el mensaje
        }
    }

    // Se llama cuando el jugador sale del trigger
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            HideMessage();  // Ocultar el mensaje
        }
    }

    void Update()
    {
        // Si el jugador est� en el trigger y presiona la tecla 'E'
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            TeleportPlayer();  // Teletransportar al jugador
        }
    }

    // M�todo para teletransportar al jugador
    private void TeleportPlayer()
    {
        if (targetLocation != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = targetLocation.position;  // Cambia la posici�n del jugador
        }
    }

    // M�todo para mostrar el mensaje
    private void ShowMessage()
    {
        if (messageText != null)
        {
            messageText.text = message;  // Asigna el texto del mensaje
        }
    }

    // M�todo para ocultar el mensaje
    private void HideMessage()
    {
        if (messageText != null)
        {
            messageText.text = "";  // Limpia el texto
        }
    }
}
