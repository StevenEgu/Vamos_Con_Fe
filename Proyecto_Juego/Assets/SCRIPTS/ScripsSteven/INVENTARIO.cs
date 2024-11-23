using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con la UI

public class INVENTARIO : MonoBehaviour
{
    // Prefab del Slot (representado como un botón con una imagen)
    public GameObject slotPrefab;
    public Transform contenedorSlots; // Contenedor de los slots (GridLayoutGroup)

    private List<Item1> items = new List<Item1>(); // Lista de items en el inventario

    // Método para agregar un item al inventario
    public void AgregarItem(Item1 nuevoItem)
    {
        if (items.Count < 10) // Limita el inventario a 10 elementos (ejemplo)
        {
            items.Add(nuevoItem);
            ActualizarUI();
            GuardarInventario(); // Guardamos el inventario
        }
        else
        {
            Debug.Log("Inventario lleno");
        }
    }

    // Método para actualizar la interfaz de usuario y mostrar los items en los slots
    void ActualizarUI()
    {
        // Limpiar los slots actuales
        foreach (Transform child in contenedorSlots)
        {
            Destroy(child.gameObject); // Elimina los slots previos
        }

        // Recorre los items y crea un nuevo slot para cada uno
        foreach (Item1 item in items)
        {
            GameObject nuevoSlot = Instantiate(slotPrefab, contenedorSlots);
            // Asigna la imagen del objeto al slot
            nuevoSlot.transform.GetChild(0).GetComponent<Image>().sprite = item.imagen;
            // Si quieres agregar el nombre o descripción, puedes hacerlo también
            nuevoSlot.transform.GetChild(1).GetComponent<Text>().text = item.nombre;
        }
    }

    // Guardar el inventario entre escenas
    void GuardarInventario()
    {
        // Aquí guardamos los datos del inventario usando PlayerPrefs (como ejemplo)
        for (int i = 0; i < items.Count; i++)
        {
            PlayerPrefs.SetString("Item_" + i, items[i].nombre);
            PlayerPrefs.SetString("ItemImagen_" + i, items[i].imagen.name); // Guardamos el nombre de la imagen
        }
        PlayerPrefs.SetInt("InventarioCount", items.Count); // Guardamos el número de objetos en el inventario
        PlayerPrefs.Save();
    }

    // Cargar el inventario cuando se cambia de escena
    public void CargarInventario()
    {
        int itemCount = PlayerPrefs.GetInt("InventarioCount", 0);
        items.Clear();

        for (int i = 0; i < itemCount; i++)
        {
            string itemName = PlayerPrefs.GetString("Item_" + i);
            string itemImageName = PlayerPrefs.GetString("ItemImagen_" + i);
            Sprite itemImage = Resources.Load<Sprite>("ItemImages/" + itemImageName); // Asumiendo que las imágenes están en la carpeta Resources

            // Crear el item y agregarlo a la lista
            Item1 item = new Item1(itemName, itemImage);
            items.Add(item);
        }
        ActualizarUI(); // Actualizamos la UI después de cargar el inventario
    }
}

