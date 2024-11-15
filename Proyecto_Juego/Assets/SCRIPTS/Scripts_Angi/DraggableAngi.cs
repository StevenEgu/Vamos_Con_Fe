using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableAngi : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Transform originalParent;  // Guardar el padre original
    public Transform placementArea;     // �rea donde quieres colocar el �tem (puede ser un objeto vac�o o un UI Panel)

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    // Al comenzar a arrastrar
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;  // Guardar el padre original (el inventario)
        canvasGroup.blocksRaycasts = false; // Desactivar raycasts para que se pueda mover
    }

    // Durante el drag, mover el �tem con el mouse
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = Input.mousePosition; // Moverlo con el mouse
    }

    // Al soltar, colocar el �tem en el �rea de colocaci�n o volver a su lugar original
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;  // Volver a activar raycasts

        // Verificar si el �tem fue soltado dentro del �rea de colocaci�n
        if (placementArea != null && RectTransformUtility.RectangleContainsScreenPoint(placementArea.GetComponent<RectTransform>(), Input.mousePosition))
        {
            // Cambiar el padre del �tem para que est� dentro del �rea de colocaci�n
            transform.SetParent(placementArea);

            // Opcional: Ajustar la posici�n del �tem dentro del �rea de colocaci�n
            transform.position = placementArea.position;  // Si quieres que se coloque en el centro del �rea
        }
        else
        {
            // Si no se solt� dentro del �rea de colocaci�n, volver al inventario
            transform.SetParent(originalParent);
            transform.localPosition = Vector3.zero;  // Volver a su posici�n original en el inventario
        }
    }
}
