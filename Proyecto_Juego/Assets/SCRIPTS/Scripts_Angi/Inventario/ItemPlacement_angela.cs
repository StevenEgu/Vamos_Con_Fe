using UnityEngine;

public class ItemPlacement_angela : MonoBehaviour
{
    public InventarioManager_angela inventarioManager;

    private void OnMouseDown()
    {
        // Ejemplo: Tomar �tem del primer slot del inventario y colocarlo aqu�
        GameObject item = inventarioManager.QuitarItem(0);
        if (item != null)
        {
            item.transform.position = transform.position;
            item.SetActive(true);
            Debug.Log("Item colocado en la escena");
        }
    }
}
