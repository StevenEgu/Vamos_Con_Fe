using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableAngi : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Transform originalParent;  // Guardar el padre original
    public Transform placementArea;     // Área donde quieres colocar el ítem (puede ser un objeto vacío o un UI Panel)

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

    // Durante el drag, mover el ítem con el mouse
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = Input.mousePosition; // Moverlo con el mouse
    }

    // Al soltar, colocar el ítem en el área de colocación o volver a su lugar original
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;  // Volver a activar raycasts

        // Verificar si el ítem fue soltado dentro del área de colocación
        if (placementArea != null && RectTransformUtility.RectangleContainsScreenPoint(placementArea.GetComponent<RectTransform>(), Input.mousePosition))
        {
            // Cambiar el padre del ítem para que esté dentro del área de colocación
            transform.SetParent(placementArea);

            // Opcional: Ajustar la posición del ítem dentro del área de colocación
            transform.position = placementArea.position;  // Si quieres que se coloque en el centro del área
        }
        else
        {
            // Si no se soltó dentro del área de colocación, volver al inventario
            transform.SetParent(originalParent);
            transform.localPosition = Vector3.zero;  // Volver a su posición original en el inventario
        }
    }
}
