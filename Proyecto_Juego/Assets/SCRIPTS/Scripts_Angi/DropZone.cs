using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public string requiredItemName;  // Nombre del ítem necesario para esta zona

    public void OnDrop(PointerEventData eventData)
    {
        GameObject draggedObject = eventData.pointerDrag;

        if (draggedObject != null)
        {
            Item_Angi item = draggedObject.GetComponent<Item_Angi>();

            if (item != null && item.name == requiredItemName)
            {
                Debug.Log($"Colocaste el ítem correcto: {item.name} en la zona.");
                // Aquí puedes añadir lógica personalizada, como activar algo en la escena
            }

            // Colocar el ítem en esta zona
            draggedObject.transform.SetParent(transform);
            draggedObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
    }
}
