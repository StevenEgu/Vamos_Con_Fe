using UnityEngine;

public class ItemPlacement_angela : MonoBehaviour
{
    public InventarioManager_angela inventarioManager; // Referencia al inventario

    private void OnMouseDown()
    {
        Debug.Log("Intentando colocar �tem desde el inventario.");

        // Tomar el �tem del primer slot del inventario
        GameObject item = inventarioManager.QuitarItem(0);
        if (item != null)
        {
            // Buscar un lugar de colocaci�n cercano y disponible
            LugarDeColocacion lugar = BuscarLugarDisponible();
            if (lugar != null)
            {
                if (lugar.ColocarItem(item))
                {
                    Debug.Log($"�tem colocado en {lugar.gameObject.name}");
                }
            }
            else
            {
                Debug.LogWarning("No se encontr� un lugar de colocaci�n disponible.");
                // Opcional: Devuelve el �tem al inventario si no hay lugar
                inventarioManager.AgregarItem(item);
            }
        }
        else
        {
            Debug.LogWarning("No hay �tems en el inventario para colocar.");
        }
    }

    private LugarDeColocacion BuscarLugarDisponible()
    {
        // Encuentra todos los lugares de colocaci�n en la escena
        LugarDeColocacion[] lugares = FindObjectsOfType<LugarDeColocacion>();

        foreach (LugarDeColocacion lugar in lugares)
        {
            if (!lugar.estaOcupado) // Verifica si el lugar est� libre
            {
                return lugar; // Devuelve el primer lugar libre encontrado
            }
        }
        return null; // No se encontr� un lugar disponible
    }
}
