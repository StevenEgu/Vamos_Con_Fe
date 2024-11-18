using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 initialPosition;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        initialPosition = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Comenzando a arrastrar el ítem.");
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Convertir la posición del ratón a coordenadas del mundo
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane + 1f; // Ajusta la profundidad
        transform.position = mainCamera.ScreenToWorldPoint(mousePosition);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Arrastre terminado. Verificando lugar de colocación...");

        // Detección de colisión con lugares de colocación
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f); // Ajusta el radio si es necesario
        foreach (Collider2D collider in colliders)
        {
            LugarDeColocacion lugar = collider.GetComponent<LugarDeColocacion>();
            if (lugar != null && !lugar.estaOcupado)
            {
                Debug.Log($"Lugar detectado: {lugar.gameObject.name}");
                lugar.ColocarItem(gameObject);
                return;
            }
        }

        // Si no hay lugar válido, vuelve a la posición inicial
        Debug.LogWarning("No se encontró un lugar de colocación válido. Volviendo a la posición inicial.");
        transform.position = initialPosition;
    }
}
