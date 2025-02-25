using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Necesario para los eventos de UI

public class CambiarColorTexto1 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TMP_Text textoBoton;  // El texto del bot�n que quieres cambiar de color
    [SerializeField] private Color colorOriginal = Color.white; // Color original
    [SerializeField] private Color colorHover = Color.red; // Color cuando el rat�n pasa por encima

    void Start()
    {
        // Establecer el color inicial del texto
        if (textoBoton != null)
        {
            textoBoton.color = colorOriginal;
        }
    }

    // Cambiar el color cuando el rat�n pasa por encima del bot�n
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
