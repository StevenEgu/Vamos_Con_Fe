using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;  // Referencia al RectTransform del objeto
    private CanvasGroup canvasGroup;     // Para manejar la transparencia del ítem al arrastrarlo
    private Canvas parentCanvas;         // El Canvas al que pertenece el ítem

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        parentCanvas = GetComponentInParent<Canvas>();
    }

    // Cuando comenzamos a arrastrar
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;  // Hacer el ítem más transparente
        canvasGroup.blocksRaycasts = false;  // Permitir que otros elementos reciban eventos
    }

    // Mientras arrastramos
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / parentCanvas.scaleFactor;
    }

    // Cuando soltamos el ítem
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;  // Restaurar la transparencia del ítem
        canvasGroup.blocksRaycasts = true;  // Bloquear eventos de clic
    }
}
