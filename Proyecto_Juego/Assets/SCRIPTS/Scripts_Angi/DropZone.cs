using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public string requiredItemName;  // Nombre del �tem necesario para esta zona

    public void OnDrop(PointerEventData eventData)
    {
        GameObject draggedObject = eventData.pointerDrag;

        if (draggedObject != null)
        {
            Item_Angi item = draggedObject.GetComponent<Item_Angi>();

            if (item != null && item.name == requiredItemName)
            {
                Debug.Log($"Colocaste el �tem correcto: {item.name} en la zona.");
                // Aqu� puedes a�adir l�gica personalizada, como activar algo en la escena
            }

            // Colocar el �tem en esta zona
            draggedObject.transform.SetParent(transform);
            draggedObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
    }
}
