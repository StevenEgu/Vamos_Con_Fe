using UnityEngine;

public class Item_Angi : MonoBehaviour
{
    public Sprite itemIcon;  // El ícono del ítem (para mostrarlo en la barra de inventario)

    // Método para usar el ítem
    public void Use()
    {
        Debug.Log("Usando el ítem: " + gameObject.name);
        // Aquí puedes añadir la lógica específica para lo que hace el ítem
    }
}
