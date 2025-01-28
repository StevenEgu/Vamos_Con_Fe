using UnityEngine;
using UnityEngine.UI;

public class BrokenGeneratorButton : MonoBehaviour
{
    public GameObject panelGenerador; // Panel que contiene el generador y sus interruptores

    void Start()
    {
        if (panelGenerador != null)
        {
            panelGenerador.SetActive(false); // Oculta el panel al inicio
        }
        else
        {
            Debug.LogError("¡Panel del generador no asignado!");
        }

        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(AbrirPanelGenerador); // Agregar el listener para abrir el panel
        }
        else
        {
            Debug.LogError("¡No se ha asignado un Button a este objeto!");
        }
    }

    void AbrirPanelGenerador()
    {
        if (panelGenerador != null)
        {
            panelGenerador.SetActive(true); // Muestra el panel del generador al hacer clic en el botón
            Debug.Log("Panel del generador abierto");
        }
    }
}
