using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 originalLocalPosition; // Posición local inicial
    private Transform originalParent; // Padre original del ítem
    private RectTransform rectTransform; // Transform del ítem
    private CanvasGroup canvasGroup; // Control de interacción durante el drag
    public RectTransform inventoryArea; // RectTransform del área válida (el inventario)

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Al comenzar a arrastrar
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Guardamos el padre y posición inicial del ítem
        originalParent = transform.parent;
        originalLocalPosition = rectTransform.localPosition;

        // Permitimos que el objeto flote sobre otros
        canvasGroup.blocksRaycasts = false;
    }

    // Mientras arrastramos
    public void OnDrag(PointerEventData eventData)
    {
        // Movemos el ítem según la posición del mouse
        rectTransform.position = Input.mousePosition;
    }

    // Al soltar el ítem
    public void OnEndDrag(PointerEventData eventData)
    {
        // Reactivamos los rayos del ítem para que interactúe con otros objetos
        canvasGroup.blocksRaycasts = true;

        // Verificamos si el ítem está dentro del área válida
        if (IsValidDropZone(eventData))
        {
            // Si es válido, el ítem permanece donde se soltó
            Debug.Log("Ítem soltado en un área válida.");
        }
        else
        {
            // Si no es válido, volvemos a su posición original
            rectTransform.SetParent(originalParent);
            rectTransform.localPosition = originalLocalPosition;
            Debug.Log("Ítem restaurado a su posición original.");
        }
    }

    // Verifica si el ítem está dentro del área válida
    private bool IsValidDropZone(PointerEventData eventData)
    {
        // Comprueba si el punto donde soltaste está dentro del RectTransform del inventario
        return RectTransformUtility.RectangleContainsScreenPoint(
            inventoryArea,
            eventData.position,
            Camera.main // Usa la cámara principal para validar
        );
    }
}
