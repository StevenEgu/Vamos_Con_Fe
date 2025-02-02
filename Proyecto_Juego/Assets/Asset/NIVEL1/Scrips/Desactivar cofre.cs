using UnityEngine;
using UnityEngine.UI;  // Necesario para trabajar con botones UI

public class Desactivarcofre : MonoBehaviour
{
    public Button boton;  // El bot�n que se desactivar�
    public GameObject panel;  // El panel que se desactivar�

    void Start()
    {
        if (boton != null)
        {
            // Asignar el m�todo que desactiva el bot�n y el panel cuando el bot�n es presionado
            boton.onClick.AddListener(DesactivarBotonYPanel);
        }
        else
        {
            Debug.LogWarning("No se ha asignado el bot�n en el Inspector.");
        }
    }

    // M�todo para desactivar el bot�n y el panel
    private void DesactivarBotonYPanel()
    {
        if (boton != null)
        {
            boton.gameObject.SetActive(false);  // Desactiva el bot�n
        }

        if (panel != null)
        {
            panel.SetActive(false);  // Desactiva el panel
        }
    }
}
