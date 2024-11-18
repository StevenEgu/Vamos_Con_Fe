using UnityEngine;

public class ItemPlacement_angela : MonoBehaviour
{
    public InventarioManager_angela inventarioManager; // Referencia al inventario

    private void OnMouseDown()
    {
        Debug.Log("Intentando colocar ítem desde el inventario.");

        // Tomar el ítem del primer slot del inventario
        GameObject item = inventarioManager.QuitarItem(0);
        if (item != null)
        {
            // Buscar un lugar de colocación cercano y disponible
            LugarDeColocacion lugar = BuscarLugarDisponible();
            if (lugar != null)
            {
                if (lugar.ColocarItem(item))
                {
                    Debug.Log($"Ítem colocado en {lugar.gameObject.name}");
                }
            }
            else
            {
                Debug.LogWarning("No se encontró un lugar de colocación disponible.");
                // Opcional: Devuelve el ítem al inventario si no hay lugar
                inventarioManager.AgregarItem(item);
            }
        }
        else
        {
            Debug.LogWarning("No hay ítems en el inventario para colocar.");
        }
    }

    private LugarDeColocacion BuscarLugarDisponible()
    {
        // Encuentra todos los lugares de colocación en la escena
        LugarDeColocacion[] lugares = FindObjectsOfType<LugarDeColocacion>();

        foreach (LugarDeColocacion lugar in lugares)
        {
            if (!lugar.estaOcupado) // Verifica si el lugar está libre
            {
                return lugar; // Devuelve el primer lugar libre encontrado
            }
        }
        return null; // No se encontró un lugar disponible
    }
}
