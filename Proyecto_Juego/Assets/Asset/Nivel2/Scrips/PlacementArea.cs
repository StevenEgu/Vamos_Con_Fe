using UnityEngine;
using UnityEngine.EventSystems;

public class PlacementArea : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        // Verificar si el objeto arrastrado es un �tem v�lido (en este caso, un objeto con el script DraggableAngi)
        DraggableAngi draggableItem = eventData.pointerDrag.GetComponent<DraggableAngi>();

        if (draggableItem != null)
        {
            // Colocar el �tem dentro de este �rea (puedes ajustarlo para centrarlo o hacer cualquier acci�n extra)
            draggableItem.transform.SetParent(transform); // Cambiar su padre para que quede en este �rea
            draggableItem.transform.localPosition = Vector3.zero; // Colocarlo en el centro de la zona de colocaci�n
        }
    }
}
