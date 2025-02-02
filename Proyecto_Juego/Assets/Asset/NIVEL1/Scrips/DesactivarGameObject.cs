using UnityEngine;
using UnityEngine.UI;  // Necesario para trabajar con UI Buttons

public class DesactivarGameObject : MonoBehaviour
{
    public GameObject objetoParaDesactivar;  // El GameObject que quieres desactivar
    public Button botonDesactivar;  // El bot�n de UI que presionar� el jugador

    void Start()
    {
        // Asegurarse de que el bot�n est� asignado
        if (botonDesactivar != null)
        {
            botonDesactivar.onClick.AddListener(DesactivarObjetoYBoton);  // Asignar el m�todo al clic del bot�n
        }
        else
        {
            Debug.LogWarning("No se ha asignado el bot�n en el Inspector.");
        }
    }

    // M�todo para desactivar el GameObject y el bot�n
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
            botonDesactivar.gameObject.SetActive(false);  // Desactiva el bot�n
        }
        else
        {
            Debug.LogWarning("No se ha asignado el bot�n a desactivar en el Inspector.");
        }
    }
}
