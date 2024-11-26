using UnityEngine;

public class CambiarSprite : MonoBehaviour
{
    public Sprite nuevoSprite;  // Sprite que se usará para reemplazar el actual
    private SpriteRenderer spriteRenderer;  // Referencia al SpriteRenderer del objeto

    private void Start()
    {
        // Obtener la referencia al SpriteRenderer del objeto
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Este método se llama para cambiar el sprite del objeto
    public void CambiarASpriteNuevo()
    {
        if (nuevoSprite != null)
        {
            // Cambia el sprite del SpriteRenderer actual por el nuevo
            spriteRenderer.sprite = nuevoSprite;
        }
        else
        {
            Debug.LogWarning("No se ha asignado un nuevo sprite.");
        }
    }
}
