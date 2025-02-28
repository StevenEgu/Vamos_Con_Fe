using UnityEngine;

public class PuertaTrigger : MonoBehaviour
{
    public GameObject indicador; // El sprite que aparecerá encima de la puerta

    private void Start()
    {
        if (indicador != null)
            indicador.SetActive(false); // Asegurar que el indicador está oculto al inicio
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Asegurar que el jugador activa el evento
        {
            if (indicador != null)
                indicador.SetActive(true); // Mostrar el sprite
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (indicador != null)
                indicador.SetActive(false); // Ocultar el sprite cuando el jugador se aleja
        }
    }
}
