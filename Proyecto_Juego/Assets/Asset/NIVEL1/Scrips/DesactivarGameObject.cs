using UnityEngine;
using UnityEngine.UI;  // Necesario para trabajar con UI Buttons

public class DesactivarGameObject : MonoBehaviour
{
    public GameObject objetoParaDesactivar;  // El GameObject que quieres desactivar
    public Button botonDesactivar;  // El botón de UI que presionará el jugador

    void Start()
    {
        // Asegurarse de que el botón esté asignado
        if (botonDesactivar != null)
        {
            botonDesactivar.onClick.AddListener(DesactivarObjetoYBoton);  // Asignar el método al clic del botón
        }
        else
        {
            Debug.LogWarning("No se ha asignado el botón en el Inspector.");
        }
    }

    // Método para desactivar el GameObject y el botón
    private void DesactivarObjetoYBoton()
    {
        if (objetoParaDesactivar != null)
        {
            objetoParaDesactivar.SetActive(false);  // Desactiva el GameObject
        }
        else
        {
            Debug.LogWarning("No se ha asignado el GameObject a desactivar en el Inspector.");
        }

        if (botonDesactivar != null)
        {
            botonDesactivar.gameObject.SetActive(false);  // Desactiva el botón
        }
        else
        {
            Debug.LogWarning("No se ha asignado el botón a desactivar en el Inspector.");
        }
    }
}
