using UnityEngine;

public class Recolector : MonoBehaviour
{
    public INVENTARIO inventario;
    public Sprite espadaImagen; // Imagen del objeto que estamos recogiendo

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Objeto")) // Suponiendo que el objeto tiene esta etiqueta
        {
            Item1 item = new Item1("Espada", espadaImagen);
            inventario.AgregarItem(item); // Agregar el item al inventario
            Destroy(other.gameObject); // Elimina el objeto de la escena
        }
    }
}
