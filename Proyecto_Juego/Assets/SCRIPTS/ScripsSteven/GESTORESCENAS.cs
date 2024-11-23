using UnityEngine;

public class GestorEscenas : MonoBehaviour
{
    public INVENTARIO inventario;

    void Start()
    {
        inventario.CargarInventario(); // Cargar el inventario al inicio de la escena
    }
}

