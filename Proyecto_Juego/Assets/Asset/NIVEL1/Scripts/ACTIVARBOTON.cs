using UnityEngine;
using UnityEngine.UI;

public class BotonControl : MonoBehaviour
{
    public Button botonAClickear;  // El bot�n que ser� destruido
    public Button botonDestino;    // El bot�n que ser� activado despu�s de destruir el actual

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
    }
}
