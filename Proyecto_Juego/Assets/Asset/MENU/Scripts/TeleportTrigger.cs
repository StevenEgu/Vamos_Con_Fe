using UnityEngine;
using UnityEngine.UI;  // Para controlar la imagen de transición
using TMPro;
using System.Collections;

public class TeleportTrigger : MonoBehaviour
{
    public Transform targetLocation;  // Lugar de teletransporte
    public string message = "Presiona F para subir las escaleras";  // Mensaje en pantalla
    private bool playerInRange = false;  // Control de colisión con el trigger

    public TextMeshProUGUI messageText;  // UI para el mensaje
    public AudioSource teleportSound;  // Sonido de teletransporte
    public float teleportDelay = 1.5f;  // Tiempo de espera antes de teletransportar
    public Image transitionImage;  // Imagen negra para la transición

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            ShowMessage();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            HideMessage();
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(TeleportWithTransition());
        }
    }

    private IEnumerator TeleportWithTransition()
    {
        if (teleportSound != null)
        {
            teleportSound.Play();  // Reproduce el sonido
        }

        yield return StartCoroutine(FadeTransition(true));  // Oscurece la pantalla

        yield return new WaitForSeconds(teleportDelay);  // Espera el tiempo del TP

        if (targetLocation != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = targetLocation.position;  // Teletransportar al jugador
        }

        yield return StartCoroutine(FadeTransition(false));  // Vuelve a la normalidad
    }

    private IEnumerator FadeTransition(bool fadeIn)
    {
        float alpha = fadeIn ? 0 : 1;
        float targetAlpha = fadeIn ? 1 : 0;
        float duration = 0.8f;  // Tiempo de la transición
        float time = 0;

        if (transitionImage != null)
        {
            while (time < duration)
            {
                time += Time.deltaTime;
                float newAlpha = Mathf.Lerp(alpha, targetAlpha, time / duration);
                transitionImage.color = new Color(0, 0, 0, newAlpha);
                yield return null;
            }

            transitionImage.color = new Color(0, 0, 0, targetAlpha);
        }
    }

    private void ShowMessage()
    {
        if (messageText != null)
        {
            messageText.text = message;
        }
    }

    private void HideMessage()
    {
        if (messageText != null)
        {
            messageText.text = "";
        }
    }
}
