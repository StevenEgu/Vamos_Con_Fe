using UnityEngine;
using UnityEngine.EventSystems;

public class PlacementArea : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        // Verificar si el objeto arrastrado es un ítem válido (en este caso, un objeto con el script DraggableAngi)
        DraggableAngi draggableItem = eventData.pointerDrag.GetComponent<DraggableAngi>();

        if (draggableItem != null)
        {
            // Colocar el ítem dentro de este área (puedes ajustarlo para centrarlo o hacer cualquier acción extra)
            draggableItem.transform.SetParent(transform); // Cambiar su padre para que quede en este área
            draggableItem.transform.localPosition = Vector3.zero; // Colocarlo en el centro de la zona de colocación
        }
    }
}
