using System.Collections;  // Aseg�rate de incluir esto
using UnityEngine;
using TMPro;  // Aseg�rate de tener TextMeshPro en tus "using" para poder usarlo

public class MostrarMensaje : MonoBehaviour
{
    public TextMeshProUGUI mensajeTexto;  // Referencia al componente TextMeshPro
    public string mensaje = "�Has colisionado con el objeto!";  // El mensaje que quieres mostrar
    public float tiempoMensaje = 3f;  // Tiempo que el mensaje estar� visible

    // M�todo que se llama cuando el jugador colisiona con el collider de este objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el objeto con el que colision� es el jugador (puedes ajustarlo seg�n el tag o nombre del jugador)
        if (collision.gameObject.CompareTag("Player"))
        {
            // Muestra el mensaje en el TextMeshPro
            mensajeTexto.text = mensaje;

            // Llama a la coroutine para esconder el mensaje despu�s de un tiempo
            StartCoroutine(OcultarMensaje());
        }
    }

    // Coroutine para ocultar el mensaje despu�s de un tiempo
    private IEnumerator OcultarMensaje()
    {
        // Espera el tiempo especificado
        yield return new WaitForSeconds(tiempoMensaje);

        // Despu�s de esperar, borra el texto del mensaje
        mensajeTexto.text = "";
    }
}
