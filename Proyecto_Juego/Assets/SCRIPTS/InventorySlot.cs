using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
   public void OnDrop(PointerEventData evenData)
    {
        if (transform.childCount == 0) { 
            InventoryItem inventoryItem = evenData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform;
        }
    }
}
