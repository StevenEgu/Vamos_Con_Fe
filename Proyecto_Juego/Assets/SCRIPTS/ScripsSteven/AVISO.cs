using System.Collections;
using UnityEngine;
using TMPro; // Necesario para usar TextMeshPro

public class AVISO : MonoBehaviour
{
    [SerializeField] private GameObject anuncio; // Panel o elemento de aviso que se activa/desactiva
    [SerializeField] private TMP_Text textoAviso; // Componente de texto de TextMeshPro
    [SerializeField] private string mensaje; // Mensaje único para mostrar
    [SerializeField] private float typingSpeed = 0.05f; // Velocidad de escritura (en segundos por carácter)

    private bool hasBeenTriggered = false; // Para evitar que el texto se muestre más de una vez

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Solo mostrar el texto si el jugador entra en la zona y el mensaje no se ha mostrado antes
        if (collision.gameObject.CompareTag("Player") && !hasBeenTriggered)
        {
            hasBeenTriggered = true; // Marca que ya se activó el mensaje
            anuncio.SetActive(true); // Activa el panel de aviso
            StartCoroutine(EfectoMaquinaDeEscribir(mensaje)); // Inicia el efecto de máquina de escribir
        }
    }

    private IEnumerator EfectoMaquinaDeEscribir(string mensaje)
    {
        textoAviso.text = ""; // Limpia el texto antes de empezar
        foreach (char letra in mensaje)
        {
            textoAviso.text += letra; // Agrega la letra al texto
            yield return new WaitForSeconds(typingSpeed); // Espera antes de agregar la siguiente letra
        }

        // Opcional: Desactiva el panel automáticamente después de que el mensaje se haya mostrado completamente
        yield return new WaitForSeconds(2f); // Espera 2 segundos después de mostrar el mensaje
        anuncio.SetActive(false); // Desactiva el panel de aviso
    }
}

