using UnityEngine;
using UnityEngine.UI;  // Necesario para trabajar con botones UI

public class Desactivarcofre : MonoBehaviour
{
    public Button boton;  // El botón que se desactivará
    public GameObject panel;  // El panel que se desactivará

    void Start()
    {
        if (boton != null)
        {
            // Asignar el método que desactiva el botón y el panel cuando el botón es presionado
            boton.onClick.AddListener(DesactivarBotonYPanel);
        }
        else
        {
            Debug.LogWarning("No se ha asignado el botón en el Inspector.");
        }
    }

    // Método para desactivar el botón y el panel
    private void DesactivarBotonYPanel()
    {
        if (boton != null)
        {
            boton.gameObject.SetActive(false);  // Desactiva el botón
        }

        if (panel != null)
        {
            panel.SetActive(false);  // Desactiva el panel
        }
    }
}
