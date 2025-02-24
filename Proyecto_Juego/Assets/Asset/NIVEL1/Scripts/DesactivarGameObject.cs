using UnityEngine;
using UnityEngine.UI;  // Necesario para trabajar con UI Buttons

public class DesactivarYActivarGameObject : MonoBehaviour
{
    public GameObject objetoParaDesactivar;  // El GameObject que quieres desactivar
    public GameObject objetoParaActivar;     // El GameObject que quieres activar
    public Button botonDesactivar;  // El bot�n de UI que presionar� el jugador

    void Start()
    {
        // Asegurarse de que el bot�n est� asignado
        if (botonDesactivar != null)
        {
            botonDesactivar.onClick.AddListener(DesactivarYActivarObjetos);  // Asignar el m�todo al clic del bot�n
        }
        else
        {
            Debug.LogWarning("No se ha asignado el bot�n en el Inspector.");
        }
    }

    // M�todo para desactivar un GameObject, activar otro y desactivar el bot�n
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

        // Desactivar el bot�n
        if (botonDesactivar != null)
        {
            botonDesactivar.gameObject.SetActive(false);  // Desactiva el bot�n
        }
        else
        {
            Debug.LogWarning("No se ha asignado el bot�n a desactivar en el Inspector.");
        }
    }
}
