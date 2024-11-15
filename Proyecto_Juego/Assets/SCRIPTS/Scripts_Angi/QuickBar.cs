using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickBar : MonoBehaviour
{
    public Button[] quickBarButtons;  // Los botones de la barra rápida
    public GameObject[] items;        // Los objetos que el jugador puede usar
    public GameObject inventoryPanel; // El panel donde se mostrarán los ítems recolectados
    public GameObject itemButtonPrefab; // Prefab del botón de ítem (para representar los ítems)

    void Start()
    {
        // Asignamos los eventos de clic a cada botón
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
            Item_Angi item = items[index].GetComponent<Item_Angi>();  // Aquí usamos Item_Angi
            if (item != null)
            {
                item.Use(); // Usamos el ítem
            }
        }
    }

    // Método para agregar un ítem a la barra rápida (al primer espacio vacío)
    public void AddItemToQuickBar(GameObject item)
    {
        for (int i = 0; i < quickBarButtons.Length; i++)
        {
            if (items[i] == null)  // Si el espacio está vacío
            {
                items[i] = item;  // Asignamos el ítem al espacio vacío
                UpdateButtonIcon(i, item.GetComponent<Item_Angi>().itemIcon);  // Actualizamos el ícono del botón
                break;
            }
        }

        // Añadir el ítem al panel de inventario
        AddItemToInventory(item);
    }

    // Método para añadir el ítem al inventario visual (panel)
    void AddItemToInventory(GameObject item)
    {
        // Instanciamos un nuevo botón o imagen para el inventario
        GameObject newItemButton = Instantiate(itemButtonPrefab, inventoryPanel.transform);

        // Actualizamos el ícono del nuevo botón del inventario con el ícono del ítem
        Image buttonImage = newItemButton.GetComponent<Image>();
        if (buttonImage != null)
        {
            buttonImage.sprite = item.GetComponent<Item_Angi>().itemIcon;  // Establecemos el ícono
        }
    }

    void UpdateButtonIcon(int index, Sprite itemIcon)
    {
        Image buttonImage = quickBarButtons[index].GetComponent<Image>();
        if (buttonImage != null)
        {
            buttonImage.sprite = itemIcon;  // Cambiamos el ícono del botón
        }
    }
}
