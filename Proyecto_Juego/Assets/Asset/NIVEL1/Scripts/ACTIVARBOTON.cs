using UnityEngine;
using UnityEngine.UI;

public class BotonControl : MonoBehaviour
{
    public Button botonAClickear;  // El bot�n que ser� destruido
    public Button botonDestino;    // El bot�n que ser� activado despu�s de destruir el actual
    public AudioSource sonidoLibro; // Referencia al AudioSource para reproducir el sonido

    // M�todo que se llama cuando el bot�n es presionado
    public void OnButtonClick()
    {
        // Verificar si el bot�n destino est� asignado
        if (botonDestino != null)
        {
            // Activar el bot�n destino
            botonDestino.gameObject.SetActive(true);
            Debug.Log("Bot�n destino activado.");
        }
        else
        {
            Debug.LogWarning("No se asign� un bot�n destino en el Inspector.");
        }

        // Verificar si el bot�n a destruir est� asignado
        if (botonAClickear != null)
        {
            // Destruir el bot�n asignado
            Destroy(botonAClickear.gameObject);
            Debug.Log("Bot�n asignado destruido.");
        }
        else
        {
            Debug.LogWarning("No se asign� un bot�n a destruir.");
        }

        // Verificar si el AudioSource est� asignado y reproducir el sonido
        if (sonidoLibro != null)
        {
            sonidoLibro.Play();  // Reproducir el sonido cuando el jugador coja el libro
            Debug.Log("Sonido del libro reproducido.");
        }
        else
        {
            Debug.LogWarning("No se asign� un AudioSource para el sonido.");
        }
    }
}
