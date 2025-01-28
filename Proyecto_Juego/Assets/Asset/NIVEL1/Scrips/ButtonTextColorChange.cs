using UnityEngine;
using TMPro;  // Importante para trabajar con TextMesh Pro

public class ButtonTextColorChange : MonoBehaviour
{
    private TextMeshProUGUI buttonText; // Referencia al componente TextMesh Pro del botón

    public Color highlightColor = Color.green; // Color cuando el puntero está sobre el texto
    public Color normalColor = Color.white;    // Color cuando el puntero no está sobre el texto

    void Start()
    {
        // Obtener el componente TextMeshProUGUI del hijo del botón
        buttonText = GetComponentInChildren<TextMeshProUGUI>();

        // Verificar si el componente TextMeshProUGUI fue encontrado
        if (buttonText != null)
        {
            buttonText.color = normalColor; // Inicializar con el color normal
        }
        else
        {
            Debug.LogWarning("No se encontró el componente TextMeshProUGUI en el botón.");
        }
    }

    // Método que cambia el color del texto cuando el puntero entra en el botón
    public void OnPointerEnter()
    {
        if (buttonText != null)
        {
            buttonText.color = highlightColor; // Cambiar a highlightColor
        }
    }

    // Método que restaura el color original cuando el puntero sale del botón
    public void OnPointerExit()
    {
        if (buttonText != null)
        {
            buttonText.color = normalColor; // Restaurar al color normal
        }
    }
}
