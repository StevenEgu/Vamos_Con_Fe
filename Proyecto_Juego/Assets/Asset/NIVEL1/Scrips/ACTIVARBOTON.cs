using UnityEngine;
using UnityEngine.UI;

public class BotonControl : MonoBehaviour
{
    public Button botonAClickear;  // El botón que será destruido
    public Button botonDestino;    // El botón que será activado después de destruir el actual

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
    }
}
