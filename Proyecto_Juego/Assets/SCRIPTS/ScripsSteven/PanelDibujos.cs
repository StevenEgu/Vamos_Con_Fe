using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelDibujos : MonoBehaviour
{
    // Referencias a los elementos UI
    public GameObject panel;  // El panel que se abrirá/cerrará
    public Button button;     // El botón que abrirá el panel

    // Tiempo configurable desde el Inspector (en segundos)
    public float tiempoParaCerrar = 5f; // Tiempo en segundos para cerrar el panel

    private bool isPanelOpen = false; // Estado del panel

    void Start()
    {
        // Asegurarse de que el panel esté cerrado al inicio
        panel.SetActive(false);

        // Asignar el evento del botón
        button.onClick.AddListener(TogglePanel);
    }

    void TogglePanel()
    {
        if (isPanelOpen)
        {
            ClosePanel(); // Si el panel está abierto, lo cerramos
        }
        else
        {
            OpenPanel();  // Si el panel está cerrado, lo abrimos
        }
    }

    void OpenPanel()
    {
        panel.SetActive(true);  // Hacemos visible el panel
        isPanelOpen = true;     // Marcamos que el panel está abierto

        // Iniciamos la corutina para cerrar el panel después del tiempo especificado
        StartCoroutine(ClosePanelAfterTime());
    }

    void ClosePanel()
    {
        panel.SetActive(false); // Hacemos invisible el panel
        isPanelOpen = false;    // Marcamos que el panel está cerrado
    }

    // Coroutine para cerrar el panel después de un tiempo
    IEnumerator ClosePanelAfterTime()
    {
        // Esperamos el tiempo especificado
        yield return new WaitForSeconds(tiempoParaCerrar);

        // Cerramos el panel después del tiempo
        ClosePanel();
    }
}
