using System.Collections;
using UnityEngine;
using TMPro; // Necesario para usar TextMeshPro

public class AVISO : MonoBehaviour
{
    [SerializeField] private GameObject anuncio; // Panel o elemento de aviso que se activa/desactiva
    [SerializeField] private TMP_Text textoAviso; // Componente de texto de TextMeshPro
    [SerializeField] private string[] mensajes; // Lista de mensajes para mostrar
    [SerializeField] private float typingSpeed = 0.05f; // Velocidad de escritura (en segundos por carácter)
    [SerializeField] private float delayBetweenMessages = 2f; // Tiempo de espera entre mensajes

    private bool hasBeenTriggered = false; // Para evitar que el evento se dispare más de una vez

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Solo mostrar los mensajes si el jugador entra en la zona y aún no han sido mostrados
        if (collision.gameObject.CompareTag("Player") && !hasBeenTriggered)
        {
            hasBeenTriggered = true; // Marca que ya se activó
            anuncio.SetActive(true); // Activa el panel de aviso
            StartCoroutine(MostrarMensajesUnoPorUno()); // Inicia la rutina para mostrar los mensajes
        }
    }

    private IEnumerator MostrarMensajesUnoPorUno()
    {
        foreach (string mensaje in mensajes)
        {
            yield return StartCoroutine(EfectoMaquinaDeEscribir(mensaje)); // Muestra el mensaje actual con efecto
            yield return new WaitForSeconds(delayBetweenMessages); // Espera antes de mostrar el siguiente mensaje
        }

        // Desactiva el panel automáticamente después de mostrar todos los mensajes
        anuncio.SetActive(false);
    }

    private IEnumerator EfectoMaquinaDeEscribir(string mensaje)
    {
        textoAviso.text = ""; // Limpia el texto antes de empezar
        foreach (char letra in mensaje)
        {
            textoAviso.text += letra; // Agrega la letra al texto
            yield return new WaitForSeconds(typingSpeed); // Espera antes de agregar la siguiente letra
        }
    }
}
