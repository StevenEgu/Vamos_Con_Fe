using UnityEngine;

public class Item_Angi : MonoBehaviour
{
    public Sprite itemIcon;  // El �cono del �tem (para mostrarlo en la barra de inventario)

    // M�todo para usar el �tem
    public void Use()
    {
        Debug.Log("Usando el �tem: " + gameObject.name);
        // Aqu� puedes a�adir la l�gica espec�fica para lo que hace el �tem
    }
}
