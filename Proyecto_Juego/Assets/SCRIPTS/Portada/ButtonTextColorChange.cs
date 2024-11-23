using UnityEngine;
using TMPro;  // Importante para trabajar con TextMesh Pro

public class ButtonTextColorChange : MonoBehaviour
{
    private TextMeshProUGUI buttonText; // Referencia al componente TextMesh Pro del bot�n

    public Color highlightColor = Color.green; // Color cuando el puntero est� sobre el texto
    public Color normalColor = Color.white;    // Color cuando el puntero no est� sobre el texto

    void Start()
    {
        // Obtener el componente TextMeshProUGUI del hijo del bot�n
        buttonText = GetComponentInChildren<TextMeshProUGUI>();

        // Verificar si el componente TextMeshProUGUI fue encontrado
        if (buttonText != null)
        {
            buttonText.color = normalColor; // Inicializar con el color normal
        }
        else
        {
            Debug.LogWarning("No se encontr� el componente TextMeshProUGUI en el bot�n.");
        }
    }

    // M�todo que cambia el color del texto cuando el puntero entra en el bot�n
    public void OnPointerEnter()
    {
        if (buttonText != null)
        {
            buttonText.color = highlightColor; // Cambiar a highlightColor
        }
    }

    // M�todo que restaura el color original cuando el puntero sale del bot�n
    public void OnPointerExit()
    {
        if (buttonText != null)
        {
            buttonText.color = normalColor; // Restaurar al color normal
        }
    }
}
