using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 originalLocalPosition; // Posici�n local inicial
    private Transform originalParent; // Padre original del �tem
    private RectTransform rectTransform; // Transform del �tem
    private CanvasGroup canvasGroup; // Control de interacci�n durante el drag
    public RectTransform inventoryArea; // RectTransform del �rea v�lida (el inventario)

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Al comenzar a arrastrar
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Guardamos el padre y posici�n inicial del �tem
        originalParent = transform.parent;
        originalLocalPosition = rectTransform.localPosition;

        // Permitimos que el objeto flote sobre otros
        canvasGroup.blocksRaycasts = false;
    }

    // Mientras arrastramos
    public void OnDrag(PointerEventData eventData)
    {
        // Movemos el �tem seg�n la posici�n del mouse
        rectTransform.position = Input.mousePosition;
    }

    // Al soltar el �tem
    public void OnEndDrag(PointerEventData eventData)
    {
        // Reactivamos los rayos del �tem para que interact�e con otros objetos
        canvasGroup.blocksRaycasts = true;

        // Verificamos si el �tem est� dentro del �rea v�lida
        if (IsValidDropZone(eventData))
        {
            // Si es v�lido, el �tem permanece donde se solt�
            Debug.Log("�tem soltado en un �rea v�lida.");
        }
        else
        {
            // Si no es v�lido, volvemos a su posici�n original
            rectTransform.SetParent(originalParent);
            rectTransform.localPosition = originalLocalPosition;
            Debug.Log("�tem restaurado a su posici�n original.");
        }
    }

    // Verifica si el �tem est� dentro del �rea v�lida
    private bool IsValidDropZone(PointerEventData eventData)
    {
        // Comprueba si el punto donde soltaste est� dentro del RectTransform del inventario
        return RectTransformUtility.RectangleContainsScreenPoint(
            inventoryArea,
            eventData.position,
            Camera.main // Usa la c�mara principal para validar
        );
    }
}
