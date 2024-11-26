using UnityEngine;
using TMPro;

public class ShowPanelOnTriggerTMP : MonoBehaviour
{
    [Header("Panel Settings")]
    [Tooltip("Arrastra aquí el GameObject del Panel que quieres mostrar.")]
    public GameObject panel;

    [Tooltip("Texto que aparecerá en el panel.")]
    public string panelText;

    [Tooltip("Referencia al componente TextMeshProUGUI del Panel.")]
    public TextMeshProUGUI panelTextComponent;

    private void Start()
    {
        // Asegúrate de que el panel esté oculto al iniciar.
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (panel != null && panelTextComponent != null)
        {
            // Muestra el panel y actualiza el texto.
            panel.SetActive(true);
            panelTextComponent.text = panelText;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (panel != null)
        {
            // Oculta el panel al salir del trigger.
            panel.SetActive(false);
        }
    }
}
