using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Necesario para los eventos de UI

public class CambiarColorTexto1 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TMP_Text textoBoton;  // El texto del botón que quieres cambiar de color
    [SerializeField] private Color colorOriginal = Color.white; // Color original
    [SerializeField] private Color colorHover = Color.red; // Color cuando el ratón pasa por encima

    void Start()
    {
        // Establecer el color inicial del texto
        if (textoBoton != null)
        {
            textoBoton.color = colorOriginal;
        }
    }

    // Cambiar el color cuando el ratón pasa por encima del botón
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse entered");
        if (textoBoton != null)
        {
            textoBoton.color = colorHover;  // Cambiar al color de hover
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse exited");
        if (textoBoton != null)
        {
            textoBoton.color = colorOriginal;  // Volver al color original
        }
    }

}
