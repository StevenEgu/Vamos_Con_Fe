using UnityEngine;
using UnityEngine.UI;  // Necesario para interactuar con los UI Buttons

public class PanelManager : MonoBehaviour
{
    public GameObject panel; // El panel que se abrir� y cerrar�
    public Button buttonToDestroy; // El bot�n que se destruir� cuando sea presionado
    public GameObject objectToActivate; // El objeto que se activar� cuando el bot�n se destruya

    // M�todo para abrir el panel
    public void OpenPanel()
    {
        if (panel != null)
        {
            panel.SetActive(true);  // Hacer visible el panel
            Debug.Log("Panel abierto.");
        }
    }

    // M�todo para cerrar el panel
    public void ClosePanel()
    {
        if (panel != null)
        {
            panel.SetActive(false);  // Hacer invisible el panel
            Debug.Log("Panel cerrado.");
        }
    }

    // M�todo que se llama cuando se presiona el bot�n
    public void OnButtonPress()
    {
        Debug.Log("Bot�n presionado, comenzando la destrucci�n y activaci�n.");

        if (buttonToDestroy != null)
        {
            // Destruir el bot�n cuando se presiona
            Debug.Log("Destruyendo el bot�n.");
            Destroy(buttonToDestroy.gameObject);
        }

        if (objectToActivate != null)
        {
            // Activar el GameObject
            Debug.Log("Activando el GameObject.");
            objectToActivate.SetActive(true);
        }

        // Cerrar el panel autom�ticamente despu�s de destruir el bot�n
        ClosePanel();
    }
}
