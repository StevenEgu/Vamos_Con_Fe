using UnityEngine;
using UnityEngine.UI;

public class SpriteClickHandler_angi : MonoBehaviour
{
    public GameObject panelToShow; // Panel de UI que aparecer�
    public float displayDuration = 2f; // Tiempo que el panel estar� visible

    private void OnMouseDown()
    {
        if (panelToShow != null)
        {
            // Mostrar el panel
            panelToShow.SetActive(true);

            // Iniciar la rutina para ocultar el panel despu�s de un tiempo
            StartCoroutine(HidePanelAfterDelay());
        }
    }

    private System.Collections.IEnumerator HidePanelAfterDelay()
    {
        // Esperar la duraci�n especificada
        yield return new WaitForSeconds(displayDuration);

        // Ocultar el panel
        panelToShow.SetActive(false);
    }
}