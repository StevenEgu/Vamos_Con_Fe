using UnityEngine;

public class ItemPickup_angela : MonoBehaviour
{
    public InventarioManager_angela inventarioManager; // Referencia al gestor de inventario

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entra al trigger es el jugador
        if (other.CompareTag("Player"))
        {
            Debug.Log(" recogido");
            // Intenta agregar el �tem al inventario
            bool fueAgregado = inventarioManager.AgregarItem(gameObject);
            if (fueAgregado)
            {
                Debug.Log("Item recogido autom�ticamente");
            }
            else
            {
                Debug.Log("Inventario lleno");
            }
        }
    }
}
