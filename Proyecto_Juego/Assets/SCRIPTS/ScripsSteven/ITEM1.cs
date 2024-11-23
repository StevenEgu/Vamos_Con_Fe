using UnityEngine;

[System.Serializable]
public class Item1
{
    public string nombre; // Nombre del objeto
    public Sprite imagen; // Imagen del objeto

    // Constructor de la clase
    public Item1(string nombre, Sprite imagen = null)
    {
        this.nombre = nombre;
        this.imagen = imagen;
    }
}

