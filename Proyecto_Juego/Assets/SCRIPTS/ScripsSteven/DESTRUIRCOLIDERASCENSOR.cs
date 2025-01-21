using UnityEngine;

public class DESTRUIRCOLIDERASCENSOR : MonoBehaviour
{
    [SerializeField] private GameObject panelToOpen; // Panel que se abrir�
    [SerializeField] private Collider2D colliderToDestroy; // Collider que se eliminar�

    void Update()
    {
        // Comprobar si el panel est� activo en la jerarqu�a
        if (panelToOpen != null && panelToOpen.activeInHierarchy)
        {
            DestroyCollider();  // Si el panel est� activo, destruir el collider
        }
    }

    // Funci�n que destruye el collider
    private void DestroyCollider()
    {
        if (colliderToDestroy != null)
        {
            Destroy(colliderToDestroy);  // Destruir el collider
            colliderToDestroy = null; // Limpiar la referencia despu�s de destruir
        }
    }

    // M�todo que puedes llamar desde otros scripts para abrir el panel y destruir el collider
    public void OpenPanelAndDestroyCollider()
    {
        if (panelToOpen != null)
        {
            panelToOpen.SetActive(true);  // Activar el panel
        }

        DestroyCollider(); // Destruir el collider cuando el panel se activa
    }
}
