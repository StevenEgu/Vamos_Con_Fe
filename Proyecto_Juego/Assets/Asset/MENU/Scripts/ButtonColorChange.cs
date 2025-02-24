using UnityEngine;
using UnityEngine.UI;

public class ButtonColorChange : MonoBehaviour
{
    public Color highlightColor = Color.green;  // Color cuando el cursor pasa sobre el bot�n
    public Color normalColor = Color.white;     // Color original del bot�n

    private Button button;
    private Image buttonImage;

    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = button.GetComponent<Image>();

        // Aseg�rate de que el color inicial es el color normal
        buttonImage.color = normalColor;
    }

    // M�todo que cambia el color cuando el puntero entra en el bot�n
    public void OnPointerEnter()
    {
        buttonImage.color = highlightColor;
    }

    // M�todo que restaura el color original cuando el puntero sale del bot�n
    public void OnPointerExit()
    {
        buttonImage.color = normalColor;
    }
}
