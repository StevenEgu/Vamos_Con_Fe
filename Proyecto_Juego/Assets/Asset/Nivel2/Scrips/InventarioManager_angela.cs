using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventarioManager_angela : MonoBehaviour
{
    public List<Image> slots; // Las imágenes que representan los slots de inventario
    public Sprite defaultSprite; // Imagen de fondo para los slots vacíos

    private Dictionary<int, GameObject> itemsEnInventario = new Dictionary<int, GameObject>();

    public bool AgregarItem(GameObject item)
    {
        // Buscar el primer slot vacío
        for (int i = 0; i < slots.Count; i++)
        {
            if (!itemsEnInventario.ContainsKey(i))
            {
                // Guardar el objeto y actualizar el slot
                itemsEnInventario[i] = item;
                slots[i].sprite = item.GetComponent<SpriteRenderer>().sprite;
                item.SetActive(false); // Oculta el objeto en la escena
                return true;
            }
        }
        Debug.Log("No hay espacio en el inventario");
        return false;
    }

    public GameObject QuitarItem(int slotIndex)
    {
        if (itemsEnInventario.ContainsKey(slotIndex))
        {
            GameObject item = itemsEnInventario[slotIndex];
            itemsEnInventario.Remove(slotIndex);
            slots[slotIndex].sprite = defaultSprite; // Restaurar apariencia del slot
            return item;
        }
        Debug.Log("No hay ningún ítem en este slot");
        return null;
    }
}
