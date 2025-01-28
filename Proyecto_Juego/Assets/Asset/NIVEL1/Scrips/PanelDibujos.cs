using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelDibujos : MonoBehaviour
{
    // Referencias a los elementos UI
    public GameObject panel;  // El panel que se abrir�/cerrar�
    public Button button;     // El bot�n que abrir� el panel

    // Tiempo configurable desde el Inspector (en segundos)
    public float tiempoParaCerrar = 5f; // Tiempo en segundos para cerrar el panel

    private bool isPanelOpen = false; // Estado del panel

    void Start()
    {
        // Asegurarse de que el panel est� cerrado al inicio
        panel.SetActive(false);

        // Asignar el evento del bot�n
        button.onClick.AddListener(TogglePanel);
    }

    void TogglePanel()
    {
        if (isPanelOpen)
        {
            ClosePanel(); // Si el panel est� abierto, lo cerramos
        }
        else
        {
            OpenPanel();  // Si el panel est� cerrado, lo abrimos
        }
    }

    void OpenPanel()
    {
        panel.SetActive(true);  // Hacemos visible el panel
        isPanelOpen = true;     // Marcamos que el panel est� abierto

        // Iniciamos la corutina para cerrar el panel despu�s del tiempo especificado
        StartCoroutine(ClosePanelAfterTime());
    }

    void ClosePanel()
    {
        panel.SetActive(false); // Hacemos invisible el panel
        isPanelOpen = false;    // Marcamos que el panel est� cerrado
    }

    // Coroutine para cerrar el panel despu�s de un tiempo
    IEnumerator ClosePanelAfterTime()
    {
        // Esperamos el tiempo especificado
        yield return new WaitForSeconds(tiempoParaCerrar);

        // Cerramos el panel despu�s del tiempo
        ClosePanel();
    }
}
