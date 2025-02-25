using UnityEngine;
using UnityEngine.UI;

public class BotonControl : MonoBehaviour
{
    public Button botonAClickear;  // El botón que será destruido
    public Button botonDestino;    // El botón que será activado después de destruir el actual
    public AudioSource sonidoLibro; // Referencia al AudioSource para reproducir el sonido

    // Método que se llama cuando el botón es presionado
    public void OnButtonClick()
    {
        // Verificar si el botón destino está asignado
        if (botonDestino != null)
        {
            // Activar el botón destino
            botonDestino.gameObject.SetActive(true);
            Debug.Log("Botón destino activado.");
        }
        else
        {
            Debug.LogWarning("No se asignó un botón destino en el Inspector.");
        }

        // Verificar si el botón a destruir está asignado
        if (botonAClickear != null)
        {
            // Destruir el botón asignado
            Destroy(botonAClickear.gameObject);
            Debug.Log("Botón asignado destruido.");
        }
        else
        {
            Debug.LogWarning("No se asignó un botón a destruir.");
        }

        // Verificar si el AudioSource está asignado y reproducir el sonido
        if (sonidoLibro != null)
        {
            sonidoLibro.Play();  // Reproducir el sonido cuando el jugador coja el libro
            Debug.Log("Sonido del libro reproducido.");
        }
        else
        {
            Debug.LogWarning("No se asignó un AudioSource para el sonido.");
        }
    }
}
