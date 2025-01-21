using UnityEngine;

public class DESTRUIRCOLIDERASCENSOR : MonoBehaviour
{
    [SerializeField] private GameObject panelToOpen; // Panel que se abrirá
    [SerializeField] private Collider2D colliderToDestroy; // Collider que se eliminará

    void Update()
    {
        // Comprobar si el panel está activo en la jerarquía
        if (panelToOpen != null && panelToOpen.activeInHierarchy)
        {
            DestroyCollider();  // Si el panel está activo, destruir el collider
        }
    }

    // Función que destruye el collider
    private void DestroyCollider()
    {
        if (colliderToDestroy != null)
        {
            Destroy(colliderToDestroy);  // Destruir el collider
            colliderToDestroy = null; // Limpiar la referencia después de destruir
        }
    }

    // Método que puedes llamar desde otros scripts para abrir el panel y destruir el collider
    public void OpenPanelAndDestroyCollider()
    {
        if (panelToOpen != null)
        {
            panelToOpen.SetActive(true);  // Activar el panel
        }

        DestroyCollider(); // Destruir el collider cuando el panel se activa
    }
}
