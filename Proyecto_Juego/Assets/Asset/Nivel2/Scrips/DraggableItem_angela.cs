using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem_angela : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Comenzando a arrastrar el �tem.");
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Convertir la posici�n del rat�n a coordenadas del mundo
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane + 1f; // Ajusta la profundidad
        transform.position = mainCamera.ScreenToWorldPoint(mousePosition);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Arrastre terminado. Verificando lugar de colocaci�n...");

        // Detecci�n de colisi�n con lugares de colocaci�n
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

        // Si no hay lugar v�lido, mantener el objeto en su posici�n actual
        Debug.LogWarning("No se encontr� un lugar de colocaci�n v�lido. El objeto no se suelta.");
    }
}
