using UnityEngine;
using UnityEngine.UI;

public class ButtonColorChange : MonoBehaviour
{
    public Color highlightColor = Color.green;  // Color cuando el cursor pasa sobre el botón
    public Color normalColor = Color.white;     // Color original del botón

    private Button button;
    private Image buttonImage;

    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = button.GetComponent<Image>();

        // Asegúrate de que el color inicial es el color normal
        buttonImage.color = normalColor;
    }

    // Método que cambia el color cuando el puntero entra en el botón
    public void OnPointerEnter()
    {
        buttonImage.color = highlightColor;
    }

    // Método que restaura el color original cuando el puntero sale del botón
    public void OnPointerExit()
    {
        buttonImage.color = normalColor;
    }
}
