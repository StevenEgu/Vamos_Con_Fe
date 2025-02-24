using UnityEngine;
using UnityEngine.UI;  // Necesario para interactuar con los UI Buttons

public class PanelManager : MonoBehaviour
{
    public GameObject panel; // El panel que se abrirá y cerrará
    public Button buttonToDestroy; // El botón que se destruirá cuando sea presionado
    public GameObject objectToActivate; // El objeto que se activará cuando el botón se destruya

    // Método para abrir el panel
    public void OpenPanel()
    {
        if (panel != null)
        {
            panel.SetActive(true);  // Hacer visible el panel
            Debug.Log("Panel abierto.");
        }
    }

    // Método para cerrar el panel
    public void ClosePanel()
    {
        if (panel != null)
        {
            panel.SetActive(false);  // Hacer invisible el panel
            Debug.Log("Panel cerrado.");
        }
    }

    // Método que se llama cuando se presiona el botón
    public void OnButtonPress()
    {
        Debug.Log("Botón presionado, comenzando la destrucción y activación.");

        if (buttonToDestroy != null)
        {
            // Destruir el botón cuando se presiona
            Debug.Log("Destruyendo el botón.");
            Destroy(buttonToDestroy.gameObject);
        }

        if (objectToActivate != null)
        {
            // Activar el GameObject
            Debug.Log("Activando el GameObject.");
            objectToActivate.SetActive(true);
        }

        // Cerrar el panel automáticamente después de destruir el botón
        ClosePanel();
    }
}
