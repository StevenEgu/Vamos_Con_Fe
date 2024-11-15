using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public QuickBar quickBar;  // Referencia a la barra r�pida

    void OnTriggerEnter2D(Collider2D col)
    {
        // Verificamos si el objeto con el que colisionamos tiene el tag "Item"
        if (col.gameObject.CompareTag("Item"))
        {
            // Obtener el componente Item_Angi del objeto
            Item_Angi item = col.gameObject.GetComponent<Item_Angi>();
            if (item != null)
            {
                // Agregar el �tem a la barra r�pida
                quickBar.AddItemToQuickBar(col.gameObject);

                // Eliminar el objeto de la escena
                Destroy(col.gameObject);  // Elimina el objeto recolectado
            }
        }
    }
}
