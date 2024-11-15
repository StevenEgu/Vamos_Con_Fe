using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickBar : MonoBehaviour
{
    public Button[] quickBarButtons;  // Los botones de la barra r�pida
    public GameObject[] items;        // Los objetos que el jugador puede usar
    public GameObject inventoryPanel; // El panel donde se mostrar�n los �tems recolectados
    public GameObject itemButtonPrefab; // Prefab del bot�n de �tem (para representar los �tems)

    void Start()
    {
        // Asignamos los eventos de clic a cada bot�n
        for (int i = 0; i < quickBarButtons.Length; i++)
        {
            int index = i;
            quickBarButtons[i].onClick.AddListener(() => UseItem(index));
        }
    }

    void UseItem(int index)
    {
        if (items[index] != null)
        {
            Item_Angi item = items[index].GetComponent<Item_Angi>();  // Aqu� usamos Item_Angi
            if (item != null)
            {
                item.Use(); // Usamos el �tem
            }
        }
    }

    // M�todo para agregar un �tem a la barra r�pida (al primer espacio vac�o)
    public void AddItemToQuickBar(GameObject item)
    {
        for (int i = 0; i < quickBarButtons.Length; i++)
        {
            if (items[i] == null)  // Si el espacio est� vac�o
            {
                items[i] = item;  // Asignamos el �tem al espacio vac�o
                UpdateButtonIcon(i, item.GetComponent<Item_Angi>().itemIcon);  // Actualizamos el �cono del bot�n
                break;
            }
        }

        // A�adir el �tem al panel de inventario
        AddItemToInventory(item);
    }

    // M�todo para a�adir el �tem al inventario visual (panel)
    void AddItemToInventory(GameObject item)
    {
        // Instanciamos un nuevo bot�n o imagen para el inventario
        GameObject newItemButton = Instantiate(itemButtonPrefab, inventoryPanel.transform);

        // Actualizamos el �cono del nuevo bot�n del inventario con el �cono del �tem
        Image buttonImage = newItemButton.GetComponent<Image>();
        if (buttonImage != null)
        {
            buttonImage.sprite = item.GetComponent<Item_Angi>().itemIcon;  // Establecemos el �cono
        }
    }

    void UpdateButtonIcon(int index, Sprite itemIcon)
    {
        Image buttonImage = quickBarButtons[index].GetComponent<Image>();
        if (buttonImage != null)
        {
            buttonImage.sprite = itemIcon;  // Cambiamos el �cono del bot�n
        }
    }
}
