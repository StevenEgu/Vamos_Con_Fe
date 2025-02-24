using UnityEngine;
using UnityEngine.UI;  // Necesario para trabajar con UI Buttons

public class DesactivarYActivarGameObject : MonoBehaviour
{
    public GameObject objetoParaDesactivar;  // El GameObject que quieres desactivar
    public GameObject objetoParaActivar;     // El GameObject que quieres activar
    public Button botonDesactivar;  // El botón de UI que presionará el jugador

    void Start()
    {
        // Asegurarse de que el botón esté asignado
        if (botonDesactivar != null)
        {
            botonDesactivar.onClick.AddListener(DesactivarYActivarObjetos);  // Asignar el método al clic del botón
        }
        else
        {
            Debug.LogWarning("No se ha asignado el botón en el Inspector.");
        }
    }

    // Método para desactivar un GameObject, activar otro y desactivar el botón
    private void DesactivarYActivarObjetos()
    {
        // Desactivar el objeto especificado
        if (objetoParaDesactivar != null)
        {
            objetoParaDesactivar.SetActive(false);  // Desactiva el GameObject
        }
        else
        {
            Debug.LogWarning("No se ha asignado el GameObject a desactivar en el Inspector.");
        }

        // Activar el objeto especificado
        if (objetoParaActivar != null)
        {
            objetoParaActivar.SetActive(true);  // Activa el GameObject
        }
        else
        {
            Debug.LogWarning("No se ha asignado el GameObject a activar en el Inspector.");
        }

        // Desactivar el botón
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
