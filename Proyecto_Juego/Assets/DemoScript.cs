using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsTopPickup;

    public void PickupItem(int id)
    {
        inventoryManager.AddItem(itemsTopPickup[id]);
    }
}
